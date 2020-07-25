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
    public partial class ViewProfile : System.Web.UI.Page
    {
        private static Model.User usr;

        protected void Page_Load(object sender, EventArgs e)
        {
            cekSession();
            LoadUser();
        }

        protected void LoadUser()
        {
            usr = (User)Session["auth_user"];
            AuthUserEmail.Text = usr.Email;
            AuthUserName.Text = usr.Name;
            AuthUserGender.Text = usr.Gender.ToString();
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
                    Response.Redirect("./Home.aspx");
                }
            }
        }

        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }
    }
}