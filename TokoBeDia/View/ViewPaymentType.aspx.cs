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
    public partial class ViewPaymentType : System.Web.UI.Page
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
                }
                else
                {
                    Response.Redirect("./Login.aspx");
                }
            }
        }

        protected int getUserId()
        {
            int userId = Convert.ToInt32(((User)Session["auth_user"]).Id);
            return userId;
        }

        protected int getUserRole()
        {
            int userId = getUserId();
            User users = UserController.getUserById(userId);
            return users.RoleID;
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

                int roleId = getUserRole();
                if(roleId == 2)
                {
                    InsertPaymentType.Visible = false;
                    TableCell SelectButtonCell = new TableCell();
                    Button SelectButton = new Button()
                    {
                        ID = (i + 1) + "_S",
                        Text = "Select",
                        CssClass = "btn btn-primary"
                    };
                    SelectButton.Click += SelectButton_Click;
                    SelectButtonCell.Controls.Add(SelectButton);
                    newRow.Cells.Add(SelectButtonCell);
                }
                else
                {
                    TableCell UpdateButtonCell = new TableCell();
                    Button UpdateButton = new Button()
                    {
                        ID = (i + 1) + "_U",
                        Text = "Update",
                        CssClass = "btn btn-warning"
                    };
                    UpdateButton.Click += UpdateButton_Click;
                    UpdateButtonCell.Controls.Add(UpdateButton);
                    newRow.Cells.Add(UpdateButtonCell);

                    TableCell deleteButtonCell = new TableCell();
                    Button deleteButton = new Button()
                    {
                        ID = (i + 1) + "_D",
                        Text = "Delete",
                        CssClass = "btn btn-danger"
                    };
                    deleteButton.Click += deleteButton_Click;
                    deleteButtonCell.Controls.Add(deleteButton);
                    newRow.Cells.Add(deleteButtonCell);
                }
            }
        }

        protected void SelectButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
            {
                int paymentTypeId = int.Parse(((Label)PaymentTypeTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
                Session["user_pay"] = paymentTypeId;
                Response.Redirect("./TransactionApprovement.aspx?=" + paymentTypeId);
            }
        }

        protected void InsertPaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("./InsertPaymentType.aspx");
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
            {
                int paymentTypeId = int.Parse(((Label)PaymentTypeTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
                Response.Redirect("./UpdatePaymentType.aspx?ID=" + paymentTypeId);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
            {
                int paymentId = int.Parse(((Label)PaymentTypeTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);

                PaymentTypeController.deletePaymentType(paymentId);

                Response.Redirect("./ViewPaymentType.aspx");
            }
        }
    }
}