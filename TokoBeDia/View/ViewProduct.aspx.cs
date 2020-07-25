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
    public partial class ViewProduct : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_ProductsAdmin();
            Load_ProductsMember();
            Load_ProductsGuest();

            if (Session["auth_user"] == null)
            {
                ProductGuestTable.Visible = true;
            }
            else
            {
                if (((User)Session["auth_user"]).RoleID == 1)
                {
                    ProductAdminTable.Visible = true;
                    InsertProductBtn.Visible = true;
                }
                else
                {
                    ProductMemberTable.Visible = true;
                }
            }
        }

        protected void Load_ProductsAdmin()
        {
            List<Product> productList = ProductController.getProduct();
            for (int i = 0; i < productList.Count; i++)
            {
                TableRow newRow = new TableRow();
                ProductAdminTable.Controls.Add(newRow);

                TableCell numberCell = new TableCell();
                numberCell.Controls.Add(new Label()
                {
                    Text = (i + 1) + "."
                });
                newRow.Cells.Add(numberCell);

                TableCell productIDCell = new TableCell();
                productIDCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(i).ID.ToString()
                });
                newRow.Cells.Add(productIDCell);

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

                TableCell productTypeCell = new TableCell();
                productTypeCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(i).ProductType.Name
                });
                newRow.Cells.Add(productTypeCell);

                TableCell productPriceCell = new TableCell();
                productPriceCell.Controls.Add(new Label()
                {
                    Text = "Rp." + productList.ElementAt(i).Price.ToString()
                });
                newRow.Cells.Add(productPriceCell);

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

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
            {
                int productId = int.Parse(((Label)ProductAdminTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
                Response.Redirect("./UpdateProduct.aspx?ID=" + productId);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
            {
                int productId = int.Parse(((Label)ProductAdminTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);

                ProductController.deleteProduct(productId);

                Response.Redirect("./ViewProduct.aspx");
            }
        }

        protected void Load_ProductsGuest()
        {
            List<Product> productList = ProductController.getProduct();
            for (int i = 0; i < productList.Count; i++)
            {
                TableRow newRow = new TableRow();
                ProductGuestTable.Controls.Add(newRow);

                TableCell numberCell = new TableCell();
                numberCell.Controls.Add(new Label()
                {
                    Text = (i + 1) + "."
                });
                newRow.Cells.Add(numberCell);

                TableCell productIDCell = new TableCell();
                productIDCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(i).ID.ToString()
                });
                newRow.Cells.Add(productIDCell);

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

                TableCell productTypeCell = new TableCell();
                productTypeCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(i).ProductType.Name
                });
                newRow.Cells.Add(productTypeCell);

                TableCell productPriceCell = new TableCell();
                productPriceCell.Controls.Add(new Label()
                {
                    Text = "Rp." + productList.ElementAt(i).Price.ToString()
                });
                newRow.Cells.Add(productPriceCell);
            }
        }

        protected void Load_ProductsMember()
        {
            List<Product> productList = ProductController.getProduct();
            for (int i = 0; i < productList.Count; i++)
            {
                TableRow newRow = new TableRow();
                ProductMemberTable.Controls.Add(newRow);

                TableCell numberCell = new TableCell();
                numberCell.Controls.Add(new Label()
                {
                    Text = (i + 1) + "."
                });
                newRow.Cells.Add(numberCell);

                TableCell productIDCell = new TableCell();
                productIDCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(i).ID.ToString()
                });
                newRow.Cells.Add(productIDCell);

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

                TableCell productTypeCell = new TableCell();
                productTypeCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(i).ProductType.Name
                });
                newRow.Cells.Add(productTypeCell);

                TableCell productPriceCell = new TableCell();
                productPriceCell.Controls.Add(new Label()
                {
                    Text = "Rp." + productList.ElementAt(i).Price.ToString()
                });
                newRow.Cells.Add(productPriceCell);

                TableCell CartButtonCell = new TableCell();
                Button CartButton = new Button()
                {
                    ID = (i + 1) + "_C",
                    Text = "Add to Cart",
                    CssClass = "btn btn-secondary"
                };
                CartButton.Click += CartButton_Click;
                CartButtonCell.Controls.Add(CartButton);
                newRow.Cells.Add(CartButtonCell);
            }
        }

        private void CartButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;

            if (((User)Session["auth_user"]).RoleID == 1)
            {
                if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
                {
                    int productId = int.Parse(((Label)ProductAdminTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
                    Response.Redirect("./InsertToCart.aspx?ID=" + productId);
                }
            }
            else
            {
                if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
                {
                    int productId = int.Parse(((Label)ProductGuestTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
                    Response.Redirect("./InsertToCart.aspx?ID=" + productId);
                }
            }
        }

        protected void InsertProductBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./InsertProduct.aspx");
        }

        protected void AddCartBtn_Click(object sender, EventArgs e)
        {

        }
    }
}