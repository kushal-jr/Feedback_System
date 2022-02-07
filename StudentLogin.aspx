<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentLogin.aspx.cs" Inherits="Login" Title="Student Feedback System" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script>
javascript:window.history.forward(1);
</script>
    <table align="center" cellspacing="1" style="width: 100%">
   
        <tr>
            <td align="center" style="width: 687px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                    Font-Names="Monotype Corsiva" Font-Size="Large" ForeColor="#000066" 
                    Text="Welcome to Student Feedback System for Graduate Students"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; width: 687px;">
            </td>
        </tr>
        <tr>
            <td style="text-align: justify" width="100%">
                The purpose of this feedback questionnaire is to gather information on your 
                learning experience, as well as your responses to&nbsp; the teacher(s). Please think 
                of these questions as eliciting your subjective perceptions on various aspects 
                of the course and the teacher(s) involved in the course. The information you 
                provide will be useful to your teacher(s) as well as to the University in the 
                ongoing efforts to enhance the quality of education. The data you provide will 
                be treated as confidential. The evaluation results will be computed using the 
                total scores from the responses from all students and will be released to the 
                affected teachers AFTER you have received your examination results.
            </td>
        </tr>
        <tr>
            <td style="height: 22px; width: 687px;">
            </td>
        </tr>
        <tr>
            <td align="center">
        &nbsp;
        <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Registration No:"></asp:Label>
                <asp:TextBox ID="TBRNo" runat="server" Width="128px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TBRNo" ErrorMessage="*"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Password :"></asp:Label>
                <asp:TextBox ID="TBPWord" runat="server" TextMode="Password"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TBPWord" ErrorMessage="*"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 21px; width: 687px; text-align: justify;">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="height: 21px; width: 687px;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;<asp:Button ID="ButtLogon" runat="server" Font-Bold="True" 
                    Font-Names="Monotype Corsiva" Font-Size="Large" ForeColor="#CC0000" 
                    Height="27px"  Text="Logon" Width="105px" onclick="ButtLogon_Click"/>
            </td>
        </tr>
        <tr>
            <td style="width: 687px">
               &nbsp;</td>
        </tr>
    </table>
</asp:Content>

