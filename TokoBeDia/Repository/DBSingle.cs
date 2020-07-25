using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class DBSingle
    {
        private static TokoBeDiaEntities db;

        public static TokoBeDiaEntities GetInstance()
        {
            if (db == null)
            {
                db = new TokoBeDiaEntities();
            }
            return db;
        }
    }
}