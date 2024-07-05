<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Regest.aspx.cs" Inherits="CompanyWeb.Regest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            background-image: url('Files/roya.jpg');
        }
    </style>

    <h2>Create account</h2>

    <div class="form-group">
        <label for="username">Username:</label>
        <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="password">Password:</label>
        <asp:TextBox ID="PasswordBox" runat="server" TextMode="Password" CssClass="form-control" Required="true"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="Email">Email:</label>
        <asp:TextBox ID="EmailTextBox" runat="server" TextMode="Email" CssClass="form-control" Required="true"></asp:TextBox>
    </div>


    <div class="form-group">
        <asp:Button ID="RegestButton" runat="server" Text="Create new account" OnClick="RunBtn_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
