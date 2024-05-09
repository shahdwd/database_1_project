<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoursesSlotsInstructor.aspx.cs" Inherits="Advising_System.CoursesSlotsInstructor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Courses and Slots</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Courses and Slots Details</h2>
            <asp:GridView ID="GridViewCourses" runat="server">
              
            </asp:GridView>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
 <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
<br />
<br />
        </div>
    </form>
</body>
</html>

