using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.HandlerFolder
{
    public class DetailTransactionHandler
    {
        public static void doInsertDetailiTransaction(int transactionId, int productId, int qty)
        {
            DetailTransactionHistoryRepository.doInsertDetailTransaction(transactionId, productId, qty);
        }

        public static List<DetailTransaction> getDetailTransactionById(int transactionId)
        {
            return DetailTransactionHistoryRepository.getDetailTransactionById(transactionId);
        }
    }
}