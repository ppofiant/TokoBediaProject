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
    public partial class InsertPaymentType : System.Web.UI.Page
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

                    if(users.RoleID != 1)
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
            List<PaymentType> paymentTypeList = PaymentTypeController.getAllPaymentType();
            for (int i = 0; i < paymentTypeList.Count; i++)
            {
                TableRow newRow = new TableRow();
                PaymentTypeTable.Controls.Add(newRow);

                TableCell numberCell = new TableCell();
                numberCell.Controls.Add(new Label()
                {
                    Text = (i + 1) + "."
                });
                newRow.Cells.Add(numberCell);

                TableCell paymentTypeIDCell = new TableCell();
                paymentTypeIDCell.Controls.Add(new Label()
                {
                    Text = paymentTypeList.ElementAt(i).ID.ToString()
                });
                newRow.Cells.Add(paymentTypeIDCell);

                TableCell paymentTypeCell = new TableCell();
                paymentTypeCell.Controls.Add(new Label()
                {
                    Text = paymentTypeList.ElementAt(i).Type
                });
                newRow.Cells.Add(paymentTypeCell);
            }
        }

        protected void InsertPaymentTypeBtn_Click(object sender, EventArgs e)
        {
            string paymentTypeName = TxtPaymentType.Text;
            string errorMessage = "";

            PaymentTypeController.createPaymentType(paymentTypeName, out errorMessage);
            if(errorMessage != "Success")
            {
                ErrorLbl.Text = errorMessage;
            }
            else
            {
                Response.Redirect("./ViewPaymentType.aspx");
            }            
        }
    }
}