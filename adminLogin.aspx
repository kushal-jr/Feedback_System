<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminLogin.aspx.cs" Inherits="adminLogin" Title="Student Feedback System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="TABLE1" align="right" 
            style="width: 471px; border: 1px solid #FFFF00;">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" 
                        ForeColor="Maroon" Width="345px">Authorization</asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 572px">
                &nbsp;</td>
            <td align="left" style="width: 384px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="width: 572px" valign="top">
                    &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" 
                        Text="User Name :"></asp:Label>
            </td>
            <td align="left" style="width: 384px">
                <asp:TextBox ID="TBName" runat="server"></asp:TextBox>
                <br />
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TBName" ErrorMessage="Required Field cannot be left bank" 
                        Display="Dynamic" Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 572px" valign="top">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                        Text="Password :"></asp:Label>
            </td>
            <td align="left" style="width: 384px">
                <asp:TextBox ID="TBPwd" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TBPwd" ErrorMessage="Required Field cannot be left bank" 
                        Display="Dynamic" Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtLogin" runat="server" Font-Bold="True" 
                        Text="Login" Width="61px" onclick="ButtLogin_Click" />
                    &nbsp;&nbsp;
                    </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

