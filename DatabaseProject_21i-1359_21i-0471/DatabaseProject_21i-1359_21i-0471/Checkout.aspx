<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
  <style>
    body {
        font-family: Arial, sans-serif;
        background-color: #f4f4f4;
        margin: 0;
        padding: 0;
    }

    #form1 {
        max-width: 600px;
        margin: 20px auto;
        padding: 20px;
        background-color: #fff;
        border-radius: 8px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    h2 {
        color: #333;
        margin-bottom: 10px;
    }

    label {
        display: inline-block;
        width: 150px; 
        margin-bottom: 5px;
    }

    input[type="text"],
    input[type="radio"] {
        width: calc(100% - 170px); 
        padding: 8px;
        margin-bottom: 15px;
        border: 1px solid #ccc;
        border-radius: 4px;
        transition: border-color 0.3s ease, box-shadow 0.3s ease;
    }

    input[type="text"]:hover,
    input[type="text"]:focus,
    input[type="radio"]:hover,
    input[type="radio"]:focus {
        border-color: #888;
        box-shadow: 0 0 5px rgba(0, 0, 0, 0.3);
    }

    #btnSubmit {
        padding: 10px 20px;
        color: white;
            background-color: black;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    #btnSubmit:hover {
            background-color: #fee456;
            color: black;
    }

    .logo {
        display: block;
        margin: 0 auto;
        max-width: 200px;
       
    }

    input[type="radio"] {
        margin-bottom: 10px; 
    }
</style>


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img src="logo.jpg" alt="Logo" class="logo" /> 

            <h2>Checkout Information</h2>
            <label for="city">City:</label>
            <input type="text" id="city" runat="server" />

            <label for="sector">Sector:</label>
            <input type="text" id="sector" runat="server" />

            <label for="streetNo">Street Number:</label>
            <input type="text" id="streetNo" runat="server" />

            <label for="houseNo">House Number:</label>
            <input type="text" id="houseNo" runat="server" />

            <label for="phoneNo">Phone Number:</label>
            <input type="text" id="phoneNo" runat="server" /><label for="phoneNo">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </label>
&nbsp;<h2>Payment Options</h2>
            <input type="radio" id="cashOnDelivery" name="payment" value="Cash On Delivery" runat="server" />
            <label for="cashOnDelivery">Cash On Delivery</label><br>

            <input type="radio" id="easypaisa" name="payment" value="Easypaisa" runat="server" />
            <label for="easypaisa">Easypaisa</label><br>

            <input type="radio" id="debitCard" name="payment" value="Debit Card" runat="server" />
            <label for="debitCard">Debit Card</label><br>

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

                <script>
        function Validation() {

            alert('Please Enter All Details');
        }
                </script>
        </div>
    </form>
</body>
</html>
