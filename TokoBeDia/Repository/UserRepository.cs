using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class UserRepository
    {
        private static TokoBeDiaEntities db = DBSingle.GetInstance();

        public static List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public static User doInsertUser(string email, string name, string pwd, string gender)
        {
            User users = UserFactory.createUser(email, name, pwd, gender);

            db.Users.Add(users);
            db.SaveChanges();

            return users;
        }

        public static User doUpdateUser(int id, string email, string name, string gender)
        {
            User users = GetUserByID(id);
            users.Email = email;
            users.Name = name;
            users.Gender = gender;

            db.SaveChanges();

            return users;
        }

        public static User GetUserByID(int id)
        {
            User users = db.Users.Where(a => a.Id == id).FirstOrDefault();
            return users;
        }

        public static User getUserbyEmail(string email)
        {
            User users = db.Users.Where(a => a.Email == email).FirstOrDefault();
            return users;
        }

        public static List<User> getUserbyEmailAndPassword(string email, string pwd)
        {
            return db.Users.Where(user => user.Email == email && user.Password == pwd).ToList();
        }

        public static User FindUser(String email, String password)
        {
            return db.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public static void UpdateStatus(int id, String userStatus)
        {
            User usr = db.Users.Where(user => user.Id == id).FirstOrDefault();
            usr.Status = userStatus;
            db.SaveChanges();
        }

        public static void UpdateRole(int id, int userRoleId)
        {
            User usr = db.Users.Where(user => user.Id == id).FirstOrDefault();
            usr.RoleID = userRoleId;
            db.SaveChanges();
        }

        public static User FindById(int id)
        {
            User usr = db.Users.Where(x => x.Id == id).FirstOrDefault();
            return usr;
        }

        public static bool checkOldPassword(int userId, string old_pwd)
        {
            User usr = (from x in db.Users
                        where x.Id == userId && x.Password == old_pwd
                        select x).FirstOrDefault();
            if (usr == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void ChangePassword(int userId, string old_pwd, string new_pwd)
        {
            User usr = (User)db.Users.Where(x => x.Id == userId && x.Password == old_pwd).FirstOrDefault();
            usr.Password = new_pwd;
            db.SaveChanges();
        }
    }
}