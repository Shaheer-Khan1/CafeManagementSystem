<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Steak.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.Steak" %>

<head runat="server">
    <title></title>
    <style>
        body {
            background-image: url('SteakBG.jpg');
            background-size: cover;
            font-family: Arial, sans-serif;
            color: #333;
            margin: 0;
            padding: 0;
        }
        
        #form1 {
            width: 800px;
            margin: auto;
            padding: 20px;
            background-color: rgba(255, 255, 255, 0.9);
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
        }

        table {
            width: 100%;
        }

        #logo {
            max-width: 100%;
            height: auto;
            display: block;
            margin: 0 auto;
        }

        #content {
            text-align: center;
            margin-top: 20px;
        }

        #Cart,
        #Checkout,
        #Menu {
            padding: 10px 20px;
            background-color: #ff9900;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin-bottom: 10px;
            margin-right: 10px; 
        }

        #ItemID,
        #Label2 {
            font-weight: bold;
            display: inline-block;
            margin-right: 10px;
        }

        input[type="text"] {
            padding: 8px;
            width: 150px;
            border-radius: 5px;
            border: 1px solid #ccc;
            margin-bottom: 10px;
        }
        #Cart,
        #Checkout,
        #Menu {
            padding: 10px 20px;
            background-color: black;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin-bottom: 10px;
            margin-right: 10px;
            transition: background-color 0.3s ease; 
            color: white;
        }

        #Cart:hover,
        #Checkout:hover,
        #Menu:hover {
            background-color: #fee456; 
            color : black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <img src="logo.jpg" alt="Logo" id="logo" />

        <div id="content">
            <asp:GridView ID="GridView1" runat="server" Height="179px" Width="100%"></asp:GridView>

            <p>
                <asp:Button ID="Menu" runat="server" Text="Back To Menu" OnClick="Menu_Click" />
                <asp:Label ID="ItemID" runat="server" Text="Enter Quantity"></asp:Label>
                <asp:TextBox ID="ItemIdtext" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Enter ItemID"></asp:Label>
                <asp:TextBox ID="QuantityText" runat="server" OnTextChanged="QuantityText_TextChanged"></asp:TextBox>
                <asp:Button ID="Cart" runat="server" OnClick="Cart_Click" Text="Add to Cart" />
                <asp:Button ID="Checkout" runat="server" Text="Checkout" OnClick="Checkout_Click" />

            </p>
        </div>
    </form>
</body>
</html>