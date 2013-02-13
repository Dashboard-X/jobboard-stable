<%@ Page Title="" Language="C#" MasterPageFile="~/Recruiters/Recruiters.Master" AutoEventWireup="true"
    CodeBehind="JobForm.aspx.cs" Inherits="JB.Recruiters.RecJobs" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
      
        
    </style>

    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="recbgstytle">
          <asp:Label ID="Label14" runat="server" CssClass="StyleR1White" 
                    Text="Job Posting"></asp:Label>
   </div>
    <table bgcolor="White" cellpadding="1" cellspacing="0" class="style2">
        <tr>
            <td width="10px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td width="100px">
                <asp:Label ID="Label1" runat="server" CssClass="StyleR1" Text="JobTitle"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="TextboxSt" Width="200px" onmouseover="this.className='TextboxStout'" onmouseout="this.className='TextboxSt'"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="X"
                    ControlToValidate="TextBox1" CssClass="StyleR1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="StyleR2" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td valign="top">
                <asp:Label ID="Label2" runat="server" CssClass="StyleR1" 
                    Text="Short Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="TextboxSt" Height="50px" TextMode="MultiLine"
                    Wrap="True" Width="400px" onmouseover="this.className='TextboxStout'" onmouseout="this.className='TextboxSt'"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="X"
                    ControlToValidate="TextBox2" CssClass="StyleR1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td valign="top">
                <asp:Label ID="Label13" runat="server" CssClass="StyleR1" Text="Details"></asp:Label>
            </td>
            <td>
                <cc1:Editor ID="Editor1" runat="server" Height="300px" 
                    Width="400px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="StyleR2" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="StyleR1" Text="Posting Start Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="TextboxSt" Width="200px" onmouseover="this.className='TextboxStout'" onmouseout="this.className='TextboxSt'"></asp:TextBox>
                <asp:CalendarExtender ID="TextBox3_CalendarExtender" runat="server" Format= "dd/M/yyyy"
                    Enabled="True" TargetControlID="TextBox3" PopupButtonID="Image8">
                </asp:CalendarExtender>
                <asp:Image ID="Image8" runat="server" ImageUrl="~/images/Calender.png" 
                    onmouseover="document.body.style.cursor='pointer'" 
                    onmouseout="document.body.style.cursor='default'" ImageAlign="AbsMiddle" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="X"
                    ControlToValidate="TextBox3" CssClass="StyleR1"></asp:RequiredFieldValidator>
            
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="StyleR1" Text="Posting End Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="TextboxSt" Width="200px" onmouseover="this.className='TextboxStout'" onmouseout="this.className='TextboxSt'"></asp:TextBox>
                <asp:CalendarExtender ID="TextBox4_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TextBox4" PopupButtonID="Image9" Format="dd/M/yyyy">
                </asp:CalendarExtender>
                <asp:Image ID="Image9" runat="server" ImageUrl="~/images/Calender.png" 
                    onmouseover="document.body.style.cursor='pointer'" 
                    onmouseout="document.body.style.cursor='default'" ImageAlign="AbsMiddle"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="X"
                    ControlToValidate="TextBox4" CssClass="StyleR1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="StyleR2" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td valign="top">
                <asp:Label ID="Label5" runat="server" CssClass="StyleR1" Text="Location"></asp:Label>
            </td>
            <td>
                <div style="border: 1px solid #808080; left: 100px; top: 100px; width: 200px; height: 108px;
                    overflow: auto;">
                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" CssClass="StyleR1">
                        <asp:ListItem>London</asp:ListItem>
                        <asp:ListItem>Italy</asp:ListItem>
                        <asp:ListItem>India</asp:ListItem>
                        <asp:ListItem>USA</asp:ListItem>
                        <asp:ListItem>Australia</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="StyleR2" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td valign="top">
                <asp:Label ID="Label6" runat="server" CssClass="StyleR1" Text="Contract Type"></asp:Label>
            </td>
            <td>
                <div style="border: 1px solid #808080; left: 100px; top: 100px; width: 200px; height: 70px;
                    overflow: auto;">
                    <asp:CheckBoxList ID="CheckBoxList3" runat="server" CssClass="StyleR1">
                        <asp:ListItem Value="3000">Permanent</asp:ListItem>
                        <asp:ListItem Value="3001">Temporary</asp:ListItem>
                        <asp:ListItem Value="3002">Contract</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="StyleR2" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td valign="top">
                <asp:Label ID="Label7" runat="server" CssClass="StyleR1" Text="Hours"></asp:Label>
            </td>
            <td>
                <div style="border: 1px solid #808080; left: 100px; top: 100px; width: 200px; height: 50px;
                    overflow: auto;">
                    <asp:CheckBoxList ID="CheckBoxList7" runat="server" CssClass="StyleR1">
                        <asp:ListItem Value="3003">Full Time</asp:ListItem>
                        <asp:ListItem Value="3004">Part Time</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="StyleR2" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td valign="top">
                <asp:Label ID="Label8" runat="server" CssClass="StyleR1" Text="Employer"></asp:Label>
            </td>
            <td>
                <div style="border: 1px solid #808080; left: 100px; top: 100px; width: 200px; height: 50px;
                    overflow: auto;">
                    <asp:CheckBoxList ID="CheckBoxList8" runat="server" CssClass="StyleR1">
                        <asp:ListItem Value="7000">Direct</asp:ListItem>
                        <asp:ListItem Value="7001">Agent</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="StyleR2" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td valign="top">
                <asp:Label ID="Label9" runat="server" CssClass="StyleR1" Text="Industry"></asp:Label>
            </td>
            <td>
                <div style="border: 1px solid #808080; left: 100px; top: 100px; width: 200px; height: 108px;
                    overflow: auto;">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="StyleR1">
                        <asp:ListItem>Test</asp:ListItem>
                        <asp:ListItem>Test2</asp:ListItem>
                        <asp:ListItem>Test3</asp:ListItem>
                        <asp:ListItem>Test4</asp:ListItem>
                        <asp:ListItem>Test5</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="StyleR2" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td valign="top">
                <asp:Label ID="Label10" runat="server" CssClass="StyleR1" Text="Salary"></asp:Label>
            </td>
            <td>
                <div style="border: 1px solid #808080; left: 100px; top: 100px; width: 200px; height: 108px;
                    overflow: auto;">
                    <asp:CheckBoxList ID="CheckBoxList6" runat="server" CssClass="StyleR1">
                    </asp:CheckBoxList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" CssClass="StyleR1" Text="Salary Text"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="TextboxSt" Width="200px" onmouseover="this.className='TextboxStout'" onmouseout="this.className='TextboxSt'"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox5"
                    CssClass="StyleR1" ErrorMessage="X"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="StyleR2" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" CssClass="StyleR1" Text="Job Ref #"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" CssClass="TextboxSt" Width="200px" onmouseover="this.className='TextboxStout'" onmouseout="this.className='TextboxSt'"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox6"
                    CssClass="StyleR1" ErrorMessage="X"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="Save" OnClick="Button1_Click" />
            </td>
            <td>
                &nbsp;<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
