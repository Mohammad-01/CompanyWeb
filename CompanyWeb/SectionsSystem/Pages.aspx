<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pages.aspx.cs" Inherits="CompanyWeb.SectionsSystem.Pages" %>

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
    <h3 id="Contact">Add page</h3>

    <div class="container">
        <div class="form-container">
            <div class="container">
                <div class="form-container">

                    <div class="form-group">
                        <label for="PageWebname ">Page web name :</label>
                        <textarea id="PageWebnameTex" name="PageWeb" class="form-control" runat="server" rows="1" placeholder="Enter the page web name "></textarea>
                    </div>

                    <div class="form-group">
                        <label for="PageWeb ">Page web:</label>
                        <textarea id="PageWebTex" name="PageWeb" class="form-control" runat="server" rows="1" placeholder="Enter the page web "></textarea>
                    </div>

                    <div class="form-group">
                        <label for="Page url ">Page URL:</label>
                        <textarea id="UrlTex" name="UrlTex" class="form-control" runat="server" rows="3" placeholder="Enter the page url "></textarea>
                    </div>

                    <div class="form-group">
                        <label for="Page Order ">Page Order:</label>
                        <textarea id="OrderTex" name="OrderTex" TextMode="Number" class="form-control" runat="server" rows="1" placeholder="Enter the page order "></textarea>
                        <asp:RegularExpressionValidator ID="OrderTexValidator" runat="server" ControlToValidate="OrderTex"
                        ErrorMessage="Page Order must be an integer." ValidationExpression="^\d+$" Display="Dynamic" />
                    </div>


                    <label for="Sec ">Section :</label>
                    <asp:DropDownList ID="DDL" runat="server" CssClass="form-control">
                    </asp:DropDownList>

                    <div class="form-group">
                        <asp:Button runat="server" ID="RunBtn" class="btn-primary" Text="Add" OnClick="RunBtn_Click" />
                    </div>


                    <div class="form-group">
                        <asp:Label ID="errorLab" ForeColor="Red" runat="server"></asp:Label>
                    </div>

                 </div>
              </div>
          </div>
      </div>

     <asp:GridView ID="PageGV" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" runat="server">
     <Columns>
         <asp:BoundField HeaderText="ID" DataField="PageId" ReadOnly="false" />
         <asp:BoundField HeaderText="Name" DataField="PageName" ReadOnly="false" />
         <asp:BoundField HeaderText="PageWeb" DataField="PageWeb" ReadOnly="false" />
         <asp:BoundField HeaderText="Page Url" DataField="PageUrl" ReadOnly="false" />
         <asp:BoundField HeaderText="Page Order" DataField="PageOrder" ReadOnly="false" />
     </Columns>

 </asp:GridView>

</asp:Content>
