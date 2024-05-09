<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlinkstci.aspx.cs" Inherits="GUCera.adminlinkstci" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Link Student to Course in a Specific Slot</h1>

            
            <asp:TextBox ID="txtCourseId4" runat="server" placeholder="Course ID"></asp:TextBox>
            <br />
            <br />

            
            <asp:TextBox ID="txtInstructorId4" runat="server" placeholder="Instructor ID"></asp:TextBox>
            <br />
            <br />

         
            <asp:TextBox ID="txtStudentId4" runat="server" placeholder="Student ID"></asp:TextBox>
            <br />
            <br />

            <asp:TextBox ID="txtSemesterCode4" runat="server" placeholder="Semester Code"></asp:TextBox>
            <br />
            <br />

            <asp:Button ID="btnSubmit4" runat="server" OnClick="btnSubmit4_Click" Text="Submit" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnMainPage4" runat="server" OnClick="btnMP4_Click" Text="Go To Main Page" />
        </div>
    </form>
</body>
</html>
