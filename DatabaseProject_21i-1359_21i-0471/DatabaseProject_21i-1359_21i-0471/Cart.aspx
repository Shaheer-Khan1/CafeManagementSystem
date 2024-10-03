<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Cart</title>
    <style>

        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }

        .header {
            text-align: center;
            margin-bottom: 20px;
        }

        .grid-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-bottom: 10px;
        }

        .textbox-container,
        .button-container {
            margin-bottom: 10px;
            height: 29px;
            width: 200px;
            text-align: center;
            padding: 5px;
            border: 1px solid #ccc;
            transition: background-color 0.3s ease;
        }

        .textbox-container:hover,
        .button-container:hover {
            background-color: #e0e0e0;
        }

        .textbox-container:focus,
        .button-container:focus {
            outline: none;
            background-color: #d3d3d3;
        }

        .button-container {
            cursor: pointer;
            background-color: black;
            color: white;
            border: none;
        }

        .button-container:hover {
            background-color: #fee456;
            color: black;
        }

        .checkout-button {
             background-color: black;
            color: white;
        }

        .checkout-button:hover {
            background-color: #fee456;
            color: black;
        }


        #GridView1 {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        #GridView1 th,
        #GridView1 td {
            padding: 8px;
            text-align: center;
        }

        #GridView1 th {
            background-color: #333;
            color: #fff;
        }

        #GridView1 tr:nth-child(even) {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <img src="logo.jpg" alt="Logo" width="150" height="100" />
        </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <div class="grid-container">
            <asp:TextBox ID="ItemIDtoRemove" runat="server" CssClass="textbox-container" OnTextChanged="ItemID_TextChanged" placeholder="CartItemID"></asp:TextBox>
            <asp:Button ID="Remove" runat="server" Text="Remove" CssClass="button-container" OnClick="Button2_Click" />
        </div>
        <div class="grid-container">
            <asp:TextBox ID="ItemToEdit" runat="server" CssClass="textbox-container" OnTextChanged="TextBox1_TextChanged" placeholder="CartItemID"></asp:TextBox>
            <asp:TextBox ID="Quantity" runat="server" CssClass="textbox-container" OnTextChanged="Quantity_TextChanged" placeholder="Quantity"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" CssClass="button-container" />
        </div>
        <div class="grid-container">
<a href="Checkout.aspx" class="button-container checkout-button">Proceed to Checkout</a>
        </div>
    </form>
</body>
</html>
