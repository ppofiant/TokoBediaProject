using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Factory;
using TokoBeDia.View;

namespace TokoBeDia.Repository
{
    public class CartRepo
    {
        private static TokoBeDiaEntities db = DBSingle.GetInstance();

        public static void doInsertProductToCart(int productId, int userId, int qty)
        {
            Cart carts = CartFactory.createCart(productId, userId, qty);
            db.Carts.Add(carts);
            db.SaveChanges();
        }

        public static List<Cart> getCartUser(int id)
        {
            return db.Carts.Where(a => a.UserID == id).ToList();
        }

        public static Cart getCartbyProductIdAndUserId(int productId, int userId)
        {
            Cart carts = db.Carts.Where(a => a.ProductID == productId && a.UserID == userId).FirstOrDefault();
            return carts;
        }

        public static void addQtyProduct(int productId, int userId, int qty)
        {
            Cart carts = getCartbyProductIdAndUserId(productId, userId);
            carts.Quantity = qty;

            db.SaveChanges();
        }

        public static bool existCartbyProductIdAndUserId(int productId, int userId)
        {
            Cart carts = getCartbyProductIdAndUserId(productId, userId);
            if(carts == null)
            {
                return false;
            }
            return true;
        }

        public static void updateQtyCart(int qty, int productId, int userId)
        {
            Cart carts = getCartbyProductIdAndUserId(productId, userId);
            carts.Quantity = qty;
            db.SaveChanges();
        }

        public static void deleteProductCart(int productId, int userId)
        {
            Cart carts = getCartbyProductIdAndUserId(productId, userId);
            db.Carts.Remove(carts);
            db.SaveChanges();
        }

        public static void deleteQtyProductCart(int productId, int userId)
        {
            Cart carts = getCartbyProductIdAndUserId(productId, userId);
            carts.Quantity--;
            db.SaveChanges();
        }

        public static void deleteCartuser(int userId)
        {
            db.Carts.RemoveRange(getCartUser(userId));
            db.SaveChanges();
        }
    }
}