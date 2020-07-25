using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Factory;

namespace TokoBeDia.Repository
{
    public class HeaderTransactionHistoryController
    {
        private static TokoBeDiaEntities db = DBSingle.GetInstance();

        public static List<HeaderTransaction> getAllHeaderTransaction()
        {
            return db.HeaderTransactions.ToList();
        }

        public static int doInsertTransaction(int userId, int paymentTypeId)
        {
            HeaderTransaction ht = HeaderTransactionFactory.CreateHeaderTransaction(userId, paymentTypeId);
            db.HeaderTransactions.Add(ht);
            db.SaveChanges();

            return ht.ID;
        }

        public static List<HeaderTransaction> getTransactionbyId(int userId)
        {
            return db.HeaderTransactions.Where(a => a.UserID == userId).ToList();
        }

        public static HeaderTransaction getTransactionbyTransactionId(int transactionId)
        {
            return db.HeaderTransactions.Where(a => a.ID == transactionId).FirstOrDefault();
        }
    }
}