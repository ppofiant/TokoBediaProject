using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.HandlerFolder;
using TokoBeDia.Helper;
using TokoBeDia.Model;
using TokoBeDia.Service;

namespace TokoBeDia.Controller
{
    public class TransactionController
    {
        public static List<HeaderTransaction> GetTransactions()
        {
            return JsonHelper.Deserialize<List<HeaderTransaction>>(TransactionServices.GetTransaction());
        }

        public static List<DetailTransaction> GetDetailTransactionById(int id)
        {
            return TransactionHandler.GetDetailByTransactionId(id);
        }
    }
}