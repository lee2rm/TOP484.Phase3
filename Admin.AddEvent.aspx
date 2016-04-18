<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Admin.AddEvent.aspx.cs" Inherits="Admin_AddEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <form id="form1" runat="server">
    <div class="formE">
        <h3>New Event</h3>
        <asp:Label ID="lblEventName" runat="server" Text="Event Name: " CssClas="labels">
            <asp:TextBox ID="txtEventName" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblDate" runat="server" Text="Event Date: " CssClass="labels">
        <asp:TextBox ID="txtDate" runat="server" placeholder="DD/MM/YYYY HH:MM:SS AM/PM" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Button ID="btnDate" runat="server" Text="Select Date" cssclass="specialB" OnClick="btnDate_Click" />
        <asp:Calendar ID="cldNewEvent" runat="server" OnSelectionChanged="cldNewEvent_SelectionChanged" Visible="False">
        </asp:Calendar><br />
        <asp:Label ID="lblElement" runat="server" Text="Element: " CssClass="labels">
        <asp:DropDownList ID="ddlElement" runat="server" CssClass="dropdowns">
            <asp:ListItem>Class</asp:ListItem>
            <asp:ListItem>Fundraiser</asp:ListItem>
            <asp:ListItem>Service</asp:ListItem>
            <asp:ListItem>Jam Session</asp:ListItem>
            <asp:ListItem>Showcase</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList></asp:Label><br />
        <asp:Label ID="lblPhoto" runat="server" Text="Upload Photo: "  CssClass="labels"><asp:FileUpload ID="flEventPhoto" runat="server" CssClass="textbox"/></asp:Label><br />
        <asp:Label ID="lblLocation" runat="server" Text="Event Location: "  CssClass="labels"><asp:TextBox ID="txtLocation" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblPCName" runat="server" Text="Primary Contact Name: "  CssClass="labels"><asp:TextBox ID="txtPCName" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblPCEmail" runat="server" Text="Primary Contact E-mail: "  CssClass="labels"><asp:TextBox ID="txtPCEmail" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblPCPhone" runat="server" Text="Primary Contact Phone #: "  CssClass="labels"><asp:TextBox ID="txtPCPhone" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblDescription" runat="server" Text="Description: "  CssClass="labels"></asp:Label><br /><asp:TextBox ID="txtDescription" runat="server" CssClass="textarea" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Button ID="btnAddEvent" runat="server" Text="Add Event: " cssclass="buttons" OnClick="btnAddEvent_Click" />
    </div>
    </form>

</asp:Content>

