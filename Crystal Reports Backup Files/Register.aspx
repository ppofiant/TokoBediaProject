<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TokoBeDia.View.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h2 class="text-center">Register</h2>
    <div class="col-md-2 offset-5">
        <hr />
        <div>
            <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server" placeholder="Input Email"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Email Required" CssClass="text-danger" ValidationGroup="groupRegis" ControlToValidate="TxtEmail" EnableClientScript="False" ID="errorEmail"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TxtName" CssClass="form-control" runat="server" placeholder="Input Name"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Name Required" CssClass="text-danger" ValidationGroup="groupRegis" ControlToValidate="TxtName" EnableClientScript="False" ID="errorName"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TxtPassword" CssClass="form-control" runat="server" placeholder="Input Password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Password Required" CssClass="text-danger" ValidationGroup="groupRegis" ControlToValidate="TxtPassword" EnableClientScript="False" ID="errorPassword"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblConPassword" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="TxtConPassword" CssClass="form-control" runat="server" placeholder="Input Confirm Password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Confirm Password Required" CssClass="text-danger" ValidationGroup="groupRegis" ControlToValidate="TxtConPassword" EnableClientScript="False" ID="errorConPassword"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblGender" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonListGender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Gender Required" CssClass="text-danger" ValidationGroup="groupRegis" ControlToValidate="RadioButtonListGender" EnableClientScript="False" ID="errorGender"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="btnRegister" CssClass="btn btn-lg btn-secondary btn-block" runat="server" Text="Register" ValidationGroup="groupRegis" OnClick="btnRegister_Click" />
        <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
        <small>Have Account Already?</small>
        <a href="Login.aspx"><small>Login</small></a>
        <hr />
    </div>
    <br />
</asp:Content>
