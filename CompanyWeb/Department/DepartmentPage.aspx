<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentPage.aspx.cs" Inherits="CompanyWeb.DepartmentPage" %>

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

    <h3 id="Contact">Departments</h3>

    <div class="container">
        <div class="form-container">
            <asp:GridView ID="DeptGV" AutoGenerateColumns="false" OnRowCommand="DeptGv_RowCommand" CssClass="table table-striped table-bordered" runat="server">

                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="DeptId" ReadOnly="false" />
                    <asp:BoundField HeaderText="Name" DataField="DeptName" ReadOnly="false" />
                    <asp:BoundField HeaderText="Address" DataField="Address" ReadOnly="false" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button class="btn btn-warning" CommandName="EditDept" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DeptId") %>' Text="Edit" runat="server" />
                            <asp:Button class="btn btn-danger" CommandName="DeleteDept" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DeptId") %>' Text="Delete" runat="server" /> 
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

            <asp:Button ID="btnGoToAnotherPage" runat="server" Text="Add new department" PostBackUrl="~/Department/Department.aspx" />

        </div>
    </div>

</asp:Content>
