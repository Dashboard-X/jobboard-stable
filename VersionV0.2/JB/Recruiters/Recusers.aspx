<%@ Page Title="" Language="C#" MasterPageFile="~/Recruiters/Recruiters.Master" AutoEventWireup="true"
    CodeBehind="Recusers.aspx.cs" Inherits="JB.Recruiters.RecUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table bgcolor="White" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td class="recbgstytle" colspan="2">
                <asp:Label ID="Label1" runat="server" CssClass="StyleR1White" 
                    Text="Users linked to this recruiter"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True"
                    CssClass="StyleR1" DataKeyNames="idUsers" OnRowEditing="GridView1_RowEditing"
                    Width="100%">
                    <Columns>
                        <asp:BoundField DataField="uUserName" HeaderText="UserName" />
                        <asp:BoundField DataField="uFirstName" HeaderText="FirstName" />
                        <asp:BoundField DataField="uLastName" HeaderText="LastName" />
                        <asp:BoundField DataField="uIsPrimary" HeaderText="MainUser" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
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
        </tr>
        <tr>
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
        </tr>
    </table>
</asp:Content>
