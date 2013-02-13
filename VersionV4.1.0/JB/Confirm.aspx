<%@ Page Title="" Language="C#" MasterPageFile="~/Job.Master" AutoEventWireup="true"
         CodeBehind="Confirm.aspx.cs" Inherits="JB.confirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ux_divback">
        <asp:Label ID="reasonforwarded" runat="server" CssClass="ux_simplefontwhite"></asp:Label>
    </div>
    <div class="ux_simpleboxdetail">
        <asp:Label ID="textreason" runat="server" CssClass="ux_simplefontblack" Text=""></asp:Label>
    </div>
</asp:Content>