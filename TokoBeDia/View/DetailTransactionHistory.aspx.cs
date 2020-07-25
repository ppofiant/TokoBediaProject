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
    public partial class DetailTransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cekSession();
            LoadDetailTransaction();
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

        protected void LoadDetailTransaction()
        {
            int transactionId = Convert.ToInt32(Request.QueryString["ID"]);
            List<DetailTransaction> detailTransactionList = DetailTransactionController.getDetailTransactionById(transactionId);

            int userId = getUserId();
            HeaderTransaction ht = HeaderTransactionController.getHeaderTransactionByTransactionId(transactionId);

            int subtotal = 0;
            int grandtotal = 0;

            for (int i = 0; i < detailTransactionList.Count ; i++)
            {
                TableRow newRow = new TableRow();
                HeaderTransactionHistoryTable.Controls.Add(newRow);

                TableCell numberCell = new TableCell();
                numberCell.Controls.Add(new Label()
                {
                    // Letak Masukkin Nomor
                    Text = (i + 1) + "."
                });
                newRow.Cells.Add(numberCell);

                //Cari nama Product dari product
                int productId = detailTransactionList.ElementAt(i).ProductID;
                Product products = ProductController.getProductById(productId);

                TableCell TransactionProductNameCell = new TableCell();
                TransactionProductNameCell.Controls.Add(new Label()
                {
                    Text=products.Name
                });
                newRow.Cells.Add(TransactionProductNameCell);


                //Quantity
                TableCell TransactionProductQuantityCell = new TableCell();
                TransactionProductQuantityCell.Controls.Add(new Label()
                {
                    Text = detailTransactionList.ElementAt(i).Quantity.ToString()
                });
                newRow.Cells.Add(TransactionProductQuantityCell);


                //Subtotal
                subtotal = (products.Price * detailTransactionList.ElementAt(i).Quantity);
                TableCell subTotalCell = new TableCell();
                subTotalCell.Controls.Add(new Label()
                {
                    Text = "Rp. " + subtotal.ToString()
                });
                newRow.Cells.Add(subTotalCell);


                //GrandTotal
                grandtotal = grandtotal + subtotal;
            }

            PaymentType pays = PaymentTypeController.getPaymentTypeById(ht.PaymentTypeID);

            LblGrandTotal.Text = "Rp. " + grandtotal.ToString();
            LblPaymentType.Text = pays.Type.ToString();
            LblTransactionDate.Text = ht.Date.ToString("dd-MM-yyyy");
        }
    }
}