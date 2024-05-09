
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentInstallment.aspx.cs" Inherits="Advising_System.StudentInstallment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Installment</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>View Upcoming Installment</h2>
            <asp:Button ID="ViewInstallmentButton" runat="server" Text="View Upcoming Installment" OnClick="ViewInstallmentButton_Click" />
            <br /><br />
            <asp:Label ID="UpcomingInstallmentLabel" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Text=""></asp:Label>

             &nbsp;&nbsp;
 <asp:Button ID="back" runat="server" Text="Back to Portal" OnClick="back_Click" />
 <br />
 <br />
        </div>
    </form>
</body>
</html>
