<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Card.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.Card" %>

<!DOCTYPE html>

<head runat="server">
    <title>Card Payment</title>
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
            var cardNumber = document.getElementById('cardNumber').value;
            var expiryMonth = document.getElementById('expiryMonth').value;
            var expiryYear = document.getElementById('expiryYear').value;
            var cvc = document.getElementById('cvc').value;


            if (cardNumber && expiryMonth && expiryYear && cvc) {
               
                if (cvc.length === 3 && parseInt(expiryMonth) >= 1 && parseInt(expiryMonth) <= 12 && parseInt(expiryYear) >= 24 && parseInt(expiryYear) <= 34) {
                    document.getElementById('paymentStatus').innerHTML = 'Payment received. Thank you!';


                    setTimeout(function () {
                        window.location.href = 'Confirmed.aspx';
                    }, 10000); 
                } else {
                    alert('Please enter valid details for CVC, Expiry Month (1-12), and Expiry Year (24-34).');
                }
            } else {
                alert('Please fill in all the card details.');
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Card Payment</h2>
            <div class="input-group">
                <label for="cardNumber">Card Number:</label>
                <input type="text" id="cardNumber" placeholder="Enter Card Number" />
            </div>
            <div class="input-group">
                <label for="expiryMonth">Expiry Month:</label>
                <input type="number" id="expiryMonth" placeholder="MM" min="1" max="12" />
            </div>
            <div class="input-group">
                <label for="expiryYear">Expiry Year:</label>
                <input type="number" id="expiryYear" placeholder="YY" min="24" max="34" />
            </div>
            <div class="input-group">
                <label for="cvc">CVC:</label>
                <input type="text" id="cvc" placeholder="Enter CVC" />
            </div>
            <button type="button" class="btn" onclick="simulatePayment()">Submit</button>
            <p id="paymentStatus"></p>
        </div>
    </form>
</body>
</html>
