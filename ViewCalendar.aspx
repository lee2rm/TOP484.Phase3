<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="ViewCalendar.aspx.cs" Inherits="ViewCalendar" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .cals tr:first-child {
	background-color: #22EECF;
        }
        .cals tr:nth-child(even) {
	        background-color: lightgrey;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="foobar" Runat="Server">



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foo" Runat="Server">
    
    
   
     <asp:Panel ID="adminPanel" runat="server">
        <div id="adminPanel1" runat="server">
        <li><a href="Admin.ManageAccounts.aspx">Manage Accounts</a>
            <ul>
                <li><a href="Admin.AddUser.aspx">Add New User</a></li>
            </ul>
        </li>
        <li><a href="Admin.ManageContent.aspx">Manage Content</a> 
            <ul>
                <li><a href="Admin.AddContent.aspx">Add Content</a></li>
                </ul>
            </li>
        <li><a href="Admin.ManageEvents.aspx">Manage Events</a> 
            <ul>
                <li><a href="Admin.AddEvent.aspx">Add Event</a></li>
            </ul>
        </li>
        <li><a href="Inventory.aspx">Manage Inventory</a>  
        </li>
        <li><a href="ViewCalendar.aspx">View Calendar</a></li>
        <li><a href="Admin.Dashboard.aspx">View Dashboard</a></li>
            </div>
    </asp:Panel>

    <asp:Panel ID="studentPanel" runat="server">
        <div id="studentPanel1" runat="server">
      <li><a href="ViewProfile.aspx">View Profile</a> </li> <!-- either change this to view your profile or link to pathbrite TBD-->
      <li><a href="ViewCalendar.aspx">View Calendar</a></li>
      <li><a href="Student.SearchClasses.aspx">Search Classes</a></li>
      <li><a href="Student.EvaluationHomePage.aspx">View Your Evaluations</a></li>
      <li><a href="Student.ClassEvaluation.aspx">Evaluate Class</a></li>
        </div>
    </asp:Panel>

     <asp:Panel ID="instructorPanel" runat="server">
         <div id="instructorPanel1" runat="server">
        <li><a href="Instructor.TakeAttendance.aspx">Take Attendance</a></li>
        <li><a href="Instructor.SubmitLessonPlan.aspx">Submit Lesson Plan</a></li>
        <li><a href="Instructor.StudentEvaluationHomePage.aspx">Submit Student Evaluations</a></li>
        <li><a href="Instructor.EvaluationHomePage.aspx">View Your Evaluations</a></li>
        <li><a href="ViewCalendar.aspx">View Calendar</a> </li>
         </div>
    </asp:Panel>

    <asp:Panel ID="parentPanel" runat="server">
        <div id="parentPanel1" runat="server">
      <li><a href="Parent.ViewStudentContent.aspx">View Student Content</a></li>
      <li><a href="Parent.EvaluationHomePage.aspx">View Students' Evaluations</a></li>
      <li><a href="Parent.EncouragementLetter.aspx">Write a Letter of Encouragement</a></li>
      <li><a href="Parent.EmailInstructor.aspx">Email Instructor</a></li>
      <li><a href="ViewCalendar.aspx">View Calendar</a></li>
            </div>
    </asp:Panel>

     <asp:Panel ID="cipherPanel" runat="server" >
         <div id="cipherPanel1" runat="server">
      <li><a href="Cipher.ViewStudentProfiles.aspx">View Student Profiles</a> </li>
      <li><a href="Cipher.MakeADonation.aspx">Make a Donation</a></li>
      <li><a href="ViewCalendar.aspx">View Calendar</a></li>
         </div>
    </asp:Panel>


</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="body" Runat="Server">

    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>View Calendar</h3>
    <hr />
    <asp:Button ID="btnViewCalendar" runat="server" Text="Calendar View" onclick="btnViewCalendar_Click"/>
    <asp:Button ID="btnViewList" runat="server" Text="Event List View" OnClick="btnViewList_Click" /><br />
    <asp:Button ID="btnExport" runat="server" Text="Export This Table to Excel" OnClick="btnExport_Click"/>
    <asp:Label ID="lbleType" runat="server" Text="Event Type: "></asp:Label>
    <asp:DropDownList ID="ddlMemberType" runat="server" AutoPostBack="true">
        <asp:ListItem>All</asp:ListItem>
        <asp:ListItem>Classes</asp:ListItem>
        <asp:ListItem>Fundraisers</asp:ListItem>
        <asp:ListItem>Service Events</asp:ListItem>
        <asp:ListItem>ShowCases</asp:ListItem>
        <asp:ListItem>Jam Sessions</asp:ListItem>
        <asp:ListItem>Other</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="lblSortyBy" runat="server" Text="Sort By: "></asp:Label>
    <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true">
            <asp:ListItem>Date (Soonest)</asp:ListItem>
            <asp:ListItem>Name</asp:ListItem>
            <asp:ListItem>Type</asp:ListItem>
            <asp:ListItem>Location</asp:ListItem>
        </asp:DropDownList><br />

        <asp:Calendar ID="Calendar1" CssClass="cals" runat="server"
    ondayrender="Calendar1_DayRender" DayHeaderStyle-Font-Bold="true"  ShowGridLines="true"></asp:Calendar>

        <h4>Event Listing</h4>

    </div>
    </form>
</body>
</html>
</asp:Content>


