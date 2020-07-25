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
    public partial class ViewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((User)Session["auth_user"]).RoleID == 1)
            {
                Load_Users();
            }
            else
            {
                Response.Redirect("./Home.aspx");
            }
        }

        protected void Load_Users()
        {
            int temp = 0;
            String nameTemp = ((User)Session["auth_user"]).Name;

            List<User> userList = UserController.getAll();
            for (int i = 0; i < userList.Count; i++)
            {
                TableRow newRow = new TableRow();
                UserTable.Controls.Add(newRow);

                if (nameTemp == userList.ElementAt(i).Name)
                {
                    temp = i;

                    TableCell numberTempCell = new TableCell();
                    numberTempCell.Controls.Add(new Label()
                    {
                        Text = (i + 1) + "."
                    });
                    newRow.Cells.Add(numberTempCell);

                    TableCell userIdTempCell = new TableCell();
                    userIdTempCell.Controls.Add(new Label()
                    {
                        Text = userList[i].Id.ToString()
                    });
                    newRow.Cells.Add(userIdTempCell);

                    TableCell userNameTempCell = new TableCell();
                    userNameTempCell.Controls.Add(new Label()
                    {
                        Text = userList.ElementAt(temp).Name
                    });
                    newRow.Cells.Add(userNameTempCell);

                    TableCell userRoleTempCell = new TableCell();
                    userRoleTempCell.Controls.Add(new Label()
                    {
                        Text = userList.ElementAt(temp).Role.Name
                    });
                    newRow.Cells.Add(userRoleTempCell);

                    TableCell userStatusTempCell = new TableCell();
                    userStatusTempCell.Controls.Add(new Label()
                    {
                        Text = userList.ElementAt(temp).Status
                    });
                    newRow.Cells.Add(userStatusTempCell);

                    TableCell editRoleTempButtonCell = new TableCell();
                    Button editRoleTempButton = new Button()
                    {
                        Text = "Can't Change Role",
                        CssClass = "btn btn-danger"
                    };
                    editRoleTempButtonCell.Controls.Add(editRoleTempButton);
                    newRow.Cells.Add(editRoleTempButtonCell);

                    TableCell editStatusTempButtonCell = new TableCell();
                    Button editStatusTempButton = new Button()
                    {
                        Text = "Can't Change Status",
                        CssClass = "btn btn-danger"
                    };
                    editStatusTempButtonCell.Controls.Add(editStatusTempButton);
                    newRow.Cells.Add(editStatusTempButtonCell);
                }
                else
                {
                    TableCell numberCell = new TableCell();
                    numberCell.Controls.Add(new Label()
                    {
                        Text = (i + 1) + "."
                    });
                    newRow.Cells.Add(numberCell);

                    TableCell userIdCell = new TableCell();
                    userIdCell.Controls.Add(new Label()
                    {
                        Text = userList[i].Id.ToString()
                    });
                    newRow.Cells.Add(userIdCell);

                    TableCell userNameCell = new TableCell();
                    userNameCell.Controls.Add(new Label()
                    {
                        Text = userList.ElementAt(i).Name
                    });
                    newRow.Cells.Add(userNameCell);

                    TableCell userRoleCell = new TableCell();
                    userRoleCell.Controls.Add(new Label()
                    {
                        Text = userList.ElementAt(i).Role.Name
                    });
                    newRow.Cells.Add(userRoleCell);

                    TableCell userStatusCell = new TableCell();
                    userStatusCell.Controls.Add(new Label()
                    {
                        Text = userList.ElementAt(i).Status
                    });
                    newRow.Cells.Add(userStatusCell);

                    TableCell editRoleButtonCell = new TableCell();
                    Button editRoleButton = new Button()
                    {
                        ID = (i + 1) + "_R",
                        Text = "Edit Role",
                        CssClass = "btn btn-warning"
                    };
                    editRoleButton.Click += EditRoleButton_Click;
                    editRoleButtonCell.Controls.Add(editRoleButton);
                    newRow.Cells.Add(editRoleButtonCell);

                    TableCell toggleButtonCell = new TableCell();
                    Button OnBtn = new Button()
                    {
                        ID = (i + 1) + "OnBtn",
                        Text = "Active",
                        OnClientClick = "OnButton_Click"
                    };
                    Button OffBtn = new Button()
                    {
                        ID = (i + 1) + "OffBtn",
                        Text = "Blocked",
                        OnClientClick = "OffButton_Click"
                    };
                    OnBtn.Click += OnButton_Click;
                    OffBtn.Click += OffButton_Click;
                    toggleButtonCell.Controls.Add(OnBtn);
                    toggleButtonCell.Controls.Add(OffBtn);
                    newRow.Cells.Add(toggleButtonCell);
                    String status = userList[i].Status.ToString();
                    if (status == "Active")
                    {
                        OnBtn.CssClass = "btn btn-success";
                        OffBtn.CssClass = "btn btn-default";
                    }
                    else if (status == "Blocked")
                    {
                        OffBtn.CssClass = "btn btn-danger";
                        OnBtn.CssClass = "btn btn-default";
                    }
                }
            }
        }

        private void EditRoleButton_Click(object sender, EventArgs e)
        {
            Button currButton = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currButton.ID.Substring(0, currButton.ID.Length - 2), out selectedRowIndex))
            {
                int userId = int.Parse(((Label)UserTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
                Response.Redirect("./EditRoleUser.aspx?ID=" + userId);
            }
        }

        private void OnButton_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            currentButton.CssClass = "btn btn-success";
            int selectedRowIndex = 0;
            if (int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 5), out selectedRowIndex))
            {
                int userId = int.Parse(((Label)UserTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
                User usr = UserController.getUserById(userId);
                if (usr.Status != "Active")
                {
                    UserController.updateStatus(userId, "Active");
                }
            }
            Response.Redirect("./ViewUser.aspx");
        }

        private void OffButton_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            currentButton.CssClass = "btn btn-danger";
            int selectedRowIndex = 0;
            if (int.TryParse(currentButton.ID.Substring(0, currentButton.ID.Length - 6), out selectedRowIndex))
            {
                int userId = int.Parse(((Label)UserTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text);
                User usr = UserController.getUserById(userId);
                if (usr.Status != "Blocked")
                {
                    UserController.updateStatus(userId, "Blocked");
                }
            }
            Response.Redirect("./ViewUser.aspx");
        }
    }
}