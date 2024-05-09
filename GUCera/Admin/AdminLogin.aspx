<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="GUCera.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Please Log In :</h1><br />
            <br />
            </div>
        <asp:TextBox ID="idTextBox" runat="server" placeholder="Admin ID"></asp:TextBox>
        <br />
        <br />
        <p>
            <asp:TextBox ID="passwordTextBox" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
        </p>
        <asp:Button ID="signin" runat="server" OnClick="login" Text="Log In" />
    </form>
</body>
</html>
