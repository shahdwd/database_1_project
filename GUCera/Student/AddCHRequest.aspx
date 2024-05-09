<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCHRequest.aspx.cs" Inherits="GUCera.AddCHRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Advising System - Send Credit Hour(s) Request</title>
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
    
    <h2>Send Credit Hour(s) Request</h2>
</div>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Success" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
            <br />
            <asp:TextBox ID="ch" runat="server" placeholder ="Credit Hours"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="comment" runat="server" placeholder ="Comment"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="btnSend_CHpressed" Text="Send Credit Hour(s) Request" />
            &nbsp;&nbsp;
            <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
            <br />
            <br />
            <asp:Label ID="Error" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
