using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int productId, int userId, int qty)
        {
            Cart cart = new Cart();
            cart.ProductID = productId;
            cart.UserID = userId;
            cart.Quantity = qty;

            return cart;
        }
    }
}