<%@ Page Language="C#" MasterPageFile="~/Administrator.master" AutoEventWireup="true" CodeFile="AssignSubject.aspx.cs" Inherits="Administrator_AssignSubject" Title="Student Feedback System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center">
          <table 
                align="center" dir="ltr">
                <tr>
                    <td colspan="5" style="height: 2px" align="center">
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; " colspan="5">
                        <table style="width: 100%" align="right">
                            <tr>
                                <td align="right" style="width: 235px">
                        <asp:Label ID="Label50" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Course Name :"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
                            ControlToValidate="RadioButtonList1" ErrorMessage="Select Course Name" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 235px">
                                    &nbsp;</td>
                                <td align="right">
                                    &nbsp;</td>
                                <td align="left" style="width: 211px">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; width: 972px;">
                        <asp:Label ID="Label57" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Regulation :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 219px;">
                        <asp:DropDownList ID="DDLReg" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DDLReg_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="height: 27px; width: 306px;">
                        <asp:Label ID="Label58" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Academic Year  :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 97px;">
                        <asp:DropDownList ID="DDLYear0" runat="server" 
                           AutoPostBack="True" onselectedindexchanged="DDLYear0_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="left" style="height: 27px; width: 612px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" 
                            ControlToValidate="DDLYear0" ErrorMessage="Select Academic Year" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; width: 972px;">
                        <asp:Label ID="Label49" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Branch Name :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 219px;">
                    &nbsp;<asp:DropDownList ID="DDLBName" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DDLBName_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                                                    <asp:Label ID="lblBranch" runat="server" Font-Bold="True"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                            ControlToValidate="DDLBName" ErrorMessage="Select Branch" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" style="height: 27px; width: 306px;">
                        <asp:Label ID="Label56" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Section :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 97px;">
                        <asp:DropDownList ID="DDLSection" runat="server" 
                            onselectedindexchanged="DDLSection_SelectedIndexChanged" 
                            AutoPostBack="True">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="left" style="height: 27px; width: 612px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" 
                            ControlToValidate="DDLSection" ErrorMessage="Select Section" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; width: 972px;">
                                <asp:Label ID="Label51" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Year :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 219px;">
                                <asp:DropDownList ID="DDLYear" runat="server" AutoPostBack="True" style="margin-left: 2px" 
                                    onselectedindexchanged="DDLYear_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" 
                            ControlToValidate="DDLYear" ErrorMessage="Select Year" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" style="height: 27px; width: 306px;">
                                <asp:Label ID="lblsem" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Semester :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 97px;">
                        <asp:DropDownList ID="DDLSemester" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DDLSemester_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="left" style="height: 27px; width: 612px;">
                                <asp:RequiredFieldValidator ID="RFVSem" runat="server" 
                            ControlToValidate="DDLSemester" ErrorMessage="Select Semister" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                   <tr>
                                <td align="right" style=" width: 972px; " valign="top">
                        <asp:Label ID="Label59" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Department :"></asp:Label>
                                </td>
                                <td align="left" style="height: 24px; width: 219px;">
                                    <asp:DropDownList ID="DDLDept" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="DDLDept_SelectedIndexChanged1">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" 
                            ControlToValidate="DDLDept" ErrorMessage="Select Department" 
                            Font-Bold="True" Font-Size="Small" InitialValue="Select"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" valign="top" style="width: 306px" class="style46">
                                    <asp:Label ID="Label54" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Faculty Name :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:DropDownList ID="DDLFName" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="height: 24px; ">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" 
                            ControlToValidate="DDLFName" ErrorMessage="Select Faculty Name" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                   <tr>
                    <td align="right" style="height: 25px; width: 972px;">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Subject :"></asp:Label>
                                </td>
                    <td align="left" style="height: 25px; width: 219px;">
                        <asp:DropDownList ID="DDLSubject" runat="server">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="DDLSubject" ErrorMessage="Select Subject" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                    <td align="left" style="height: 25px; width: 306px;">
                        &nbsp;</td>
                    <td align="left" style="height: 25px; width: 97px;">
                        &nbsp;</td>
                    <td align="left" style="height: 25px; ">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" style="height: 27px; " colspan="5">
                        <asp:Button ID="ButtSave" runat="server" Font-Bold="True" 
                            
                             style="height: 26px" Text="Save" Width="77px" onclick="ButtSave_Click" />
                        &nbsp;
                        <asp:Button ID="ButtReset" runat="server" CausesValidation="False" 
                            Font-Bold="True" Height="26px" 
                             Text="Reset" 
                            Width="69px" onclick="ButtReset_Click"  />
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 347px; " colspan="5">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                            ForeColor="#333333" GridLines="None" Width="80%" 
                            onrowcommand="GridView1_RowCommand" onrowdeleting="GridView1_RowDeleting" 
                           >
                            <PagerSettings Mode="NextPreviousFirstLast" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#E3EAEB" />
                             <Columns>
                                <asp:CommandField HeaderText="Select" ShowDeleteButton="True" />
                            </Columns>
                            <PagerStyle BackColor="Silver" ForeColor="White" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </div>
</asp:Content>

