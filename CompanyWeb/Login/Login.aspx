<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CompanyWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RJ Login</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .container {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 300px;
        }

            .container h2 {
                text-align: center;
                margin-bottom: 20px;
            }

        .form-group {
            margin-bottom: 20px;
        }

            .form-group label {
                display: block;
                margin-bottom: 5px;
            }

            .form-group input {
                width: 100%;
                padding: 10px;
                border: 1px solid #ccc;
                border-radius: 5px;
                box-sizing: border-box;
            }

            .form-group button {
                width: 100%;
                padding: 10px;
                border: none;
                background-color: #007bff;
                color: #fff;
                border-radius: 5px;
                cursor: pointer;
            }

                .form-group button:hover {
                    background-color: #0056b3;
                }

        #video-background {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            z-index: -1;
            overflow: hidden;
        }

        #video-content {
            position: relative;
            z-index: 1;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .video-container {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            overflow: hidden;
            z-index: -1;
        }

        video {
            min-width: 100%;
            min-height: 100%;
            width: auto;
            height: auto;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }


    </style>

</head>


<body>
    <link rel="icon" href="~/Files/icon.png" type="image/x-icon" />
    <form id="form1" runat="server">

   
        
        <div class="container">
            <h2>Login page</h2>

            <div class="form-group">
                <label for="username">Username:</label>
                <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control" Required="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="password">Password:</label>
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="form-control" Required="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button ID="LoginButton" runat="server" Text="Submit" OnClick="LoginButton_Click" CssClass="btn btn-primary" />
            </div>

            <div class="form-group">
                <asp:HyperLink ID="ForgotPasswordLink" runat="server" Text="Forgot Password?" NavigateUrl="~/Login/ForgetPassword.aspx" />
            </div>

            <div class="form-group">
                <asp:HyperLink ID="Regest" runat="server" Text="Regest new account" NavigateUrl="~/Login/Regest.aspx" />
            </div>

            <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>

</body>
</html>
