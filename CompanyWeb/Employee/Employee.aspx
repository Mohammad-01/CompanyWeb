<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="CompanyWeb.Employee" %>

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

    <h3 id="Contact">Employees</h3>

    <div class="container">
        <div class="form-container">
            <asp:GridView ID="EmpGv" AutoGenerateColumns="false" OnRowCommand="EmpGv_RowCommand" CssClass="table table-striped table-bordered" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="EmpId" ReadOnly="false" />
                    <asp:BoundField HeaderText="Name" DataField="EmpName" ReadOnly="false" />
                    <asp:BoundField HeaderText="Department Name" DataField="DeptName" ReadOnly="false" />
                    <asp:BoundField HeaderText="Date Of Birth" DataField="DOB" ReadOnly="false" />
                    <asp:BoundField HeaderText="Start Date" DataField="StartDate" ReadOnly="false" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button class="btn btn-warning" CommandName="EditEmp" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"EmpId") %>' Text="Edit" runat="server" />
                            <asp:Button class="btn btn-danger" CommandName="DeleteEmp" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"EmpId") %>' Text="Delete" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnGoToAnotherPage" runat="server" Text="Add new employee" PostBackUrl="~/Employee/AddEmployee.aspx" />

        </div>
    </div>

</asp:Content>
