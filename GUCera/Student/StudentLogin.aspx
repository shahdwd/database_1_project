<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="GUCera.StudentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
               <title>Advising System - Add Phone Number(s)</title>
 <style>
     .header {
         background-color: #f2f2f2;
         padding: 20px;
         text-align: center;
     }
     h1 {
         margin: 0;
     }
 </style>
</head>
<body>
    <div >
    
    <h2>Please Log In:</h2>
</div>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <asp:TextBox ID="username" runat="server" placeholder ="Username"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="password" runat="server" placeholder ="Password" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="signin" runat="server" Text="Log In" OnClick="signin_Click" />
             <br />
            <br />
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
             <br />
             <br />
             new user?&nbsp;
             <asp:Button ID="signup" runat="server" Text="sign up" OnClick="signup_Click" />
        </div>
    </form>
</body>
</html>