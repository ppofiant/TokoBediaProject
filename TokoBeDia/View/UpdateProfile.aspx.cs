using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.View
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        private static Model.User usr;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth_user"] == null)
            {
                HttpCookie cookies = Request.Cookies.Get("auth_user");
                if (cookies != null)
                {
                    int cookie_id = int.Parse(cookies.Value);

                    User users = UserController.getUserById(cookie_id);

                    Session["auth_user"] = users;

                }
                else
                {
                    
                }
            }
            else
            {
                usr = (Model.User)Session["auth_user"];
                User users = UserController.getUserById(Convert.ToInt32(usr.Id.ToString()));

                if (users == null)
                {
                    Response.Redirect("./Home.aspx");
                }
                else
                {
                    TxtEmail.Text = users.Email;
                    TxtName.Text = users.Name;
                    RadioButtonListGender.SelectedValue = users.Gender.ToString();
                    Session.Remove("auth_user");
                }
            }
        }

        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            string name = TxtName.Text;
            string gender = RadioButtonListGender.Text;
            string errorMessage = "";
            User users = UserController.doUpdateUser(usr.Id, email, name, gender, out errorMessage);
            if(users==null)
            {
                LblError.Text = errorMessage;
            }
            else
            {
                Session.Add("auth_user", users);
                Response.Redirect("./ViewProfile.aspx");
            }
        }
    }
}