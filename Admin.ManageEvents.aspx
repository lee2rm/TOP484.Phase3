<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Admin.ManageEvents.aspx.cs" Inherits="ViewCalendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Manage Events</h3>
    <hr />
    <asp:Button ID="btnAddEvent" runat="server" Text="Add New Event" OnClick="btnAddEvent_Click" />
    <asp:Button ID="btnViewCalendar" runat="server" Text="Calendar View" onclick="btnViewCalendar_Click"/>
    <asp:Button ID="btnViewList" runat="server" Text="Event List View" OnClick="btnViewList_Click" /><br />
    <asp:Button ID="btnExport" runat="server" Text="Export This Table to Excel" OnClick="btnExport_Click"/>
    <asp:Label ID="lbleType" runat="server" Text="Event Type: "></asp:Label>
    <asp:DropDownList ID="ddlMemberType" runat="server" AutoPostBack="true" CssClass="drop">
        <asp:ListItem>All</asp:ListItem>
        <asp:ListItem>Classes</asp:ListItem>
        <asp:ListItem>Fundraisers</asp:ListItem>
        <asp:ListItem>Service Events</asp:ListItem>
        <asp:ListItem>ShowCases</asp:ListItem>
        <asp:ListItem>Jam Sessions</asp:ListItem>
        <asp:ListItem>Other</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="lblSortyBy" runat="server" Text="Sort By: "></asp:Label>
    <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true" CssClass="drop">
            <asp:ListItem>Date (Soonest)</asp:ListItem>
            <asp:ListItem>Name</asp:ListItem>
            <asp:ListItem>Type</asp:ListItem>
            <asp:ListItem>Location</asp:ListItem>
        </asp:DropDownList><br />


        <asp:Calendar ID="Calendar1" runat="server"
    ondayrender="Calendar1_DayRender" DayHeaderStyle-Font-Bold="true" CssClass="calendar" Caption="Words Beats and Life Master Calendar" ShowGridLines="true"></asp:Calendar>

    </div>
    </form>
</body>
</html>
</asp:Content>

