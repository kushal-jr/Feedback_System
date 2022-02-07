<%@ Page Language="C#" MasterPageFile="~/Administrator.master" AutoEventWireup="true" CodeFile="Assessment.aspx.cs" Inherits="Admin_Assessment" Title="Student Feedback System" %>

<script runat="server">

  
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center">
        <div style="text-align: center">
            <table style="width: 100%">
                <tr>
                    <td colspan="6">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label30" runat="server" Font-Bold="True" Font-Names="Candara" 
                            Font-Size="X-Large" ForeColor="Maroon" Text="View Assessment Details" 
                            Width="424px"></asp:Label>
                            &nbsp;</td>
                    <td>
                           <b> <input type="button" value="Print" onclick="window.print();" 
                            style="background-color: #69918F" /> </b></td>
                </tr>
                <tr>
                    <td align="right" colspan="7" style="height: 27px">
                        <div style="text-align: center">
                            <table width="100%">
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;The Following is the assessment of students mentioned againest 
                                        their names for the subjects taught by the faculty.The Faculty are adviced to 
                                        take more interest int the preparation of the class notes,delivery,problem 
                                        solving and giving tutorials to enhance the subject knowledge to the students.</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="color: #FF0000">
                                        <b>The faculty members whose assessment is less than 
                                        <span style="font-size: large">&nbsp;65%</span> are adviced to improve their 
                                        performance.</b></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="7">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" colspan="7">
                        <table style="width: 100%" align="right">
                            <tr>
                                <td align="right" style="width: 235px">
                        <asp:Label ID="Label50" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Course Name :"></asp:Label>
                                </td>
                                <td align="left">
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
                                <td align="right" colspan="3">
                                    &nbsp;</td>
                            </tr>
                        </table>
                                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; width: 490px;">
                        <asp:Label ID="Label61" runat="server" Font-Bold="True" ForeColor="Black" 
                            Text="Academic Year :"></asp:Label>
                    </td>
                    <td align="left" style="width: 173px;" class="style36">
                                                    <asp:DropDownList ID="DDLYear0" runat="server" AutoPostBack="True" onselectedindexchanged="DDLYear0_SelectedIndexChanged" 
                                                        
                            >
                                                        <asp:ListItem>Select</asp:ListItem>
                                                    </asp:DropDownList>
                    </td>
                    <td align="left" style="width: 124px;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" 
                                                        ControlToValidate="DDLYear0" ErrorMessage="Select Academic Year " 
                                                        Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" class="style36" style="width: 107px">
                        <asp:Label ID="Label57" runat="server" Font-Bold="True" ForeColor="Black" 
                            Text="Branch :"></asp:Label>
                    </td>
                    <td align="left" style="width: 362px;" class="style35" valign="middle">
                        <asp:DropDownList ID="DDLBName" runat="server" AutoPostBack="True" onselectedindexchanged="DDLBName_SelectedIndexChanged" 
                         >
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                                                    <asp:Label ID="lblBranch" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td align="left" style="width: 148px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="DDLBName" ErrorMessage="Select Branch" 
                            InitialValue="Select" Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" style="height: 27px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; width: 490px;">
                        <asp:Label ID="Label58" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Year :"></asp:Label>
                    </td>
                    <td align="left" style="width: 173px;" class="style36">
                        <asp:DropDownList ID="DDLYear" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DDLYear_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="left" style="width: 124px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="DDLYear" ErrorMessage="Select Year" 
                            InitialValue="Select" Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" style="width: 107px;" class="style36">
                        <asp:Label ID="lblsem" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Semester :"></asp:Label>
                    </td>
                    <td align="left" style="width: 362px;" class="style35">
                        <asp:DropDownList ID="DDLSemester" runat="server" 
                            onselectedindexchanged="DDLSemester_SelectedIndexChanged" 
                            AutoPostBack="True">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="left" style="width: 148px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="DDLSemester" ErrorMessage="Select Semester" 
                            InitialValue="Select" Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" style="height: 27px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="height: 27px; width: 490px;">
                                                    
                        <asp:Label ID="Label60" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Section :"></asp:Label>
                                                    
                    </td>
                    <td align="left" style="width: 173px;" class="style36">
                        <asp:DropDownList ID="DDLSection" runat="server" 
                            onselectedindexchanged="DDLSection_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="left" style="width: 124px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" 
                            ControlToValidate="DDLSection" ErrorMessage="Select Section" 
                            InitialValue="Select" Font-Bold="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" style="width: 107px;" class="style36">
                        
                    </td>
                    <td align="left" style="width: 362px;" class="style35">
                        &nbsp;</td>
                    <td align="left" style="width: 148px">
                        &nbsp;</td>
                    <td align="left" style="height: 27px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="7">
                        <asp:Button ID="ButtSubmit" runat="server" Font-Bold="True" Height="26px" 
                            Text="Submit" Width="77px" onclick="ButtSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 490px">
                        &nbsp;</td>
                    <td align="left" style="height: 27px; width: 173px;">
                        &nbsp;</td>
                    <td align="left" style="height: 27px; width: 124px;">
                        &nbsp;</td>
                    <td align="left" style="height: 27px; width: 107px;">
                        &nbsp;</td>
                    <td align="left" style="height: 27px; width: 362px;">
                        &nbsp;</td>
                    <td align="left" style="height: 27px; width: 148px;">
                        &nbsp;</td>
                    <td align="left" style="height: 27px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="7">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" AutoGenerateColumns="False" 
                            ondatabound="GridView1_DataBound" Width="80%" >
                            <Columns>

                            <asp:BoundField DataField="FacultyName" HeaderText="FacultyName" />
                            <asp:BoundField DataField="Department" HeaderText="Department" />
                          <%--  <asp:BoundField DataField="Section" HeaderText="Section" />
                            <asp:BoundField DataField="Year" HeaderText="Year" />
                             <asp:BoundField DataField="Semester" HeaderText="Semester" />--%>
                            <asp:BoundField DataField="Subject" HeaderText="Subject" />
                            <asp:BoundField DataField="Percentage" HeaderText="Percentage(%)" />
</Columns> 
                                       
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" />
                            <PagerStyle BackColor="#666666" ForeColor="White" 
                                HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                </table>
        </div>
    </div>
</asp:Content>

