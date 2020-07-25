using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.HandlerFolder;
using TokoBeDia.Repository;

namespace TokoBeDia.Controller
{
    public class ProductController
    {
        public static List<Product> getProduct()
        {
            return ProductHandler.getProduct();
        }

        public static void createProduct(int productTypeId, String name, int stock, int price, out string errorMessage)
        {
            Product existName = getProductByName(name);
            if(existName == null)
            {
                bool success = checkProductConstraint(productTypeId, name, stock, price, out errorMessage);
                if (success == true)
                {
                    ProductHandler.createProduct(productTypeId, name, stock, price);
                    errorMessage = "Success";
                }
            }
            else
            {
                errorMessage = "The Product Name is Exist !";
            }
        }

        public static void updateProduct(int productId, String name, int stock, int price, out string errorMessage)
        {
            bool success = checkProductConstraint(productId, name, stock, price, out errorMessage);
            if(success == true)
            {
                ProductHandler.updateProduct(productId, name, stock, price);
            }
        }

        public static void deleteProduct(int productId)
        {
            ProductHandler.deleteProduct(productId);
        }

        public static Product getProductById(int productId)
        {
            return ProductHandler.getProductById(productId);
        }

        public static Product getProductByName(string productName)
        {
            return ProductHandler.getProductByName(productName);
        }

        public static void decreaseQtyProduct(int productId, int qty)
        {
            ProductHandler.decreaseQtyProduct(productId, qty);
        }

        public static bool checkProductConstraint(int id, string name, int stock, int price, out string errorMessage)
        {
            if (name != "")
            {
                if (stock >= 1)
                {
                    if (price > 1000 && (price % 1000) == 0)
                    {
                        errorMessage = "Success";
                        return true;
                    }
                    else
                    {
                        errorMessage = "Invalid Price Data";
                        return false;
                    }
                }
                else
                {
                    errorMessage = "Invalid Stock Data";
                    return false;
                }
            }
            else
            {
                errorMessage = "Invalid Name Data";
                return false;
            }
        }
    }
}