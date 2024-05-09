<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addmexam.aspx.cs" Inherits="GUCera.addmexam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Add makeup exam</h1>
            <br />
            <asp:Label ID="Success" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Exam Type"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Date"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Course ID"></asp:TextBox>
            <br />
            <asp:Label ID="Error" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Enter" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Back to the main page" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
