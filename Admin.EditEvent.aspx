<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Admin.EditEvent.aspx.cs" Inherits="Admin_EditEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="formE">
    <h3>Event Details</h3>
    <asp:Label ID="lblEventName" runat="server" Text="Event Name: " CssClas="labels">
            <asp:TextBox ID="txtEventName" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblDate" runat="server" Text="Event Date: " CssClass="labels">
        <asp:TextBox ID="txtDate" runat="server" placeholder="DD/MM/YYYY HH:MM:SS AM/PM" CssClass="textbox"></asp:TextBox></asp:Label><br />
         <asp:Calendar ID="cldEditEvent" runat="server" OnSelectionChanged="cldEditEvent_SelectionChanged" Visible="False">
        </asp:Calendar><br />
        <asp:Label ID="lblElement" runat="server" Text="Element: "></asp:Label>
        <asp:DropDownList ID="ddlElement" runat="server" CssClass="dropdowns">
            <asp:ListItem>Class</asp:ListItem>
            <asp:ListItem>Fundraiser</asp:ListItem>
            <asp:ListItem>Service</asp:ListItem>
            <asp:ListItem>Jam Session</asp:ListItem>
            <asp:ListItem>Showcase</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList><br />
        <%--NEED TO FIGURE OUT HOW TO DISPLAY EVENT PHOTO SOMEWHERE--%>
         <asp:Label ID="lblPhoto" runat="server" Text="Upload Photo: "  CssClass="labels"><asp:FileUpload ID="flEventPhoto" runat="server" CssClass="textbox"/></asp:Label><br />
        <asp:Label ID="lblLocation" runat="server" Text="Event Location: "  CssClass="labels"><asp:TextBox ID="txtLocation" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblPCName" runat="server" Text="Primary Contact Name: "  CssClass="labels"><asp:TextBox ID="txtPCName" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblPCEmail" runat="server" Text="Primary Contact E-mail: "  CssClass="labels"><asp:TextBox ID="txtPCEmail" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblPCPhone" runat="server" Text="Primary Contact Phone #: "  CssClass="labels"><asp:TextBox ID="txtPCPhone" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblDescription" runat="server" Text="Description: "  CssClass="labels"></asp:Label><br /><asp:TextBox ID="txtDescription" runat="server" CssClass="textarea" TextMode="MultiLine"></asp:TextBox><br />
       
        
        <asp:Button ID="btnUpdate" runat="server" Text="Update This Event" OnClick="btnUpdate_Click" />
    </div>
    </form>
</body>
</html>

</asp:Content>

