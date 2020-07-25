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
    public partial class UpdateProductType : System.Web.UI.Page
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
            int productId = Convert.ToInt32(Request.QueryString["ID"]);
            ProductType prk = ProductTypeRepo.GetProductTypeByID(productId);

            TableRow newRow = new TableRow();
            ProductTypeTable.Controls.Add(newRow);

            TableCell productTypeCell = new TableCell();
            productTypeCell.Controls.Add(new Label()
            {
                Text = prk.Name
            });
            newRow.Cells.Add(productTypeCell);

            TableCell productDescCell = new TableCell();
            productDescCell.Controls.Add(new Label()
            {
                Text = prk.Description
            });
            newRow.Cells.Add(productDescCell);

        }

        protected void UpdateProductTypeBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            String productType = TxtProductType.Text;
            String description = TxtDescription.Text;
            string errorMessage = "";

            ProductTypeController.updateProductType(id, productType, description, out errorMessage);
            if(errorMessage != "Success")
            {
                ErrorLbl.Text = errorMessage;
                ErrorLbl.Visible = true;
            }
            else
            {
                Response.Redirect("./ViewProductType.aspx");
            }
        }
    }
}