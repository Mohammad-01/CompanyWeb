<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddItems.aspx.cs" Inherits="CompanyWeb.CompanyItems.AddItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .form-container {
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 20px;
            background-color: white;
        }

        body {
            background-image: url('Files/new.jpg');
        }
    </style>
    <h3>Add Items</h3>

    <div class="container">
        <div class="form-container">

            <div class="form-group">
                <label for="name">Name:</label>
                <input type="text" id="nameTex" name="name" runat="server" class="form-control" placeholder="Enter item name">
            </div>

            <div class="form-group">
                <label for="number">Number of items in warehouse:</label>
                <input type="number" id="numberTex" name="number" runat="server" class="form-control" placeholder="Enter the number of items in warehouse">
            </div>


            <div class="form-group">
                <asp:Button runat="server" OnClick="RunBtn_Click" ID="RunBtn" class="btn-primary" Text="Add new item" />
            </div>

        </div>
    </div>

    <asp:GridView ID="ItemsGv" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" runat="server">
    <Columns>
        <asp:BoundField HeaderText="Item ID" DataField="ItemId" ReadOnly="false" />
        <asp:BoundField HeaderText="Item name" DataField="ItemName" ReadOnly="false" />
        <asp:BoundField HeaderText="Item number at warehouse" DataField="Count" ReadOnly="false" />
    </Columns>

</asp:GridView>
</asp:Content>
