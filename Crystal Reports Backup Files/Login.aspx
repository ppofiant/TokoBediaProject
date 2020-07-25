<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TokoBeDia.View.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <h2 class="text-center">Login</h2>
    <div class="col-md-2 offset-5">
        <hr />
        <div>
            <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server" placeholder="Input Email"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Email Required" CssClass="text-danger" ValidationGroup="groupLogin" ControlToValidate="TxtEmail"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TxtPassword" CssClass="form-control" runat="server" placeholder="Input Password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Password Required" CssClass="text-danger" ValidationGroup="groupLogin" ControlToValidate="TxtPassword"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:CheckBox ID="CbRemeberMe" runat="server" Text="Remember Me" />
        </div>

        <asp:Button ID="LoginBtn" runat="server" CssClass="btn btn-lg btn-secondary btn-block" Text="Login" ValidationGroup="groupLogin" OnClick="btnLogin_Click" />
        <asp:Label ID="ErrorLbl" Visible="false" runat="server" ForeColor="Red" Text="[Error Message]"></asp:Label>
        <hr />
        <small>Don't Have Account ?</small>
        <a href="Register.aspx"><small>Register</small></a>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
