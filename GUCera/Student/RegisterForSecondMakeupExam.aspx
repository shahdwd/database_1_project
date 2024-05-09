<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForSecondMakeupExam.aspx.cs" Inherits="Advising_System.RegisterForSecondMakeupExam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register for Second Makeup Exam</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h2>Register for Second Makeup Exam</h2>
            <br />
            <label for="CourseIDTextBox">Course ID:</label>
            <asp:TextBox ID="CourseIDTextBox" runat="server"></asp:TextBox>
             <br />
            <br />
            <label for="CurrentSemesterTextBox">Current Semester:</label>
            <asp:TextBox ID="CurrentSemesterTextBox" runat="server"></asp:TextBox>
             <br />
            <br />
            <asp:Button ID="RegisterForSecondMakeupExamButton" runat="server" Text="Register for Second Makeup Exam" OnClick="RegisterForSecondMakeupExamButton_Click" />
             &nbsp;&nbsp;
 <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
 <br />
 <br />
        </div>
    </form>
</body>
</html>
