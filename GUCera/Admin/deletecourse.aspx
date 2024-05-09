<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deletecourse.aspx.cs" Inherits="GUCera.deletecourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
     <div>
         <h1>Delete a course</h1>
         <br />
         <asp:TextBox ID="courseID" runat="server" placeholder="Course ID"></asp:TextBox>
         <br />
         <br />
         <asp:Button ID="deleteButton" runat="server" OnClick="DeleteCourse" Text="Delete" />
         &nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button1" runat="server" Text="Back to the main page" OnClick="Button1_Click" />
     </div>
 </form>
</body>
</html>
