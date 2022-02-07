<%@ Page Language="C#" MasterPageFile="~/Administrator.master" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="Administrator_Student" Title="Student Feedback System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center">
    
        <table 
                align="center" dir="ltr">
            <tr>
                <td align="right" style="height: 27px; " colspan="3">
                        &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="height: 28px; width: 539px;">
                    <asp:Label ID="Label50" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Course Name :"></asp:Label>
                </td>
                <td align="left" style="height: 28px; width: 431px;">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                            Font-Bold="True" ForeColor="Black" Height="24px" RepeatDirection="Horizontal" 
                            Width="367px" style="margin-left: 0px" 
                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem>B.Tech</asp:ListItem>
                        <asp:ListItem>M.Tech</asp:ListItem>
                        <asp:ListItem>MCA</asp:ListItem>
                        <asp:ListItem>MBA</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="left" style="height: 28px; width: 612px;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
                            ControlToValidate="RadioButtonList1" ErrorMessage="Select Course" 
                            Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 28px; " colspan="3">
                    <asp:Panel ID="Panel1" runat="server">
                        <table class="style5">
                            <tr>
                                <td align="right" style="width: 253px">
                                    <asp:Label ID="Label59" runat="server" Font-Bold="True" ForeColor="Black" 
                                        Text="Admission Type :"></asp:Label>
                                </td>
                                <td align="left" style="width: 395px">
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" 
                                        Font-Bold="True" ForeColor="Black" Height="24px" RepeatDirection="Horizontal" 
                                        Width="367px" 
                                        onselectedindexchanged="RadioButtonList2_SelectedIndexChanged" 
                                        style="margin-left: 0px">
                                        <asp:ListItem>Regular</asp:ListItem>
                                        <asp:ListItem>Lateral Entry</asp:ListItem>
                                        <asp:ListItem>Transfer</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" 
                                        ControlToValidate="RadioButtonList1" ErrorMessage="Select Admission " 
                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            </table>
                             </asp:Panel>
                             </td>
                             </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Panel ID="Panel2" runat="server">
                                        <table class="style5">
                                            <tr>
                                                <td align="right" style="width: 253px">
                                                    <asp:Label ID="Label60" runat="server" Font-Bold="True" ForeColor="Black" 
                                                        Text="Branch Name :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DDLBName" runat="server" 
                                                        onselectedindexchanged="DDLBName_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblBranch" runat="server" Font-Bold="True"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" 
                                                        ControlToValidate="DDLBName" ErrorMessage="Select Admission " 
                                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 253px">
                                                    <asp:Label ID="Label61" runat="server" Font-Bold="True" ForeColor="Black" 
                                                        Text="Academic Year :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DDLYear" runat="server" 
                                                        onselectedindexchanged="DDLYear_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" 
                                                        ControlToValidate="DDLYear" ErrorMessage="Select Year " 
                                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 253px">
                                                    <asp:Label ID="Label62" runat="server" Font-Bold="True" ForeColor="Black" 
                                                        Text="No of Students :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TBStud" runat="server" AutoPostBack="True" MaxLength="3" 
                                                        ontextchanged="TBStud_TextChanged"></asp:TextBox>
                                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" 
                                                        ControlToValidate="TBStud" ErrorMessage="Enter No of Students" 
                                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                        ControlToValidate="TBStud" ErrorMessage="Enter Digits(3)" Font-Bold="True" 
                                                        Font-Size="Small" ValidationExpression="\d{2,3}"></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="3">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="ButtRSave" runat="server" Font-Bold="True" style="height: 26px" 
                                                        Text="Save" Width="77px" onclick="ButtRSave_Click" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButtRReset" runat="server" CausesValidation="False" 
                                                        Font-Bold="True" Height="26px" Text="Reset" Width="69px" 
                                                        onclick="ButtRReset_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        
                   
               
            <tr>
                <td align="center" style="height: 27px; " colspan="3">
                    <asp:Panel ID="Panel3" runat="server">
                        <table class="style5">
                            <tr>
                                <td align="right" style="width: 250px">
                                    <asp:Label ID="Label63" runat="server" Font-Bold="True" ForeColor="Black" 
                                        Text="Student Id :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TBSID" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                        ControlToValidate="TBSID" ErrorMessage="Enter Id(10)" Font-Bold="True" 
                                        Font-Size="Small" ValidationExpression="^[A-Z,a-z,0-9]{10}"></asp:RegularExpressionValidator>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" 
                                        ControlToValidate="TBSID" ErrorMessage="Select Studnet Id" 
                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 250px">
                                    <asp:Label ID="Label64" runat="server" Font-Bold="True" ForeColor="Black" 
                                        Text="Branch Name :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLLBName" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" 
                                        ControlToValidate="DDLLBName" ErrorMessage="Select Year " 
                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 250px">
                                    <asp:Label ID="Label65" runat="server" Font-Bold="True" ForeColor="Black" 
                                        Text="Academic Year :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLLYear" runat="server" 
                                        onselectedindexchanged="DDLLYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" 
                                        ControlToValidate="DDLLYear" ErrorMessage="Enter No of Students" 
                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                    <asp:Button ID="ButtLSave" runat="server" Font-Bold="True" style="height: 26px" 
                                        Text="Save" Width="77px" onclick="ButtLSave_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButtLReset" runat="server" CausesValidation="False" 
                                        Font-Bold="True" Height="26px" Text="Reset" Width="69px" 
                                        onclick="ButtLReset_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 21px; " colspan="3">
                    <asp:Panel ID="Panel4" runat="server">
                        <table class="style5">
                            <tr>
                                <td align="right" style="width: 249px">
                                    <asp:Label ID="Label66" runat="server" Font-Bold="True" ForeColor="Black" 
                                        Text="Student Id  :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TBTSId" runat="server"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" 
                                        ControlToValidate="TBTSId" ErrorMessage="Select Studnet Id" 
                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 249px">
                                    <asp:Label ID="Label67" runat="server" Font-Bold="True" ForeColor="Black" 
                                        Text="Branch Name :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLTBName" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" 
                                        ControlToValidate="DDLTBName" ErrorMessage="Select Year " 
                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 249px">
                                    <asp:Label ID="Label68" runat="server" Font-Bold="True" ForeColor="Black" 
                                        Text="Academic Year :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DDLTYear" runat="server" onselectedindexchanged="DDLTYear_SelectedIndexChanged" 
                                        >
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="ButttSave" runat="server" Font-Bold="True" style="height: 26px" 
                                        Text="Save" Width="77px" onclick="ButttSave_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButtReset" runat="server" CausesValidation="False" 
                                        Font-Bold="True" Height="26px" Text="Reset" Width="69px" 
                                        onclick="ButtReset_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    
</div>
</asp:Content>

