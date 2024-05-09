<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourseRequest.aspx.cs" Inherits="GUCera.AddCourseRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Advising System - Send Course Request</title>
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
    
    <h2>Send Course Request</h2>
</div>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Success" runat="server" ForeColor="Green" Font-Bold="true" ></asp:Label>
            <br />
            <asp:TextBox ID="courseid" runat="server" placeholder ="Course ID"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="comment" runat="server" placeholder="Comment"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="btnSend_Coursepressed" Text="Send Course Request" />
            &nbsp;&nbsp;
            <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
            <br />
            <br />
            <asp:Label ID="Error" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
        </div>
    </form>
</body>
</html>
