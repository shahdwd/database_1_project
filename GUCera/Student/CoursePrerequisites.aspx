<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoursePrerequisites.aspx.cs" Inherits="Advising_System.CoursePrerequisites" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advising System - View Course Prerequisites</title>
    <style>
        .header {
            background-color: #f2f2f2;
            padding: 20px;
            text-align: center;
        }
        h1 {
            margin: 0;
        }
    </style>
</head>
<body>
    <div >
        
        <h2>View Course Prerequisites</h2>
    </div>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="CoursesGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="course_id" HeaderText="Course ID" />
                    <asp:BoundField DataField="name" HeaderText="Course Name" />
                    <asp:BoundField DataField="preRequsite_course_id" HeaderText="Prerequisite Course ID" />
                    <asp:BoundField DataField="preRequsite_course_name" HeaderText="Prerequisite Course Name" />
                </Columns>
            </asp:GridView>
             <br />
             &nbsp;&nbsp;&nbsp;
             <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
            <br />
            <br />
            <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
        </div>
    </form>
</body>
</html>

