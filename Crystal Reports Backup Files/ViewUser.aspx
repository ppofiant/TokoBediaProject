<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="TokoBeDia.View.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="col-md-12" style="margin: 20px 0px;">
        <div class="col-md-12 py-3">
            <div class="container d-flex justify-content-between align-items-center">
                <h2>List of User</h2>
            </div>
        </div>
    </div>

    <div class="col-md-12">
        <div class="container">

            <asp:Table ID="UserTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">No.</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">User ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">User Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Role</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Status</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2">Action</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>

        </div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
