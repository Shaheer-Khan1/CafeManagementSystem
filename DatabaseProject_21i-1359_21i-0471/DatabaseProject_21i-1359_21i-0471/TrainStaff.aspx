<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainStaff.aspx.cs" Inherits="DatabaseProject_21i_1359_21i_0471.TrainStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Train Staff</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            background-image: url(MainBG.jpg); 
            color: #fee456; 
            margin: 0;
            padding: 0;
        }

        form {
            display: flex;
            flex-direction: column;
            align-items: center;
            padding-top: 20px;
        }

        #form1 {
            background-color: #222222; 
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
            margin-top: 20px;
        }

        #GridView1 {
            width: 80%;
            margin-bottom: 20px;
            background-color: #444444; 
            color: #fee456;
        }

        input[type="text"],
        input[type="submit"] {
            width: 80%;
            margin: 5px 0;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            color: #333333;
        }

        input[type="submit"] {
            width: 40%;
            padding: 10px;
            border: none;
            border-radius: 5px;
            background-color: #222222; 
            color: #fee456; 
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        input[type="submit"]:hover {
            background-color: #555555; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img id="logo" src="logo.jpg" alt="Logo" />
        </div>
        <div id="buttons-container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowUpdating="GridView1_RowUpdating" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" />
                    <asp:BoundField DataField="TrainingStatus" HeaderText="Training Status" />
                    <asp:TemplateField HeaderText="Update Training">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkTrainingStatus" runat="server" Checked='<%# Convert.ToBoolean(Eval("TrainingStatus")) %>' Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnTrain" runat="server" Text="Train" OnClick="btnTrain_Click" CssClass="button-style" />
            <asp:Button ID="btnReturn" runat="server" Text="Go Back" OnClick="return_Click" CssClass="button-style" />
        </div>
    </form>
</body>
</html>
