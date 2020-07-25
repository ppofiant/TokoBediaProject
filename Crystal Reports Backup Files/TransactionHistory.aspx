<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="TokoBeDia.View.TransactionHistory" %>

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
            <h2>Transaction History</h2>

            <div align="right">
                    <asp:Button ID="TransactionReportBtn" runat="server" Text="Transaction Report" CssClass="btn btn-info" OnClick="TransactionReportBtnBtn_Click" />
            </div>
        </div>
    </div>

    <div class="container text-center">
        <h2>
            <asp:Label ID="SpaceUp" Visible="false" runat="server">
                <br />
                <br />
                <br />
                <br />
            </asp:Label>
            <asp:Label ID="LblEmpty" runat="server"></asp:Label>
            <asp:Label ID="SpaceDown" Visible="false" runat="server">
                <br />
                <br />
                <br />
                <br />
                <br />
            </asp:Label>
        </h2>
    </div>

    <div class="col-md-12">
        <br />
        <div class="container">
            <asp:Table ID="HeaderTransactionHistoryTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">No.</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Transaction ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Payment Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Transaction Date</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="1">Action</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div class="container">
            <asp:Table ID="AllHeaderTransaction" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">No.</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Transaction ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Customer Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Payment Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Transaction Date</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="1">Action</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <asp:Label ID="SpaceTable" Visible="false" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </asp:Label>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
