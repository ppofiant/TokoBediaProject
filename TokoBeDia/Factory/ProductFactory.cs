using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class ProductFactory
    {
        public static Product CreateProduct(int productTypeId, String name, int stock, int price)
        {
            return new Product()
            {
                ProductTypeID = productTypeId,
                Name = name,
                Stock = stock,
                Price = price,
            };
        }
    }
}