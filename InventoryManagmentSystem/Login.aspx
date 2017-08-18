<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InventoryManagmentSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/login.css" rel="stylesheet" />
</head>
<body>
    
    <div class="frmlogin">
        <br />
      
        <h1>Login Form</h1>
        <form id="form1" runat="server">
            <asp:TextBox ID="txtUserName" runat="server" placeholder="UserName"  ></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password"  TextMode="Password"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server"  Text="Login" CssClass ="btn" OnClick="btnLogin_Click1" />

            <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="Button" style="margin-top: 0px" />
        </form>
        
    </div>

</body>
</html>
