<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeekers/Candidates.Master" AutoEventWireup="true"
    CodeBehind="Changeuserpwd.aspx.cs" Inherits="JB.JobSeekers.Changeuserpwd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 100%;
            border-collapse: collapse;
            background-color: #FFFFFF;
        }
        
        .addcustline
        {
            border-top-style: solid;
            border-top-width: 2px;
            border-collapse: collapse;
        }
    </style>
    <link href="JSeeker.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" class="style2">
        <tr>
            <td colspan="3" class="backgrdstyle">
                &nbsp;<asp:Label ID="Label5" runat="server" CssClass="StyleR1" Text="Password change in progress..."></asp:Label>
            </td>
        </tr>
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
                <asp:TextBox ID="TextBox1" runat="server" CssClass="TextboxSt" Width="150px" TextMode="Password"></asp:TextBox>
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
                <asp:TextBox ID="TextBox2" runat="server" CssClass="TextboxSt" Width="150px" TextMode="Password"></asp:TextBox>
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
                <asp:Label ID="Label3" runat="server" CssClass="StyleR1" Text="Confirm password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="TextboxSt" Width="150px" TextMode="Password"></asp:TextBox>
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
                    CssClass="button" CausesValidation="False"  />
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
                &nbsp;<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
            </td>
        </tr>
    </table>
</asp:Content>
