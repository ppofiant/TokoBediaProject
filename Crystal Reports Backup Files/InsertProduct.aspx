<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="InsertProduct.aspx.cs" Inherits="TokoBeDia.View.InsertProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="col-md-12" style="margin: 20px 0px;">
        <div class="col-md-12 py-3">
            <div class="container d-flex justify-content-between align-items-center">
                <h2>Insert Product</h2>
            </div>
        </div>
    </div>

    <div class="col-md-12">
        <div class="container">
            <asp:Table ID="ProductTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">No.</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Stock</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Price</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <br />
            <asp:Table ID="ProductTypeTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">Product Type ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Type</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>

    <div class="col-md-2 offset-5">
        <hr />
        <div>
            <asp:Label ID="LblProductTypeID" runat="server" Text="Product Type ID"></asp:Label>
            <asp:TextBox ID="TxtProductTypeID" CssClass="form-control" runat="server" placeholder="Input Product Type ID"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Product Type ID Required" CssClass="text-danger" ValidationGroup="groupProduct" ControlToValidate="TxtProductTypeID"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblProductName" runat="server" Text="Product Name"></asp:Label>
            <asp:TextBox ID="TxtProductName" CssClass="form-control" runat="server" placeholder="Input Product Name"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Product Name Required" CssClass="text-danger" ValidationGroup="groupProduct" ControlToValidate="TxtProductName"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblProductStock" runat="server" Text="Product Stock"></asp:Label>
            <asp:TextBox ID="TxtProductStock" CssClass="form-control" runat="server" placeholder="Input Product Stock"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Product Stock Required" CssClass="text-danger" ValidationGroup="groupProduct" ControlToValidate="TxtProductStock"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblProductPrice" runat="server" Text="Product Price"></asp:Label>
            <asp:TextBox ID="TxtProductPrice" CssClass="form-control" runat="server" placeholder="Input Product Price"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Product Price Required" CssClass="text-danger" ValidationGroup="groupProduct" ControlToValidate="TxtProductPrice"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="InsertProductBtn" runat="server" CssClass="btn btn-lg btn-secondary btn-block" Text="Insert Product" ValidationGroup="groupProduct" OnClick="InsertProductBtn_Click" />
        <hr />
        <asp:Label ID="ErrorLbl" Visible="false" runat="server" ForeColor="Red" Text="[Error Message]"></asp:Label>
    </div>
</asp:Content>
