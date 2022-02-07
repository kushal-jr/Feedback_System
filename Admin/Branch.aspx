<%@ Page Language="C#" MasterPageFile="~/Administrator.master" AutoEventWireup="true" CodeFile="Branch.aspx.cs" Inherits="Administrator_Branch" Title="Student Feedback System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center;">
       
            <table 
                align="center" width="100%">
                <tr  align ="center">
                    <td align="left" style=" " colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" >
                <asp:Label ID="Label50" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Course Name :"></asp:Label>
                    </td>
                    <td align="left" style="width: 207px" >
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                            Font-Bold="True" ForeColor="Black" Height="24px" RepeatDirection="Horizontal" 
                            Width="217px" 
                            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                            <asp:ListItem>B.Tech</asp:ListItem>
                            <asp:ListItem>M.Tech</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
                            ControlToValidate="RadioButtonList1" ErrorMessage="Select Course" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" >
                <asp:Label ID="Label49" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Branch Name :"></asp:Label>
                    </td>
                    <td align="left" style="width: 207px" >
                        <asp:TextBox ID="BName" runat="server"></asp:TextBox>
                    </td>
                    <td align="left" >
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                            ControlToValidate="BName" ErrorMessage="Enter Branch Name" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                <asp:Label ID="Label51" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Branch Code :"></asp:Label>
                    </td>
                    <td align="left" style="width: 207px">
                        <asp:TextBox ID="BCode" runat="server" Columns="2"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" 
                            ControlToValidate="BCode" ErrorMessage="Enter Branch Code" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" >
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="BCode" Display="Dynamic" ErrorMessage="Enter Digits Only" 
                            Font-Bold="True" ValidationExpression="\d{2}" Font-Size="Small"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Button ID="ButtSave" runat="server" Font-Bold="True" 
                            
                             style="height: 26px" Text="Save" Width="77px" onclick="ButtSave_Click" />
                    &nbsp;
                        &nbsp;
                        <asp:Button ID="ButtReset" runat="server" CausesValidation="False" 
                            Font-Bold="True" Height="26px" 
                             Text="Reset" 
                            Width="69px" onclick="ButtReset_Click"  />
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 27px; " colspan="3">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="4" 
                            ForeColor="#333333" GridLines="None" Width="462px" Height="16px" 
                            onrowcommand="GridView1_RowCommand" onrowdeleting="GridView1_RowDeleting">
                            <FooterStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#E3EAEB" />
                            <Columns>
                                <asp:CommandField HeaderText="Select Branch" ShowDeleteButton="True" />
                            </Columns>
                            <PagerStyle BackColor="Silver" ForeColor="White" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <asp:Label ID="lblMessage1" runat="server" Font-Bold="True" ForeColor="Fuchsia"></asp:Label>
                    </td>
                </tr>
                </table>
       
    </div>
</asp:Content>

