<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CertainCourseSlotsInstructor.aspx.cs" Inherits="Advising_System.CertainCourseSlotsInstructor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Certain Course Slots Instructor</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Certain Course Slots Instructor</h2>
            <div>
                <asp:TextBox ID="txtCourseID" runat="server" placeholder="Course ID"></asp:TextBox>
                <br />
                <br />
                </div>
                <div>
                <asp:TextBox ID="txtInstructorID" runat="server" placeholder="Instructor ID"></asp:TextBox>
                    <br />
                </div>
                <div>
                <asp:Button ID="btnDisplay" runat="server" Text="Display" OnClick="btnDisplay_Click" />
                    <br />
            </div>
            <div>
                <asp:GridView ID="GridViewSlots" runat="server">
                    
                </asp:GridView>
                <br />
           
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
                <br />
                <br />
                <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
