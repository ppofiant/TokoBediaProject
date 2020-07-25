using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.HandlerFolder;

namespace TokoBeDia.Controller
{
    public class DetailTransactionController
    {
        public static void doInsertDetailiTransaction(int transactionId, int productId, int qty)
        {
            DetailTransactionHandler.doInsertDetailiTransaction(transactionId, productId, qty);
        }

        public static List<DetailTransaction> getDetailTransactionById(int transactionId)
        {
            return DetailTransactionHandler.getDetailTransactionById(transactionId);
        }
    }
}