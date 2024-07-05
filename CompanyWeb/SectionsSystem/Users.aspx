<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="CompanyWeb.SectionsSystem.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .form-container {
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 20px;
        }
    </style>

    <h3>Add user</h3>

    <div class="container">
        <div class="form-container">
            <div class="form-group">
                <label for="Username ">Username:</label>
                <asp:DropDownList ID="DDLUser" runat="server" ClientIDMode="Static" AutoPostBack="true" CssClass="form-control" OnTextChanged="DDLUser_TextChanged">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="name">Page web:</label>
                <asp:DropDownList ID="DDL" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Button runat="server" ID="RunBtn" class="btn-primary" Text="Add" OnClick="RunBtn_Click" />
            </div>
        </div>
    </div>

    <asp:GridView ID="UserGV" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Username" DataField="Username" ReadOnly="false" />
            <asp:BoundField HeaderText="PageWeb" DataField="PageWeb" ReadOnly="false" />
        </Columns>

    </asp:GridView>
</asp:Content>
