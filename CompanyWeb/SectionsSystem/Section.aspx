<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Section.aspx.cs" Inherits="CompanyWeb.SectionsSystem.Section" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .form-container {
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 20px;
        }
    </style>

    <h3>Add Section</h3>

    <div class="container">
        <div class="form-container">

            <label for="name">Name:</label>
            <input type="text" id="nameTex" name="name" runat="server" class="form-control" placeholder="Enter section name">
            <label for="Section Order ">Section Order:</label>
            <textarea id="OrderTex" name="OrderTex" textmode="Number" class="form-control" runat="server" rows="1" placeholder="Enter the page order "></textarea>
            <asp:Button runat="server" ID="RunBtn" class="btn-primary" Text="Add" OnClick="RunBtn_Click" />
            <asp:RegularExpressionValidator ID="OrderTexValidator" runat="server" ControlToValidate="OrderTex"
                ErrorMessage="Page Order must be an integer." ValidationExpression="^\d+$" Display="Dynamic" />

        </div>


    </div>


    <asp:GridView ID="SectionGV" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" runat="server">
        <Columns>
            <asp:BoundField HeaderText="SectionId" DataField="SectionId" ReadOnly="false" />
            <asp:BoundField HeaderText="SectionName" DataField="SectionName" ReadOnly="false" />
            <asp:BoundField HeaderText="SectionOrder" DataField="SectionOrder" ReadOnly="false" />

        </Columns>

    </asp:GridView>

    <div>

        <asp:Button ID="Pages" runat="server" Text="Add new page"
            PostBackUrl="~/SectionsSystem/Pages.aspx" />

        <asp:Button ID="Users" runat="server" Text="Add new user"
            PostBackUrl="~/SectionsSystem/Users.aspx" />
    </div>

</asp:Content>
