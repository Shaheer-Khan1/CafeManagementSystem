<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffManagement.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.StaffManagement" %>

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
            background-image: url('MainBg.jpg');
            background-size: cover;
            background-position: center;
        }

        #logo {
            max-height: 100%;
            width: auto;
        }

        #buttons-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            margin-top: 20px;
        }

        .button-style {
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img id="logo" src="logo.jpg" alt="Logo" />
        </div>
        <div id="buttons-container">
            <asp:Button ID="VStaff" runat="server" Text="View Staff" CssClass="button-style" OnClick="VStaff_Click" />
            <asp:Button ID="Hire" runat="server" Text="Hire Staff" CssClass="button-style" OnClick="Hire_Click" />
            <asp:Button ID="tStaff" runat="server" Text="Train Staff" CssClass="button-style" OnClick="tStaff_Click" />
            <asp:Button ID="SchedStaff" runat="server" Text="Schedule Staff" CssClass="button-style" OnClick="SchedStaff_Click" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go Back" CssClass="button-style" />

        </div>
    </form>
</body>
</html>
