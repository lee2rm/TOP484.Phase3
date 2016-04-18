<%@ Page Title="" Language="C#" MasterPageFile="~/ParentMasterPage.master" AutoEventWireup="true" CodeFile="Parent.EmailInstructor.aspx.cs" Inherits="Parent_EmailInstructor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <form id="form1" runat="server">
    <div class="formE">

        <h3>Email Instructor</h3>

        <asp:Label ID="Label1" runat="server" Text="Your Childs Name" CssClass="labels">
        <asp:DropDownList ID="ddlStudent" runat="server" cssclass="dropdowns" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged" AutoPostBack ="true"/></asp:Label>

        </br><asp:Label ID="Label2" runat="server" Text="Professors Name" CssClass="labels">
        <asp:DropDownList ID="ddlProf" runat="server" OnSelectedIndexChanged="ddlProf_SelectedIndexChanged" AutoPostBack ="true" CssClass="dropdowns">
        </asp:DropDownList></asp:Label>
        <br/>
        <asp:Label ID="lblEmailSubject" runat="server" Text="Subject: " CssClass="labels"><asp:TextBox ID="txtEmailSubject" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />

        <asp:Label ID="lblEmailDescription" runat="server" Text="Description: " CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtEmailDescription" runat="server" TextMode="MultiLine" cssclass="textarea"></asp:TextBox><br />
        <asp:Button ID="btnSendEmail" runat="server" Text="Send" OnClick="btnSendEmail_Click" cssclass="buttons"/>


         </div>
    </form>
</asp:Content>
