using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Helper;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.HandlerFolder
{
    public class HeaderTransactionHandler
    {
        public static List<HeaderTransaction> getAllHeaderTransaction()
        {
            return HeaderTransactionHistoryController.getAllHeaderTransaction();
        }
        public static int doInsertHeaderTransaction(int userId, int paymentTypeId)
        {
            return HeaderTransactionHistoryController.doInsertTransaction(userId, paymentTypeId);
        }

        public static List<HeaderTransaction> getHeaderTransactionById(int userId)
        {
            return HeaderTransactionHistoryController.getTransactionbyId(userId);
        }

        public static HeaderTransaction getHeaderTransactionByTransactionId(int transactionId)
        {
            return HeaderTransactionHistoryController.getTransactionbyTransactionId(transactionId);
        }
    }
}