<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CafeManager.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.CafeManager" %>

<!DOCTYPE html>

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
        }

        .btn:hover {
            background-color: #fee456; 
            color: #333333; 
        }

        
        #Others,
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

        #Others:hover,
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
            <h1>Hello Cafe Manager</h1>
        </div>

        <div class="button-container">
            <asp:Button ID="MenuM" runat="server" OnClick="Button1_Click" Text="Menu Management" CssClass="btn" />
            <asp:Button ID="StaffM" runat="server" Text="Staff Management" CssClass="btn" OnClick="StaffM_Click" />
            <asp:Button ID="InventoryM" runat="server" Text="Inventory Management" CssClass="btn" OnClick="InventoryM_Click" />
            <asp:Button ID="FinancialM" runat="server" Text="Financial Management" CssClass="btn" OnClick="FinancialM_Click" />
            <asp:Button ID="VFeedback" runat="server" Text="View Feedback" CssClass="btn" OnClick="VFeedback_Click" />
            <asp:Button ID="Others" runat="server" OnClick="Button2_Click" Text="Other Options" />
            <asp:Button ID="Audit" runat="server" OnClick="Audit_Click" Text="Show Audit" CssClass = "btn" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Log Out" />
        </div>
    </form>
</body>
</html>
