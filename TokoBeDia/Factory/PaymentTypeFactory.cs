using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Factory
{
    public class PaymentTypeFactory
    {
        public static PaymentType CreatePayment(String paymentTypeName)
        {
            return new PaymentType()
            {
                Type = paymentTypeName
            };
        }
    }
}