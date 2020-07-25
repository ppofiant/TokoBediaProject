<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="UpdateCart.aspx.cs" Inherits="TokoBeDia.View.UpdateCart" %>

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
            <h2>Update Cart</h2>
        </div>
    </div>
    <div class="col-md-12">
        <div class="container">
            <asp:Table ID="CartTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">ProductID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Price</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Quantity</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Sub Total</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>

    <div class="container">
        <asp:Label ID="LblQty" runat="server" Text="Product Quantity"></asp:Label>
        <asp:TextBox ID="TxtQty" CssClass="form-control" runat="server" ValidationGroup="groupProduct" placeholder="Input Product Quantity"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtQty" ForeColor="Red" ErrorMessage="Input Must Be Numeric !" ValidationExpression="^\d+$" ValidationGroup="groupProduct"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator runat="server" ErrorMessage="Product Quantity Required" CssClass="text-danger" ValidationGroup="groupProduct" ControlToValidate="TxtQty"></asp:RequiredFieldValidator>
    </div>
    <br />
    <div class="container">
        <asp:Button class="container" ID="UpdateBtn" runat="server" CssClass="btn btn-lg btn-secondary btn-block" Text="Update Cart" ValidationGroup="groupLogin" OnClick="UpdateBtn_Click" Font-Bold="True" />
        <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
