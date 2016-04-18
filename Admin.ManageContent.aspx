<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Admin.ManageContent.aspx.cs" Inherits="Admin_ManageContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <h3>Manage Content</h3>
    <hr />
    <%--TODO: Add in thumbnail view somehow--%>

<form id="form1" runat="server">
    <div class="formE">
    <asp:Button ID="btnAddContent" runat="server" Text="Add a File" OnClick="btnAddContent_Click" />
    <asp:Label ID="lblFileType" runat="server" Text="Select a File Type: "></asp:Label>
    <asp:DropDownList ID="ddlContentType" runat="server" AutoPostBack="true" CssClass="drop">
        <asp:ListItem>All</asp:ListItem>
        <asp:ListItem>Word</asp:ListItem>
            <asp:ListItem>PDF</asp:ListItem>
            <asp:ListItem>MP3</asp:ListItem>
            <asp:ListItem>MP4</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="lblSortBy" runat="server" Text="Sort By: "></asp:Label>
    <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true" CssClass="drop">
        <asp:ListItem>File Name</asp:ListItem>
            <asp:ListItem>File Type</asp:ListItem>
            <asp:ListItem>Approval Status</asp:ListItem>
            <asp:ListItem>Owner</asp:ListItem>
    </asp:DropDownList>
        </form>
    </div>


</asp:Content>

