<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmailLog.aspx.cs" Inherits="EmailLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="UId" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:BoundField DataField="UId" HeaderText="UId" ReadOnly="True" SortExpression="UId" />
                <asp:BoundField DataField="UserEmail" HeaderText="UserEmail" SortExpression="UserEmail" />
                <asp:BoundField DataField="EmailSentFlag" HeaderText="EmailSentFlag" SortExpression="EmailSentFlag" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NETTestConnectionString %>" DeleteCommand="DELETE FROM [UserRegistration] WHERE [UId] = @UId" InsertCommand="INSERT INTO [UserRegistration] ([UserEmail], [EmailSentFlag]) VALUES (@UserEmail, @EmailSentFlag)" ProviderName="<%$ ConnectionStrings:NETTestConnectionString.ProviderName %>" SelectCommand="SELECT [UId], [UserEmail], [EmailSentFlag] FROM [UserRegistration]" UpdateCommand="UPDATE [UserRegistration] SET [UserEmail] = @UserEmail, [EmailSentFlag] = @EmailSentFlag WHERE [UId] = @UId">
            <DeleteParameters>
                <asp:Parameter Name="UId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="UserEmail" Type="String" />
                <asp:Parameter Name="EmailSentFlag" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="UserEmail" Type="String" />
                <asp:Parameter Name="EmailSentFlag" Type="String" />
                <asp:Parameter Name="UId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
