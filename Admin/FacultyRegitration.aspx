<%@ Page Language="C#" MasterPageFile="~/Administrator.master" AutoEventWireup="true" CodeFile="FacultyRegitration.aspx.cs" Inherits="Administrator_FacultyRegitration" Title="Student Feedback System" %>

<script runat="server">

   
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <div style="text-align: center;" align="center">
            <table 
                align="center" width="100%">
                <tr>
                    <td colspan="4" style="height: 2px" align="center">
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; " colspan="4">
                        <table style="width: 100%">
                            <tr>
                                <td align="right">
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" 
                            ControlToValidate="RadioButtonList2" ErrorMessage="Select Course Name" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
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
                    <td align="right" style="height: 27px; width: 673px;">
                        <asp:Label ID="Label49" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Name :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 579px;">
                        <asp:TextBox ID="TBName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                            ControlToValidate="TBName" ErrorMessage="Enter Name" Font-Bold="True" 
                            Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" class="style6" style="width: 140px">
                        <asp:Label ID="Label52" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Department :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 840px;">
                        <asp:DropDownList ID="DDLDept" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DDLDept_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblDept" runat="server" Font-Bold="True"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" 
                            ControlToValidate="DDLDept" ErrorMessage="Select Department" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; width: 673px;">
                        <asp:Label ID="Label54" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Email Id :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 579px;">
                        <asp:TextBox ID="TBEmailId" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="TBEmailId" ErrorMessage="Plz Enter Valid format" 
                            Font-Bold="True" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            Font-Size="Small"></asp:RegularExpressionValidator>
                            
                    </td>
                    <td align="right" style="height: 27px; width: 140px;">
                        <asp:Label ID="Label55" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Mobile :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 840px;">
                        <asp:TextBox ID="TBMobile" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" 
                            ControlToValidate="TBMobile" ErrorMessage="Enter Mobile No" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="TBMobile" Display="Dynamic" ErrorMessage="Enter Digits(10)" 
                            Font-Bold="True" Font-Size="Small" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; width: 673px;">
                        <asp:Label ID="Label53" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Address :"></asp:Label>
                    </td>
                    <td align="left" style="height: 27px; width: 579px;">
                        <asp:TextBox ID="TBAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                            
                    </td>
                    <td align="right" style="height: 27px; width: 140px;">
                        <asp:Label ID="Label56" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Remarks :"></asp:Label>
                    </td>
                    <td align="left" style="width: 840px">
                        <asp:TextBox ID="TBRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; width: 673px;">
                        &nbsp;</td>
                    <td align="left" style="height: 27px; width: 579px;">
                        &nbsp;</td>
                    <td align="left" style="height: 27px; " colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" style="height: 27px; " colspan="4">
                        <asp:Button ID="Save" runat="server" Font-Bold="True" 
                            
                             style="height: 26px" Text="Save" Width="77px" onclick="Save_Click" />
                        &nbsp;
                        <asp:Button ID="Reset" runat="server" CausesValidation="False" 
                            Font-Bold="True" Height="26px" 
                             Text="Reset" 
                            Width="69px" onclick="Reset_Click"  />
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 27px; " colspan="4">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" onrowcommand="GridView1_RowCommand" 
                            onrowdeleting="GridView1_RowDeleting" 
                            onselectedindexchanged="GridView1_SelectedIndexChanged" 
                            onrowediting="GridView1_RowEditing">
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#E3EAEB" />
                              <Columns>
                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                 
                            </Columns>
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <asp:Label ID="lblMessage1" runat="server" Font-Bold="True" ForeColor="#FF3399"></asp:Label>
                    </td>
                </tr>
                </table>
        
    </div>
</asp:Content>

