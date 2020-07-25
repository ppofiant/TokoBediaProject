<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="InsertToCart.aspx.cs" Inherits="TokoBeDia.View.InsertToCart" %>

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
            <h2>Add to Cart</h2>
        </div>
    </div>
    <div class="col-md-12">
        <div class="container">
            <asp:Table ID="CartTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">Product Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Price</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Stock</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Type</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>
    <br />
    <div class="container">
        <asp:Label ID="LblQtyProduct" runat="server" Text="Product QTY"></asp:Label>
        <asp:TextBox ID="TxtQty" CssClass="form-control" runat="server" ValidationGroup="groupProduct" placeholder="Input Product QTY"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtQty" ForeColor="Red" ErrorMessage="Input Must Be Numeric !" ValidationExpression="^\d+$" ValidationGroup="groupProduct"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator runat="server" ErrorMessage="Product QTY Required" CssClass="text-danger" ValidationGroup="groupProduct" ControlToValidate="TxtQty" EnableClientScript="False"></asp:RequiredFieldValidator>
    </div>
    <br />
    <div class="container">
        <asp:Button ID="AddToCartBtn" runat="server" CssClass="btn btn-lg btn-secondary btn-block" Text="Add Product" ValidationGroup="groupProduct" OnClick="AddCartBtn_Click" />
        <asp:Label ID="LblError" ForeColor="Red" runat="server"></asp:Label>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
