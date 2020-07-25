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
    public partial class ChangePassword : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            cekSession();
        }

        protected void cekSession()
        {
            if (Session["auth_user"] == null)
            {
                HttpCookie cookies = Request.Cookies.Get("auth_user");
                if (cookies != null)
                {
                    int cookie_id = int.Parse(cookies.Value);

                    User users = UserRepository.GetUserByID(cookie_id);

                    Session["auth_user"] = users;
                }
                else
                {
                    Response.Redirect("./Login.aspx");
                }
            }
        }

        protected void ChangeBtn_Click(object sender, EventArgs e)
        {
            string oldPwd = TxtOld.Text;
            string newPwd = TxtNew.Text;
            string conPwd = TxtConfirm.Text;
            User usr = (User)Session["auth_user"];
            string errorMessage = "";

            bool success = UserController.doChangePassword(usr.Id, oldPwd, newPwd, conPwd, out errorMessage);
            if(!success)
            {
                LblError.Visible = true;
                LblError.Text = errorMessage;
            }
            else
            {
                Response.Redirect("./Home.aspx");
            }
        }
    }
}