<%@ Page Title="" Language="C#" MasterPageFile="~/Job.Master" AutoEventWireup="true"
         CodeBehind="Contact.aspx.cs" Inherits="JB.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/styles/cs2.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ux_divback">
        <div class="ux_simplefontwhite">
            Contact Information
        </div>
    </div>
    <div class="ux_boxcorner">
        <div id="divftsleft100">
            <asp:Label ID="Label16" runat="server" CssClass="ux_Stylea8" Text="So that we can answer your queries in a timely fashion please choose one of the following departments to contact:"></asp:Label>
            <br />
            <br />
            <div class="ux_cleardata">
            </div>
            <div class="ux_contactstylist">
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="ux_fontredh1" NavigateUrl="mailto:abuse@Ahrcloud.com">info@Ahrcloud.com</asp:HyperLink>
            </div>
            <div class="ux_contactstylist">
                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="ux_fontredh1" NavigateUrl="mailto:jobboard@Ahrcloud.com">support@Ahrcloud.com</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>