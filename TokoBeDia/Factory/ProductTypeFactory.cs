using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class ProductTypeFactory
    {
        public static ProductType CreateProduct(String productTypeName, String description)
        {
            return new ProductType()
            {
                Name = productTypeName,
                Description = description
            };
        }
    }
}