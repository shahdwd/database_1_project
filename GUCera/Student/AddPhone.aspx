<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPhone.aspx.cs" Inherits="GUCera.AddPhone" %>

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
    
    <h2>Add Phone Number(s)</h2>
</div>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtPhoneNumber" runat="server" placeholder="Enter Phone Number" TextMode="Phone" ></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Add_Phone" Text="Add Phone Number(s)" />
            &nbsp;&nbsp;
            <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
            <br />
            <br />
            <asp:ListBox ID="lstPhoneNumbers" runat="server"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="Error" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
