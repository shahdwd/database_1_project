<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoursesAndExams.aspx.cs" Inherits="Advising_System.CoursesAndExams" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Courses and Exams</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>View Courses and Exams Details</h2>
            <asp:GridView ID="CoursesExamsGridView" runat="server"></asp:GridView>
            <br />
             &nbsp;&nbsp;&nbsp;
 <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
<br />
<br />
        </div>
    </form>
</body>
</html>