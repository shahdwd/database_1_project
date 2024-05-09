<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addnewsem.aspx.cs" Inherits="GUCera.addnewsem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Enter Semester Details</h1>
           
            <asp:TextBox ID="txtSemester" runat="server" placeholder="Semester Code"></asp:TextBox>
            <br />
            <br />
            Start Date:<br />
            
            
            <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" placeholder="Start Date"></asp:TextBox>
            <br />
            <br />
            End Date:<br />
            
            
            <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" placeholder="End Date"></asp:TextBox>
            <br />
            <br />
            
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnmainpage1" runat="server" OnClick="btnMP1_Click" Text="Go To Main Page" />
        </div>
    </form>
</body>
</html>
