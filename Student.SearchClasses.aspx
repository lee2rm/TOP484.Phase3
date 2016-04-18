<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="true" CodeFile="Student.SearchClasses.aspx.cs" Inherits="Student_SearchClasses2" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent1" Runat="Server">
<form id="form1" runat="server">
    <div class="formE">
        <h3>Search Classes </h3>
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="Search for: " OnClick="btnAddUser_Click" /><asp:TextBox ID="txtSearch" runat="server" CssClass="textbox"></asp:TextBox><br/>
        <asp:Button ID="btnEnroll" runat="server" Text="Enroll!" OnClick="btnEnroll_Click" />
        <asp:Button ID="btnViewCalendar" runat="server" Text="View Your Class Schedule" OnClick="btnViewCalendar_Click" /><br />
        <asp:Label ID="lblElement" runat="server" Text="Select Element:  " CssClass="labels">
        <asp:DropDownList ID="ddlElementType" runat="server" AutoPostBack="true" CssClass="dropdowns">
            <asp:ListItem>All</asp:ListItem>
            <asp:ListItem>DJ</asp:ListItem>
            <asp:ListItem>MC</asp:ListItem>
            <asp:ListItem>BBOY</asp:ListItem>
            <asp:ListItem>Art</asp:ListItem>
            <asp:ListItem>Scratching</asp:ListItem>
            <asp:ListItem>Graffiti</asp:ListItem>
            <asp:ListItem>Knowledge of Self</asp:ListItem>
        </asp:DropDownList></asp:Label><br />
        <asp:Label ID="lblSortBy" runat="server" Text="Sort By:  " CssClass="labels">
        <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true" CssClass="dropdowns">
            <asp:ListItem>Name</asp:ListItem>
            <asp:ListItem>Instructor</asp:ListItem>
            <asp:ListItem>Date (Soonest)</asp:ListItem>
            <asp:ListItem>Location</asp:ListItem>
        </asp:DropDownList></asp:Label><br />
        <asp:Label ID="lblShoppingCart" runat="server" Text="Shopping Cart" CssClass="labels"></asp:Label><br />
        <asp:ListBox ID="lbShoppingCart" runat="server" Width="400px" Height="100px" CssClass="textarea"><asp:ListItem></asp:ListItem></asp:ListBox>
      <br />
        <br />
        <br />
    </div>
    </form>
</asp:Content>


