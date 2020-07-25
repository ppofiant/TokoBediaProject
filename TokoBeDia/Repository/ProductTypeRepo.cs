using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class ProductTypeRepo
    {
        private static TokoBeDiaEntities db = DBSingle.GetInstance();

        public static List<ProductType> GetProductType()
        {
            return db.ProductTypes.ToList();
        }

        public static ProductType GetProductTypeByID(int id)
        {
            ProductType prk = db.ProductTypes.Where(a => a.ID == id).FirstOrDefault();
            return prk;
        }

        public static void Create(String productTypeName, String description)
        {
            ProductType prk = ProductTypeFactory.CreateProduct(productTypeName, description);
            db.ProductTypes.Add(prk);
            db.SaveChanges();
        }

        public static void Update(int id, String productType, String description)
        {
            ProductType prk = db.ProductTypes.Where(a => a.ID == id).FirstOrDefault();
            prk.Name = productType;
            prk.Description = description;
            db.SaveChanges();
        }

        public static void Delete(int id)
        {
            ProductType prk = db.ProductTypes.Where(a => a.ID == id).First();
            db.ProductTypes.Remove(prk);
            db.SaveChanges();
        }

        public static ProductType getProductTypeByName(string name)
        {
            ProductType prk = db.ProductTypes.Where(a => a.Name == name).FirstOrDefault();
            return prk;
        }
    }
}