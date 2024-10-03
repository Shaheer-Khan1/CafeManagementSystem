<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryManagement.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.InventoryManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: flex-start;
            height: 100vh;
            background-color: white;
            background-size: cover;
            background-position: center;
            background-color: #fee456; 

        .text-box-style {
        padding: 8px;
        border-radius: 5px;
        border: 1px solid #ccc; 
        background-size: cover;
        background-position: center;
        color: black; 
        }

        .gridview-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            background-color: #222222;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            color: white;
            margin-top: 20px; 
        }

        .button-style {
            margin-top: 10px;
            margin-bottom: 10px;
            padding: 10px 20px;
            font-size: 16px;
            border-radius: 5px;
            background-color: black;
            color: white;
            border: none;
            cursor: pointer;
        }

        .button-style:hover {
            background-color: #fee456;
            color: black;
        }

        .gridview-style {
            border-collapse: collapse;
            width: 100%;
            margin-bottom: 20px;
            border: 1px solid #fff; 
            color: white;
        }

        .gridview-style th,
        .gridview-style td {
            padding: 8px;
            text-align: left;
            border: 1px solid #fff;
        }

        .gridview-style th {
            background-color: #222222;
        }

        .gridview-style tr:nth-child(even) {
            background-color: #444444; 
        }

        .gridview-style tr:nth-child(odd) {
            background-color: #333333; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="gridview-container">
            <asp:GridView ID="GridView1" runat="server" CssClass="gridview-style"></asp:GridView>
            <asp:TextBox ID="IngredientID" runat="server" CssClass="text-box-style" placeholder="Ingredient ID"></asp:TextBox>
            <asp:TextBox ID="IngredientName" runat="server" CssClass="text-box-style" placeholder="Ingredient Name"></asp:TextBox>
            <asp:Button ID="Update" runat="server" OnClick="Update_Click" Text="Edit" CssClass="button-style" />
            <asp:TextBox ID="IngIDtoDLT" runat="server" CssClass="text-box-style" placeholder="Ingredient ID"></asp:TextBox>
            <asp:Button ID="Delete" runat="server" OnClick="Delete_Click" Text="Remove" CssClass="button-style" />
            <asp:TextBox ID="ItemNameToAdd" runat="server" CssClass="text-box-style" placeholder="Ingredient Name"></asp:TextBox>
            <asp:Button ID="Add" runat="server" OnClick="Add_Click" Text="Insert" CssClass="button-style" />
        </div>
    </form>
</body>
</html>
