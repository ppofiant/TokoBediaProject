using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.Model;
using TokoBeDia.Repository;
using TokoBeDia.HandlerFolder;

namespace TokoBeDia.View
{
    public partial class UpdateCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cekSession();
            int id = getProductId();
            int userId = getUserId();

            Product prk = ProductRepo.GetProductByID(id);
            Cart carts = CartRepo.getCartbyProductIdAndUserId(id, userId);

            TableRow newRow = new TableRow();
            CartTable.Controls.Add(newRow);

            TableCell productIdCell = new TableCell();
            productIdCell.Controls.Add(new Label()
            {
                Text = prk.ID.ToString()
            });
            newRow.Cells.Add(productIdCell);

            TableCell productNameCell = new TableCell();
            productNameCell.Controls.Add(new Label()
            {
                Text = prk.Name
            });
            newRow.Cells.Add(productNameCell);

            TableCell productPriceCell = new TableCell();
            productPriceCell.Controls.Add(new Label()
            {
                Text = "Rp. " + prk.Price.ToString()
            });
            newRow.Cells.Add(productPriceCell);

            TableCell qtyCell = new TableCell();
            qtyCell.Controls.Add(new Label()
            {
                Text = carts.Quantity.ToString()
            });
            newRow.Cells.Add(qtyCell);

            int subTotal = carts.Quantity * prk.Price;

            TableCell subTotalCell = new TableCell();
            subTotalCell.Controls.Add(new Label()
            {
                Text = "Rp. " + subTotal.ToString()
            });
            newRow.Cells.Add(subTotalCell);
        }

        protected int getUserId()
        {
            int userId = Convert.ToInt32(((User)Session["auth_user"]).Id);
            return userId;
        }

        protected int getProductId()
        {
            int productId = Convert.ToInt32(Request.QueryString["ID"]);
            return productId;
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
                    Response.Redirect("./Home.aspx");
                }
                else
                {
                    Response.Redirect("./Login.aspx");
                }
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int id = getProductId();
            int userId = getUserId();
            int qty = Convert.ToInt32(TxtQty.Text);

            Product products = ProductRepo.GetProductByID(id);

            if (qty >= products.Stock)
            {
                LblError.Text = "Sorry, This Product Stock is just " + products.Stock;
            }
            else if (qty == 0)
            {
                CartRepo.deleteProductCart(id, userId);
                Response.Redirect("./Cart.aspx");
            }
            else
            {
                CartRepo.updateQtyCart(qty, id, userId);
                Response.Redirect("./Cart.aspx");
            }
        }
    }
}