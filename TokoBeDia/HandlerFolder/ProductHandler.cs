using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.HandlerFolder
{
    public class ProductHandler
    {
        public static List<Product> getProduct()
        {
            return ProductRepo.GetProduct();
        }

        public static void createProduct(int productTypeId, String name, int stock, int price)
        {
            ProductRepo.Create(productTypeId, name, stock, price);
        }

        public static void updateProduct(int productId, String name, int stock, int price)
        {
            ProductRepo.Update(productId, name, stock, price);
        }

        public static void deleteProduct(int productId)
        {
            ProductRepo.Delete(productId);
        }

        public static Product getProductById(int productId)
        {
            return ProductRepo.GetProductByID(productId);
        }

        public static Product getProductByName(string productName)
        {
            return ProductRepo.getProductByName(productName);
        }

        public static void decreaseQtyProduct(int productId, int qty)
        {
            ProductRepo.decreaseQuantityProduct(productId, qty);
        }
    }
}