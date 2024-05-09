<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_gradplan_courses.aspx.cs" Inherits="Advising_System.Student_gradplan_courses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <h2>Your Graduation Plan and your Courses </h2>

    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ViewGradPlanButton" runat="server" Text="View Graduation Plan" OnClick="ViewGradPlanButton_Click" />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:Label ID="StudentIDErrorLabel" runat="server" ForeColor="Red"></asp:Label>
        
        </div>
        <p>
            <asp:Label ID="NotFoundErrorLabel" runat="server" ForeColor="Red"></asp:Label>
        
        </p>
         &nbsp;&nbsp;
 <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
 <br />
 <br />
    </form>
</body>
</html>
