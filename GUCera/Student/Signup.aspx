<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="GUCera.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
           <title>Advising System - Register</title>
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
    
    <h2>Register as a New Student:</h2>
</div>
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="SuccessLabel" runat="server" ForeColor="Green"></asp:Label>
            <br />
            <br />
            <asp:Label ID="IDLabel" runat="server" ForeColor="Green"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="fname" runat="server" placeholder="First Name"></asp:TextBox>
            <br />
            <br />
            
            <asp:TextBox ID="lname" runat="server" placeholder="Last Name"></asp:TextBox>
            <br />
            <br />
            
            <asp:TextBox ID="pass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            <br />
            <br />

            <asp:TextBox ID="confirmpass" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
<br />
<br />
            
            <asp:TextBox ID="fac" runat="server" placeholder="Faculty"></asp:TextBox>
            <br />
            <br />
            
            <asp:TextBox ID="em" runat="server" placeholder="Email"></asp:TextBox>
            <br />
            <br />
            
            <asp:TextBox ID="maj" runat="server" placeholder="Major"></asp:TextBox>
            <br />
            <br />
            
            <asp:TextBox ID="sem" runat="server" placeholder="Semester"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="sign_up" runat="server" Text="Register" OnClick="sign_up_Click" />
            <br />
            <asp:Label ID="Error" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="login" runat="server" Text="Back to Login" OnClick="login_Click" />
            <br />
        </div>
    </form>
</body>
</html>
