using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TokoBeDia.HandlerFolder;
using TokoBeDia.Model;
using TokoBeDia.Repository;

namespace TokoBeDia.View
{
    public partial class InsertToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cekSession();

            int productId = Convert.ToInt32(Request.QueryString["ID"]);
            Product prk = ProductRepo.GetProductByID(productId);

            TableRow newRow = new TableRow();
            CartTable.Controls.Add(newRow);

            TableCell productNameCell = new TableCell();
            productNameCell.Controls.Add(new Label()
            {
                Text = prk.Name
            });
            newRow.Cells.Add(productNameCell);

            TableCell productPriceCell = new TableCell();
            productPriceCell.Controls.Add(new Label()
            {
                Text = prk.Price.ToString()
            });
            newRow.Cells.Add(productPriceCell);

            TableCell productStockCell = new TableCell();
            productStockCell.Controls.Add(new Label()
            {
                Text = prk.Stock.ToString()
            });
            newRow.Cells.Add(productStockCell);

            TableCell productTypeCell = new TableCell();
            productTypeCell.Controls.Add(new Label()
            {
                Text = prk.ProductType.Name
            });
            newRow.Cells.Add(productTypeCell);
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

        protected void AddCartBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            int userId = Convert.ToInt32(((User)Session["auth_user"]).Id.ToString());
            int qty = Convert.ToInt32(TxtQty.Text);
            
            Product products = ProductRepo.GetProductByID(id);
            bool isExist = CartHandler.isExist(id, userId);

            if (isExist == true)
            {
                Cart carts = CartRepo.getCartbyProductIdAndUserId(id, userId);
                qty = qty + carts.Quantity;
            }
            

            if(qty > products.Stock)
            {
                LblError.Text = "Sorry, This Product Stock is just " + products.Stock;
            }
            else
            {
                if(isExist==false)
                {
                    CartRepo.doInsertProductToCart(id, userId, qty);
                }

                else
                {
                    CartRepo.addQtyProduct(id, userId, qty);
                }

                Response.Redirect("./ViewProduct.aspx");
            }
        }
    }
}