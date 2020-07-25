using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TokoBeDia.DbManager
{
    /*
    public class DbManager
    {
        static SqlConnection connection = null;

        private DbManager() { }

        public static SqlConnection GetInstance()
        {
            if(DbManager.connection == null)
            {
                string attachDbFilename = @"'C:\Users\ROG-STRIX\Desktop\TokoBeDia\TokoBeDia\App_Data\TokoBeDia.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework'";
                DbManager.connection = new SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + attachDbFilename + ";IntegratedSecurity=True");
            }

            return DbManager.connection;
        }
    }
    */
}