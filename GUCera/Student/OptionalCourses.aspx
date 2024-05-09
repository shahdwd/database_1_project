﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OptionalCourses.aspx.cs" Inherits="GUCera.OptionalCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
               <title>Advising System - Optional Courses</title>
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
    
    <h2>Optional Courses</h2>
</div>
    <form id="form1" runat="server">
        <div>
             <asp:TextBox ID="semcode" runat="server" placeholder="Insert Semester Code"></asp:TextBox>
             <br />
             <br />
             <asp:Button ID="optcourses" runat="server" Text="View Optional Courses" OnClick="optcourses_Click" />
             <br />
             <br />
             <asp:GridView ID="gridView3" runat="server" AutoGenerateColumns="true"></asp:GridView>
             <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
             <br />
             <br />
             <asp:Label ID="Error" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
        </div>
    </form>
</body>
</html>
