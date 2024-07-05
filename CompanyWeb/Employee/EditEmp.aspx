<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmp.aspx.cs" Inherits="CompanyWeb.EditEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .form-container {
            border: 1px solid #ccc;
            border-radius: 5px;OnClick="EmpBtn_Click"
            padding: 20px;
            background-color: white;
        }

        body {
            background-image: url('Files/roya.jpg');
        }
    </style>
    <h3 id="Contact">Edit Employee Information</h3>

    <div class="container">
        <div class="form-container">

            <div class="form-group">
                <label for="Id">Enter the ID of employee that you need to do edit on the info:</label>
                <input type="text" id="EmpId" name="name" runat="server" class="form-control">
                <asp:Button runat="server" ID="EmpBtn" Text="Get Employee"  />
            </div>

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
                        <asp:Button runat="server" OnClick="RunBtn_Click" ID="RunBtn" class="btn-primary" Text="Edit employee information" />
                    </div>


                    <div class="form-group">
                        <asp:Label ID="errorLab" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
</asp:Content>
