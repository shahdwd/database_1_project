<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="slotsdelete.aspx.cs" Inherits="GUCera.slotsdelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Delete unoffered slots</h1>
        <br />
        <asp:TextBox ID="semcode" runat="server" placeholder="Semester Code"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="semButton" runat="server" Text="Done" OnClick="semButton_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Back to the main page" OnClick="Button1_Click" />
        <br />
    </div>
</form>
</body>
</html>
