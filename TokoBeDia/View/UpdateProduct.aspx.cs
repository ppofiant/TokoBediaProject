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
    public partial class UpdateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((User)Session["auth_user"]).RoleID == 1)
            {
                Load_Products();
            }
            else
            {
                Response.Redirect("./Home.aspx");
            }
        }

        protected void Load_Products()
        {
            int productId = Convert.ToInt32(Request.QueryString["ID"]);
            Product prk = ProductController.getProductById(productId);

            TableRow newRow = new TableRow();
            ProductTable.Controls.Add(newRow);

            TableCell productNameCell = new TableCell();
            productNameCell.Controls.Add(new Label()
            {
                Text = prk.Name
            });
            newRow.Cells.Add(productNameCell);

            TableCell productStockCell = new TableCell();
            productStockCell.Controls.Add(new Label()
            {
                Text = prk.Stock.ToString()
            });
            newRow.Cells.Add(productStockCell);

            TableCell productPriceCell = new TableCell();
            productPriceCell.Controls.Add(new Label()
            {
                Text = "Rp." + prk.Price.ToString()
            });
            newRow.Cells.Add(productPriceCell);
        }

        protected void UpdateProductBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            String name = TxtProductName.Text;
            int stock = Convert.ToInt32(TxtProductStock.Text);
            int price = Convert.ToInt32(TxtProductPrice.Text);
            string errorMessage = "";

            ProductController.updateProduct(id, name, stock, price, out errorMessage);
            if(errorMessage != "Success")
            {
                ErrorLbl.Text = errorMessage;
                ErrorLbl.Visible = true;
            }
            else
            {
                Response.Redirect("./ViewProduct.aspx");
            }
        }
    }
}