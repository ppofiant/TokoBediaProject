<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="TokoBeDia.View.ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../Assets/Bootstrap/profile.css" />
    <style type="text/css">
        .auto-style2 {
            width: 247px;
        }

        .auto-style3 {
            width: 38px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container content-wrapper">
        <div class="title-user">
            <br />
            <br />
            <br />
            <br />
            <br />
            <h2>My Profile</h2>
        </div>

        <div class="container">
            <table style="width: 100%; font-size: 30px;">

                <tr>
                    <td class="auto-style2">E-mail</td>
                    <td class="auto-style3">:</td>
                    <td>
                        <asp:label ID="AuthUserEmail" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">Name</td>
                    <td class="auto-style3">:</td>
                    <td>
                        <asp:label ID="AuthUserName" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">Gender</td>
                    <td class="auto-style3">:</td>
                    <td>
                        <asp:label ID="AuthUserGender" runat="server" />
                    </td>
                </tr>

            </table>
            <br />
            <br />
        </div>

        <div class="container">
            <asp:Button ID="UpdateProfileBtn" runat="server" CssClass="btn btn-lg btn-secondary btn-block" Text="Update Profile" OnClick="UpdateProfileBtn_Click" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>


    </div>
</asp:Content>
