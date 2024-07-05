<%@ Page Title="Add Department" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="CompanyWeb.Department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .form-container {
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 20px;
            background-color: white;
        }

        body {
            background-image: url('Files/roya.jpg');
        }
    </style>
    <h3 id="Contact">Add Department</h3>

    <div class="container">
        <div class="form-container">

            <div class="form-group">
                <label for="DeptName">Department Name:</label>
                <input type="text" id="nameTex" name="name" runat="server" class="form-control" placeholder="Enter your name">
            </div>
            <div class="form-group">
                <label for="Address">Address:</label>
                <input type="text" id="addressTex" name="address" runat="server" class="form-control" placeholder="Enter your email">
            </div>

            <div class="form-group">
                <asp:Button runat="server" OnClick="RunBtn_Click" ID="RunBtn" class="btn-primary" Text="Add new department" />
            </div>

        </div>
    </div>

</asp:Content>
