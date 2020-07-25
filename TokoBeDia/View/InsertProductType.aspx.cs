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
    public partial class InsertProductType : System.Web.UI.Page
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

                    Session["auth_user"] = users;
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
            }
        }

        protected void InsertProductTypeBtn_Click(object sender, EventArgs e)
        {
            String productTypeName = TxtProductType.Text;
            String description = TxtDescription.Text;
            string errorMessage = "";

            ProductTypeController.createProductType(productTypeName, description, out errorMessage);
            if(errorMessage != "Success")
            {
                ErrorLbl.Text = errorMessage;
                ErrorLbl.Visible = true;
            }
            else
            {
                ErrorLbl.Visible = false;
                Response.Redirect("./InsertProductType.aspx");
            }
        }
    }
}