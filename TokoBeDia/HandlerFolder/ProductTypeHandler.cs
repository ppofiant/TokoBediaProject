using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.HandlerFolder
{
    public class ProductTypeHandler
    {
        public static List<ProductType> getAllProductType()
        {
            return ProductTypeRepo.GetProductType();
        }

        public static ProductType getProductTypeById(int id)
        {
            return ProductTypeRepo.GetProductTypeByID(id);
        }

        public static ProductType getProductTypeByName(string name)
        {
            return ProductTypeRepo.getProductTypeByName(name);
        }

        public static void doCreateProductType(string productTypeName, string description)
        {
            ProductTypeRepo.Create(productTypeName, description);
        }

        public static void doUpdateProductType(int id, string productTypeName, string description)
        {
            ProductTypeRepo.Update(id, productTypeName, description);
        }

        public static void doDeleteProductType(int id)
        {
            ProductTypeRepo.Delete(id);
        }
    }
}