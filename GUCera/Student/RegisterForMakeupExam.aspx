<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForMakeupExam.aspx.cs" Inherits="Advising_System.RegisterForMakeupExam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register for Makeup Exam</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register for First Makeup Exam</h2>
            <p>&nbsp;</p>
            <p>Course ID: <asp:TextBox ID="CourseIDTextBox" runat="server"></asp:TextBox></p>
            <p>Current Semester: <asp:TextBox ID="CurrentSemesterTextBox" runat="server"></asp:TextBox></p>
            <asp:Button ID="RegisterForMakeupExamButton" runat="server" Text="Register" OnClick="RegisterForMakeupExamButton_Click" />
             &nbsp;&nbsp;
 <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
 <br />
 <br />
        </div>
    </form>
</body>
</html>
