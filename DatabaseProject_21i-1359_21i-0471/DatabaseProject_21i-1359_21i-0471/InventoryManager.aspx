<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryManager.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.InventoryManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inventory Management</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            background-image: url('MainBG.jpg'); 
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
        }

        .btn:hover {
            background-color: #fee456; 
            color: #333333; 
        }

        
        #Button1 {
            width: 200px;
            margin-bottom: 10px;
            padding: 10px;
            border: none;
            border-radius: 5px;
            background-color: #333333; 
            color: #fee456; 
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        #Button1:hover {
            background-color: #fee456; 
            color: #333333; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="logo-container">
            <img id="logo" src="logo.jpg" alt="Logo" />
        </div>

        <div id="header">
            <h1>Hello Inventory Manager</h1>
        </div>

        <div class="button-container">
            <asp:Button ID="Button1" runat="server" Text="Menu Management" CssClass="btn" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Inventory Management" CssClass="btn" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Log Out" CssClass="btn" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
