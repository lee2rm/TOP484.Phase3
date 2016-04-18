<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Admin.ManageAccounts.aspx.cs" Inherits="Admin_ManageAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

     <form id="form1" runat="server">
    <div class="formE">
        <h3>Manage Accounts</h3>
        <hr />
        <asp:Button ID="btnSearch" runat="server" Text="Search for:" />
        <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox"></asp:TextBox>
        <asp:Button ID="btnAddUser" runat="server" Text="Add New User" OnClick="btnAddUser_Click" />
        <asp:Button ID="btnExport" runat="server" Text="Export This Table to Excel" OnClick="btnExport_Click" />
        <asp:Button ID="btnBulkEmail" runat="server" Text="Email everyone on this list" OnClick="btnBulkEmail_Click"/>
        <br />
        <asp:Label ID="lblMemberType" runat="server" Text="Select Member Type:  ">
        <asp:DropDownList ID="ddlMemberType" runat="server" AutoPostBack="true" CssClass="drop">
            <asp:ListItem>All</asp:ListItem>
            <asp:ListItem>Applicants</asp:ListItem>
            <asp:ListItem>Students</asp:ListItem>
            <asp:ListItem>Parents</asp:ListItem>
            <asp:ListItem>Instructors / Interns</asp:ListItem>
            <asp:ListItem>Ciphers</asp:ListItem>
            <asp:ListItem>Administrators</asp:ListItem>
        </asp:DropDownList></asp:Label>
        <asp:Label ID="lblSortBy" runat="server" Text="Sort By:  ">
        <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true"  CssClass="drop">
            <asp:ListItem>Last Name</asp:ListItem>
            <asp:ListItem>First Name</asp:ListItem>
            <asp:ListItem>Member Type</asp:ListItem>
        </asp:DropDownList></asp:Label>
         </div>
    </form>


</asp:Content>

