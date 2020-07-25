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
    public partial class UpdatePaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cekSession();
            Load_PaymentType();
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

                    Session["user"] = users;

                    if (users.RoleID != 1)
                    {
                        Response.Redirect("./Home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("./Login.aspx");
                }
            }
        }

        protected void Load_PaymentType()
        {
            int paymentId = Convert.ToInt32(Request.QueryString["ID"]);
            PaymentType pay = PaymentTypeController.getPaymentTypeById(paymentId);

            TableRow newRow = new TableRow();
            PaymentTypeTable.Controls.Add(newRow);

            TableCell paymentTypeIDCell = new TableCell();
            paymentTypeIDCell.Controls.Add(new Label()
            {
                Text = pay.ID.ToString()
            });
            newRow.Cells.Add(paymentTypeIDCell);

            TableCell paymentTypeCell = new TableCell();
            paymentTypeCell.Controls.Add(new Label()
            {
                Text = pay.Type
            });
            newRow.Cells.Add(paymentTypeCell);

        }

        protected void UpdatePaymentTypeBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            String paymentType = TxtPaymentType.Text;
            string errorMessage = "";

            PaymentTypeController.updatePaymentType(id, paymentType, out errorMessage);
            if (errorMessage != "Success")
            {
                ErrorLbl.Text = errorMessage;
                ErrorLbl.Visible = true;
            }
            else
            {
                ErrorLbl.Visible = false;
                Response.Redirect("./ViewPaymentType.aspx");
            }  
        }
    }
}