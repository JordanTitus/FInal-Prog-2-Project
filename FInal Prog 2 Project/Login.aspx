<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FInal_Prog_2_Project.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>
                <font face="Verdana">Login</font>
            </h3>
            <table>
                <tr>
                    <td>Email:</td>
                    <td><input id="txtUserName" type="text" runat="server"></td>
                    <td><ASP:RequiredFieldValidator ControlToValidate="txtUserName"
                        Display="Static" ErrorMessage="*" runat="server" 
                        ID="vUserName" /></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><input id="txtUserPassword" type="password" runat="server"></td>
                    <td><ASP:RequiredFieldValidator ControlToValidate="txtUserPass"
                        Display="Static" ErrorMessage="*" runat="server"
                        ID="vUserPass" />
                    </td>
                </tr>
                <tr>
                    <td><label for="SelectUserType">Choose user type:</label></td>
                    <td>
                        <select id="SelectUserType" name="SelectUserType" runat="server" style="display: block">
                            <option value="Default">-Select an Option-</option>
                            <option value="Farmer">Farmer</option>
                            <option value="Employee">Employee</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Persistent Cookie:</td>
                    <td><ASP:CheckBox id="CheckPersistCookie" runat="server" autopostback="false" /></td>
                    <td></td>
                </tr>
            </table>
        <input type="submit" Value="Login" runat="server" ID="cmdLogin"><p></p>
        <asp:Label id="lblMsg" ForeColor="blue" Font-Name="Verdana" Font-Size="12" runat="server" />
        </div>
    </form>
</body>
</html>
</asp:Content>
