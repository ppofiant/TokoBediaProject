using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TokoBeDia.HandlerFolder;
using TokoBeDia.Helper;

namespace TokoBeDia.Service
{
    /// <summary>
    /// Summary description for TransactionServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TransactionServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public static string test()
        {
            return "test";
        }

        [WebMethod]
        public static string GetTransaction()
        {
            return JsonHelper.Serialize(TransactionHandler.GetTransactions());
        }

        [WebMethod]
        public string GetDetailTransactionId(int id)
        {
            return JsonHelper.Serialize(DetailTransactionHandler.getDetailTransactionById(id));
        }

    }
}
