<%@ Page Language="C#" MasterPageFile="~/Administrator.master" AutoEventWireup="true" CodeFile="Section.aspx.cs" Inherits="Administrator_Section" Title="Student Feedback System" %>

<script runat="server">

   
   
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center" align="right">
 
        <table 
                align="center" dir="ltr">
            <tr>
                <td colspan="5" style="height: 2px" align="center">
                        &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="height: 27px; " colspan="5">
                        <table style="width: 100%">
                            <tr>
                                <td align="right" style="width: 270px">
                        <asp:Label ID="Label59" runat="server" Font-Bold="True" ForeColor="Black" 
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
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="3">
                    <asp:Panel ID="Panel1" runat="server">
                        <table class="style5">
                            <tr>
                                <td align="right" style="width: 270px">
                                    <asp:Label ID="Label60" runat="server" Font-Bold="True" ForeColor="Black" 
                                        Text="Admission Type :"></asp:Label>
                                </td>
                                <td align="left" style="width: 395px">
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" 
                                        Font-Bold="True" ForeColor="Black" Height="24px" RepeatDirection="Horizontal" 
                                        Width="367px" 
                                       
                                        style="margin-left: 0px" 
                                        onselectedindexchanged="RadioButtonList2_SelectedIndexChanged">
                                        <asp:ListItem>Regular</asp:ListItem>
                                        <asp:ListItem>Lateral Entry</asp:ListItem>
                                        <asp:ListItem>Transfer</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" 
                                        ControlToValidate="RadioButtonList2" ErrorMessage="Select Admission " 
                                        Font-Bold="True" Font-Size="Small" ValidationGroup="atype"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             </table>
                                 </asp:Panel>   
                                </td>
                                
                            </tr>
                       </table>
                    </td>
            </tr>
            <tr>
                <td align="right" style="width: 205px;" valign="top">
                                                    <asp:Label ID="Label61" runat="server" Font-Bold="True" ForeColor="Black" 
                                                        Text="Academic Year :"></asp:Label>
                </td>
                <td align="left" style="height: 25px; width: 196px;">
                                                    <asp:DropDownList ID="DDLYear0" runat="server" 
                        AutoPostBack="True" onselectedindexchanged="DDLYear_SelectedIndexChanged" 
                                                      >
                                                        <asp:ListItem>Select</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" 
                                                        ControlToValidate="DDLYear0" ErrorMessage="Select Year " 
                                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    <br />
                </td>
                <td align="right" style="width: 172px;" class="style38">
                    <asp:Label ID="Label55" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Branch Name : "></asp:Label>
                </td>
                <td align="left" style="height: 25px; width: 177px;">
                    <asp:DropDownList ID="DDLBName" runat="server" 
                            Height="20px" 
                        onselectedindexchanged="DDLBName_SelectedIndexChanged1" 
                        AutoPostBack="True">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                                                    <asp:Label ID="lblBranch" runat="server" Font-Bold="True"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" 
                            ControlToValidate="DDLBName" ErrorMessage="Select Branch Name" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic" 
                        InitialValue="Select"></asp:RequiredFieldValidator>
                </td>
                <td align="left" style="height: 25px; ">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width: 205px;" valign="top">
                            <asp:Label ID="Label57" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Section Wise Students :"></asp:Label>
                </td>
                <td align="left" valign="top" style="width: 196px">
                            <asp:TextBox ID="TBStud" runat="server" ></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" 
                            ControlToValidate="TBStud" ErrorMessage="Enter No of Students for Section" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                            <br />
                </td>
                <td align="right" style="width: 172px" class="style38" valign="top">
                    <asp:Label ID="lblnstud" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="No of Students :"></asp:Label>
                </td>
                <td align="left" valign="top">
                            <asp:Label ID="lbltotal" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td align="left" style="height: 25px; ">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                    <table style="width: 100%">
                        <tr>
                            <td align="right">
                                &nbsp;<asp:Label ID="Label58" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Section :"></asp:Label>
                            </td>
                            <td style="width: 504px" align="left">
                                <asp:DropDownList ID="DDLSection" runat="server" 
                            Height="20px" Width="92px" 
                                   >
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>D</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" 
                            ControlToValidate="DDLSection" ErrorMessage="Select Section" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 27px; " colspan="5">
                    <asp:Button ID="ButtSave" runat="server" Font-Bold="True" 
                            
                             style="height: 26px" Text="Save" Width="77px" 
                        onclick="ButtSave_Click" />
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

