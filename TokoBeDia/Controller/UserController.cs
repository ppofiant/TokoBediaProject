using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;
using TokoBeDia.Repository;
using TokoBeDia.HandlerFolder;

namespace TokoBeDia.Controller
{
    public class UserController
    {
        private static TokoBeDiaEntities db = DBSingle.GetInstance();

        public static List<User> getAll()
        {
            return UserHandler.getAll();
        }

        public static void updateStatus(int userId, string status)
        {
            UserHandler.updateStatus(userId, status);
        }

        public static User doInsertUser(string email, string name, string pwd, string con_pwd, string gender, out string errorMessage)
        {
            bool success = checkConstraintUser(email, name, pwd, con_pwd, out errorMessage);
            if (success == false)
            {
                return null;
            }
            return UserHandler.doInsertUser(email, name, pwd, gender);
        }

        public static User getUserById(int id)
        {
            return UserHandler.getUserbyId(id);
        }

        public static User findUser(string email, string pwd)
        {
            return UserHandler.findUser(email, pwd);
        }

        public static User doUpdateUser(int userId, string email, string name, string gender, out string errorMessage)
        {
            bool success = checkConstraintEmail(email, out errorMessage);
            if (success == false)
            {
                return null;
            }
            success = checkName(name, out errorMessage);
            if (success == false)
            {
                return null;
            }

            return UserHandler.doUpdateUser(userId, email, name, gender);
        }

        public static bool checkConstraintUser(string email, string name, string pwd, string con_pwd, out string errorMessage)
        {
            bool success = false;
            errorMessage = "";

            success = checkEmail(email, out errorMessage);
            if (success == false)
            {
                return success = false;
            }
            success = checkName(name, out errorMessage);
            if (success == false)
            {
                return success = false;
            }
            success = checkPassword(pwd, con_pwd, out errorMessage);
            if (success == false)
            {
                return success = false;
            }

            return success = true;
        }

        public static bool doChangePassword(int userId, string old_pwd, string new_pwd, string con_pwd, out string errorMessage)
        {
            bool password = UserHandler.checkOldPassword(userId, old_pwd);
            errorMessage = "";
            if (!password)
            {
                errorMessage = "Old Password Not Match !";
                return false;
            }
            else if (new_pwd == "" || old_pwd == "" || con_pwd == "")
            {
                errorMessage = "Data must be filled !";
                return false;
            }
            else if (old_pwd == new_pwd)
            {
                errorMessage = "The New Password musn't same with Old password !";
                return false;
            }
            else if (new_pwd != con_pwd)
            {
                errorMessage = "Confirm Password must be same with New Password !";
                return false;
            }
            else if (new_pwd.Length < 6)
            {
                errorMessage = "The Password Length must 6 or above !";
                return false;
            }
            else
            {
                changePassword(userId, old_pwd, new_pwd);
                return true;
            }
        }

        public static void changePassword(int userId, string old_pwd, string new_pwd)
        {
            UserHandler.doChangePassword(userId, old_pwd, new_pwd);
        }

        public static bool checkChangePassword(string old, string new_pwd, string con_pwd, out string errorMessage)
        {
            if(old == new_pwd)
            {
                errorMessage = "The New Password musn't same with Old password !";
                return false;
            }
            else
            {
                bool success = checkPassword(new_pwd, con_pwd, out errorMessage);
                return success;
            }
        }

        public static bool checkPassword(string pwd , string con_pwd, out string errorMessage)
        {
            if(pwd.Length < 6)
            {
                errorMessage = "The Password Length must 6 or above !";
                return false;
            }
            else if(con_pwd != pwd)
            {
                errorMessage = "Not Matched !";
                return false;
            }
            else
            {
                errorMessage = "Password Success";
                return true;
            }
        }

        public static bool checkConstraintEmail(string email, out string errorMessage)
        {
            if (!email.Contains("@") || (!email.EndsWith(".com") && !email.EndsWith(".co.id")))
            {
                if (!email.EndsWith(".ac.id"))
                {
                    errorMessage = "Email Format must containt '@' and end with '.com' or '.id'";
                    return false;
                }
            }

            errorMessage = "Success";
            return true;
        }

        public static bool checkEmail(string email, out string errorMessage)
        {
            if(checkConstraintEmail(email, out errorMessage) == false)
            {
                return false;
            }
            else
            {
                bool existEmail = UserHandler.isExistEmail(email);

                if (existEmail == false)
                {
                    errorMessage = "This email is exist, please login here";
                    return false;
                }
                else
                {
                    errorMessage = "Success";
                    return true;
                }
            }
        }

        public static bool checkName(string name, out string errorMessage)
        {
            if(name.Length < 4)
            {
                errorMessage = "Name length must 4 or above";
                return false;
            }
            errorMessage = "Success";
            return true;
        }

        public static void doUpdateRole(int id, int roleId)
        {
            UserHandler.doUpdateRoleUser(id, roleId);
        }
    }
}