<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="UpdateProductType.aspx.cs" Inherits="TokoBeDia.View.UpdateProductType" %>

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
                <h2>Update Product Type</h2>
            </div>
        </div>
    </div>

    <div class="col-md-12">
        <div class="container">

            <asp:Table ID="ProductTypeTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">Product Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Description</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>

    <div class="col-md-2 offset-5">
        <hr />
        <div>
            <asp:Label ID="LblProductType" runat="server" Text="Product Type"></asp:Label>
            <asp:TextBox ID="TxtProductType" CssClass="form-control" runat="server" placeholder="Input Product Type"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Product Type Required" CssClass="text-danger" ValidationGroup="groupProductType" ControlToValidate="TxtProductType"></asp:RequiredFieldValidator>
        </div>

        <div>
            <asp:Label ID="LblDescription" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="TxtDescription" CssClass="form-control" runat="server" placeholder="Input Description"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Description Required" CssClass="text-danger" ValidationGroup="groupProductType" ControlToValidate="TxtDescription"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="UpdateProductTypeBtn" runat="server" CssClass="btn btn-lg btn-secondary btn-block" Text="Update Product Type" ValidationGroup="groupProductType" OnClick="UpdateProductTypeBtn_Click" />
        <hr />
        <asp:Label ID="ErrorLbl" Visible="false" runat="server" ForeColor="Red" Text="[Error Message]"></asp:Label>
    </div>
</asp:Content>
