<%@ Page Title="" Language="C#" MasterPageFile="~/View/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="UpdatePaymentType.aspx.cs" Inherits="TokoBeDia.View.UpdatePaymentType" %>

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
                <h2>Update Payment Type</h2>
            </div>
        </div>
    </div>

    <div class="col-md-12">
        <div class="container">

            <asp:Table ID="PaymentTypeTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">Payment Type ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Payment Type Name</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>

    <div class="col-md-2 offset-5">
        <hr />
        <div>
            <asp:Label ID="LblPaymentType" runat="server" Text="Payment Type"></asp:Label>
            <asp:TextBox ID="TxtPaymentType" CssClass="form-control" runat="server" placeholder="Input Payment Type"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Payment Type Required" CssClass="text-danger" ValidationGroup="groupPaymentType" ControlToValidate="TxtPaymentType"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="UpdatePaymentTypeBtn" runat="server" CssClass="btn btn-lg btn-secondary btn-block" Text="Update Payment Type" ValidationGroup="groupPaymentType" OnClick="UpdatePaymentTypeBtn_Click" />
        <hr />
        <asp:Label ID="ErrorLbl" Visible="false" runat="server" ForeColor="Red" Text="[Error Message]"></asp:Label>
    </div>
</asp:Content>
