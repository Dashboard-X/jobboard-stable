<%@ Page Title="" Language="C#" MasterPageFile="~/Recruiters/Recruiters.Master" AutoEventWireup="true"
    CodeBehind="Recapplication.aspx.cs" Inherits="JB.Recruiters.RecApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <link href="Rec.css" rel="stylesheet" type="text/css" />
    <!--load popup here-->
    <link href="../src/facebox.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../Css/examplewobody.css" rel="stylesheet" type="text/css" />
    <script src="../src/jquery.min.js" type="text/javascript"></script>
    <script src="../src/facebox.js" type="text/javascript"></script>
    <script type="text/javascript">

        function pageLoad(sender, args) {

            jQuery(document).ready(function ($) {
                $('a[rel*=facebox]').facebox({
                    loadingImage: '../images/loading.gif',
                    closeImage: '../images/closelabel.png'
                });
            });
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="recbgstytle">
                <asp:Label ID="Label1" runat="server" CssClass="StyleR1White" 
                    Text="Applications Made"></asp:Label>
</div>
    <table bgcolor="White" class="style2302" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="30px">
                &nbsp;
            </td>
            <td>
            <!-- hook up ajax-->
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="StyleR1"
                    OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" 
                    OnPageIndexChanging="GridView1_PageIndexChanging" GridLines="Horizontal"
                    BorderStyle="None" CellSpacing="1" Width="400px">
                    <Columns>
                        <asp:BoundField DataField="aFirstName" HeaderText="FirstName" />
                        <asp:BoundField DataField="aLastName" HeaderText="LastName" />
                        <asp:BoundField DataField="sTitle" HeaderText="Title" />
                        <asp:BoundField DataField="dtentered" DataFormatString="{0:dd/M/yyyy}" HeaderText="Date Applied" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("idapplications", "Recapplicationdetail.aspx?applyid={0}") %>'
                                    Text="view profile..." rel="facebox"></asp:HyperLink>
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
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
