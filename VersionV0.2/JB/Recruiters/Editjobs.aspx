<%@ Page Title="" Language="C#" MasterPageFile="~/Recruiters/Recruiters.Master" AutoEventWireup="true"
    CodeBehind="Editjobs.aspx.cs" Inherits="JB.Recruiters.Editjobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    <link href="Rec.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="recbgstytle">
            <asp:Label ID="Label5" runat="server" CssClass="StyleR1White" Text="Job Edits"></asp:Label>
</div>
    <table bgcolor="White" class="style2" cellpadding="0" cellspacing="0">
        <tr>
            <td style="margin-left: 40px; text-align: right;">
                <asp:Image ID="Image11" runat="server" ImageUrl="~/images/red.png" />
                &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" CssClass="StyleGray" OnClick="LinkButton4_Click">Active</asp:LinkButton>
                &nbsp;<asp:Image ID="Image12" runat="server" ImageUrl="~/images/green.png" />
                &nbsp;<asp:LinkButton ID="LinkButton5" runat="server" CssClass="StyleBlack" OnClick="LinkButton5_Click">Archived</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="margin-left: 40px" class="addcustline">
                &nbsp;</td>
        </tr>
        <tr>
            <td><!-- hookup ajax-->
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    Width="400px" ShowHeader="False" BorderWidth="0px" AllowPaging="True" GridLines="None"
                    OnPageIndexChanging="GridView1_PageIndexChanging" 
                    onrowdatabound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("sTitle") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <table cellpadding="0" class="style1">
                                    <tr>
                                        <td class="dottedlines" >
                                            <asp:Label ID="Label1" runat="server" 
                                                 Text='<%# Bind("sTitle") %>' CssClass="StyleBlackbold"></asp:Label>
                                            <br />
                                            <asp:Label ID="Label3" runat="server" 
                                                 Text='<%# Bind("dtEnteredDate","{0:dd/M/yyyy}") %>' CssClass="StyleBlack"></asp:Label>
                                            &nbsp;<span class="StyleBlack">/</span>&nbsp;<asp:Label ID="Label4" runat="server" 
                                                 Text='<%# Bind("sSalaryText") %>' CssClass="StyleBlack"></asp:Label>
                                            &nbsp;<br /> <br />
                                            <asp:Label ID="Label2" runat="server" CssClass="StyleGray" 
                                                 Text='<%# Bind("sShortDescription") %>'></asp:Label>
                                        </td>
                                        <td class="dottedlines" width="50px" >
                                            <asp:HyperLink ID="HyperLink7" runat="server" CssClass="Stylea8" 
                                                NavigateUrl='<%# "JobForm.aspx?Fg=1&JobID=" + Eval("idJobs") %>'>Edit...</asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" Visible="False" Value="1" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
