<%@ Page Title="" Language="C#" MasterPageFile="~/Recruiters/Recruiters.Master" AutoEventWireup="true"
    CodeBehind="Changerecpwd.aspx.cs" Inherits="JB.Recruiters.Changerecpwd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="/Rec.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
   <div class="recbgstytle">
   <asp:Label ID="Label5" runat="server" CssClass="StyleR1White" Text="Password Change in progress"></asp:Label>
   </div>
            <table cellpadding="0" class="style2">
                <tr>
                    <td width="10px">
                        &nbsp;
                    </td>
                    <td width="150px">
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
                        <asp:Label ID="Label1" runat="server" CssClass="StyleR1" Text="Old password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="TextboxSt" Width="150px" onmouseover="this.className='TextboxStout'"
                            onmouseout="this.className='TextboxSt'" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
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
                        <asp:Label ID="Label2" runat="server" CssClass="StyleR1" Text="New password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="TextboxSt" Width="150px" onmouseover="this.className='TextboxStout'"
                            onmouseout="this.className='TextboxSt'" TextMode="Password"></asp:TextBox>
                        <asp:PasswordStrength ID="TextBox2_PasswordStrength" runat="server" Enabled="True"
                            TargetControlID="TextBox2" DisplayPosition="RightSide" StrengthIndicatorType="Text"
                            PreferredPasswordLength="10" PrefixText="Strength:" TextCssClass="Stylepwd" MinimumNumericCharacters="0"
                            MinimumSymbolCharacters="0" RequiresUpperAndLowerCaseCharacters="false" CalculationWeightings="15;20;15;50">
                        </asp:PasswordStrength>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                            CssClass="StyleR1" ErrorMessage="X"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" CssClass="StyleR1" Text="New password again"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="TextboxSt" Width="150px" onmouseover="this.className='TextboxStout'"
                            onmouseout="this.className='TextboxSt'" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                            CssClass="StyleR1" ErrorMessage="X"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox3"
                            ControlToValidate="TextBox2" CssClass="Stylepwd" ErrorMessage="Passwords donot match!"></asp:CompareValidator>
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
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" CssClass="button"
                           />
                        &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cancel"
                            CssClass="button" CausesValidation="False" 
                           />
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" CssClass="StyleR1"></asp:Label>
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
                        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </asp:ToolkitScriptManager>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
