<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
      <li>View Portfolio</li> <!-- either change this to view your profile or link to pathbrite TBD-->
      <li><a>View Calendar</a></li>
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
      <li><a href="http://www.wblinc.org/donations/">Make a Donation</a></li>
      <li><a href="ViewCalendar.aspx">View Calendar</a></li>
         </div>
    </asp:Panel>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" Runat="Server">

    
    <form id="form1" runat="server">
        <h3>Your Account Information</h3>
        <asp:Image ID="imgProfile" runat="server"  ImageUrl="~/img/Lex.jpg" Style="margin-bottom:5%;"/><br />
        <div class="formE"
        <br />
        <asp:Label ID="lblName" runat="server" Text="Name: " CssClass="labels"><asp:TextBox ID="txtName" runat="server" CssClass="textbox" ReadOnly></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblLevel" runat="server" Text="Academy Level: " CssClass="labels"><asp:TextBox ID="txtLevel" runat="server" CssClass="textbox" ReadOnly></asp:TextBox></asp:Label><br />
        <asp:Label ID="lblBucks" runat="server" Text="Your WBL Bucks: " CssClass="labels"><asp:TextBox ID="txtBucks" runat="server" CssClass="textbox" ReadOnly></asp:TextBox></asp:Label>
            <asp:Button ID="btnShop" runat="server" Text="Shop Now!" CssClass="buttons" /><br />
        <asp:Label ID="lblWaiver" runat="server" Text="Waiver Status: " CssClass="labels"><asp:TextBox ID="txtWaiver" runat="server" CssClass="textbox" ReadOnly></asp:TextBox></asp:Label><br />
        
        <asp:Button ID="btnViewProfile" runat="server" Text="View Your Profile" OnClick="btnViewProfile_Click" Width="300px"/>
        <asp:Button ID="btnEditInfo" runat="server" Text="Edit Your Information" OnClick="btnEditInfo_Click" Width="300px"/><br />
        <asp:Button ID="btnDownloadWaiver" runat="server" Text="Download Waivers" OnClick="btnDownloadWaiver_Click" Width="300px"/>
        <asp:Button ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click" Text="Change Your Password" Width="300px"/><br />
        <asp:Button ID="btnViewSchedule" runat="server" Text="View your Class Schedule" OnClick="btnViewSchedule_Click" Width="600px"/><br />
        </div>
        
    </form>


</asp:Content>
