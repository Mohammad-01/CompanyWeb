<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CompanyWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h3 id="Contact">Contact info</h3>

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




        <div class="container">
            <div class="form-container">
                <asp:GridView ID="EmpGv" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" runat="server">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="EmpId" ReadOnly="false" />
                        <asp:BoundField HeaderText="Name" DataField="EmpName" ReadOnly="false" />
                        <asp:BoundField HeaderText="Department Name" DataField="DeptName" ReadOnly="false" />
                        <asp:BoundField HeaderText="Date Of Birth" DataField="DOB" ReadOnly="false" />
                        <asp:BoundField HeaderText="Start Date" DataField="StartDate" ReadOnly="false" />
                        <asp:BoundField HeaderText="Phone number" DataField="PhoneNumber" ReadOnly="false" />
                        <asp:BoundField HeaderText="Alternative Number" DataField="AlternativePhoneNumber" ReadOnly="false" />
                        <asp:BoundField HeaderText="Email" DataField="Email" ReadOnly="false" />
                        <asp:BoundField HeaderText="Address" DataField="Address" ReadOnly="false" />

                    </Columns>

                </asp:GridView>
                <asp:Button ID="btnGoToAnotherPage" runat="server" Text="Add new employee" PostBackUrl="~/Employee/AddEmployee.aspx" />

            </div>
        </div>
</asp:Content>

