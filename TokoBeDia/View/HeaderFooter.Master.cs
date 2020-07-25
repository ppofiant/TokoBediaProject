using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.View
{
    public partial class HeaderFooter : System.Web.UI.MasterPage
    {
        private Model.User usr;

        protected void Page_Load(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;

            if (Session["auth_user"]==null)
            {
                if(path == "/View/Login.aspx" || path == "/View/Register.aspx" || path == "/View/UpdateProfile.aspx")
                {
                    LoginBtn.Visible = false;
                }
                else
                {
                    LoginBtn.Visible = true;
                }
                LogoutBtn.Visible = false;
                LblCart.Visible = false;
                LblPayment.Visible = false;
                LblProfile.Visible = false;
                LblUser.Visible = false;
                LblProductType.Visible = false;
                LblTransaction.Visible = false;
            }

            else
            {
                LoginBtn.Visible = false;
                LogoutBtn.Visible = true;

                usr = (User)Session["auth_user"];
                LblName.Text = "Welcome, " + usr.Name;

                if (usr.RoleID == 1)
                {
                    LblCart.Visible = true;
                    LblPayment.Visible = true;
                    LblProfile.Visible = true;
                    LblUser.Visible = true;
                    LblProduct.Visible = true;
                    LblProductType.Visible = true;
                    LblCart.Visible = false;
                    LblTransaction.Visible = true;
                }
                else if(usr.RoleID == 2)
                {
                    LblCart.Visible = true;
                    LblPayment.Visible = false;
                    LblProfile.Visible = true;
                    LblUser.Visible = false;
                    LblProduct.Visible = true;
                    LblProductType.Visible = false;
                    LblTransaction.Visible = true;
                }
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Login.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            HttpCookie cookies = Response.Cookies.Get("auth_user");
            if(cookies != null)
            {
                cookies.Expires = DateTime.Now.AddHours(-1);
            }
            Response.Redirect("./Home.aspx");
        }
    }
}