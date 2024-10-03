<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fullfill.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.Fullfill" %>

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
        }

        .text-box-style {
            padding: 8px;
            border-radius: 5px;
            border: 1px solid #ccc; 
            background-size: cover;
            background-position: center;
            color: black; 
            margin-top: 10px;
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
            <asp:TextBox ID="ID" runat="server" CssClass="text-box-style"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Fulfill" CssClass="button-style" />
        </div>
    </form>
</body>
</html>
