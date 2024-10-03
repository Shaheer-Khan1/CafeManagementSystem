<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cashier.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.Cashier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            background-image: url('CafeManagerBG.jpg');
            background-size: cover;
            background-repeat: no-repeat;
            margin: 0;
            padding: 0;
        }

        #header {
            text-align: center;
            padding: 20px;
            color: #ffd800;
            margin-top: 20px;
        }

        #logo {
            max-width: 100%;
            height: auto;
            margin-bottom: 20px;
            z-index: 1;
        }

        .button-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 20px;
        }

        .btn {
            width: 200px;
            margin-bottom: 10px;
            padding: 10px;
            border: none;
            border-radius: 5px;
            background-color: #333333;
            color: #fee456;
            cursor: pointer;
            transition: background-color 0.3s ease;
            background-color: black;
            color: white;
        }

        .btn:hover {
            background-color: #fee456;
            color: black;
        }

        #LogOut {
            width: 200px;
            margin-bottom: 10px;
            padding: 10px;
            border: none;
            border-radius: 5px;
            background-color: #333333;
            background-color: black;
            color: white;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        #LogOut:hover {
            background-color: #fee456;
            color: black;
        }
    
        #LogOut0 {
            width: 200px;
            margin-bottom: 10px;
            padding: 10px;
            border: none;
            border-radius: 5px;
            background-color: #333333;
            background-color: black;
            color: white;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="logo-container">
            <img id="logo" src="logo.jpg" alt="Logo" />
        </div>

        <div id="header">
            <h1>Hello Cashier</h1>
        </div>

        <div class="button-container">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" CssClass="btn" Text="FullFill Orders" />
            <asp:Button ID="Button1" runat="server" Text="Order Statuses" CssClass="btn" OnClick="Button1_Click" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" CssClass="btn" Text="Other Details" />
            <asp:Button ID="LogOut" runat="server" OnClick="LogOut_Click" Text="Log Out" CssClass="btn" />
        </div>
    </form>
</body>
</html>
