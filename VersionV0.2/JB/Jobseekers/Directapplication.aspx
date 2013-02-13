<%@ Page Title="" Language="C#" MasterPageFile="~/JOB.Master" AutoEventWireup="true"
    CodeBehind="Directapplication.aspx.cs" Inherits="JB.JobSeekers.DirectApplication" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/styles/cs2.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divback">
        <asp:Label ID="Label11" runat="server" CssClass="simplefontwhite" Text="Application in progress..."></asp:Label>
    </div>
    <div class="simpleboxdetail">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td width="100px">
                    <asp:Label ID="Label15" runat="server" CssClass="fontredh1" Text="Quick Uploader"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="addcustline">
                    &nbsp;
                </td>
                <td width="100px" class="addcustline">
                    &nbsp;
                </td>
                <td class="addcustline">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" CssClass="Stylea2" Text="FirstName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="TextboxSt" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox3"
                        CssClass="Stylea1" ErrorMessage="X"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label13" runat="server" CssClass="Stylea2" Text="LastName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="TextboxSt" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4"
                        CssClass="Stylea1" ErrorMessage="X"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="Label14" runat="server" CssClass="Stylea2" Text="Date of Birth"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="TextboxSt" Width="200px"></asp:TextBox>
                    <asp:CalendarExtender ID="TextBox5_CalendarExtender" runat="server" Enabled="True"
                        TargetControlID="TextBox5" PopupButtonID="Image8" Format="dd/M/yyyy">
                    </asp:CalendarExtender>
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/images/Calender.png" onmouseover="document.body.style.cursor='pointer'"
                        onmouseout="document.body.style.cursor='default'" ImageAlign="AbsMiddle" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label20" runat="server" CssClass="Stylea2" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="TextboxSt" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6"
                        CssClass="Stylea2" ErrorMessage="X"></asp:RequiredFieldValidator>
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
                <td class="addcustline">
                    &nbsp;
                </td>
                <td class="addcustline">
                    &nbsp;
                </td>
                <td class="addcustline">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td valign="top">
                    <asp:Label ID="Label16" runat="server" CssClass="Stylea2" Text="Profile Summary"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="TextboxSt" Height="100px" TextMode="MultiLine"
                        Width="300px" Wrap="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2"
                        CssClass="Stylea1" ErrorMessage="X"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td valign="top">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="addcustline">
                    &nbsp;
                </td>
                <td class="addcustline">
                    &nbsp;
                </td>
                <td valign="top" class="addcustline">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label17" runat="server" CssClass="Stylea2" Text="Upload CV"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="button" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload1"
                        CssClass="Stylea1" ErrorMessage="X"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="Label18" runat="server" CssClass="Stylea2" Text="Only support *.docx, *.pdf, *.doc &lt; 2mb"></asp:Label>
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
                <td class="addcustline">
                    &nbsp;
                </td>
                <td class="addcustline">
                    &nbsp;
                </td>
                <td class="addcustline">
                    &nbsp;
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
                    <asp:Button ID="Button2" runat="server" CssClass="button" Text="Submit" OnClick="Button2_Click" />
                    &nbsp;
                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="Cancel" OnClick="Button3_Click"
                        CausesValidation="False" />
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
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label19" runat="server" CssClass="Stylea101"></asp:Label>
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
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
    </div>
</asp:Content>
