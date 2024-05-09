<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatestatus.aspx.cs" Inherits="GUCera.updatestatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Update Student Status</h1>
            <br />
            <asp:TextBox ID="TextBox13" runat="server" placeholder="Student ID"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Enter" OnClick="Button1_Click" />
            
            &nbsp;&nbsp;
            
            <asp:Button ID="Button2" runat="server" Text="Back to the main page" OnClick="Button2_Click" />
            
        </div>
    </form>
</body>
</html>
