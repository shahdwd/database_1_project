<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="activvv.aspx.cs" Inherits="GUCera.activvv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Active Students</h1>
            
            <br />
            <asp:GridView ID="GridView1" runat="server">
                 <EmptyDataTemplate>
                    No data available.
                </EmptyDataTemplate>
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Back to main page" OnClick="Button1_Click1" />
        </div>
    </form>
</body>
</html>
