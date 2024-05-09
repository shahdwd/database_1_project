<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MissingCourses.aspx.cs" Inherits="GUCera.MissingCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title>Missing Courses</title>
</head>
<body>
    
    
    <h2>Missing Courses</h2>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:GridView ID="gridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
            <br />
            <br />
            <asp:Label ID="Error" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
        </div>
        
    </form>
</body>
</html>
