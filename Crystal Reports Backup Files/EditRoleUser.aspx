<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="EditRoleUser.aspx.cs" Inherits="TokoBeDia.View.EditRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="col-md-12" style="margin: 20px 0px;">
        <div class="col-md-12 py-3">
            <div class="container d-flex justify-content-between align-items-center">
                <h2>Change Role User</h2>
            </div>
        </div>
    </div>

    <div class="col-md-12">
        <div class="container">
            <asp:Table ID="UserTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">User Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">User Role</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>

    <div class="col-md-2 offset-5">
        <hr />
        <div>
            <asp:Label ID="RoleLbl" runat="server" ForeColor="Red" Text="Role ID"></asp:Label><br />
            <asp:Label ID="Administrator" runat="server" ForeColor="Red" Text="1. Administrator"></asp:Label><br />
            <asp:Label ID="Member" runat="server" ForeColor="Red" Text="2. Member"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="LblRoleUser" runat="server" Text="User Role"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonListRole" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="User Role Required" CssClass="text-danger" ValidationGroup="groupRole" ControlToValidate="RadioButtonListRole"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="ChangeRoleBtn" runat="server" CssClass="btn btn-lg btn-secondary btn-block" Text="Change Role" ValidationGroup="groupRole" OnClick="ChangeRoleBtn_Click" />
        <hr />
    </div>
    <br />
    <br />
    <br />
</asp:Content>
