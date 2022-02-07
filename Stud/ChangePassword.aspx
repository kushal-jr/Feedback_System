<%@ Page Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Student_ChangePassword" Title="Student Feedback System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<table width="100%">
        <tr>
            <td align="right" style="width: 469px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Old Password :"></asp:Label>
                <b>&nbsp; </b></td>
            <td align="left">
                <asp:TextBox ID="txtOldPassword" runat="server" MaxLength="20" 
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtOldPassword" ErrorMessage="Enter Old Password"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="color: #000000">
            <td align="right" style="width: 469px">
                <b>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="New Password :"></asp:Label>
&nbsp; </b></td>
            <td align="left">
                <asp:TextBox ID="txtNewPassword" runat="server" MaxLength="20" 
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtNewPassword" ErrorMessage="Enter New Password"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 469px; height: 11px;">
                <b>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                    Text="Confirm New Password :"></asp:Label>
&nbsp; </b></td>
            <td align="left" style="height: 11px">
                <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="20" 
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" 
                    ErrorMessage="Password not matching"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 26px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtSave" runat="server" Font-Bold="True" 
                    Text="Save" onclick="ButtSave_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>

