<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="TokoBeDia.View.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <h2>Update Profile</h2>
    </div>
    <br />
    <br />
    <div class="container">
        <div>
            <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server" placeholder="Input Email"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Email Required" CssClass="text-danger" ValidationGroup="groupUpdate" ControlToValidate="TxtEmail"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TxtName" CssClass="form-control" runat="server" placeholder="Input Name"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Name Required" CssClass="text-danger" ValidationGroup="groupUpdate" ControlToValidate="TxtName"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblGender" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonListGender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Gender Required" CssClass="text-danger" ValidationGroup="groupUpdate" ControlToValidate="RadioButtonListGender"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="UpdateProfileBtn" CssClass="btn btn-lg btn-secondary btn-block" runat="server" ValidationGroup="groupUpdate" Text="Update Profile" OnClick="UpdateProfileBtn_Click"/>
        <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
