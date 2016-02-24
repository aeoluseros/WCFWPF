<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Employee Name"></asp:Label>
&nbsp;
        <br />
        <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Salary"></asp:Label>
&nbsp;
        <br />
        <asp:TextBox ID="txtEmployeeSalary" runat="server" OnTextChanged="txtEmployeeSalary_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
    
    </div>
    </form>
</body>
</html>
