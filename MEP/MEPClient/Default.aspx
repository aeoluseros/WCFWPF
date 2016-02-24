<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtUserEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign Up" />
    
    </div>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="UId" DataSourceID="MEPSqlDataSource" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="UId" HeaderText="UId" InsertVisible="False" ReadOnly="True" SortExpression="UId" />
                <asp:BoundField DataField="UserEmail" HeaderText="UserEmail" SortExpression="UserEmail" />
                <asp:BoundField DataField="EmailSentFlag" HeaderText="EmailSentFlag" SortExpression="EmailSentFlag" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="MEPSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:NETTestConnectionString %>" SelectCommand="SELECT * FROM [UserRegistration]"></asp:SqlDataSource>
    </form>
</body>
</html>
