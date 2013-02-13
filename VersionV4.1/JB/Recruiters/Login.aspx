<%@ Page Title="" Language="C#" MasterPageFile="~/Logins.Master" AutoEventWireup="true"
         CodeBehind="Login.aspx.cs" Inherits="JB.Recruiters.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loginleft">
        <img alt="login logo" src="/Brandimages/brand_login.png" />
        <br />
        <asp:Label ID="Label10" runat="server" CssClass="ux_ftblack" Text="Username"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" CssClass="ux_TextBoxStyle"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                                    CssClass="ux_ftblack" ErrorMessage="X"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label11" runat="server" CssClass="ux_ftblack" Text="Password"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" CssClass="ux_TextBoxStyle">test</asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
                                    CssClass="ux_ftblack" ErrorMessage="X"></asp:RequiredFieldValidator>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="ux_Stylea101" OnClick="LinkButton1_Click"
                        CausesValidation="False">Forgot Password</asp:LinkButton>
        <asp:Label ID="Label12" runat="server" Text="or" CssClass="ux_ftblack"></asp:Label>
        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="ux_Stylea101" OnClick="LinkButton2_Click"
                        CausesValidation="False">Register Now!</asp:LinkButton>
        <br />
        <br />
        <div class="ux_alignright">
            <asp:Button ID="Button2" runat="server" Text="Login" OnClick="Button2_Click" CssClass="ux_button" />
            <asp:Button ID="Button3" runat="server" Text="Cancel" OnClick="Button3_Click" CssClass="ux_button"
                        CausesValidation="False" />
        </div>
    </div>
    <div id="loginright">
        <h1>Get More
        </h1>
        <p>
            Currently we are offering free job postings to connect new employers who are un
            familiar with the jobboards. Sign up quickly and gain access to our jobposting sections.
            <br />
            <br />
        </p>
        <ul class="ux_ulist">
            <li>Manage Applicants</li>
            <li>Post Jobs*</li>
            <li>Track Resumes</li>
        </ul>

        <p>
            * for limited time only
        </p>
    </div>
    <div class="ux_cleardata">
    </div>
    <br />
    <br />
</asp:Content>