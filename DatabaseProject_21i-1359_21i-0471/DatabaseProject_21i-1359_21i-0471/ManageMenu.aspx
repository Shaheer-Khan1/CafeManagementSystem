<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageMenu.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.ManageMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Menu</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: white; 
            background-size: cover;
            background-position: center;
            margin: 0;
            padding: 0;
        }

        #header {
            text-align: center;
            padding: 20px;
        }

        #logo {
            max-width: 100%;
            height: auto;
            margin-bottom: 20px;
        }

        form {
            display: flex;
            flex-direction: column;
            align-items: center;
            padding: 20px;
            color: white;
        }

        #form1 {
background-color: #222222; 
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        input[type="text"],
        input[type="submit"] {
            width: 80%;
            margin: 5px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            color: white;
        }



        input[type="text"]::placeholder {
            color: #999999; 
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
    </style>
</head>
<body>
    <div id="header">
        <img id="logo" src="logo.jpg" alt="Logo" />
    </div>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
        <asp:TextBox ID="ItemID" runat="server" placeholder="Enter Item ID"></asp:TextBox>
        <asp:TextBox ID="ItemName" runat="server" placeholder="Enter Item Name"></asp:TextBox>
        <asp:TextBox ID="CategoryID" runat="server" placeholder="Enter Category ID"></asp:TextBox>
        <asp:TextBox ID="Price" runat="server" placeholder="Enter Price"></asp:TextBox>
        <asp:TextBox ID="AvailabilityStatus" runat="server" placeholder="Enter Availability Status"></asp:TextBox>
         <asp:Button ID="Update" runat="server" OnClick="Update_Click" Text="Update" CssClass="btn" />
        <asp:Button ID="GoBack" runat="server" OnClick="GoBack_Click" Text="Go Back" CssClass="btn" />
    </form>
</body>
</html>
