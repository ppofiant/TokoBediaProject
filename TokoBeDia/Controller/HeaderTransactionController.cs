using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.HandlerFolder;
using TokoBeDia.Service;
using TokoBeDia.Helper;

namespace TokoBeDia.Controller
{
    public class HeaderTransactionController
    {
        public static List<HeaderTransaction> gettAllHeaderTransaction()
        {
            return HeaderTransactionHandler.getAllHeaderTransaction();
        }

        public static List<HeaderTransaction> getTransaction()
        {
            return JsonHelper.Deserialize<List<HeaderTransaction>>(TransactionServices.GetTransaction());
        }

        public static int doInsertHeaderTransaction(int userId, int paymentTypeId)
        {
            return HeaderTransactionHandler.doInsertHeaderTransaction(userId, paymentTypeId);
        }

        public static List<HeaderTransaction> getHeaderTransactionById(int userId)
        {
            return HeaderTransactionHandler.getHeaderTransactionById(userId);
        }

        public static HeaderTransaction getHeaderTransactionByTransactionId(int transactionId)
        {
            return HeaderTransactionHandler.getHeaderTransactionByTransactionId(transactionId);
        }
    }
}