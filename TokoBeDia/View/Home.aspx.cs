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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_ProductsGuest();

                if (Session["auth_user"] == null)
                {
                    ProductGuestTable.Visible = true;
                }
                else
                {
                    if (((User)Session["auth_user"]).RoleID == 2)
                    {
                        GridViewProduct.Visible = true;
                    }
                    else
                    {
                        ProductGuestTable.Visible = true;
                    }
                }
            }
        }

        protected void Load_ProductsGuest()
        {
            List<Product> productList = ProductController.getProduct();
            Random rand = new Random();
            int randomNum = 0;
            for (int i = 0; i < 5; i++)
            {
                randomNum = rand.Next(productList.Count);

                TableRow newRow = new TableRow();
                ProductGuestTable.Controls.Add(newRow);

                TableCell numberCell = new TableCell();
                numberCell.Controls.Add(new Label()
                {
                    Text = (i + 1) + "."
                });
                newRow.Cells.Add(numberCell);

                TableCell productNameCell = new TableCell();
                productNameCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(randomNum).Name
                });
                newRow.Cells.Add(productNameCell);

                TableCell productStockCell = new TableCell();
                productStockCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(randomNum).Stock.ToString()
                });
                newRow.Cells.Add(productStockCell);

                TableCell productTypeCell = new TableCell();
                productTypeCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(randomNum).ProductType.Name
                });
                newRow.Cells.Add(productTypeCell);

                TableCell productPriceCell = new TableCell();
                productPriceCell.Controls.Add(new Label()
                {
                    Text = "Rp." + productList.ElementAt(randomNum).Price.ToString()
                });
                newRow.Cells.Add(productPriceCell);
            }
        }

        protected void CartButton_Click(object send, EventArgs e)
        {
            int productId = Int32.Parse((send as LinkButton).CommandArgument);
            Response.Redirect("./InsertToCart.aspx?ID=" + productId);
        }
    }
}