<%@ Page Language="C#" MasterPageFile="~/Administrator.master" AutoEventWireup="true" CodeFile="Charts1.aspx.cs" Inherits="Admin_Charts1" Title="Student Feedback System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center">
              <table 
                align="center" style="width: 879px">
                <tr>
                    <td colspan="4" style="height: 2px" align="center">
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; " colspan="4">
                        <table style="width: 100%">
                            <tr>
                                <td align="right" style="width: 252px">
                                    <asp:Label ID="Label54" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Course Name :"></asp:Label>
                                </td>
                                <td align="left" style="width: 350px">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                            Font-Bold="True" ForeColor="Black" Height="16px" RepeatDirection="Horizontal" 
                            Width="340px" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                        style="margin-left: 0px">
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
                                <td align="right" style="width: 252px">
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
                    <td align="right" style="width: 251px;" valign="middle" class="style38">
                                                    <asp:Label ID="Label61" runat="server" Font-Bold="True" ForeColor="Black" 
                                                        Text="Academic Year :"></asp:Label>
                    </td>
                    <td align="left" valign="top" style="width: 182px">
                                                    <asp:DropDownList ID="DDLYear0" runat="server" 
                                                        onselectedindexchanged="DDLYear0_SelectedIndexChanged" AutoPostBack="True" 
                                                        
                           >
                                                        <asp:ListItem>Select</asp:ListItem>
                                                    </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" 
                            ControlToValidate="DDLYear0" ErrorMessage="Select Academic Year" 
                            Display="Dynamic" Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                    <td align="right" valign="top" style="width: 102px">
                        <asp:Label ID="Label49" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Branch Name :"></asp:Label>
                    </td>
                    <td align="left" valign="top">
                        <asp:DropDownList ID="DDLBName" runat="server" AutoPostBack="True" 
                            Height="20px" 
                            onselectedindexchanged="DDLBName_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblBranch" runat="server" Font-Bold="True"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                            ControlToValidate="DDLBName" ErrorMessage="Select Branch Name" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 251px; " valign="middle" class="style38">
                        <asp:Label ID="Label51" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Year :"></asp:Label>
                    </td>
                    <td align="left" style="width: 182px; ">
                        <asp:DropDownList ID="DDLYear" runat="server" AutoPostBack="True" Height="20px" style="margin-left: 2px" 
                            onselectedindexchanged="DDLYear_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" 
                            ControlToValidate="DDLYear" ErrorMessage="Select Year" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" valign="middle">
                        <asp:Label ID="lblsem" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Semester :"></asp:Label>
                    </td>
                    <td align="left" class="style40" style="width: 304px">
                        <asp:DropDownList ID="DDLSemester" runat="server" AutoPostBack="True" 
                            style="margin-left: 0px" Height="19px" onselectedindexchanged="DDLSemester_SelectedIndexChanged" 
                            >
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" 
                            ControlToValidate="DDLSemester" ErrorMessage="Select Semister" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; width: 251px;">
                        <asp:Label ID="Label53" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Section :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 182px;">
                        <asp:DropDownList ID="DDLSection" runat="server" AutoPostBack="True" 
                            style="margin-left: 0px" Height="20px" onselectedindexchanged="DDLSection_SelectedIndexChanged" 
                            >
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" 
                            ControlToValidate="DDLSection" ErrorMessage="Select Section" 
                            Display="Dynamic" Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                    <td align="right" style="height: 27px; width: 102px;">
                        <asp:Label ID="Label55" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Faculty Name :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px">
                        <asp:DropDownList ID="DDLFName" runat="server" AutoPostBack="True" 
                            style="margin-left: 0px" Height="19px" 
                            onselectedindexchanged="DDLFName_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" 
                            ControlToValidate="DDLFName" ErrorMessage="Select Faculty " 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 25px; width: 251px;">
                        <asp:Label ID="Label62" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Subject :"></asp:Label>
                    </td>
                    <td align="left" style="height: 25px; " colspan="3">
                        <asp:DropDownList ID="DDLsubject" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DDLsubject_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" 
                            ControlToValidate="DDLsubject" ErrorMessage="Select Subject" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 251px;" valign="top" class="style38">
                        <asp:Label ID="Label57" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Question :"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="DDLQuestion" runat="server" 
                            style="margin-left: 0px" onselectedindexchanged="DDLQuestion_SelectedIndexChanged" 
                            >
                            <asp:ListItem>Select All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 27px; " colspan="4">
                        <asp:Button ID="ButtSubmit" runat="server" Font-Bold="True" 
                            
                             style="height: 26px" Text="Submit" Width="77px" onclick="ButtSubmit_Click"  
                        />
                        &nbsp;
                        <asp:Button ID="ButtReset" runat="server" CausesValidation="False" 
                            Font-Bold="True" Height="26px" 
                             Text="Reset" 
                            Width="69px" onclick="ButtReset_Click"  />
                    </td>
                </tr>
                </table>
        
    </div>
</asp:Content>

