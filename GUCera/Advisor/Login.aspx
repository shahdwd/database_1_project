<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUCera.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server" style="display: flex; align-items: center; justify-content: center; height: 100vh;">

    <div>


        <h1 class="">Log in</h1>

        <br />
        Username:<br />
        <asp:TextBox ID="username" runat="server"  ></asp:TextBox>
        <br />
        Password:<br />
        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
    <asp:Label ID="lbl5" runat="server" ForeColor="Red" Visible="false"></asp:Label>


        <br />
      <br />
        <asp:Button ID="signin" runat="server" OnClick="login" Text="Log in" />

            <br />

        <br />

        <asp:Button ID="Button1" runat="server" OnClick="Register" Text="Register for a new Account" />
        <br />


        


    </div>
    </form>
    </body>
</html>

