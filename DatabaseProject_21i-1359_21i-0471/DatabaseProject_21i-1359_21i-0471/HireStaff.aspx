<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HireStaff.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.HireStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            text-align: center;
            background-color: #f2f2f2;
            font-family: Arial, sans-serif;
        }

        #form1 {
            margin: 0 auto;
            width: 50%;
            padding-top: 20px;
        }

        #logo {
            max-width: 150px;
            display: block;
            margin: 0 auto;
        }

        #Panel1 {
            margin-top: 30px;
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        #Panel1 input[type="text"], 
        #Panel1 input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
        }

        #Hire {
            width: 100%;
            padding: 10px;
            border: none;
            border-radius: 5px;
            background-color: black;
            color: white;
            cursor: pointer;
            transition: background-color 0.3s ease; 
        }
            #Hire:hover {
                background-color: yellow;
                color: black;
            }

                    #Button1 {
            width: 50%;
            padding: 10px;
            border: none;
            border-radius: 5px;
            margin-top: 100px;
            background-color: black;
            color: white;
            cursor: pointer;
            transition: background-color 0.3s ease; 
        }
            #Button1:hover {
                background-color: yellow;
                color: black;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <img src="logo.jpg" alt="Logo" id="logo">

        <asp:Panel ID="Panel1" runat="server">
            <asp:TextBox ID="UserName" runat="server" placeholder="Enter username"></asp:TextBox>
            <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="Enter password"></asp:TextBox>
            <asp:TextBox ID="Pay" runat="server" placeholder="Enter pay"></asp:TextBox>
            <asp:TextBox ID="SchedStart" runat="server" placeholder="Enter start schedule"></asp:TextBox>
            <asp:TextBox ID="SchedEnd" runat="server" placeholder="Enter end schedule"></asp:TextBox>
            <asp:TextBox ID="TrainingStatus" runat="server" placeholder="Enter training status"></asp:TextBox>
            <br />
            <asp:TextBox ID="UserType" runat="server" placeholder="Enter user type"></asp:TextBox>
            <asp:Button ID="Hire" runat="server" Text="Hire Employee" OnClick="Hire_Click" />
        </asp:Panel>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go Back" />
    </form>
</body>
</html>
