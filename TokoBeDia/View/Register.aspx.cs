using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Controller;
using TokoBeDia.Model;

namespace TokoBeDia.View
{
    public partial class Register : System.Web.UI.Page
    {

        private static TokoBeDiaEntities db = new TokoBeDiaEntities();

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
                    Response.Redirect("./Home.aspx");
                }
                else
                {

                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            string name = TxtName.Text;
            string pwd = TxtPassword.Text;
            string con_pwd = TxtConPassword.Text;
            string gender = RadioButtonListGender.Text;
            string errorMessage = "";

            User users = UserController.doInsertUser(email, name, pwd, con_pwd, gender, out errorMessage);
            if(users==null)
            {
                LblError.Text = errorMessage;
            }
            else
            {
                Session["auth_user"] = users;
                Response.Redirect("./Home.aspx");
            }
        }
    }
}