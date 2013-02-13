<%@ Page Title="" Language="C#" MasterPageFile="~/Jobseekers/Candidates.Master" AutoEventWireup="true"
    CodeBehind="CanNotes.aspx.cs" Inherits="JB.Jobseekers.CanNotes" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div class="backgrdstyle">
<asp:Label ID="Label1" runat="server" CssClass="simplefontblack" Text="My Notes"></asp:Label>
</div>

<div class="jseekermidback">

Notes
 
<div>
<div class="cannoteslft">
    
    <cc1:Editor ID="Editor1" runat="server" /> 

</div>

<div class="cannotesrt">
    Current notes
    <br />

</div>

</div>
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
</div>
</asp:Content>
