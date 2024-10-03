<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmed.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.Confirmed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Confirmed</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            text-align: center;
        }

        #header {
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }

        #logo {
            max-width: 150px;
            height: auto;
        }

        #confirmationMessage {
            font-size: 24px;
            margin-top: 30px;
        }

        #gridContainer {
            margin: 30px auto;
            width: 80%;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            overflow-x: auto;
        }

        #backButton {
            display: inline-block;
            padding: 10px 20px;
            margin-top: 20px;
            text-decoration: none;
            background-color: #3498db;
            color: #fff;
            border-radius: 5px;
            transition: background-color 0.3s;
        }

        #backButton:hover {
            background-color: #2980b9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <img id="logo" src="logo.jpg" alt="Logo" />
        </div>
        <div id="confirmationMessage">
            Your order has been confirmed!
        </div>
        <div id="gridContainer">
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
        </div>
        <div>
            <asp:Button ID="backButton" runat="server" Text="Back to Customer Page" OnClick="backButton_Click" />
        </div>
    </form>
</body>
</html>