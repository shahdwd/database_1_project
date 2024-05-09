<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GUCera.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form2" runat="server" style="display: flex; align-items: center; justify-content: center; height: 100vh;">        <div>
            <asp:Panel ID="Panel1" runat="server">
               
                <h1 class="">Sign up</h1>
                <p class="">
                    <span>Already have an account?</span>  <a href="login.aspx">Log in</a> </p>
                <asp:Label ID="Label1" runat="server" Visible="False" Text="Label"></asp:Label>
                <br />
                Name<br /> <asp:TextBox ID="advisorname" runat="server"></asp:TextBox>
                <br />
                Email<br /><asp:TextBox ID="advisoremail" TextMode="Email" runat="server"></asp:TextBox>
                <br />
                Password<br />
                <asp:TextBox ID="advisorpassword1" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                Confirm Password<br />
                <asp:TextBox ID="advisorpassword2" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                Office<br/><asp:TextBox ID="office" runat="server"></asp:TextBox>
                <br />
                <br />
               
                <asp:Button ID="Registered" runat="server" Height="28px" Text="Register" Width="111px" OnClick="Resgistered" />

                <br />
                <br />
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="Green"></asp:Label>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
