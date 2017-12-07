<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditThing.aspx.cs" Inherits="AppBuilder.EditThing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h2>Edit Thing</h2>
            </div>
            <div>
                <asp:Label id="lblId" runat="server" AssociatedControlID="txtId" Text="Id:" />
                <asp:TextBox ID="txtId" runat="server" /><br />

                <asp:Label id="lblName" runat="server" AssociatedControlID="txtName" Text="Thing Name:" />
                <asp:TextBox ID="txtName" runat="server" /><br />

                <asp:Label id="lblDescription" runat="server" AssociatedControlID="txtDescription" Text="Description:" />
                <asp:TextBox ID="txtDescription" runat="server" /><br />

                <asp:Label id="lblTypes" runat="server" AssociatedControlID="ddlTypes" Text="Thing Type:" />
                <asp:DropDownList ID="ddlTypes" runat="server" /><br />               

            </div>
            <div>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
            <div>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div>
                <h3>Property List</h3>
            </div>
            <div>
                <asp:GridView ID="gvProperties" runat="server" BackColor="White" EmptyDataText="No properties for this Thing. Add a new Property"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                    HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProperties_SelectedIndexChanged">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"
                        HorizontalAlign="Center" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                    <Columns>
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblId" Text='<%#Eval("ThingPropertyId") %>' Enabled="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblName" Text='<%#Eval("PropertyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDescription" Text='<%#Eval("PropertyDescription") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IsList">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblList" Text='<%#Eval("IsList") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblType" Text='<%#Eval("OwnedThing.Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnEdit" runat="server" Text="Edit" OnCommand="gvProperties_SelectedIndexChanged"
                                    CommandArgument='<%# Eval("ThingPropertyId") %>' CommandName="Select"/>     
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                        <%--<asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:TextBox ID="QantityTextBox" runat="server" Text='<%# Eval("Quantity") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <asp:Button id="btnAddProperty" runat="server" Text="Add Property" OnClick="btnAddProperty_Click" />
            </div>
            
        </div>
    </form>
</body>
</html>
