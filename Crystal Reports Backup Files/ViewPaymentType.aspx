<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="ViewPaymentType.aspx.cs" Inherits="TokoBeDia.View.ViewPaymentType" %>
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
                <h2>List of Payment Type</h2>

                <div align="right">
                    <asp:Button Text="Insert Payment Type" runat="server" ID="InsertPaymentType" CssClass="btn btn-info" OnClick="InsertPaymentType_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-12">
        <div class="container">

            <asp:Table ID="PaymentTypeTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">No.</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Payment Type ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Payment Type Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2">Action</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
