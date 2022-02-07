<%@ Page Language="C#" MasterPageFile="~/Administrator.master" AutoEventWireup="true" CodeFile="FeedBackQuestions.aspx.cs" Inherits="Administrator_AddFeedBackSystem" Title="Student Feedback System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center; ">
       
            <table 
                align="center" style="height: 230px; width: 100%">
                <tr>
                    <td align="right" style="height: 27px; width: 403px;">
                        &nbsp;</td>
                    <td align="left" style="height: 27px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; " colspan="2">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 413px">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                            Text="Add Your Questions :"></asp:Label>
                                </td>
                                <td align="left">
                        <asp:TextBox ID="TextBox2" runat="server" Width="272px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 27px; " colspan="2">
                        <asp:Button ID="Button4" runat="server" Font-Bold="True" 
                            
                             style="height: 26px" Text="Save" Width="77px" onclick="Button4_Click" 
                            Height="26px" />
                        &nbsp;
                        <asp:Button ID="Button6" runat="server" CausesValidation="False" 
                            Font-Bold="True" Height="26px" 
                             Text="Reset" 
                            Width="69px" onclick="Button6_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 27px; " colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" style="height: 27px; " colspan="2">
                        <asp:GridView ID="GridView1" runat="server" Height="127px" 
                            onrowcommand="GridView1_RowCommand" onrowdeleting="GridView1_RowDeleting" 
                            CellPadding="4" ForeColor="#333333" GridLines="None" 
                           >
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#E3EAEB" />
                            <Columns>
                                <asp:CommandField HeaderText="Select Question" ShowDeleteButton="True" />
                            </Columns>
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
            </table>
       
    </div>
</asp:Content>

