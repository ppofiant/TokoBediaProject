using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Repository;

namespace TokoBeDia.Controller
{
    public class TransactionApprovementController
    {
        public static void doInsertDetailTransaction(int transactionId, int productId, int qty)
        {
            DetailTransactionHistoryRepository.doInsertDetailTransaction(transactionId, productId, qty);
            ProductRepo.decreaseQuantityProduct(productId, qty);
        }
    }
}