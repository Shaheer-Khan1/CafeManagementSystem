<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CampusBites - Login & Signup</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-image: url('MainBg.jpg');
            background-size: cover;
            background-position: center;
        }
        .CampusBites {
            text-align: center;
            padding: 20px;
            background-color: none;
            margin-top: 1px;
            margin-left: 550px;
            margin-right: 550px;
            color: black; 
        }
        .CampusBites img {
            width: 100%;
            height: auto;
        }
        .sign-up-form {
            margin: 20px auto;
            width: 300px;
            background-color: #333333;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            color: #fee456; 
        }
        .sign-up-form h1 {
            text-align: center;
            color: #fee456; 
        }
        .input-box {
            width: calc(100% - 20px);
            margin-bottom: 10px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            color: #000000; 
        }
        .input-box[type="password"] {
            color: #000000; 
        }
        .signup-btn {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            margin-bottom: 10px;
            padding: 10px;
            border-radius: 3px;
            background-color: #000000;
            color: white;
            cursor: pointer;
            margin-top: 3px;
        }
        .signup-btn:hover {
            background-color: #fee456;

        }
        .response-message {
            color: white; 
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="CampusBites">
            <img src="logo.jpg" alt="Logo" />
        </div>
        <div class="sign-up-form">
            <h1>Sign Up</h1>
            <asp:TextBox runat="server" CssClass="input-box" ID="txtSignupEmail" placeholder="Enter Email" /><br />
           
            <asp:TextBox runat="server" CssClass="input-box" ID="txtSignupPassword" TextMode="Password" placeholder="Enter Password" /><br />
            <asp:CheckBox runat="server" ID="chkAgree" /><span>I agree to the terms and condition.</span><br />
            <asp:Button runat="server" CssClass="signup-btn" Text="Sign Up" OnClick="Signup_Click" Width="302px" /><br />
            <hr />
            <asp:Label runat="server" ID="lblResponse" CssClass="response-message"></asp:Label>

            <p style="color: #ffffff;">Already have an account? <a href='Sign_In.aspx' style="color: #ffffff;">Sign in</a></p>
        </div>
    </form>
</body>
</html>
