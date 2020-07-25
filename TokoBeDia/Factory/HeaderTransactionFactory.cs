using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Factory
{
    public class HeaderTransactionFactory
    {
        
        public static HeaderTransaction CreateHeaderTransaction(int userId, int paymentTypeId)
        {
            HeaderTransaction ht = new HeaderTransaction();
            ht.UserID = userId;
            ht.PaymentTypeID = paymentTypeId;
            ht.Date = DateTime.Now;

            return ht;
        }
    }
}