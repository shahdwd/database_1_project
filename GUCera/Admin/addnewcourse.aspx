<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addnewcourse.aspx.cs" Inherits="GUCera.addnewcourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Enter Course Details</h1>
            
            <asp:TextBox ID="txtMajor" runat="server" placeholder="Major"></asp:TextBox>
            <br />
            <br />


            <asp:TextBox ID="txtSemester1" runat="server" placeholder="Semester"></asp:TextBox>
            <br />
            <br />

            
            <asp:TextBox ID="txtCreditHours" runat="server" placeholder="Credit Hours"></asp:TextBox>
            <br />
            <br />

           
            <asp:TextBox ID="txtCourseName" runat="server" placeholder="Course Name"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblIsOffered" runat="server" Text="Is Offered:"></asp:Label>
            <asp:DropDownList ID="ddlIsOffered" runat="server">
                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />

            <asp:Button ID="btnSubmit1" runat="server" OnClick="btnSubmit1_Click" Text="Submit" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnmainpage" runat="server" OnClick="btnMP_Click" Text="Go To Main Page" />
        </div>
    </form>
</body>
</html>
