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
    public partial class ViewProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cekSession();
            Load_ProductType();
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

                    Session["user"] = users;
                }
                else
                {
                    Response.Redirect("./Login.aspx");
                }
            }
        }

        protected void Load_ProductType()
        {
            List<ProductType> productTypeList = ProductTypeController.getAllProductType();
            for (int i = 0; i < productTypeList.Count; i++)
            {
                TableRow newRow = new TableRow();
                ProductTypeTable.Controls.Add(newRow);

                TableCell numberCell = new TableCell();
                numberCell.Controls.Add(new Label()
                {
                    Text = (i + 1) + "."
                });
                newRow.Cells.Add(numberCell);

                TableCell productTypeIDCell = new TableCell();
                productTypeIDCell.Controls.Add(new Label()
                {
                    Text = productTypeList.ElementAt(i).ID.ToString()
                });
                newRow.Cells.Add(productTypeIDCell);

                TableCell productTypeCell = new TableCell();
                productTypeCell.Controls.Add(new Label()
                {
                    Text = productTypeList.ElementAt(i).Name
                });
                newRow.Cells.Add(productTypeCell);

                TableCell productTypeDescCell = new TableCell();
                productTypeDescCell.Controls.Add(new Label()
                {
                    Text = productTypeList.ElementAt(i).Description
                });
                newRow.Cells.Add(productTypeDescCell);

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

        protected void InsertProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("./InsertProductType.aspx");
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
            {
                int productTypeId = int.Parse(((Label)ProductTypeTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
                Response.Redirect("./UpdateProductType.aspx?ID=" + productTypeId);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
            {
                int productId = int.Parse(((Label)ProductTypeTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);

                ProductTypeController.deleteProductType(productId);

                Response.Redirect("./ViewProductType.aspx");
            }
        }
    }
}