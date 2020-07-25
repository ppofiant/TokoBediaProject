using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.HandlerFolder;

namespace TokoBeDia.Controller
{
    public class PaymentTypeController
    {
        public static List<PaymentType> getAllPaymentType()
        {
            return PaymentTypeHandler.getAllPaymentType();
        }

        public static PaymentType getPaymentTypeById(int id)
        {
            return PaymentTypeHandler.getPaymentTypeById(id);
        }

        public static void createPaymentType(string name, out string errorMessage)
        {
            PaymentType payment = getPaymentbyName(name);
            if(payment == null)
            {
                bool success = checkConstraintPaymentType(name, out errorMessage);
                if (success == true)
                {
                    errorMessage = "Success";
                    PaymentTypeHandler.createPaymentType(name);
                }
            }
            else
            {
                errorMessage = "Payment Type is Already Registered";
            }
        }

        public static bool checkConstraintPaymentType(string name, out string errorMessage)
        {
            if (name.Length >= 3)
            {
                errorMessage = "Success";
                return true;
            }
            else
            {
                errorMessage = "The Payment Name must be 3 or Above";
                return false;
            }
        }

        public static void updatePaymentType(int id, string name, out string errorMessage)
        {
            bool success = checkConstraintPaymentType(name, out errorMessage);
            if (success == true)
            {
                errorMessage = "Success";
                PaymentTypeHandler.updatePaymentType(id, name);
            }
        }

        public static void deletePaymentType(int id)
        {
            PaymentTypeHandler.deletePaymentType(id);
        }

        public static PaymentType getPaymentbyName(string name)
        {
            return PaymentTypeHandler.getPaymentbyName(name);
        }
    }
}