<%@ Page Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeFile="FeedBack.aspx.cs" Inherits="Student_FeedBack" Title="Student Feedback System" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table style="width: 100%">
            <tr>
                <td style="height: 21px" align="center">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#FF0066"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
                       
                            <table style="width: 100%">
                                <tr>
                                    <td align="right" class="style20" style="width: 7%">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="False" 
                                            Font-Names="Microsoft Sans Serif" Font-Size="Small" ForeColor="Black" 
                                            ToolTip=" ">Faculty :</asp:Label>
                                    </td>
                                    <td style="width: 19%">
                                        <asp:Label ID="LblFName" runat="server" Font-Bold="True" 
                                            Font-Names="Microsoft Sans Serif" Font-Size="Small" ForeColor="#435C5B"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 10%">
                                        <asp:Label ID="Label6" runat="server" Font-Bold="False" 
                                            Font-Names="Microsoft Sans Serif" Font-Size="Small" ForeColor="Black">Subject 
                                        :</asp:Label>
                                    </td>
                                    <td style="width: 42%">
                                        <asp:Label ID="LblSubj" runat="server" Font-Bold="True" 
                                            Font-Names="Microsoft Sans Serif" Font-Size="Small" ForeColor="#435C5B"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 9%">
                                        <asp:Label ID="Label8" runat="server" Font-Bold="False" 
                                            Font-Names="Microsoft Sans Serif" Font-Size="Small" ForeColor="Black">Branch 
                                        :</asp:Label>
                                    </td>
                                    <td style="width: 121px">
                                        <asp:Label ID="LblBranch" runat="server" Font-Bold="True" 
                                            Font-Names="Microsoft Sans Serif" Font-Size="Small" ForeColor="#435C5B"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 10%">
                                        <asp:Label ID="Label10" runat="server" Font-Bold="False" 
                                            Font-Names="Microsoft Sans Serif" Font-Size="Small" ForeColor="Black">Section 
                                        :</asp:Label>
                                    </td>
                                    <td style="width: 16%">
                                        <asp:Label ID="LblSection" runat="server" Font-Bold="True" 
                                            Font-Names="Microsoft Sans Serif" Font-Size="Small" ForeColor="#435C5B"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="8">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                            CellPadding="4" ForeColor="#333333" GridLines="None" 
                                            onselectedindexchanged="GridView1_SelectedIndexChanged" Width="100%">
                                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#E3EAEB" Font-Size="Small" HorizontalAlign="Left" 
                                                Width="100%" />
                                            <Columns>
                                                <asp:BoundField DataField="Question" HeaderText="Question" />
                                                <asp:TemplateField HeaderText="Feedback">
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList ID="rblChoices" runat="server" 
                                                            RepeatDirection="Horizontal">
                                                            <asp:ListItem>Excellent</asp:ListItem>
                                                            <asp:ListItem>VeryGood</asp:ListItem>
                                                            <asp:ListItem>Good</asp:ListItem>
                                                            <asp:ListItem>Satisfactory</asp:ListItem>
                                                            <asp:ListItem>NotSatisfactory</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="rblChoices" Display="Dynamic"
                                                        EnableClientScript="false" EnableViewState="false" ErrorMessage="Required!" SetFocusOnError="true">
                                                        </asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                                                HorizontalAlign="Left" />
                                            <EditRowStyle BackColor="#7C6F57" Font-Size="X-Small" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                        <br />
                                        <asp:Button ID="ButtNext" runat="server" Font-Bold="True" 
                                            onclick="ButtNext_Click" Text="Next" />
                                        &nbsp;</td>
                                </tr>
                            </table>
                       
                            <br />
                            <br />
                            <center>
                                   </center>
                           <br />
                       
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            </table>
        <br />
    </center>
</asp:Content>

