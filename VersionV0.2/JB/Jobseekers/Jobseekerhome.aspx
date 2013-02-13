<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeekers/Candidates.Master" AutoEventWireup="true"
    CodeBehind="Jobseekerhome.aspx.cs" Inherits="JB.JobSeekers.JobSeekerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 100%;
            background-color: #FFFFFF;
        }
        
        .jseekerhometop
        {
            background-color: #fff;
            text-align: right;
        }
    </style>
    <link href="JSeeker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function loadpg(pgsrc) {


            ifra.location = "/Jobseekers/Supportdoc/" + pgsrc;

            return false;
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="backgrdstyle">
        <asp:Label ID="Label2" runat="server" CssClass="StyleR1" Text="Tips to get jobs"></asp:Label>
    </div>
    <div class="jseekerhometop">
        <asp:LinkButton ID="LinkButton5" runat="server" OnClientClick="return loadpg('Cvprepration.htm');"
            onmouseover="this.className='canhomepagelinksover'" onmouseout="this.className='canhomepagelinks'"
            CssClass="canhomepagelinks">CV Advice</asp:LinkButton>
        &nbsp;
        <asp:LinkButton ID="LinkButton6" runat="server" OnClientClick="return loadpg('Interviewtips.htm');"
            onmouseover="this.className='canhomepagelinksover'" onmouseout="this.className='canhomepagelinks'"
            CssClass="canhomepagelinks">Interviewing tips</asp:LinkButton>
    </div>
    <div class="jseekermidback">
        <iframe id="ifra" security="restricted" name="ifra" width="100%" height="400px" frameborder="0"
            src="../Blank.aspx"></iframe>
    </div>
</asp:Content>
