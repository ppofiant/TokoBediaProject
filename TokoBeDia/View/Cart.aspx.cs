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
    public partial class Carts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cekSession();
            LoadCartUser();
        }

        protected int getUserId()
        {
            int userId = Convert.ToInt32(((User)Session["auth_user"]).Id);
            return userId;
        }

        protected void LoadCartUser()
        {
            int userId = getUserId();
            List<Cart> cartList = CartController.getCartbyUserId(userId);

            if(cartList.Count == 0)
            {
                SpaceUp.Visible = true;
                LblEmpty.Text = "You Have no Cart Right Now";
                LblEmpty.Visible = true;
                SpaceDown.Visible = true;
                CartTable.Visible = false;
                LblGrandTotal.Visible = false;
                CheckOutBtn.Visible = false;   
            }
            else
            {
                int subtotal = 0;
                int grandtotal = 0;

                for (int i = 0; i < cartList.Count; i++)
                {
                    TableRow newRow = new TableRow();
                    CartTable.Controls.Add(newRow);

                    TableCell numberCell = new TableCell();
                    numberCell.Controls.Add(new Label()
                    {
                        Text = (i + 1) + "."
                    });
                    newRow.Cells.Add(numberCell);

                    TableCell productIdCell = new TableCell();
                    productIdCell.Controls.Add(new Label()
                    {
                        Text = cartList.ElementAt(i).ProductID.ToString()
                    });
                    newRow.Cells.Add(productIdCell);

                    //Cari tau nama Product dari Product Id
                    int productId = cartList.ElementAt(i).ProductID;
                    Product products = ProductController.getProductById(productId);

                    TableCell productNameCell = new TableCell();
                    productNameCell.Controls.Add(new Label()
                    {
                        Text = products.Name
                    });
                    newRow.Cells.Add(productNameCell);

                    TableCell productPriceCell = new TableCell();
                    productPriceCell.Controls.Add(new Label()
                    {
                        Text = "Rp. " + products.Price.ToString()
                    });
                    newRow.Cells.Add(productPriceCell);

                    TableCell qtyCell = new TableCell();
                    qtyCell.Controls.Add(new Label()
                    {
                        Text = cartList.ElementAt(i).Quantity.ToString()
                    });
                    newRow.Cells.Add(qtyCell);

                    //Hitung subTotal Produk
                    subtotal = (products.Price * cartList.ElementAt(i).Quantity);

                    TableCell subTotalCell = new TableCell();
                    subTotalCell.Controls.Add(new Label()
                    {
                        Text = "Rp. " + subtotal.ToString()
                    });
                    newRow.Cells.Add(subTotalCell);

                    //Hitung Grand Total Keseluruhan
                    grandtotal = grandtotal + subtotal;

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
                    deleteButton.Click += DeleteButton_Click;
                    deleteButtonCell.Controls.Add(deleteButton);
                    newRow.Cells.Add(deleteButtonCell);
                }
                LblGrandTotal.Text = "GRAND TOTAL : Rp. " + grandtotal.ToString();
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
            {
                int productId = int.Parse(((Label)CartTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
                
                Response.Redirect("./UpdateCart.aspx?ID=" + productId);
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;
            int userId = getUserId();

            if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
            {
                int productId = int.Parse(((Label)CartTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
                CartController.deleteCartUser(productId, userId);
            }
            Response.Redirect("./Cart.aspx");
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

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ViewPaymentType.aspx");
        }
    }
}