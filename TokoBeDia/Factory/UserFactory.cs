using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.Factory
{
    public class UserFactory
    {
        private static TokoBeDiaEntities db = DBSingle.GetInstance();
        public static User createUser(string email, string name, string pwd, string gender)
        {
            User users = new User();
            users.Email = email;
            users.Name = name;
            users.Password = pwd;
            users.Gender = gender;
            users.RoleID = 2;
            users.Status = "Active";

            return users;
        }
        
    }
}