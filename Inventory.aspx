<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Inventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

      <meta charset="utf-8">
    <meta name="description" content="Free Web tutorials">
    <meta name="keywords" content="HTML,CSS,XML,JavaScript">
    <meta name="author" content="Hege Refsnes">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        
        #body_Panel4 {
            text-align: center;
        }
            #body_Panel4 a {
                text-align: center;
                color: white !important;
            }
        #body_Panel4 h2 {
            border-bottom: 5px solid black;
            text-align: left;
        }
        .col-sm-4 {
        text-align: center;
        }


    </style>

    <!-- Bootstrap CSS -->
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="screen">

<!-- Cutstom CSS -->
<link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">




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
  
  <div class="row">
  <div class="col-sm-12">
    <h2>Items</h2></br>
  </div>
</div><!--This is just the line with the words items-->

<div class="row">
  
  <div class="col-sm-4">
        <div class="thumbnail">
        <img src="img/boombox.png" alt="Boom Box">
        <div class="caption">
        <h3>Boom Box</h3>
        <p>Price: $150</p>
        <p><a id="A1" href="#" class="btn btn-primary" role="button" onclick="btnBuy" runat="server">Buy</a><form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
        <input type="hidden" name="cmd" value="_donations"><input type="hidden" name="business" value="top484.wordsbeatslifeproject@gmail.com"><input type="hidden" name="lc" value="US"><input type="hidden" name="item_name" value="Words Beats and Life, Inc"><input type="hidden" name="item_number" value="WBL"><input type="hidden" name="no_note" value="0"><input type="hidden" name="currency_code" value="USD"><input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest"><input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!"><img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
        </p>        

        </div>
        </div>
      </div>

      <div class="col-sm-4">
        <div class="thumbnail">
        <img src="img/camera.jpg" alt="Cameras">
        <div class="caption">
        <h3>Cameras</h3>
        <p>Price: $150</p>
<p><a id="A2" href="#" class="btn btn-primary" role="button" onclick="btnBuy" runat="server">Buy</a><br /><form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
        <input type="hidden" name="cmd" value="_donations"><input type="hidden" name="business" value="top484.wordsbeatslifeproject@gmail.com"><input type="hidden" name="lc" value="US"><input type="hidden" name="item_name" value="Words Beats and Life, Inc"><input type="hidden" name="item_number" value="WBL"><input type="hidden" name="no_note" value="0"><input type="hidden" name="currency_code" value="USD"><input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest"><input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!"><img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
        </p>        
     </div>
        </div>
      </div>

      <div class="col-sm-4">
        <div class="thumbnail">
        <img src="img/ChessPieces.jpg" alt="Chess Pieces">
        <div class="caption">
        <h3>Chess Pieces</h3>
        <p>Price: $20</p>
<p><a id="A3" href="#" class="btn btn-primary" role="button" onclick="btnBuy" runat="server">Buy</a><br /><form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
        <input type="hidden" name="cmd" value="_donations"><input type="hidden" name="business" value="top484.wordsbeatslifeproject@gmail.com"><input type="hidden" name="lc" value="US"><input type="hidden" name="item_name" value="Words Beats and Life, Inc"><input type="hidden" name="item_number" value="WBL"><input type="hidden" name="no_note" value="0"><input type="hidden" name="currency_code" value="USD"><input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest"><input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!"><img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
        </p>        
       </div>
        </div>
      </div>
</div><!--closing div for row-->


<div class="row">
  <div class="col-sm-12">
    <h2>Programs</h2></br>
  </div>
</div><!--This is just the line with the words student shop-->

<div class="row">
  
  <div class="col-sm-4">
        <div class="thumbnail">
        <img src="img/dance.jpg" alt="dance program">
        <div class="caption">
        <h3>Donate to the Dance Program</h3>
<p><a id="A4" href="#" class="btn btn-primary" role="button" onclick="btnBuy" runat="server">Buy</a><br /><form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
        <input type="hidden" name="cmd" value="_donations"><input type="hidden" name="business" value="top484.wordsbeatslifeproject@gmail.com"><input type="hidden" name="lc" value="US"><input type="hidden" name="item_name" value="Words Beats and Life, Inc"><input type="hidden" name="item_number" value="WBL"><input type="hidden" name="no_note" value="0"><input type="hidden" name="currency_code" value="USD"><input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest"><input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!"><img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
        </p>        
       </div>
        </div>
      </div>

      <div class="col-sm-4">
        <div class="thumbnail">
        <img src="img/chessgame.jpg" alt="A Game of Chess">
        <div class="caption">
        <h3>Donate to the Chess Program</h3>
<p><a id="A5" href="#" class="btn btn-primary" role="button" onclick="btnBuy" runat="server">Buy</a><br /><form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
        <input type="hidden" name="cmd" value="_donations"><input type="hidden" name="business" value="top484.wordsbeatslifeproject@gmail.com"><input type="hidden" name="lc" value="US"><input type="hidden" name="item_name" value="Words Beats and Life, Inc"><input type="hidden" name="item_number" value="WBL"><input type="hidden" name="no_note" value="0"><input type="hidden" name="currency_code" value="USD"><input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest"><input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!"><img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
        </p>        
       </div>
        </div>
      </div>

      <div class="col-sm-4">
        <div class="thumbnail">
        <img src="img/photo_program.jpg" alt="Photography Program">
        <div class="caption">
        <h3>Donate to the Photography Program</h3>
<p><a id="A6" href="#" class="btn btn-primary" role="button" onclick="btnBuy" runat="server">Buy</a><br /><form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
        <input type="hidden" name="cmd" value="_donations"><input type="hidden" name="business" value="top484.wordsbeatslifeproject@gmail.com"><input type="hidden" name="lc" value="US"><input type="hidden" name="item_name" value="Words Beats and Life, Inc"><input type="hidden" name="item_number" value="WBL"><input type="hidden" name="no_note" value="0"><input type="hidden" name="currency_code" value="USD"><input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest"><input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!"><img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
        </p>        
          </div>
        </div>
      </div>
</div><!--closing div for row-->

<div class="row">
  <div class="col-sm-12">
    <h2>Projects and Tours</h2></br>
  </div>
</div><!--This is just the line with the words student shop-->

<div class="row">
  
  <div class="col-sm-4">
        <div class="thumbnail">
        <img src="img/citytour.jpg" alt="City Tour">
        <div class="caption">
        <h3>Purchase Tickets for the City Tour</h3>
        <p>Donate today to help us raise $5,000 to rent a 12-passenger van for a monthly creative economy tour of the District of Columbia, for a week long rental for an Alternative Winter Break tour and Alternative Spring Break tour.</p>
<p><a id="A7" href="#" class="btn btn-primary" role="button" onclick="btnBuy" runat="server">Buy</a><br /><form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
        <input type="hidden" name="cmd" value="_donations"><input type="hidden" name="business" value="top484.wordsbeatslifeproject@gmail.com"><input type="hidden" name="lc" value="US"><input type="hidden" name="item_name" value="Words Beats and Life, Inc"><input type="hidden" name="item_number" value="WBL"><input type="hidden" name="no_note" value="0"><input type="hidden" name="currency_code" value="USD"><input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest"><input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!"><img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
        </p>        
         </div>
        </div>
      </div>

      <div class="col-sm-4">
        <div class="thumbnail">
        <img src="img/muralproject1.jpg" alt="Mural Project #1">
        <div class="caption">
        <h3>Donate to Mural Project I</h3>
        <p>“We want our mural to represent what we stand for as a house. We are men of different faiths, different backgrounds, different races, and different socioeconomic classes, but we all share a desire to make a positive difference in the world.” -Graham McLaughlin, Clean Decisions</p>
<p><a id="A8" href="#" class="btn btn-primary" role="button" onclick="btnBuy" runat="server">Buy</a><br /><form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
        <input type="hidden" name="cmd" value="_donations"><input type="hidden" name="business" value="top484.wordsbeatslifeproject@gmail.com"><input type="hidden" name="lc" value="US"><input type="hidden" name="item_name" value="Words Beats and Life, Inc"><input type="hidden" name="item_number" value="WBL"><input type="hidden" name="no_note" value="0"><input type="hidden" name="currency_code" value="USD"><input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest"><input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!"><img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
        </p>        
         </div>
        </div>
      </div>

      <div class="col-sm-4">
        <div class="thumbnail">
        <img src="img/muralproject2.jpg" alt="Mural Project #2">
        <div class="caption">
        <h3>Donate to Mural Project II</h3>
        <p>“The DC Council voted to rename the 500 block of U Street, Lawrence Guyot Way in honor of my father’s contributions to the District, as well as his Civil Rights legacy.” -Julie Guyot, Daughter of Lawrence Guyot</p>
<p><a id="A9" href="#" class="btn btn-primary" role="button" onclick="btnBuy" runat="server">Buy</a><br /><form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
        <input type="hidden" name="cmd" value="_donations"><input type="hidden" name="business" value="top484.wordsbeatslifeproject@gmail.com"><input type="hidden" name="lc" value="US"><input type="hidden" name="item_name" value="Words Beats and Life, Inc"><input type="hidden" name="item_number" value="WBL"><input type="hidden" name="no_note" value="0"><input type="hidden" name="currency_code" value="USD"><input type="hidden" name="bn" value="PP-DonationsBF:btn_donateCC_LG.gif:NonHostedGuest"><input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!"><img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
        </p>        
       </div>
        </div>
      </div>


  </div><!--closing div -->



        
<!-- jQuery and Bootstrap links - do not delete! -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>

<!-- Include all compiled plugins (below), or include individual files as needed -->




</asp:Content>

