<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlinksta.aspx.cs" Inherits="GUCera.adminlinksta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Link Student to Advisor</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Link Student to Advisor</h1>

            
            <asp:TextBox ID="txtStudentId3" runat="server" placeholder="Student ID"></asp:TextBox>
            <br />
            <br />

            
            <asp:TextBox ID="txtAdvisorId3" runat="server" placeholder="Advisor ID"></asp:TextBox>
            <br />
            <br />

            <asp:Button ID="btnSubmit3" runat="server" OnClick="btnSubmit3_Click" Text="Submit" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID = "btnmainpage4" runat = "server" OnClick = "btnMP4_Click" Text = "Go To Main Page"/>
        </div>
    </form>
</body>
</html>
