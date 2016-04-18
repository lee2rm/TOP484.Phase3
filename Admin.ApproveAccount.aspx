<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Admin.ApproveAccount.aspx.cs" Inherits="Admin_ApproveAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

        <form id="form1" runat="server">
    <div class="formE">
       <h3 id="lblApplicantInfo" runat="server">Applicant Information</h3>
        <asp:Label ID="lblfName" runat="server" Text="First Name: " CssClass="labels"><asp:TextBox ID="txtfName" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lbllName" runat="server" Text="Last Name: " CssClass="labels"><asp:TextBox ID="txtlName" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblEmail" runat="server" Text="E-mail Address: " CssClass="labels"><asp:TextBox ID="txtEmail" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblDOB" runat="server" Text="Date of Birth: " CssClass="labels"><asp:TextBox ID="txtDOB" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblCellPhone" runat="server" Text="Cell Phone: " CssClass="labels"><asp:TextBox ID="txtCellPhone" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblUserType" runat="server" Text="Requested User Type: " CssClass="labels"><asp:TextBox ID="txtUserType" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />

        <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" cssClass="buttons"/><br />
        <asp:Button ID="btnDeny" runat="server" Text="Deny" OnClick="btnDeny_Click" cssClass="buttons"/>                
    </div>
    </form>

</asp:Content>

