<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFeedback.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.ViewFeedback" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: space-between;
            height: 100vh;
            margin: 0;
            padding: 0;
             background-image: url('FeedbackBG.jpg'); 
            background-size: cover;
        }

        .content {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            margin-top: 50px; 
            color: white;
        }

        #logo {
            width: auto;
            height: 100%;
            margin-bottom: 20px;
        }

        .menu {
            margin-top: 20px;
        }

        .menu-btn {
            display: inline-block;
            padding: 10px 20px;
            background-color: black;
            color: white;
            text-decoration: none;
            border-radius: 5px;
            transition: background-color 0.3s ease;
        }

        .menu-btn:hover {
            background-color: yellow;
            color: black;
        }

        .gridview-table {
        background-color: black;
        color: white; 
        border-radius: 5px; 
        padding: 10px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <img id="logo" src="logo.jpg" alt="Logo">
            <div id="GridViewContainer" style="text-align: center;">
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="gridview-table">
    </asp:GridView>
</div>

        </div>
        <div class="menu">
            <a href="CafeManager.aspx" class="menu-btn">Go Back</a>
        </div>
    </form>
</body>
</html>
