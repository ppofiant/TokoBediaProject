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
    public partial class InsertProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((User)Session["auth_user"]).RoleID == 1)
            {
                Load_Products();
                Load_ProductsType();
            }
            else
            {
                Response.Redirect("./Home.aspx");
            }
        }

        protected void Load_Products()
        {
            List<Product> productList = ProductController.getProduct();
            for (int i = 0; i < productList.Count; i++)
            {
                TableRow newRow = new TableRow();
                ProductTable.Controls.Add(newRow);

                TableCell numberCell = new TableCell();
                numberCell.Controls.Add(new Label()
                {
                    Text = (i + 1) + "."
                });
                newRow.Cells.Add(numberCell);

                TableCell productNameCell = new TableCell();
                productNameCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(i).Name
                });
                newRow.Cells.Add(productNameCell);

                TableCell productStockCell = new TableCell();
                productStockCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(i).Stock.ToString()
                });
                newRow.Cells.Add(productStockCell);

                TableCell productPriceCell = new TableCell();
                productPriceCell.Controls.Add(new Label()
                {
                    Text = "Rp." + productList.ElementAt(i).Price.ToString()
                });
                newRow.Cells.Add(productPriceCell);
            }
        }

        protected void Load_ProductsType()
        {
            List<ProductType> productTypeList = ProductTypeRepo.GetProductType();
            for (int i = 0; i < productTypeList.Count; i++)
            {
                TableRow newRow = new TableRow();
                ProductTypeTable.Controls.Add(newRow);

                TableCell productTypeIdCell = new TableCell();
                productTypeIdCell.Controls.Add(new Label()
                {
                    Text = productTypeList.ElementAt(i).ID.ToString()
                });
                newRow.Cells.Add(productTypeIdCell);

                TableCell productTypeNameCell = new TableCell();
                productTypeNameCell.Controls.Add(new Label()
                {
                    Text = productTypeList.ElementAt(i).Name
                });
                newRow.Cells.Add(productTypeNameCell);
            }
        }

        protected void InsertProductBtn_Click(object sender, EventArgs e)
        {
            int productTypeId = Convert.ToInt32(TxtProductTypeID.Text);
            String name = TxtProductName.Text;
            int stock = Convert.ToInt32(TxtProductStock.Text);
            int price = Convert.ToInt32(TxtProductPrice.Text);
            string errorMessage = "";
            ProductController.createProduct(productTypeId, name, stock, price, out errorMessage);
            if(errorMessage != "Success")
            {
                ErrorLbl.Text = errorMessage;
            }
            else
            {
                Response.Redirect("./InsertProduct.aspx");
            }
        }
    }
}