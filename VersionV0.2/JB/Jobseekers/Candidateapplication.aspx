<%@ Page Title="" Language="C#" MasterPageFile="~/JOB.Master" AutoEventWireup="true"
    CodeBehind="Candidateapplication.aspx.cs" Inherits="JB.JobSeekers.Candidateapplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="10px" bgcolor="Gray">
                &nbsp;</td>
            <td bgcolor="Gray" colspan="2">
                <asp:Label ID="Label11" runat="server" CssClass="Stylea1" Text="Application in progress..."></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td width="100px">
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
            <td colspan="2">
                <asp:Label ID="Label15" runat="server" CssClass="Stylea101" 
                    Text="Please choose/update your cv/resume here"></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td width="100px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td valign="top">
                &nbsp;</td>
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
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="TextboxSt" onmouseover="this.className='TextboxStover'" onmouseout="this.className='TextboxSt'"/>
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="addcustline">
                &nbsp;</td>
            <td class="addcustline">
                &nbsp;</td>
            <td class="addcustline">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" CssClass="TextboxSt" Text="Submit" 
                    OnClick="Button2_Click" onmouseover="this.className='TextboxStover'" onmouseout="this.className='TextboxSt'"/>
                &nbsp;
                <asp:Button ID="Button3" runat="server" CssClass="TextboxSt" Text="Cancel" OnClick="Button3_Click"
                    CausesValidation="False" onmouseover="this.className='TextboxStover'" onmouseout="this.className='TextboxSt'"/>
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
