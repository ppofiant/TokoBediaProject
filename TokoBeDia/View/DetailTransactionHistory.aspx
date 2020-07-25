<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="DetailTransactionHistory.aspx.cs" Inherits="TokoBeDia.View.DetailTransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 350px;
        }
    </style>
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
                <h2>Detail Transaction</h2>
            </div>

            <div class="container d-flex justify-content-between align-items-center">
                <h2>
                    <asp:Label ID="LblEmpty" runat="server"></asp:Label></h2>
            </div>
        </div>
    </div>

    <div class="col-md-12">
        <div class="container">
            <asp:Table ID="HeaderTransactionHistoryTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">No.</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Product Quantity</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Subtotal</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>

        <div class="container">
            <br />
            <table style="width: 100%; font-size: 20px;">
                
                <tr>
                    <td class="auto-style2">Payment Type</td>
                    <td class="auto-style5">:</td>
                    <td>
                        <asp:Label ID="LblPaymentType" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">Transaction Date</td>
                    <td class="auto-style5">:</td>
                    <td>
                        <asp:Label ID="LblTransactionDate" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">Grand Total</td>
                    <td class="auto-style5">:</td>
                    <td>
                        <asp:Label ID="LblGrandTotal" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <br />
</asp:Content>
