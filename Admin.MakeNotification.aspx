<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true"  CodeFile="Admin.MakeNotification.aspx.cs" Inherits="Admin_MakeNotification" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

        <form id="form1" runat="server">
    <div class="formE">
       <h3 id="lblAnnouncement" runat="server">Send Notification</h3>
        <asp:Label ID="lblRecipient" runat="server" Text="Choose Recipients: " CssClass="labels">
            <asp:DropDownList ID="ddlUser" runat="server" CssClass="dropdowns">
                <asp:ListItem Value="0" Text="Please Select"/>
                <asp:ListItem Value="GeneralUser" Text="All"/>
                <asp:ListItem Value="Administrator" Text="Administrators"/>
                <asp:ListItem Value="Staff" Text="Staff"/>
                <asp:ListItem Value="Student" Text="Student"/>
                <asp:ListItem Value="Cipher" Text="Cipher"/>
                <asp:ListItem Value="Parent" Text="Parents"/>        
            </asp:DropDownList></asp:Label><br />
        <asp:Label ID="lblHeader" runat="server" Text="Announcement Header: " CssClass="labels">
            <asp:TextBox ID="txtHeader" runat="server" MaxLength="50" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblAnnounceText" runat="server" Text="Announcement Text: " CssClass="labels">
            <asp:TextBox ID="txtText" runat="server" CssClass="textarea"></asp:TextBox></asp:Label><br />
        
        <asp:Button ID="btnSendAnnounce" runat="server" Text="Send Announcment" cssclass="buttons" OnClick="btnSend_Click" /><br />      
        
        <br />
        <br />
        <h3 id="lblEmail" runat="server">Send Weekly Email</h3>
        <asp:Label ID="lblEmailRecipients" runat="server" Text="Choose Recipients: " CssClass="labels">
            <asp:DropDownList ID="ddlEmail" runat="server" CssClass="dropdowns">
                <asp:ListItem Value="0" Text="Please Select"/>
                <asp:ListItem Value="GeneralUser" Text="All"/>
                <asp:ListItem Value="Administrator" Text="Administrators"/>
                <asp:ListItem Value="Staff" Text="Staff"/>
                <asp:ListItem Value="Student" Text="Student"/>
                <asp:ListItem Value="Cipher" Text="Cipher"/>
                <asp:ListItem Value="Parent" Text="Parents"/>        
            </asp:DropDownList></asp:Label><br />
        <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" OnClick="btnSendEmail_Click" cssclass="buttons"/><br />         
    </div>
    </form>

</asp:Content>
