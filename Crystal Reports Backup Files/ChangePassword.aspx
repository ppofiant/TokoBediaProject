<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TokoBeDia.View.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <h2 class="text-center">Change Password</h2>
    <p class="text-center">&nbsp;</p>
    <div class="col-md-2 offset-5">
        <hr />
        <div>
            <asp:Label ID="LblOld" runat="server" Text="Old Password"></asp:Label>
            <asp:TextBox ID="TxtOld" CssClass="form-control" runat="server" placeholder="Input Old Password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Old Password Required" CssClass="text-danger" ValidationGroup="groupChange" ControlToValidate="TxtOld"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblNew" runat="server" Text="New Password"></asp:Label>
            <asp:TextBox ID="TxtNew" CssClass="form-control" runat="server" placeholder="Input New Password" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="New Password Required" CssClass="text-danger" ValidationGroup="groupChange" ControlToValidate="TxtNew"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblConfirm" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="TxtConfirm" CssClass="form-control" runat="server" placeholder="Input Confirm Password" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator runat="server" ErrorMessage="Confirm Password Required" CssClass="text-danger" ValidationGroup="groupChange" ControlToValidate="TxtNew" ControlToCompare="TxtConfirm"></asp:CompareValidator>
        </div>

        <asp:Button ID="ChangeBtn" runat="server" CssClass="btn btn-lg btn-secondary btn-block" Text="Change Password" ValidationGroup="groupChange" OnClick="ChangeBtn_Click"/>
        <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
        <hr />
    </div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
