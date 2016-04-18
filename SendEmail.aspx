<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="SendEmail.aspx.cs" Inherits="SendEmail" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title></title>
</head>
<body>
    <h3>Send an Email</h3>
    <form id="form1" runat="server">
    <div class="formE">
        <asp:Label ID="lblRecipient" runat="server" Text="E-mail Recipient: "><asp:TextBox ID="txtRecipient" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblSubject" runat="server" Text="Subject: "></asp:Label><br />
        <asp:TextBox ID="txtSubject" runat="server" Width="100%" Style="color:black;"></asp:TextBox><br />
        <asp:Label ID="lblMessage" runat="server" Text="Message Body: "></asp:Label><br />
        <asp:TextBox ID="txtMessage" runat="server" cssclass="textarea" TextMode="MultiLine" ></asp:TextBox><br />
        <asp:Button ID="btnSend" runat="server" Text="Send E-mail"  cssclass="buttons" OnClick="btnSend_Click" />
    </div>
    </form>
</body>
</html>

</asp:Content>

