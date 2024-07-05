<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CompanyWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #aspnetTitle {
             color: #d6191f; 
             height: 100%;
             margin: 0;
             display: flex;
             justify-content: center;
             align-items: center;
             font-size: larger;
        }
        
        #title {
             color: #d6191f; 
             height: 100%;
             margin: 0;
             display: flex;
             justify-content: center;
             align-items: center;
             font-size: larger;
        }

        body {
             background-image: url('Files/new.jpg');
        }

    </style>

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Welcome to RJ website</h1>
            <p id="title">SEE THE WORLD</p>

        </section>



    </main>

</asp:Content>
