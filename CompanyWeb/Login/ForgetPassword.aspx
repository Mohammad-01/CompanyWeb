<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="CompanyWeb.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forget Password</title>
    <style>
        .container {
            width: 400px;
            margin: 50px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 8px;
            background-color: #f9f9f9;
        }

        h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .btn {
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

            .btn:hover {
                background-color: #0056b3;
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

        ِِ
    </style>
</head>
<body>

    <div class="video-container">
        <video autoplay muted loop id="myVideo">
            <source src="Files/Intro.webm" type="video/mp4">
        </video>
    </div>

    <form id="form1" runat="server">
        <div class="container">
            <h2>Forget Password</h2>
            <div class="form-group">
                <asp:Label ID="EmailLabel" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="ResetPasswordButton" runat="server" Text="Reset Password" OnClick="ResetPasswordButton_Click" CssClass="btn btn-primary" />
            </div>
            <asp:Label ID="ResetMessageLabel" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </form>
</body>
</html>
