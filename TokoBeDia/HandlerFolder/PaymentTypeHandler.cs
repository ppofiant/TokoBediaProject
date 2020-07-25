using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.HandlerFolder
{
    public class PaymentTypeHandler
    {
        public static List<PaymentType> getAllPaymentType()
        {
            return PaymentTypeRepo.GetPaymentType();
        }

        public static PaymentType getPaymentTypeById(int id)
        {
            return PaymentTypeRepo.GetPaymentTypeByID(id);
        }

        public static void createPaymentType(string name)
        {
            PaymentTypeRepo.Create(name);
        }

        public static void updatePaymentType(int id, string name)
        {
            PaymentTypeRepo.Update(id, name);
        }

        public static void deletePaymentType(int id)
        {
            PaymentTypeRepo.Delete(id);
        }

        public static PaymentType getPaymentbyName(string name)
        {
            return PaymentTypeRepo.getPaymentbyName(name);
        }
    }
}