<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInPage.aspx.cs" Inherits="Sport.LogInPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Task Management System</title>
    <style>
        body {
                font-size: 15px;
            }
        .center {
                margin: auto;
                width: 40%;
                
                padding-top: 200px;
                text-align: center;
                font-family:'Times New Roman', Times, serif;
                font-size:15px;
            }


     </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="center" >
            <table style="width:100%;">
                <tr>
                    <td style="width:50%; text-align:right; padding-right:20px">
                        User ID:
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:TextBox ID="TxtBox_UserID" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_UserID" runat="server" ErrorMessage="User ID is required" Display="Dynamic" ControlToValidate="TxtBox_UserID"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%; text-align:right; padding-right:20px">
                        Password :
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:TextBox ID="TxtBox_Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_Password" runat="server" ErrorMessage="Password is required" Display="Dynamic" ControlToValidate="TxtBox_Password"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:50%;">
                        &nbsp;
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:Button ID="Btn_Login" runat="server" Text="Log In" OnClick="Btn_Login_Click" />
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Clear" OnClick="Btn_Cancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="width:50%; padding-top:50px">
                        &nbsp;
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:Label ID="Lbl_UserLogin" runat="server" Text=""></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:50%; padding-top:50px">
                        &nbsp;
                    </td>
                    <td style="width:50%; text-align:right">
                        <a runat="server" href="~/NewUser">New User</a>
                    </td>
                </tr>
            </table>
            

            

        </div>
    </form>
</body>
</html>
