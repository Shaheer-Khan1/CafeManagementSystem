<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Menu Cards</title>
  <style>
    body {
      margin: 0;
      font-family: Arial, sans-serif;
      display: flex;
      flex-direction: column;
      align-items: center;
      height: 100vh; 
      overflow: hidden;
    }

    #video-container {
      position: absolute;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      overflow: hidden;
      z-index: -1;
    }

    video {
      width: 100%;
      height: 100%;
      object-fit: cover;
    }

    .logo {
      height: 100%
      width: auto;
      margin-top: 20px;
    }

    .container {
      display: grid;
      grid-template-columns: repeat(3, 1fr);
      gap: 20px;
      padding: 20px;
      justify-items: center;
    }

    .card {
      position: relative;
      width: 300px;
      height: 200px;
      overflow: hidden;
      border-radius: 10px;
      box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
      transition: transform 0.3s ease-in-out;
    }

    .card img {
      width: 100%;
      height: 100%;
      object-fit: cover;
      border-radius: 10px;
    }

    .card .overlay {
      position: absolute;
      bottom: 0;
      left: 0;
      width: 100%;
      padding: 10px;
      background: rgba(0, 0, 0, 0.6);
      color: white;
      text-align: center;
      font-size: 20px;
      opacity: 0;
      transition: opacity 0.3s ease-in-out;
    }

    .card:hover {
      transform: scale(1.05);
    }

    .card:hover .overlay {
      opacity: 1;
    }

    .top-buttons {
      position: absolute;
      top: 20px;
      right: 20px;
      display: flex;
      gap: 10px;
      z-index: 1; 
    }

    .top-buttons button {
      padding: 10px 15px;
      border: none;
      border-radius: 5px;
      background-color: #333;
      color: white;
      cursor: pointer;
      transition: background-color 0.3s ease;
    }

    .top-buttons button:hover {
      color: black;  
      background-color: #fee456;
    }

  </style>
</head>
<body>
    <div id="video-container">
    <video autoplay muted loop>
      <source src="video.mp4" type="video/mp4">
      Your browser does not support the video tag.
    </video>
  </div>
  <div class="top-buttons">
    <button onclick="location.href='Feedback.aspx'">Feedback</button>
    <button onclick="location.href='Cart.aspx'">View Cart</button>
    <button onclick="location.href='OrderStatus.aspx'">Order Status</button>
  </div>
  <img src="logo.jpg" class="logo" alt="Logo" />
  <div class="container">
    <a href="Pizza.aspx" class="card pizza">
      <img src="pizza.jpg" alt="Pizza" />
      <div class="overlay">Pizza</div>
    </a>
    <a href="Burger.aspx" class="card burger">
      <img src="burger.jpg" alt="Burger" />
      <div class="overlay">Burger</div>
    </a>
    <a href="Pasta.aspx" class="card pasta">
      <img src="pasta.jpg" alt="Pasta" />
      <div class="overlay">Pasta</div>
    </a>
    <a href="Steak.aspx" class="card steak">
      <img src="steak.jpg" alt="Steak" />
      <div class="overlay">Steak</div>
    </a>
    <a href="Fries.aspx" class="card fries">
      <img src="fries.jpg" alt="Fries" />
      <div class="overlay">Fries</div>
    </a>
    <a href="BBQ.aspx" class="card bbq">
      <img src="bbq.jpg" alt="BBQ" />
      <div class="overlay">BBQ</div>
    </a>
  </div>
</body>
</html>
