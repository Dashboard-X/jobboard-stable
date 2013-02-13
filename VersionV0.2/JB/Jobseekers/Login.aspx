<%@ Page Title="" Language="C#" MasterPageFile="~/Logins.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="JB.JobSeekers.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loginleft">
        <table>
            <tr>
                <td colspan="2">
                    <img alt="" src="../Brandimages/brand_login.png" />
                    <div class="simplecleargreyln">
                    </div>
                </td>
            </tr>
            <tr>
                <td width="100px">
                    &nbsp;
                    <asp:Label ID="Label10" runat="server" CssClass="StyleR1" Text="Username"></asp:Label>
                </td>
                <td width="240px">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="TextboxSt" Width="200px">moin@hot.com</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                        CssClass="StyleR1" ErrorMessage="X"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:Label ID="Label11" runat="server" CssClass="StyleR1" Text="Password"></asp:Label>
                </td>
                <td width="260px">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" CssClass="TextboxSt"
                        Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
                        CssClass="StyleR1" ErrorMessage="X"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="Stylea101" OnClick="LinkButton1_Click"
                        CausesValidation="False">Forgot Password</asp:LinkButton>
                    &nbsp;<asp:Label ID="Label12" runat="server" Text="or" CssClass="StyleR1"></asp:Label>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CssClass="Stylea101" OnClick="LinkButton2_Click"
                        CausesValidation="False">Register Now!</asp:LinkButton>
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
                    <asp:Button ID="Button2" runat="server" Text="Login" OnClick="Button2_Click" CssClass="button" />
                    &nbsp;
                    <asp:Button ID="Button3" runat="server" Text="Cancel" OnClick="Button3_Click" CssClass="button"
                        CausesValidation="False" />
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
    </div>
    <div id="loginright">
        <div class="StyleR1">
            Did you know that you can get a lot more from purchased / hosted version of AHRCLOUD's
            Job board platform
            <br />
            <br />
            with paid version you get:
            <br />
            <br />
            1- Rss feeds
            <br />
            2- Fully customized logins<br />
            3- Advanced search controls<br />            
            4- WAP Site<br />
            5- Mobile Apps<br />
            6- Recruiter Listings<br />
            7- Content Management System
            8- Payment Gateways (most popular merchants already
            integrated, like paypal etc) <br />
            9- Multi-Channel Adverts to generate ROI<br />
            10- Secure and tested System<br />
            11- Clean, Optimzed, Elegant and Innovative User Interface
            <br />
            <br />
            and a lot more...<br />
            visit
            <br />
            <br />
            <a href="http://ahrcloud.com">www.ahrcloud.com</a>
        </div>
    </div>
</asp:Content>
