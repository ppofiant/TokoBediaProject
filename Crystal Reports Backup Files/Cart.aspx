<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="TokoBeDia.View.Carts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="col-md-12 py-3">
        <div class="container d-flex justify-content-between align-items-center">
            <h2>My Cart</h2>
        </div>
    </div>

    <div class="container text-center">
        <h2>
            <asp:Label ID="SpaceUp" Visible="false" runat="server">
                <br />
                <br />
                <br />
            </asp:Label>
            <asp:Label ID="LblEmpty" runat="server"></asp:Label>
            <asp:Label ID="SpaceDown" Visible="false" runat="server">
                <br />
                <br />
            </asp:Label>
        </h2>
    </div>

    <div class="col-md-12">
        <div class="container">
            <asp:Table ID="CartTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">No.</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">ProductID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Price</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Quantity</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Sub Total</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2">Action</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <br />
            <div>
                <asp:Label ID="LblGrandTotal" runat="server" Font-Size="Larger" Font-Bold="True"></asp:Label>
            </div>
            <br />
        </div>
    </div>
    <br />
    <div class="container">
        <asp:Button class="container" ID="CheckOutBtn" runat="server" CssClass="btn btn-lg btn-secondary btn-block" Text="Check Out" ValidationGroup="groupLogin" OnClick="CheckOutBtn_Click" />
    </div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
