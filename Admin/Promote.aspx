<%@ Page Language="C#" MasterPageFile="~/Administrator.master" AutoEventWireup="true" CodeFile="Promote.aspx.cs" Inherits="Administrator_Promote" Title="Student Feedback System" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center">
<script>
Function showconfirm()
{
if(confirm("Are you sure")==true)
{
return true;

}
else
{
return false;

}
}

</script>    
        <table 
                align="center">
            <tr>
                <td colspan="5" style="height: 2px" align="center">
                        &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="height: 27px; " colspan="5">
                        <table style="width: 100%; height: 25px;">
                            <tr>
                                <td align="right" style="width: 294px">
                        <asp:Label ID="Label57" runat="server" Font-Bold="True" ForeColor="Black" 
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
                                    <asp:Panel ID="Panel2" runat="server">
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label60" runat="server" Font-Bold="True" ForeColor="Black" 
                                                        Text="Admission Type :"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 367px">
                                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" 
                                                        Font-Bold="True" ForeColor="Black" Height="24px" 
                                                        onselectedindexchanged="RadioButtonList2_SelectedIndexChanged" 
                                                        RepeatDirection="Horizontal" style="margin-left: 0px" Width="367px">
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
                <td align="right" style="height: 27px; width: 1192px;">
                        <asp:Label ID="Label61" runat="server" Font-Bold="True" ForeColor="Black" 
                            Text="Academic Year :"></asp:Label>
                </td>
                <td align="left" style="height: 27px; width: 823px;">
                                                    <asp:DropDownList ID="DDLYear0" runat="server" 
                        AutoPostBack="True" onselectedindexchanged="DDLYear0_SelectedIndexChanged" 
                                                        
                            >
                                                        <asp:ListItem>Select</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" 
                                                        ControlToValidate="DDLYear0" ErrorMessage="Select Academic Year " 
                                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
                <td align="right" style="height: 27px; width: 400px;">
                    <asp:Label ID="Label49" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Branch Name :"></asp:Label>
                </td>
                <td align="left" style="height: 27px; width: 961px;">
                    <asp:DropDownList ID="DDLBName" runat="server" AutoPostBack="True" 
                            Height="20px" 
                        onselectedindexchanged="DDLBName_SelectedIndexChanged">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblBranch" runat="server" Font-Bold="True"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                            ControlToValidate="DDLBName" ErrorMessage="Select Branch" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
                <td align="left" style="height: 27px; width: 612px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="height: 27px; width: 1192px;">
                                <asp:Label ID="Label51" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Year :"></asp:Label>
                </td>
                <td align="left" style="height: 27px; width: 823px;">
                                <asp:DropDownList ID="DDLYear" runat="server" AutoPostBack="True" Height="20px" 
                                        Width="92px" style="margin-left: 2px" 
                                    onselectedindexchanged="DDLYear_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" 
                            ControlToValidate="DDLYear" ErrorMessage="Select Year" 
                            Font-Bold="True" Display="Dynamic" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
                <td align="right" style="height: 27px; width: 400px;">
                                <asp:Label ID="lblsem" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Semester :"></asp:Label>
                </td>
                <td align="left" style="height: 27px; width: 961px;">
                                <asp:DropDownList ID="DDLSemester" runat="server" 
                            Width="74px" style="margin-left: 0px" Height="19px">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" 
                            ControlToValidate="DDLSemester" ErrorMessage="Select Semister" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
                <td align="left" style="height: 27px; width: 612px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="height: 27px; width: 1192px;">
                    <asp:Label ID="Label53" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Section :"></asp:Label>
                </td>
                <td align="left" style="height: 27px; width: 823px;">
                    <asp:DropDownList ID="DDLSection" runat="server" 
                            Width="69px" style="margin-left: 0px" Height="20px">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" 
                            ControlToValidate="DDLSection" ErrorMessage="Select Section" 
                            Display="Dynamic" Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
                <td align="right" style="height: 27px; width: 400px;">
                                &nbsp;</td>
                <td align="left" style="height: 27px; width: 961px;">
                                &nbsp;</td>
                <td align="left" style="height: 27px; width: 612px;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" style="height: 27px; " colspan="5">
                    <asp:Button ID="Submit" runat="server" Font-Bold="True" 
                            
                             style="height: 26px" Text="Submit" Width="77px" 
                        onclick="Submit_Click" />
                        &nbsp;
                        <asp:Button ID="Reset" runat="server" CausesValidation="False" 
                            Font-Bold="True" Height="26px" 
                             Text="Reset" 
                            Width="69px" onclick="Reset_Click"  />
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 21px; " colspan="5">
                    <asp:Panel ID="Panel1" runat="server" Height="571px">
                        <table style="width: 100%; height: 550px;" align="left">
                            <tr>
                                <td colspan="5" align="center">
                                    <asp:Button ID="ButtPromote1" runat="server" Font-Bold="True" style="height: 26px; margin-bottom: 0px;" 
                                        Text="Promote" Width="71px" Height="26px" onclick="ButtPromote1_Click" 
                                        onclientclick="return confirm('Are You Sure?');" />
                                    &nbsp;
                                    <asp:Button ID="BtnDelete1" runat="server" Font-Bold="True" 
                                        onclick="BtnDelete1_Click" Text="Delete" CausesValidation="False" />
                                    </td>
                            </tr>
                            <tr>
                                <td class="style52" style="width: 1193px" align="right">
                                    <asp:Label ID="Label58" runat="server" Font-Bold="True" ForeColor="Black" 
                                        Text="Select :"></asp:Label>
                                </td>
                                <td align="left" class="style52" style="height: 33px; width: 32%">
                                    <asp:LinkButton ID="LBAll" runat="server" Font-Bold="True" 
                                        Font-Names="Comic Sans MS" OnClick="LinkButton1_Click" Width="27px"> All
                                    </asp:LinkButton>
                                    <b>,&nbsp; </b>
                                    <asp:LinkButton ID="LBNone" runat="server" Font-Bold="True" 
                                        Font-Names="Comic Sans MS" OnClick="LinkButton2_Click" style="margin-left: 0px" 
                                        Width="41px">None</asp:LinkButton>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left" style="width: 225px">
                                    &nbsp;</td>
                                <td align="left" style="width: 8%; height: 33px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">
                                    <asp:Label ID="LBLMessage" runat="server" Font-Bold="True" ForeColor="#FF3399"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                        GridLines="None" Height="294px" 
                                        onpageindexchanging="GridView1_PageIndexChanging" Width="70%" 
                                        onselectedindexchanged="GridView1_SelectedIndexChanged">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkbox" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSid" runat="server" Text='<%# Eval("StudentId") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Course Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSid1" runat="server" Text='<%# Eval("CourseName") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Branch Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSid2" runat="server" Text='<%# Eval("BranchName") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Section">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSid3" runat="server" Text='<%# Eval("Section") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Year">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSid4" runat="server" Text='<%# Eval("Year") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings Mode="NextPreviousFirstLast" />
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#E3EAEB" />
                                        <PagerStyle BackColor="Silver" ForeColor="White" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#7C6F57" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                    <asp:Label ID="LBLMessage0" runat="server" Font-Bold="True" ForeColor="#FF0066"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">
                                    <asp:Button ID="ButtPromote2" runat="server" Font-Bold="True" 
                                        onclick="ButtPromote2_Click" onclientclick="return confirm('Are You Sure?');" 
                                        style="height: 26px" Text="Promote" Width="77px" />
                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="BtnDelete2" runat="server" Font-Bold="True" 
                                        onclick="BtnDelete2_Click" Text="Delete" CausesValidation="False" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            </table>
    
</div>
</asp:Content>

