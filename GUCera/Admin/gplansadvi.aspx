<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gplansadvi.aspx.cs" Inherits="GUCera.gplansadvi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Graduation Plans</h1>
            <br />
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No data available">
                <EmptyDataTemplate>
                    <p>No data available.</p>
                </EmptyDataTemplate>
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Back to the main page" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
