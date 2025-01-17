<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Async="true" CodeBehind="Weather.aspx.cs" Inherits="Client.Weather" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Weather
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="mt-4">Weather</h1>
        <div class="form-group">
            <label for="cityTextBox">City:</label>
            <asp:TextBox ID="cityTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="getWeatherButton" runat="server" Text="Get Weather" CssClass="btn btn-primary" OnClick="GetWeatherButton_Click" />
        </div>
        <div class="form-group">
            <asp:Label ID="resultLabel" runat="server" CssClass="form-control-plaintext"></asp:Label>
        </div>
    </div>
</asp:Content>