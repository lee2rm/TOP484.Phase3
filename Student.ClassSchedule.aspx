<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="true" CodeFile="Student.ClassSchedule.aspx.cs" Inherits="Student_ClassSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
    
    <form id="form1" runat="server">
        <div>
            <h3>Your Class Schedule</h3>
        <hr />
            <asp:Button ID="btnShow" runat="server" Text="Calendar View" OnClick="btnShow_Click" />
            <asp:Button ID="btnHide" runat="server" Text="Class List View" OnClick="btnHide_Click" />
            <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true">
                <asp:ListItem>Name</asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Location</asp:ListItem>
                <asp:ListItem>Semester</asp:ListItem>
            </asp:DropDownList>
            <asp:Calendar ID="Calendar1" cssClass="cals" runat="server"
            ondayrender="Calendar1_DayRender" DayHeaderStyle-Font-Bold="true" ShowGridLines="true"></asp:Calendar>
        </div>
    </form>
</asp:Content>

