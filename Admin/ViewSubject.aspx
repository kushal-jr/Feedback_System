<%@ Page Language="C#" MasterPageFile="~/Administrator.master" AutoEventWireup="true" CodeFile="ViewSubject.aspx.cs" Inherits="Administrator_ViewSubject" Title="Student Feedback System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
        <div style="text-align: center; " align="center">
            <table 
                align="center">
                <tr>
                    <td colspan="4" style="height: 2px" align="center">
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; " colspan="4">
                        <table style="width: 100%">
                            <tr>
                                <td align="right" style="width: 254px">
                                    <asp:Label ID="Label57" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Course Name :"></asp:Label>
                                </td>
                                <td align="left" style="width: 350px">
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" 
                            Font-Bold="True" ForeColor="Black" Height="24px" RepeatDirection="Horizontal" 
                            Width="422px" onselectedindexchanged="RadioButtonList2_SelectedIndexChanged">
                                        <asp:ListItem>B.Tech</asp:ListItem>
                                        <asp:ListItem>M.Tech</asp:ListItem>
                                        <asp:ListItem>MCA</asp:ListItem>
                                        <asp:ListItem>MBA</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" 
                            ControlToValidate="RadioButtonList2" ErrorMessage="Select Course Name" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 254px">
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
                    <td align="right" style="height: 27px; width: 692px;">
                        <asp:Label ID="Label49" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Branch Name :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 681px;">
                        <asp:DropDownList ID="DDLBName" runat="server" AutoPostBack="True" 
                            Height="20px" Width="92px" 
                            onselectedindexchanged="DDLBName_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                    &nbsp;<asp:Label ID="lblBranch" runat="server" Font-Bold="True"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                            ControlToValidate="DDLBName" ErrorMessage="Select Branch Name" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" style="height: 27px; width: 214px;">
                        <asp:Label ID="Label59" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Regulation :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 612px;">
                        <asp:DropDownList ID="DDLReg" runat="server" AutoPostBack="True" 
                            Width="69px" style="margin-left: 2px" Height="20px" 
                            onselectedindexchanged="DDLReg_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" 
                            ControlToValidate="DDLReg" ErrorMessage="Select Regulation" 
                            Display="Dynamic" Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; width: 692px;">
                        <asp:Label ID="Label51" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Year :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 681px;">
                        <asp:DropDownList ID="DDLYear" runat="server" AutoPostBack="True" Height="20px" 
                                        Width="92px" style="margin-left: 2px" 
                            onselectedindexchanged="DDLYear_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" 
                            ControlToValidate="DDLYear" ErrorMessage="Select Year" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" style="height: 27px; width: 214px;">
                        <asp:Label ID="Lblsem" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Semister :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 612px;">
                        <asp:DropDownList ID="DDLSem" runat="server" AutoPostBack="True" 
                            Width="69px" style="margin-left: 2px" Height="20px" 
                            onselectedindexchanged="DDLSem_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" 
                            ControlToValidate="DDLSem" ErrorMessage="Select Semister" 
                            Font-Bold="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 27px; " colspan="4">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" Width="80%" onrowcommand="GridView1_RowCommand" 
                            onrowdeleting="GridView1_RowDeleting">
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#E3EAEB" Wrap="True" HorizontalAlign="Left" />
                           <Columns>
                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                            </Columns>
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <asp:Label ID="lblMessage1" runat="server" Font-Bold="True" ForeColor="#FF33CC"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                            Font-Bold="True" PostBackUrl="~/Admin/Subject.aspx" Text="Back" />
                    </td>
                </tr>
            </table>
        
    </div>
</asp:Content>

