using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.HandlerFolder
{
    public class CartHandler
    {
        public static bool isExist(int productId, int userId)
        {
            bool exist = CartRepo.existCartbyProductIdAndUserId(productId, userId);
            return exist;
        }

        public static void doInsertCart(int productId, int userId, int qty)
        {
            CartRepo.doInsertProductToCart(productId, userId, qty);
        }

        public static List<Cart> getAllCartUser(int userId)
        {
            return CartRepo.getCartUser(userId);
        } 

        public static Cart getCartByProductIdAndUserId(int productId, int userId)
        {
            return CartRepo.getCartbyProductIdAndUserId(productId, userId);
        }

        public static void addQtyCartProduct(int productId, int userId, int qty)
        {
            CartRepo.addQtyProduct(productId, userId, qty);
        }

        public static void createCart(int productId, int userId, int qty)
        {
            CartRepo.doInsertProductToCart(productId, userId, qty);
        }

        public static void updateCart(int productId, int userId, int qty)
        {
            CartRepo.updateQtyCart(qty, productId, userId);
        }

        public static void deleteCartbyUserId(int userId)
        {
            CartRepo.deleteCartuser(userId);
        }

        public static void deleteProductCart(int productId, int userId)
        {
            CartRepo.deleteProductCart(productId, userId);
        }

        public static void decreaseQtyCartProduct(int productId, int userId)
        {
            CartRepo.deleteQtyProductCart(productId, userId);
        }
    }
}