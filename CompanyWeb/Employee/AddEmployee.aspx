<%@ Page Title="Add Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="CompanyWeb.Page.AddEmployee" %>

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
    <h3>Add Employee</h3>

    <div class="container">
        <div class="form-container">
            <div class="form-group">
                <label for="name">Name:</label>
                <input type="text" id="nameTex" name="name" runat="server" class="form-control" placeholder="Enter your name">
            </div>

            <div class="form-group">
                <label for="dob">Date of Birth:</label>
                <input type="date" id="dobTex" name="dob" runat="server" class="form-control">
            </div>
            <div class="form-group">
                <label for="start_date">Start Date:</label>
                <input type="date" id="start_dateTex" name="start_date" runat="server" class="form-control">
            </div>

            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control">
            </asp:DropDownList>

            <h5 id="Contact">Contact Informations</h5>

            <div class="form-group">
                <label for="phone_number">Phone Number:</label>
                <input type="tel" id="phone_numberTex" name="phone_number" class="form-control" runat="server" placeholder="00962*********">
            </div>
            <div class="form-group">
                <label for="alt_number">Alternative Number:</label>
                <input type="tel" id="alt_numberTex" name="alt_number" class="form-control" runat="server" placeholder="00962*********">
            </div>

            <div class="form-group">
                <label for="email">Email:</label>
                <input type="email" id="emailTex" name="email" runat="server" class="form-control" placeholder="Enter your email">
            </div>

            <div class="form-group">
                <label for="address">Address:</label>
                <textarea id="addressTex" name="address" class="form-control" runat="server" rows="4"></textarea>
            </div>
            <div class="form-group">
                <asp:Button runat="server" OnClick="RunBtn_Click" ID="RunBtn" class="btn-primary" Text="Add new employee" />
            </div>
        </div>
    </div>
</asp:Content>


