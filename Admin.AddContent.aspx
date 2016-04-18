<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Admin.AddContent.aspx.cs" Inherits="Admin_AddContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

        <form id="form1" runat="server">
    <div class="formE">
        <h3>Add New Content</h3>
        <asp:Label ID="lblTitle" runat="server" Text="Title: " CssClass="labels"><asp:TextBox ID="txtTitle" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblCreator" runat="server" Text="Student: " CssClass="labels"><asp:DropDownList ID="ddlStudent" runat="server" cssclass="dropdowns"></asp:DropDownList></asp:Label><br />
        <asp:SqlDataSource ID="StudentList" runat="server"   SelectCommand="SELECT [EmailAddress] FROM [Student] ORDER BY [EmailAddress]"></asp:SqlDataSource>
        <asp:Label ID="lblElement" runat="server" Text="Element: " CssClass="labels"><asp:DropDownList ID="ddlElement" runat="server" CssClass="dropdowns">
            <asp:ListItem>MC</asp:ListItem>
            <asp:ListItem>DJ</asp:ListItem>
            <asp:ListItem>B-boy</asp:ListItem>
            <asp:ListItem>Art</asp:ListItem>
            <asp:ListItem>Knowledge of Self</asp:ListItem>
        </asp:DropDownList></asp:Label><br />
        <asp:FileUpload ID="fuAdminAddContent" runat="server" /><br />
        <asp:CheckBox ID="ckCommunityWall" runat="server" Text="Add this file to Community Wall" cssclass="radioButtons"/><br />
        <asp:Label ID="lblDescription" runat="server" Text="Description: " CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
        <br />
        <asp:Button ID="btnUpload" runat="server" Text="Upload File" OnClick="btnUpload_Click" CssClass="buttons" />
        
    </div>
    </form>


</asp:Content>

