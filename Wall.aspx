<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Wall.aspx.cs" Inherits="Wall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    
     <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="js/jssor.slider.mini.js"></script>
    <!-- use jssor.slider.debug.js instead for debug -->
    <script>
        jQuery(document).ready(function ($) {

            var jssor_1_options = {
                $AutoPlay: true,
                $AutoPlaySteps: 4,
                $SlideDuration: 160,
                $SlideWidth: 200,
                $SlideSpacing: 3,
                $Cols: 4,
                $ArrowNavigatorOptions: {
                    $Class: $JssorArrowNavigator$,
                    $Steps: 4
                }

            };

            var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

            //responsive code begin
            //you can remove responsive code if you don't want the slider scales while window resizing
            function ScaleSlider() {
                var refSize = jssor_1_slider.$Elmt.parentNode.clientWidth;
                if (refSize) {
                    refSize = Math.min(refSize, 809);
                    jssor_1_slider.$ScaleWidth(refSize);
                }
                else {
                    window.setTimeout(ScaleSlider, 30);
                }
            }
            ScaleSlider();
            $(window).bind("load", ScaleSlider);
            $(window).bind("resize", ScaleSlider);
            $(window).bind("orientationchange", ScaleSlider);
            //responsive code end
        });
    </script>

    <style>
        
        /* jssor slider bullet navigator skin 03 css */
        /*
        .jssorb03 div           (normal)
        .jssorb03 div:hover     (normal mouseover)
        .jssorb03 .av           (active)
        .jssorb03 .av:hover     (active mouseover)
        .jssorb03 .dn           (mousedown)
        */
        .jssorb03 {
            position: absolute;
        }
        .jssorb03 div, .jssorb03 div:hover, .jssorb03 .av {
            position: absolute;
            /* size of bullet elment */
            width: 21px;
            height: 21px;
            text-align: center;
            line-height: 21px;
            color: white;
            font-size: 12px;
            background: url('img/b03.png') no-repeat;
            overflow: hidden;
            cursor: pointer;
        }
        .jssorb03 div { background-position: -5px -4px; }
        .jssorb03 div:hover, .jssorb03 .av:hover { background-position: -35px -4px; }
        .jssorb03 .av { background-position: -65px -4px; }
        .jssorb03 .dn, .jssorb03 .dn:hover { background-position: -95px -4px; }

        /* jssor slider arrow navigator skin 03 css */
        /*
        .jssora03l                  (normal)
        .jssora03r                  (normal)
        .jssora03l:hover            (normal mouseover)
        .jssora03r:hover            (normal mouseover)
        .jssora03l.jssora03ldn      (mousedown)
        .jssora03r.jssora03rdn      (mousedown)
        */
        .jssora03l, .jssora03r {
            display: block;
            position: absolute;
            /* size of arrow element */
            width: 55px;
            height: 55px;
            cursor: pointer;
            background: url('img/a03.png') no-repeat;
            overflow: hidden;
        }
        .jssora03l { background-position: -3px -33px; }
        .jssora03r { background-position: -63px -33px; }
        .jssora03l:hover { background-position: -123px -33px; }
        .jssora03r:hover { background-position: -183px -33px; }
        .jssora03l.jssora03ldn { background-position: -243px -33px; }
        .jssora03r.jssora03rdn { background-position: -303px -33px; }


        #daWall {
            position: absolute;
            margin-left: -32%;
            margin-top: -3%;
            background-image:url(img/wall.jpg);
            z-index: -100;
            background-repeat: no-repeat;
            opacity: 0.8;
            background-size: 100%;
            height: 1280px;
            width: 1800px;
            box-shadow: 0 3px 5px #888888;
        }
        /*#wallAnnouncements {
            margin-left: 
        }*/

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

    <div id="daWall"></div>
    
        <div id="wallTitle">
            <br />
	    	<h3 style="margin:3% auto;font-size:3.3em;">Community Wall</h3><br />
            <p style="margin: 0 auto;text-wrap:initial; margin-right:2%;">Welcome to the community!
                DC’s pre-vocational Hip-Hop program for youth ages 13-23.
                <br />We harness and protect a sacred space of creativity through instruction in all the artistic forms and practices of Hip-Hop Culture.
               <br /> Our interactive classes in the core elements of hip-hop annually enroll 150-225 students in the DC Metro area. Our program is free of charge to all participants. Each session lasts 8-10 weeks.
            </p>
            </div>
    <br />
    

    <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 5%; width: 809px; height: 150px; box-shadow: 7px 7px 5px grey; overflow: hidden; visibility: hidden;">
        <!-- Loading Screen -->
        <div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
            <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
            <div style="position:absolute;display:block;background:url('img/loading.gif') no-repeat center center;top:0px;left:0px;width:100%;height:100%;"></div>
        </div>
        <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 809px; height: 150px; overflow: hidden;">
            <div style="display: none;">
                <img data-u="image" src="img/Andrew.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/GB.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/BBoyBridge.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/simon.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/beat_production.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/EA1.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/DJpic.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/chess.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/Andrew.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/GB.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/BBoyBridge.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/simon.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/beat_production.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/EA1.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/DJpic.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/chess.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/Andrew.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/GB.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/BBoyBridge.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/simon.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/beat_production.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/EA1.jpg" />
            </div>
            <div style="display: none;">
                <img data-u="image" src="img/DJpic.jpg" />
            </div>
            
        
        </div>
        <!-- Bullet Navigator -->
        <div data-u="navigator" class="jssorb03" style="bottom:10px;right:10px;">
            <!-- bullet navigator item prototype -->
            <div data-u="prototype" style="width:21px;height:21px;">
                <div data-u="numbertemplate"></div>
            </div>
        </div>
        <!-- Arrow Navigator -->
        <span data-u="arrowleft" class="jssora03l" style="top:0px;left:8px;width:55px;height:55px;" data-autocenter="2"></span>
        <span data-u="arrowright" class="jssora03r" style="top:0px;right:8px;width:55px;height:55px;" data-autocenter="2"></span>
    </div>





<!-- COMMUNITY WALL Queso-->
        <div id="imgBoxes">
	    	<div id="wall" class="ten columns">
	    		<img src="img/BBoyBridge.jpg"
		            alt="WBL BBoy"
		            title="WBL BBoy"
		            data-desc="WBL BBoy 101"
		            data-category="image category here"
		            data-fullsrc="img/img.jpg"
		        />
		        <img src="img/chess.jpg"
		            alt="Andrew W. Chess"
		            title="Chess by Andrew W."
		            data-desc="12 year old chess player from DC"
		            data-category="image category here"
		            data-fullsrc="img/img.jpg"
		        /> 
		        <img src="img/simon.jpg"
		            alt="Grafitti"
		            title="Grafitti Story"
		            data-desc="Grafitti description"
		            data-category="image category here"
		            data-fullsrc="img/img.jpg"
		        /> 
		        <img src="img/GB.jpg"
		            alt="Gabriel Benn Photography"
		            title="Gabriel Benn Photography"
		            data-desc="Photography 101"
		            data-category="image category here"
		            data-fullsrc="img/img.jpg"
		        />
		        <img src="img/DJpic.jpg"
		            alt="DJ"
		            title="DJ by Javier G."
		            data-desc="DJ 101"
		            data-category="image category here"
		            data-fullsrc="img/img.jpg"
		        /> 
		        <img src="img/beat_production.jpg"
		            alt="Beat Production"
		            title="Beat Production"
		            data-desc="some description"
		            data-category="image category here"
		            data-fullsrc="img/img.jpg"
		        />  

    		</div>
            </div>
       
    		<!-- END COMMUNITY WALL -->


   <div id="announcements">
        <h3>Announcements</h3>
   
       
     <div id="wallAnnouncements">
        <ul>
            <li>Learn the prep process on April 23rd before the Paint Jam on the 30th!</li><br />
            <li>Anti-Graffiti Amendment Act of 2016: dishing out fines and prison time for paint caps?</li><br />
            <li>The launch of the Creative Core has allowed WBL to work toward becoming a city wide and eventually a regional Hip-Hop Apprentice Program</li><br />
            <li>The Living Classrooms is a monthly Friday Academy field trip series dedicated to support our apprentice students exploration of creative careers and developing relationships in the creative sector among entrepreneurs, arts managers and educators.</li>
        </ul>
          <%--<ul>
            <li>BE CREATIVE</li>
            <li>BE CREATIVE</li>
            <li>BE CREATIVE</li>
            <li>BE CREATIVE</li>
            <li>BE CREATIVE</li>
        </ul>--%>

    </div>
    </div>

    

  

</asp:Content>


