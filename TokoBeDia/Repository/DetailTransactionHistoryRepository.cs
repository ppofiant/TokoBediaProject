using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Factory;

namespace TokoBeDia.Repository
{
    public class DetailTransactionHistoryRepository
    {
        private static TokoBeDiaEntities db = DBSingle.GetInstance();

        public static void doInsertDetailTransaction(int transactionId, int productId, int qty)
        {
            DetailTransaction dt = DetailTransactionFactory.createDetailTransaction(transactionId, productId, qty);

            db.DetailTransactions.Add(dt);
            db.SaveChanges();    
        }

        public static List<DetailTransaction> getDetailTransactionById(int transactionId)
        {
            return db.DetailTransactions.Where(a => a.TransactionID == transactionId).ToList();
        }
    }
}