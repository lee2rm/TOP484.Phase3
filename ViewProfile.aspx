<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <!-- Bootstrap CSS -->
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="screen">

<!-- Cutstom CSS -->
<link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">
    <style type="text/css">
        #body_Panel4_profDesc {
            float: left;
            position: relative;
            width: 80%;
        }
                #body_Panel4 a {
            color: white !important;
        }
                        #body_Panel4 {
            text-align: center;
        }
        #body_Panel4 a {
                text-align: center;
                color: white !important;
            }
        .caption {
            text-align: center;
        }
        p {
        color: white;
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
   

    <div class="col-sm-10">
  
  <div class="col-sm-6">
    <div class="thumbnail">
      <img src="img/mazi.png" alt="Mazi Mutafa">
      <div class="caption">
        <h3>Mazi Mutafa</h3>
        <p><a href="#" class="btn btn-primary" role="button">Previous Profile</a> <a href="#" class="btn btn-default" role="button">Next Profile</a></p>
      </div>
    </div>
  </div>

  <div id="profDesc" class="profile" >
    <h3>Mazi Mutafa</h3>
    <p>Mazi Mutafa, is one of six children, and the big brother to four sisters and one brother.  He received his BA in African American Studies and English from the University of Maryland (UMD). He is the founder and executive director of Words Beats & Life, Inc. (WBL), a hip-hop non-profit committed to transforming individual lives and whole communities through the elements of hip-hop culture. As an undergraduate, Mazi was an active member of the student leadership community and in his junior year was elected the President of the Black Student Union (BSU), the largest culture based student organization at UMD. While president of the BSU, Mazicreated the Words Beats & Life Hip-Hop Conference, a six-day hip-hop conference.  Upon his graduation he partnered with three other UMD Students to turn the conference into a non-profit.  Mr. Mutafa was also made brother of Phi Beta Sigma Fraternity, Inc, Epsilon Psi Chapter and voted President his senior year. Today he is a member of the Phi Beta Sigma Fraternity Inc, Tri-Sigma Alumni Chapter.</p>

    <p>His entire professional career has been dedicated to serving youth and community development. Post-graduation, he worked for the Maya Angelou Public Charter School as a resident male counselor. Following this, he began working at the Institute for Cultural Affairs as the Mid-Atlantic Coordinator for “Youth as Facilitative Leaders” and conducted intergenerational facilitation trainings. The final position Mazi had before becoming the full-time Executive Director of Words Beats & Life was as the Street Outreach Coordinator for Motivational Educational Entertainment’s (MEE) “Be on the Safe Side,” a campaign to prevent teen pregnancy.</p>

    <p>All of these professional and academic experiences prepared Mazi to take on the leadership of an organization dedicated to transformation.  This chapter in his life began in 2002, and after all these years, his leadership and vision are taking WBL into the next phase of its development as producer of creativity, innovation and excellence.</p>

  </div>
         <iframe title="Pathbrite Widget" runat="server" width="1280" height="720" src="https://pathbrite.com/WordsBeatsLife/profile" frameborder="0" id="pathbrite" allowfullscreen></iframe>

  </div>
</asp:Content>

