<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TokoBeDia.View.Home" %>

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
            <h2>Product Recommended</h2>
        </div>
    </div>
    <br />
    <div class="col-md-12">
        <div class="container">
            <asp:Table ID="ProductGuestTable" Visible="false" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">No.</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Stock</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Price</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>

        <div class="container">
            <asp:GridView ID="GridViewProduct" Visible="false" CssClass="table table-bordered text-center" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="RandomProduct">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="ProductTypeID" HeaderText="Product Type" SortExpression="Product Type" />

                    <asp:BoundField DataField="Name" HeaderText="Product Name" SortExpression="Product Name" />
                    <asp:BoundField DataField="Price" HeaderText="Product Price" SortExpression="Product Price" />
                    <asp:BoundField DataField="Stock" HeaderText="Product Stock" SortExpression="Product Stock" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton OnClick="CartButton_Click" ID="CartRedirect" CssClass="btn btn-secondary" CommandArgument='<%# Eval("ID")%>' runat="server">Add to cart</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="RandomProduct" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="
                SELECT TOP 5 *
                FROM Products
                ORDER BY NEWID()"></asp:SqlDataSource>
        </div>
    </div>
    <br />
    <br />
</asp:Content>
