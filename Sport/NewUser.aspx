<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="Sport.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="center" >
            <table style="width:100%;padding-top:150px">
                <tr>
                    <td style="width:50%; text-align:right; padding-right:20px">
                        First Name:
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:TextBox ID="TxtBox_FName" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%; text-align:right; padding-right:20px">
                        Last Name:
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:TextBox ID="TxtBox_LName" runat="server" ></asp:TextBox>
                    </td>
                </tr>

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
                        <asp:TextBox ID="TxtBox_Password" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_Password1" runat="server" ErrorMessage="Password is required" Display="Dynamic" ControlToValidate="TxtBox_Password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%; text-align:right; padding-right:20px">
                        Retype Password :
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:TextBox ID="TxtBox_rePassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV_Password2" runat="server" ErrorMessage="Retype Password is required" Display="Dynamic" ControlToValidate="TxtBox_rePassword"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="ComV_retypePass" runat="server" 
                             ControlToValidate="TxtBox_rePassword"
                             ControlToCompare="TxtBox_Password"
                             ErrorMessage="No Match" 
                             ToolTip="Password must be the same" />
                    </td>
                </tr>
                <tr>
                    <td style="width:50%;">
                        &nbsp;
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:Button ID="Btn_Save" runat="server" Text="Save" OnClick="Btn_Save_Click" />
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" OnClick="Btn_Cancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="width:50%; padding-top:50px">
                        &nbsp;
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:Label ID="Lbl_NewUser" runat="server" Text=""></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:50%; padding-top:50px">
                        &nbsp;
                    </td>
                    <td style="width:50%; text-align:left">
                        <a runat="server" href="~/LogInPage">LogIn Page</a>
                    </td>
                </tr>
            </table>

            

        </div>
    </form>
</body>
</html>
