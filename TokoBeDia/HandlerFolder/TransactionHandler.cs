using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.HandlerFolder
{
    public class TransactionHandler
    {
        public static List<HeaderTransaction> GetTransactions()
        {
            return TransactionRepository.GetTransactions();
        }

        public static List<DetailTransaction> GetDetailByTransactionId(int id)
        {
            return DetailTransactionHistoryRepository.getDetailTransactionById(id);
        }
    }
}