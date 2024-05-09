<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transcript.aspx.cs" Inherits="GUCera.transcript" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>View Transcripts</h1>
            <br />
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No transcripts available">
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Back to the main page" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
