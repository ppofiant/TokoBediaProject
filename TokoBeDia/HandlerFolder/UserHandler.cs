using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.HandlerFolder
{
    public class UserHandler
    {
        private static TokoBeDiaEntities db = DBSingle.GetInstance();

        public static List<User> getAll()
        {
            return UserRepository.GetAll();
        }

        public static void updateStatus(int userId, string status)
        {
            UserRepository.UpdateStatus(userId, status);
        }

        public static bool isExistEmail(string email)
        {
            User users = UserRepository.getUserbyEmail(email);
            if(users != null)
            {
                return false;
            }
            return true;
        }

        public static User getUserbyId(int id)
        {
            return UserRepository.GetUserByID(id);
        }

        public static User doInsertUser(string email, string name, string pwd, string gender)
        {
            return UserRepository.doInsertUser(email, name, pwd, gender);
        }

        public static User findUser(string email, string pwd)
        {
            return UserRepository.FindUser(email, pwd);
        }

        public static User doUpdateUser(int id, string email, string name, string gender)
        {
            return UserRepository.doUpdateUser(id, email, name, gender);
        }

        public static bool checkOldPassword(int userId, string old_pwd)
        {
            return UserRepository.checkOldPassword(userId, old_pwd);
        }

        public static void doChangePassword(int userId, string old_pwd, string new_pwd)
        {
            UserRepository.ChangePassword(userId, old_pwd, new_pwd);
        }

        public static void doUpdateRoleUser(int id , int userRoleId)
        {
            UserRepository.UpdateRole(id, userRoleId);
        }
    }
}