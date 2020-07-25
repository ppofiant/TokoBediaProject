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
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cekSession();
            int role = getUserRoleById();

            if (role == 1)
            {
                LoadAllTransaction();
                HeaderTransactionHistoryTable.Visible = false;
            }
            else
            {
                LoadTransaction();
                AllHeaderTransaction.Visible = false;
                TransactionReportBtn.Visible = false;
            }
        }

        protected int getUserRoleById()
        {
            int id = getUserId();
            User users = UserController.getUserById(id);

            return users.RoleID;
        }

        protected void LoadAllTransaction()
        {
            List<HeaderTransaction> headerTransactionList = HeaderTransactionController.gettAllHeaderTransaction();
            if (headerTransactionList.Count < 1)
            {
                SpaceUp.Visible = true;
                LblEmpty.Text = "There's No Payment Available";
                SpaceDown.Visible = true;
                HeaderTransactionHistoryTable.Visible = false;
            }
            else
            {
                for (int i = 0; i < headerTransactionList.Count; i++)
                {
                    TableRow newRow = new TableRow();
                    AllHeaderTransaction.Controls.Add(newRow);

                    TableCell numberCell = new TableCell();
                    numberCell.Controls.Add(new Label()
                    {
                        Text = (i + 1) + "."
                    });
                    newRow.Cells.Add(numberCell);

                    TableCell transactionIdCell = new TableCell();
                    transactionIdCell.Controls.Add(new Label()
                    {
                        Text = headerTransactionList.ElementAt(i).ID.ToString()
                    });
                    newRow.Cells.Add(transactionIdCell);

                    TableCell transactionNameCell = new TableCell();
                    transactionNameCell.Controls.Add(new Label()
                    {
                        Text = headerTransactionList.ElementAt(i).User.Name.ToString()
                    });
                    newRow.Cells.Add(transactionNameCell);

                    //Cari paymentName dari PaymentId nya
                    string paymentTypeName = getPaymentTypeName(headerTransactionList.ElementAt(i).PaymentTypeID);
                    TableCell paymentTypeCell = new TableCell();
                    paymentTypeCell.Controls.Add(new Label()
                    {
                        Text = paymentTypeName
                    });
                    newRow.Cells.Add(paymentTypeCell);

                    TableCell transactionDateCell = new TableCell();
                    transactionDateCell.Controls.Add(new Label()
                    {
                        Text = headerTransactionList.ElementAt(i).Date.ToString("dd-MM-yyy")
                    });
                    newRow.Cells.Add(transactionDateCell);

                    TableCell DetailButtonCell = new TableCell();
                    Button DetailButton = new Button()
                    {
                        ID = (i + 1) + "_D",
                        Text = "Detail",
                        CssClass = "btn btn-secondary"
                    };
                    DetailButton.Click += DetailButton_Click;
                    DetailButtonCell.Controls.Add(DetailButton);
                    newRow.Cells.Add(DetailButtonCell);
                }
                SpaceTable.Visible = true;
            }
        }

        protected void cekSession()
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
                    Response.Redirect("./Login.aspx");
                }
            }
        }

        protected int getUserId()
        {
            int userId = Convert.ToInt32(((User)Session["auth_user"]).Id);
            return userId;
        }

        protected void LoadTransaction()
        {
            int userId = getUserId();
            List<HeaderTransaction> headerTransactionList = HeaderTransactionController.getHeaderTransactionById(userId);

            if(headerTransactionList.Count < 1)
            {
                SpaceUp.Visible = true;
                LblEmpty.Text = "You have not do any Payment yet";
                SpaceDown.Visible = true;
                HeaderTransactionHistoryTable.Visible = false;
            }
            else
            {
                for (int i = 0; i < headerTransactionList.Count; i++)
                {
                    TableRow newRow = new TableRow();
                    HeaderTransactionHistoryTable.Controls.Add(newRow);

                    TableCell numberCell = new TableCell();
                    numberCell.Controls.Add(new Label()
                    {
                        Text = (i + 1) + "."
                    });
                    newRow.Cells.Add(numberCell);

                    TableCell transactionIdCell = new TableCell();
                    transactionIdCell.Controls.Add(new Label()
                    {
                        Text = headerTransactionList.ElementAt(i).ID.ToString()
                    });
                    newRow.Cells.Add(transactionIdCell);

                    string paymentTypeName = getPaymentTypeName(headerTransactionList.ElementAt(i).PaymentTypeID);
                    TableCell paymentTypeCell = new TableCell();
                    paymentTypeCell.Controls.Add(new Label()
                    {
                        Text = paymentTypeName
                    });
                    newRow.Cells.Add(paymentTypeCell);

                    TableCell transactionDateCell = new TableCell();
                    transactionDateCell.Controls.Add(new Label()
                    {
                        Text = headerTransactionList.ElementAt(i).Date.ToString("dd-MM-yyy")
                    });
                    newRow.Cells.Add(transactionDateCell);

                    TableCell DetailButtonCell = new TableCell();
                    Button DetailButton = new Button()
                    {
                        ID = (i + 1) + "_D",
                        Text = "Detail",
                        CssClass = "btn btn-secondary"
                    };
                    DetailButton.Click += DetailButton_Click;
                    DetailButtonCell.Controls.Add(DetailButton);
                    newRow.Cells.Add(DetailButtonCell);
                }

                SpaceTable.Visible = true;
            }
        }

        protected void DetailButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
            {
                int headerTransactionId = getTransactionidToDetail(selectedRowIndex);
                Response.Redirect("./DetailTransactionHistory.aspx?ID=" + headerTransactionId);
            }
        }

        protected int getTransactionidToDetail(int selectedRowIndex)
        {
            int role = getUserRoleById();
            if (role == 1)
            {
                return int.Parse(((Label)AllHeaderTransaction.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
            }
            else
            {
                return int.Parse(((Label)HeaderTransactionHistoryTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
            }
        }

        protected string getPaymentTypeName(int paymentTypeId)
        {
            PaymentType pays = PaymentTypeController.getPaymentTypeById(paymentTypeId);
            return pays.Type;
        }

        protected void TransactionReportBtnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ViewReport.aspx");
        }
    }
}