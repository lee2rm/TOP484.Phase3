<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewEvent.aspx.cs" Inherits="ViewEvent" %>

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

    <form id="form1" runat="server">
    <div class="formE" style="float: left;width:45%;">
    <h3>Event Details</h3>
    <asp:Label ID="lblEventName" runat="server" Text="Event Name: " CssClass="labels">
        <asp:TextBox ID="txtEventName" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblDate" runat="server" Text="Event Date: " CssClass="labels">
        <asp:TextBox ID="txtDate" runat="server" placeholder="DD/MM/YYYY HH:MM:SS AM/PM" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblElement" runat="server" Text="Element: " CssClass="labels">
        <asp:DropDownList ID="ddlElement" runat="server" CssClass="dropdowns">
            <asp:ListItem>MC</asp:ListItem>
            <asp:ListItem>DJ</asp:ListItem>
            <asp:ListItem>B-boy</asp:ListItem>
            <asp:ListItem>Art</asp:ListItem>
            <asp:ListItem>Knowledge of Self</asp:ListItem>
        </asp:DropDownList></asp:Label><br />
        <%--NEED TO FIGURE OUT HOW TO DISPLAY EVENT PHOTO SOMEWHERE--%>
        <asp:Label ID="lblLocation" runat="server" Text="Event Location: " CssClass="labels"><asp:TextBox ID="txtLocation" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblPCName" runat="server" Text="Primary Contact Name: " CssClass="labels"><asp:TextBox ID="txtPCName" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblPCEmail" runat="server" Text="Primary Contact E-mail: " CssClass="labels"><asp:TextBox ID="txtPCEmail" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblPCPhone" runat="server" Text="Primary Contact Phone #: " CssClass="labels"><asp:TextBox ID="txtPCPhone" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblDescription" runat="server" Text="Description: " CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"  CssClass="textarea"></asp:TextBox>
        <%--API KEY: AIzaSyBZi6ob0guXfcA9OV2j1fKMhKDJIP7upHE--%>
        
    </div>
        <div style="float: right; margin-right: 3%; margin-top: 5%;">
                    <iframe id="myIframe"
          width="500"
          height="450"
          frameborder="0" style="border:0" runat="server"
          src="https://www.google.com/maps/embed/v1/place?key=AIzaSyBZi6ob0guXfcA9OV2j1fKMhKDJIP7upHE
            &q=Words_Beats_Life_Inc" allowfullscreen>
            </iframe>

        </div>
    </form>

</asp:Content>

