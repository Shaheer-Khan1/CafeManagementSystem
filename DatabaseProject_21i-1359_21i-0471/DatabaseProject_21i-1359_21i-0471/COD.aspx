<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="COD.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.COD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Upon Arrival</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .content {
            text-align: center;
            background-color: #fff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            color: #333;
        }
        p {
            color: #666;
        }
        .confirm-button {
            padding: 10px 20px;
            font-size: 16px;
            border: none;
            border-radius: 5px;
            color: white;
            background-color: black;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        .confirm-button:hover {
            background-color: #fee456;
            color: black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <h1>Payment Upon Arrival</h1>
            <p>Our rider will collect payment from you upon arrival.</p>
            <asp:Button ID="confirmButton" runat="server" Text="Confirm Order" OnClick="confirmOrder" CssClass="confirm-button" />

        </div>
    </form>

</body>
</html>
