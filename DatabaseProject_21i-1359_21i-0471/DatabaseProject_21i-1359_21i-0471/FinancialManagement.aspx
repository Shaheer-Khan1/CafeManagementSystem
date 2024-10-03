<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinancialManagement.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.FinancialManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
    body {
        background-image: url('MainBg.jpg');
        background-size: cover;
        margin: 0;
        padding: 0;
        font-family: Arial, sans-serif;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
    }

    #container {
        text-align: center;
    }

    #logo {
        width: 200px;
        margin-top: 20px;
    }

    .grid-view {
        margin-top: 10px;
        margin-bottom: 10px;
        padding: 10px;
        border: 1px solid #ccc;
        border-radius: 3px;
        color: black;
        width: 168px;
        background-color: white; 
    }
#Button1 {
    margin-top: 10px;
    margin-bottom: 10px;
    padding: 10px 20px;
    font-size: 16px;
    border-radius: 5px;
    background-color: black;
    color: white;
    border: none;
    cursor: pointer;
    transition: background-color 0.3s ease, color 0.3s ease;
}

#Button1:hover {
    background-color: #fee456;
    color: black;
}

</style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <img id="logo" src="logo.jpg" alt="Logo">
            <asp:Panel ID="Panel1" runat="server" style="margin-top: 20px;">
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="grid-view">
                </asp:GridView>
            </asp:Panel>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go Back" CssClass="button" />

        </p>
    </form>
</body>
</html>
