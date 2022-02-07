<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CollegeRegistration.aspx.cs" Inherits="Administrator_CollegeRegistration" Title="Student Feedback System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" style="width: 102%">
        <tr>
            <td style="width: 447px">
                &nbsp;</td>
            <td style="width: 87px">
                &nbsp;</td>
            <td style="width: 366px">
                </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 33px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                    Font-Names="Times New Roman" Font-Size="Large" ForeColor="Black" 
                    Text="College Registration"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="Label23" runat="server" ForeColor="Black" 
                    Text="Fill the following Form for the  Registration" Font-Size="Small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="width: 447px">
                <asp:Label ID="Label49" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="College Name :"></asp:Label>
            </td>
            <td align="left" style="width: 87px">
                <asp:TextBox ID="CName" runat="server"></asp:TextBox>
            </td>
            <td align="left" style="width: 366px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="CName" ErrorMessage="Enter College Name" 
                    Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 447px">
                <asp:Label ID="Label50" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="College Code :"></asp:Label>
            </td>
            <td style="width: 87px" align="left">
                <asp:TextBox ID="CCode" runat="server" Columns="2" MaxLength="2"></asp:TextBox>
            </td>
            <td style="width: 366px" align="left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="CCode" ErrorMessage="Enter College Code" 
                    Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 447px">
                <asp:Label ID="Label51" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Established Year :"></asp:Label>
            </td>
            <td style="width: 87px" align="left">
                <asp:TextBox ID="EYear" runat="server" Columns="4" MaxLength="4"></asp:TextBox>
            </td>
            <td style="width: 366px" align="left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="EYear" ErrorMessage="Enter Year" Font-Bold="True" 
                    Font-Size="Small"></asp:RequiredFieldValidator>
            &nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                    ControlToValidate="EYear" ErrorMessage="Enter Digits" Font-Bold="True" 
                    Font-Italic="False" ValidationExpression="\d{4,4}" Font-Size="Small"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 447px">
                &nbsp;</td>
            <td style="width: 87px">
                &nbsp;</td>
            <td style="width: 366px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BttnSave" runat="server" Font-Bold="True" 
                Text="Save" onclick="BttnSave_Click" Width="48px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtClear" runat="server" CausesValidation="False" 
                    Font-Bold="True" Text="Reset" onclick="ButtClear_Click" />
            </td>
        </tr>
        </table>
</asp:Content>

