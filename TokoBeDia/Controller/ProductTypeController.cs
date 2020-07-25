using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.HandlerFolder;

namespace TokoBeDia.Controller
{
    public class ProductTypeController
    {
        public static List<ProductType> getAllProductType()
        {
            return ProductTypeHandler.getAllProductType();
        }

        public static ProductType getProductTypeById(int id)
        {
            return ProductTypeHandler.getProductTypeById(id);
        }

        public static void createProductType(string productTypeName, string description, out string errorMessage)
        {
            ProductType isExist = getProductTypeByName(productTypeName);
            if(isExist == null)
            {
                bool success = checkConstraintProductType(productTypeName, description, out errorMessage);
                if (success == true)
                {
                    ProductTypeHandler.doCreateProductType(productTypeName, description);
                    errorMessage = "Success";
                }
            }
            else
            {
                errorMessage = "The Product Type Name is Exist !";
            }

        }

        public static ProductType getProductTypeByName(string name)
        {
            return ProductTypeHandler.getProductTypeByName(name);
        }

        public static void updateProductType(int id, string productTypeName, string description, out string errorMessage)
        {
            bool success = checkConstraintProductType(productTypeName, description, out errorMessage);
            if (success == true)
            {
                ProductTypeHandler.doUpdateProductType(id, productTypeName, description);
            }
        }

        public static bool checkConstraintProductType(string productTypeName, string description, out string errorMessage)
        {
            if(productTypeName.Length >= 5)
            {
                if(description != "")
                {
                    errorMessage = "Success";
                    return true;
                }
                else
                {
                    errorMessage = "Invalid Description Data";
                    return false;
                }
            }
            else
            {
                errorMessage = "Product Type Name length must be 5 or above";
                return false;
            }
        }

        public static void deleteProductType(int id)
        {
            ProductTypeHandler.doDeleteProductType(id);
        }
    }
}