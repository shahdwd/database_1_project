<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlinkinst.aspx.cs" Inherits="GUCera.adminlinkinst" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Link instructor to a course in a specific slot</h1>
            
            
            <asp:TextBox ID="txtCourseId2" runat="server" placeholder="Course ID"></asp:TextBox>
            <br />
            <br />

           
           
            <asp:TextBox ID="txtInstructorId" runat="server" placeholder="Instructor ID"></asp:TextBox>
            <br />
            <br />

            
          
            <asp:TextBox ID="txtSlotId" runat="server" placeholder="Slot ID"></asp:TextBox>
            <br />
            <br />

            <asp:Button ID="btnSubmit2" runat="server" OnClick="btnSubmit2_Click" Text="Submit" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID = "btnmainpage2" runat = "server" OnClick = "btnMP2_Click" Text = "Go To Main Page"/>            

        </div>
    </form>
</body>
</html>