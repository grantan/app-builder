<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewApplicationMockup.aspx.cs" Inherits="AppBuilder.NewApplicationMockup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:label runat="server">New Thing or Inherit from List</asp:label>
            <asp:DropDownList ID="DDLThing" runat="server"></asp:DropDownList>
            <asp:Button runat="server" ID="btnNew" Text="New Thing"/>
        </div>
        
    </form>
</body>
</html>
