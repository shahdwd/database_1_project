<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseCourseInstructor.aspx.cs" Inherits="Advising_System.ChooseCourseInstructor" %>

<!DOCTYPE html>
<html>
<head>
    <title>Choose Course Instructor</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Choose Course Instructor</h2>
            <br />
            <asp:TextBox ID="txtInstructorID" runat="server" placeholder="Instructor ID"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtCourseID" runat="server" placeholder="Course ID"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtSemesterCode" runat="server" placeholder="Semester Code"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnChooseInstructor" runat="server" Text="Choose Instructor" OnClick="btnChooseInstructor_Click" />
            <br />
            <br />
            

            <asp:GridView ID="YourGridView" runat="server">
             
            </asp:GridView>

            <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />

            <br />
            <br />

            <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label><br />
        </div>
    </form>
</body>
</html>

