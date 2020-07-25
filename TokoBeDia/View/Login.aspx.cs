using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Repository;
using TokoBeDia.Model;
using TokoBeDia.Controller;

namespace TokoBeDia.View
{
    public partial class Login : System.Web.UI.Page
    {
        private static TokoBeDiaEntities db = DBSingle.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["auth_user"] == null)
            {
                HttpCookie cookies = Request.Cookies.Get("auth_user");
                if (cookies != null)
                {
                    int cookie_id = int.Parse(cookies.Value);

                    User users = UserController.getUserById(cookie_id);

                    Session["auth_user"] = users;
                    Response.Redirect("./Home.aspx");
                }
                else
                {
                    
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;

            User users = UserController.findUser(email, password);
            if(users == null)
            {
                ErrorLbl.Text = "Wrong E-Mail or Password !";
                ErrorLbl.Visible = true;
            }
            else
            {
                if (users.Status == "Blocked")
                {
                    ErrorLbl.Visible = true;
                    ErrorLbl.Text = "Sorry You Were Blocked By The Administrator !";
                }
                else
                {
                    // Session["auth_user"] = users;
                    Session.Add("auth_user", users);

                    if (CbRemeberMe.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("auth_user", users.Id.ToString());
                        cookie.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(cookie);
                    }
                    ErrorLbl.Text = "Login Successful";
                    ErrorLbl.Visible = true;
                    Response.Redirect("./Home.aspx");
                }
            }
        }
    }
}