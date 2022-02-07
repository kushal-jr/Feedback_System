<%@ Page Language="C#" MasterPageFile="~/Administrator.master" AutoEventWireup="true" CodeFile="Charts.aspx.cs" Inherits="Administrator_Charts" Title="Student Feedback System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center">
    
        <table 
                align="center">
            <tr>
                <td colspan="5" style="height: 2px" align="center">
                        &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="height: 27px; " colspan="5">
                        <table style="width: 100%">
                            <tr>
                                <td align="right" style="width: 282px">
                        <asp:Label ID="Label54" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Course Name :"></asp:Label>
                                </td>
                                <td align="left" style="width: 350px">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                            Font-Bold="True" ForeColor="Black" Height="24px" RepeatDirection="Horizontal" 
                            Width="422px" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                            <asp:ListItem>B.Tech</asp:ListItem>
                            <asp:ListItem>M.Tech</asp:ListItem>
                            <asp:ListItem>MCA</asp:ListItem>
                            <asp:ListItem>MBA</asp:ListItem>
                        </asp:RadioButtonList>
                                </td>
                                <td align="left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" 
                            ControlToValidate="RadioButtonList1" ErrorMessage="Select Course Name" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 282px">
                                    &nbsp;</td>
                                <td align="left" style="width: 350px">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                        </table>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 19px; width: 386px;">
                        <asp:Label ID="Label58" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Regulation :"></asp:Label>
                </td>
                <td align="left" style="height: 19px; width: 243px;">
                        <asp:DropDownList ID="DDLReg" runat="server" AutoPostBack="True" Height="17px" 
                            onselectedindexchanged="DDLReg_SelectedIndexChanged" Width="90px">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td align="right" style="height: 19px; width: 214px;">
                    <asp:Label ID="Label49" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Branch Name :"></asp:Label>
                </td>
                <td align="left" style="height: 19px; width: 453px;">
                    <asp:DropDownList ID="DDLBName" runat="server" AutoPostBack="True" 
                            Height="20px" Width="92px" 
                        onselectedindexchanged="DDLBName_SelectedIndexChanged">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblBranch" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td align="left" style="height: 19px; width: 612px;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                            ControlToValidate="DDLBName" ErrorMessage="Select Branch Name" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 19px; width: 386px;">
                                <asp:Label ID="Label51" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Year :"></asp:Label>
                </td>
                <td align="left" style="height: 19px; width: 243px;">
                                <asp:DropDownList ID="DDLYear" runat="server" AutoPostBack="True" Height="20px" 
                                        Width="92px" style="margin-left: 2px" 
                                    onselectedindexchanged="DDLYear_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" 
                            ControlToValidate="DDLYear" ErrorMessage="Select Year" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
                <td align="right" style="height: 19px; width: 214px;">
                                <asp:Label ID="lblsem" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Semester :"></asp:Label>
                </td>
                <td align="left" style="height: 19px; width: 453px;">
                                <asp:DropDownList ID="DDLSemester" runat="server" AutoPostBack="True" 
                            Width="74px" style="margin-left: 0px" Height="19px" 
                                    onselectedindexchanged="DDLSemester_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                </td>
                <td align="left" style="height: 19px; width: 612px;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" 
                            ControlToValidate="DDLSemester" ErrorMessage="Select Semister" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 11px; width: 386px;">
                    <asp:Label ID="Label56" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Subject :"></asp:Label>
                </td>
                <td align="left" style="width: 243px; height: 11px;">
                                <asp:DropDownList ID="DDLSubject" runat="server" AutoPostBack="True" 
                            Width="74px" style="margin-left: 0px" Height="19px">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" 
                            ControlToValidate="DDLSubject" ErrorMessage="Select Subject" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
                <td align="right" style="height: 11px; width: 214px;">
                    <asp:Label ID="Label53" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Section :"></asp:Label>
                </td>
                <td align="left" style="height: 11px; width: 453px;">
                    <asp:DropDownList ID="DDLSection" runat="server" AutoPostBack="True" 
                            Width="71px" style="margin-left: 0px" Height="20px" 
                                    onselectedindexchanged="DDLSection_SelectedIndexChanged">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" 
                            ControlToValidate="DDLSection" ErrorMessage="Select Section" 
                            Display="Dynamic" Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
                <td align="left" style="height: 11px; ">
                                &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="height: 11px; width: 386px;">
                    <asp:Label ID="Label55" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Faculty Name :"></asp:Label>
                </td>
                <td align="left" style="width: 243px; height: 11px;">
                                <asp:DropDownList ID="DDLFName" runat="server" AutoPostBack="True" 
                            Width="74px" style="margin-left: 0px" Height="19px">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" 
                            ControlToValidate="DDLFName" ErrorMessage="Select Faculty " 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
                <td align="right" style="height: 11px; width: 214px;">
                    <asp:Label ID="Label57" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Question :"></asp:Label>
                </td>
                <td align="left" style="height: 11px; " colspan="2">
                                <asp:DropDownList ID="DDLQuestion" runat="server" AutoPostBack="True" 
                            Width="74px" style="margin-left: 0px" Height="19px">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" 
                            ControlToValidate="DDLQuestion" ErrorMessage="Select Question" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 386px">
                    &nbsp;</td>
                <td align="left" colspan="4">
                                &nbsp;</td>
            </tr>
            <tr>
                <td align="center" style="height: 27px; " colspan="5">
                    <asp:Button ID="ButtSave" runat="server" Font-Bold="True" 
                            
                             style="height: 26px" Text="Save" Width="77px" onclick="ButtSave_Click" 
                        />
                        &nbsp;
                        <asp:Button ID="ButtReset" runat="server" CausesValidation="False" 
                            Font-Bold="True" Height="26px" 
                             Text="Reset" 
                            Width="69px"  />
                </td>
            </tr>
            </table>
 
</div>
</asp:Content>

