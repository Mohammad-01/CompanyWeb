<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditDept.aspx.cs" Inherits="CompanyWeb.EditDept" %>

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
    <h3 id="Contact">Edit Department Information</h3>

    <div class="container">
        <div class="form-container">

            <div class="form-group">
                <label for="Id">Enter the ID of department that you need to do edit on the info:</label>
                <input type="text" id="DeptId" name="DeptId" runat="server" class="form-control">
                <asp:Button runat="server" ID="EmpBtn" Text="Get Employee" OnClick="EmpBtn_Click" />
            </div>
        </div>
    </div>

    <div class="container">
        <div class="form-container">
            <div class="form-group">
                <label for="name">Name:</label>
                <input type="text" id="nameTex" name="name" runat="server" class="form-control" placeholder="Enter your name">
            </div>

            <div class="form-group">
                <label for="address">Address:</label>
                <textarea id="addressTex" name="address" class="form-control" runat="server" rows="4" placeholder="Enter the address of department"></textarea>
            </div>


            <div class="form-group">
                <asp:Button runat="server" OnClick="RunBtn_Click" ID="RunBtn" class="btn-primary" Text="Edit Department information" />
            </div>


            <div class="form-group">
                <asp:Label ID="errorLab" ForeColor="Red" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
