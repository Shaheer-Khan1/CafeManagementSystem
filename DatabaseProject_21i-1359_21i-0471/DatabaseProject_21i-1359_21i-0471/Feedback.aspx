<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedbackaspx.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.Feedbakcaspx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Feedback Form</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            background-image: url('FeedbackBG.jpg'); 
        }

        .container {
            width: 60%;
            margin: 0 auto;
            padding: 20px;
            background-color: lightyellow;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin-top: 50px;
        }

        h1 {
            text-align: center;
        }

        #form1 {
            text-align: center;
        }

        #txtFeedback {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
        }

        #btnSubmit {
            padding: 10px 20px;
            background-color: #000;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        #btnSubmit:hover {
            background-color: #ff0;
            color: black;
        }

        #lblMessage {
            display: block;
            margin-top: 10px;
            text-align: center;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>Feedback Form</h1>
        <form id="form1" runat="server">
            <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" Rows="4" Columns="50" placeholder="Enter your feedback here"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Feedback" OnClick="btnSubmit_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" Visible="false" ForeColor="Green"></asp:Label>
        </form>
    </div>
</body>
</html>

