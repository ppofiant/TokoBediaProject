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
    public partial class EditRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Users();
        }

        protected void Load_Users()
        {
            int userId = Convert.ToInt32(Request.QueryString["ID"]);
            User usr = UserController.getUserById(userId);

            TableRow newRow = new TableRow();
            UserTable.Controls.Add(newRow);

            TableCell userNameCell = new TableCell();
            userNameCell.Controls.Add(new Label()
            {
                Text = usr.Name
            });
            newRow.Cells.Add(userNameCell);

            TableCell userRoleCell = new TableCell();
            userRoleCell.Controls.Add(new Label()
            {
                Text = usr.Role.Name
            });
            newRow.Cells.Add(userRoleCell);
        }

        protected void ChangeRoleBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            int userRoleId = Convert.ToInt32(RadioButtonListRole.Text);

            UserController.doUpdateRole(id, userRoleId);

            Response.Redirect("./ViewUser.aspx");
        }
    }
}