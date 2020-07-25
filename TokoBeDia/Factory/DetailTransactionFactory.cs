using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Factory
{
    public class DetailTransactionFactory
    {
        public static DetailTransaction createDetailTransaction(int transactionId, int productId, int qty)
        {
            DetailTransaction dt = new DetailTransaction();
            dt.TransactionID = transactionId;
            dt.ProductID = productId;
            dt.Quantity = qty;

            return dt;
        } 
    }
}