<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReqItems.aspx.cs" Inherits="CompanyWeb.CompanyItems.ReqItems" %>

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

        .form-group {
            display: flex;
            flex-direction: row;
            align-items: baseline;
            align-content: space-between;
            flex-wrap: nowrap;
        }
    </style>

    <h3>Request Items</h3>

    <div class="container">
            <div class="form-container">

                
                <label for="EmpId">Employee ID:</label>
                <div class="form-group">
                    <asp:TextBox ID="EmpIdTex" runat="server" CssClass="form-control" placeholder="Enter the employee ID" OnTextChanged="EmpIdTex_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:TextBox ID="EmpNameTex" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <label for="ddlItems">Select the item:</label>
                <asp:DropDownList ID="ddlItems" runat="server" CssClass="form-control">
                </asp:DropDownList>


                <div class="formgroup">
                    <label for="SerialNo">Serial number of item:</label>
                    <input type="text" id="SerialNoTex" name="SerialNo" runat="server" class="form-control" placeholder="Enter the serial number of the item">
                </div>

            
                <div class="formgroup">
                    <label for="Count">The request number of item:</label>
                    <input type="number" id="CountTex" name="Count" runat="server" class="form-control" placeholder="Enter the number of items that request">
                </div>

                <div class="formgroup">
                    <asp:Button runat="server" OnClick="RunBtn_Click" ID="RunBtn" class="btn-primary" Text="Add new item" />
                </div>

        </div>
    </div>

</asp:Content>
