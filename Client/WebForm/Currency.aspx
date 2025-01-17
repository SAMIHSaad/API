<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Async="true" CodeBehind="Currency.aspx.cs" Inherits="Client.Currency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Currency Converter
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="mt-4">Currency Converter</h1>
        <div class="form-group">
            <label for="amount">Amount:</label>
            <asp:TextBox ID="amount" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="from">From:</label>
            <asp:DropDownList ID="from" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="to">To:</label>
            <asp:DropDownList ID="to" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="convertButton" runat="server" Text="Convert" CssClass="btn btn-primary" OnClick="ConvertButton_Click" />
        </div>
        <div class="form-group">
            <label for="result">Result:</label>
            <asp:Label ID="result" runat="server" CssClass="form-control-plaintext"></asp:Label>
        </div>
    </div>
</asp:Content>