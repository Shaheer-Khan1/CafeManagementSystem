<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Easypaisa.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.Easypaisa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Easypaisa Payment</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-color: #f4f4f4;
        }
        .container {
            text-align: center;
        }
        .input-group {
            margin-bottom: 20px;
        }
        .input-group label {
            display: block;
            margin-bottom: 5px;
        }
        .input-group input {
            padding: 8px;
            width: 250px;
            border-radius: 5px;
            border: 1px solid #ccc;
        }
        .btn {
            padding: 10px 20px;
            border: none;
            background-color: #007bff;
            color: white;
            border-radius: 5px;
            cursor: pointer;
        }
        .btn:hover {
            background-color: #0056b3;
        }
    </style>
    <script>
        function simulatePayment() {
            var easypaisaAccount = document.getElementById('easypaisaAccount').value;
            var otp = document.getElementById('otp').value;


            if (easypaisaAccount && otp) {

                document.getElementById('paymentStatus').innerHTML = 'Payment received. Thank you!';

                setTimeout(function() {
                    window.location.href = 'Confirmed.aspx';
                }, 10000); 
            } else {
                alert('Please fill in both Easypaisa account and OTP.');
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Easypaisa Payment</h2>
            <div class="input-group">
                <label for="easypaisaAccount">Easypaisa Account:</label>
                <input type="text" id="easypaisaAccount" placeholder="Enter Easypaisa Account" />
            </div>
            <div class="input-group">
                <label for="otp">OTP:</label>
                <input type="text" id="otp" placeholder="Enter OTP" />
            </div>
            <button type="button" class="btn" onclick="simulatePayment()">Submit</button>
            <p id="paymentStatus"></p>
        </div>
    </form>
</body>
</html>
