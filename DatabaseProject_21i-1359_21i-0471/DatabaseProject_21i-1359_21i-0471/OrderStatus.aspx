<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderStatus.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.OrderStatus" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Status</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 800px;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align: center;
            margin-bottom: 20px;
            color: #333;
        }
        #logo {
            display: block;
            margin: 0 auto;
            max-width: 200px;
        }
        .button {
            display: block;
            width: 150px;
            padding: 10px;
            text-align: center;
            margin: 20px auto;
            text-decoration: none;
            color: white;
            background-color: black;
            border-radius: 5px;
            transition: background-color 0.3s;
        }
        .button:hover {
            background-color: #fee456;
            color: black;
        }
        .message {
            text-align: center;
            margin-top: 20px;
            color: #888;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <img id="logo" src="logo.jpg" alt="Company Logo" />
            <h1>Order Status</h1>
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <p class="message">We appreciate your patience.</p>
            <a href="Customer.aspx" class="button" title="Go back to Customer Page">Back to Main Page</a>
        </div>
    </form>
</body>
</html>
