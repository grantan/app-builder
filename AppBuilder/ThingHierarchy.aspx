<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThingHierarchy.aspx.cs" Inherits="AppBuilder.ThingHierarchy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtHierarchy" runat="server" Columns="50" Rows="15" TextMode="MultiLine" ></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" />
        </div>        
    </form>
</body>
</html>
