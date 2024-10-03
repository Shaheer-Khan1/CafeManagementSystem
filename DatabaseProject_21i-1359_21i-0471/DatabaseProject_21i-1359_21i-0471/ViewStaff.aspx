<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStaff.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.ViewStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            text-align: center;
        }

        #header {
            background-color: #333;
            color: #fff;
            padding: 20px 0;
        }

        #logo {
            max-height: 100px;
            width: auto;
            display: block;
            margin: 0 auto;
        }

        #footer {
            position: fixed;
            bottom: 0;
            width: 100%;
            background-color: #222;
            color: #fff;
            padding: 10px 0;
        }

        #goBackButton {
            color: #fff;
            text-decoration: none;
            padding: 8px 20px;
            border-radius: 5px;
            background-color: #444;
            transition: background-color 0.3s ease;
        }

        #goBackButton:hover {
            background-color: yellow;
            color: black;
        }

.grid-view {
    text-align: center;
    border-collapse: collapse;
    width: 80%; /* Adjust width as needed */
    margin: 0 auto;
}

.grid-view th {
    background-color: #333;
    color: #fff;
    padding: 8px;
}

.grid-view td {
    padding: 8px;
}

.grid-view tr:nth-child(even) {
    background-color: #f2f2f2;
}

.grid-view tr:hover {
    background-color: #ddd;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <img id="logo" src="logo.jpg" alt="Logo">
        </div>
        <div>
            <asp:Panel ID="Panel1" runat="server" style="margin: 20px auto;">
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="grid-view">
                </asp:GridView>
            </asp:Panel>
        </div>
        <div id="footer">
            <a href="StaffManagement.aspx" id="goBackButton">Go Back</a>
        </div>
    </form>
</body>
</html>
