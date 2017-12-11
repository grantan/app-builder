﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddThingProperty.aspx.cs" Inherits="AppBuilder.AddThingProperty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h2>Add Thing Property</h2>
                <asp:Label ID="lblOwnerName" runat="server"></asp:Label>
            </div>
            <div>
                <asp:Label id="lblName" runat="server" AssociatedControlID="txtName" Text="Property Name:" />
                <asp:TextBox ID="txtName" runat="server" /><br />

                <asp:Label id="lblDescription" runat="server" AssociatedControlID="txtDescription" Text="Description:" />
                <asp:TextBox ID="txtDescription" runat="server" /><br />

                <asp:Label id="lblTypes" runat="server" AssociatedControlID="ddlTypes" Text="Property Thing Type:" />
                <asp:DropDownList ID="ddlTypes" runat="server" /><br />

                <asp:Label ID="lblList" runat="server"  Text="Is a list?" />
                <asp:CheckBox ID="cbList" runat="server" /><br />

                <asp:Label ID="lblSequence" runat="server"  Text="Sequence Order" />
                <asp:TextBox ID="txtOrder" runat="server" /> <br />

                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Height="26px" /><br />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="26px" OnClick="btnCancel_Click" />

            </div>
        </div>
    </form>
</body>
</html>
