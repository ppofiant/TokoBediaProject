using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class ProductRepo
    {
        private static TokoBeDiaEntities db = DBSingle.GetInstance();

        public static List<Product> GetProduct()
        {
            return db.Products.ToList();
        }

        public static void Create(int productTypeId, String name, int stock, int price)
        {
            Product prk = ProductFactory.CreateProduct(productTypeId, name, stock, price);
            db.Products.Add(prk);
            db.SaveChanges();
        }

        public static Product GetProductByID(int id)
        {
            Product prk = db.Products.Where(a => a.ID == id).FirstOrDefault();
            return prk;
        }

        public static void Update(int id, String productName, int stock, int price)
        {
            Product prk = db.Products.Where(a => a.ID == id).FirstOrDefault();
            prk.Name = productName;
            prk.Stock = stock;
            prk.Price = price;
            db.SaveChanges();
        }

        public static void Delete(int id)
        {
            Product prk = db.Products.Where(a => a.ID == id).First();
            db.Products.Remove(prk);
            db.SaveChanges();
        }

        public static Product getProductByName(string name)
        {
            Product prk = db.Products.Where(a => a.Name == name).FirstOrDefault();
            return prk;
        }

        public static void decreaseQuantityProduct(int productId, int qty)
        {
            Product prk = GetProductByID(productId);
            prk.Stock = prk.Stock - qty;
        }
    }
}