using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.HandlerFolder;

namespace TokoBeDia.Controller
{
    public class CartController
    {
        public static Cart getCartByProductIdAndUserId(int productId, int userId)
        {
            return CartHandler.getCartByProductIdAndUserId(productId, userId);
        }

        public static bool isExist(int productId, int userId)
        {
            return CartHandler.isExist(productId, userId);
        }

        public static void createCart(int productId, int userId, int qty)
        {
            //Cek Dulu cartnya udah ada atau belum
            Cart carts = getCartByProductIdAndUserId(productId, userId);
            if(carts == null)
            {
                CartHandler.doInsertCart(productId, userId, qty);
            }
            else
            {
                CartHandler.addQtyCartProduct(productId, userId, qty);
            }
        }

        public static void updateCart(int productId, int userId, int qty)
        {
            //Cek Dulu cartnya udah ada atau belum
            Cart carts = getCartByProductIdAndUserId(productId, userId);
            if (carts == null)
            {
                // NULL
            }
            else
            {
                CartHandler.updateCart(productId, userId, qty);
            }
        }

        public static void deleteCartUser(int productId, int userId)
        {
            Cart carts = getCartByProductIdAndUserId(productId, userId);
            if(carts == null)
            {
                //NULL
            }
            else
            {
                if(carts.Quantity > 1)
                {
                    CartHandler.decreaseQtyCartProduct(productId, userId);
                }
                else
                {
                    CartHandler.deleteProductCart(productId, userId);
                }
            }
        }

        public static void deleteAlLCartByUser(int userId)
        {
            CartHandler.deleteCartbyUserId(userId);
        }

        public static List<Cart> getCartbyUserId(int userId)
        {
            return CartHandler.getAllCartUser(userId);
        }
    }
}