using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Repository;
using TokoBeDia.Controller;

namespace TokoBeDia.View
{
    public partial class TransactionApprovement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cekSession();

            AuthUserEmail.Text = ((User)Session["auth_user"]).Email;
            AuthUserName.Text = ((User)Session["auth_user"]).Name;
            AuthUserGender.Text = ((User)Session["auth_user"]).Gender.ToString();

            int userId = getUserId();
            List<Cart> cartList = CartController.getCartbyUserId(userId);
            int subtotal = 0;
            int grandtotal = 0;

            for (int i = 0; i < cartList.Count; i++)
            {
                TableRow newRow1 = new TableRow();
                CartTable.Controls.Add(newRow1);

                TableCell numberCell = new TableCell();
                numberCell.Controls.Add(new Label()
                {
                    Text = (i + 1) + "."
                });
                newRow1.Cells.Add(numberCell);

                TableCell productIdCell = new TableCell();
                productIdCell.Controls.Add(new Label()
                {
                    Text = cartList.ElementAt(i).ProductID.ToString()
                });
                newRow1.Cells.Add(productIdCell);

                //Cari tau nama Product dari Product Id
                int productId = cartList.ElementAt(i).ProductID;
                Product products = ProductController.getProductById(productId);

                TableCell productNameCell = new TableCell();
                productNameCell.Controls.Add(new Label()
                {
                    Text = products.Name
                });
                newRow1.Cells.Add(productNameCell);

                TableCell productPriceCell = new TableCell();
                productPriceCell.Controls.Add(new Label()
                {
                    Text = "Rp. " + products.Price.ToString()
                });
                newRow1.Cells.Add(productPriceCell);

                TableCell qtyCell = new TableCell();
                qtyCell.Controls.Add(new Label()
                {
                    Text = cartList.ElementAt(i).Quantity.ToString()
                });
                newRow1.Cells.Add(qtyCell);

                //Hitung subTotal Produk
                subtotal = (products.Price * cartList.ElementAt(i).Quantity);

                TableCell subTotalCell = new TableCell();
                subTotalCell.Controls.Add(new Label()
                {
                    Text = "Rp. " + subtotal.ToString()
                });
                newRow1.Cells.Add(subTotalCell);

                //Hitung Grand Total Keseluruhan
                grandtotal = grandtotal + subtotal;
            }
            LblGrandTotal.Text = "Rp. " + grandtotal.ToString();
            LblPaymentType.Text = getPaymentType();
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

        protected int getUserId()
        {
            int userId = Convert.ToInt32(((User)Session["auth_user"]).Id);
            return userId;
        }

        protected string getPaymentType()
        {
            string paymentId = HttpContext.Current.Session["user_pay"].ToString();

            PaymentType pays = PaymentTypeController.getPaymentTypeById(Convert.ToInt32(paymentId));
            return pays.Type;
        }

        protected int getPaymentTypeId()
        {
            string paymentId = HttpContext.Current.Session["user_pay"].ToString();

            return Convert.ToInt32(paymentId);
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            int userId = getUserId();
            int PaymentTypeId = getPaymentTypeId();

            int headerTransactionId = HeaderTransactionController.doInsertHeaderTransaction(userId, PaymentTypeId);
            List<Cart> cartList = CartController.getCartbyUserId(userId);

            for(int i = 0; i < cartList.Count; i++ )
            {
                TransactionApprovementController.doInsertDetailTransaction(headerTransactionId, cartList.ElementAt(i).ProductID, cartList.ElementAt(i).Quantity);
            }

            //Remove Cart
            CartController.deleteAlLCartByUser(userId);
            
            Response.Redirect("./Home.aspx");
        }
    }
}