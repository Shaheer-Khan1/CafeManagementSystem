<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OtherDetails.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.OtherDetails" %>

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
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="gridview-container">
            <asp:GridView ID="GridView1" runat="server" CssClass="gridview-style"></asp:GridView>
            <asp:GridView ID="GridView2" runat="server" CssClass="gridview-style"></asp:GridView>
            <asp:GridView ID="GridView4" runat="server" CssClass="gridview-style"></asp:GridView>
            <asp:GridView ID="GridView3" runat="server" CssClass="gridview-style"></asp:GridView>
            
        </div>
    </form>
</body>
</html>
