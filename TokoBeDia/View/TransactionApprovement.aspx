<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="TransactionApprovement.aspx.cs" Inherits="TokoBeDia.View.TransactionApprovement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 25px;
        }

        .auto-style6 {
            width: 430px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="col-md-12 py-3">
        <div class="container d-flex justify-content-between align-items-center">
            <h2>Transaction Approvement</h2>
        </div>
    </div>

    <div class="container">
        <h2>
            <asp:Label ID="LblEmpty" runat="server"></asp:Label>
        </h2>

        <div>
            <table style="width: 100%; font-size: 20px;">

                <tr>
                    <td class="auto-style6">E-mail</td>
                    <td class="auto-style5">:</td>
                    <td>
                        <asp:Label ID="AuthUserEmail" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style6">Name</td>
                    <td class="auto-style5">:</td>
                    <td>
                        <asp:Label ID="AuthUserName" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style6">Gender</td>
                    <td class="auto-style5">:</td>
                    <td>
                        <asp:Label ID="AuthUserGender" runat="server" />
                    </td>
                </tr>

            </table>
            <br />
            <br />
        </div>

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
                </asp:TableHeaderRow>
            </asp:Table>
            
            <div>
                <br />
                <table style="width: 100%; font-size: 20px;">

                    <tr>
                        <td class="auto-style6">Grand Total</td>
                        <td class="auto-style5">:</td>
                        <td>
                            <asp:Label ID="LblGrandTotal" runat="server"/>
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style6">Payment Type</td>
                        <td class="auto-style5">:</td>
                        <td>
                            <asp:Label ID="LblPaymentType" runat="server"/>
                        </td>
                    </tr>

                </table>
            </div>
        </div>
    </div>
    <br />
    <div class="container">
        <asp:Button class="container" ID="CheckOutBtn" runat="server" CssClass="btn btn-lg btn-secondary btn-block" Text="Check Out" ValidationGroup="groupLogin" OnClick="CheckOutBtn_Click" />
    </div>
    <br />
    <br />
    <br />
</asp:Content>
