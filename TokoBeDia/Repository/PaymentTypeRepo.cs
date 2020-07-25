
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class PaymentTypeRepo
    {
        private static TokoBeDiaEntities db = DBSingle.GetInstance();

        public static List<PaymentType> GetPaymentType()
        {
            return db.PaymentTypes.ToList();
        }

        public static PaymentType GetPaymentTypeByID(int id)
        {
            PaymentType pay = db.PaymentTypes.Where(a => a.ID == id).FirstOrDefault();
            return pay;
        }

        public static void Create(string paymentTypeName)
        {
            PaymentType pay = PaymentTypeFactory.CreatePayment(paymentTypeName);
            db.PaymentTypes.Add(pay);
            db.SaveChanges();
        }

        public static void Update(int id, string paymentTypeName)
        {
            PaymentType pay = db.PaymentTypes.Where(a => a.ID == id).FirstOrDefault();
            pay.Type = paymentTypeName;
            db.SaveChanges();
        }

        public static void Delete(int id)
        {
            PaymentType pay = db.PaymentTypes.Where(a => a.ID == id).First();
            db.PaymentTypes.Remove(pay);
            db.SaveChanges();
        }

        public static PaymentType getPaymentbyName(string name)
        {
            PaymentType pay = db.PaymentTypes.Where(a => a.Type == name).FirstOrDefault();
            return pay;
        }
    }
}