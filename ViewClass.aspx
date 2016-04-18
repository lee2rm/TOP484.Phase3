<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="true" CodeFile="ViewClass.aspx.cs" Inherits="ViewClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <form id="form1" runat="server">
    <div class="formE" style="width:50%;" >
        <h3>View Class</h3>
        <asp:Label ID="lblCourseName" runat="server" Text="Course Name: " CssClass="labels">
            <asp:TextBox ID="txtCourseName" runat="server" cssclass="textbox"></asp:TextBox></asp:Label>
       
        <br />
        
        <asp:Label ID ="lblCourseElement" runat ="server" Text ="Course Element:" CssClass="labels">
           <asp:Textbox ID="txtCourseElement" runat="server" CssClass="textbox"></asp:Textbox>
          </asp:Label><br />
      

        <asp:Label ID ="lblInstructor" runat ="server" Text ="Instructor: " CssClass="labels">
           <asp:Textbox ID ="txtInstructor" runat="server" CssClass="textbox"></asp:Textbox>
            </asp:Label><br />

        <asp:Label ID ="lblEmail" runat="server" Text="Email: " CssClass="labels">
            <asp:TextBox ID="txtEmail" runat="server"  CssClass="textbox"></asp:TextBox>
        </asp:Label>
      <br />
        

        
        <asp:Label ID ="lblLocation" runat="server" Text ="Location: " CssClass="labels">
            <asp:TextBox ID ="txtLocation" runat ="server" CssClass="textbox"></asp:TextBox>
        </asp:Label>
        <br />

        <asp:Label ID ="lblSemester" runat ="server" Text ="Semester: " CssClass="labels">
            <asp:Textbox ID="txtSemester" runat="server" CssClass="textbox"></asp:Textbox>
        </asp:Label>
        <br />

        
        <asp:Label ID="lblTime" runat="server" Text="Days of the Week: " CssClass="labels">
             <asp:Textbox ID="txtTime" runat="server"  CssClass="textbox"></asp:Textbox>
        </asp:Label><br />
       


        <asp:Label ID="lblLessonPlan" runat="server" Text="Lesson Plan: " CssClass="labels">
            <asp:FileUpload ID="flLessonPlan" runat="server" cssclass="textbox" style="color:white;"/>
        </asp:Label><br />
        <asp:Label ID ="lblPeriscope" runat="server" Text ="View this class on Periscope! " CssClass="labels"></asp:Label>
        <script>window.twttr = function (t, e, r) { var n, i = t.getElementsByTagName(e)[0], w = window.twttr || {}; return t.getElementById(r) ? w : (n = t.createElement(e), n.id = r, n.src = "https://platform.twitter.com/widgets.js", i.parentNode.insertBefore(n, i), w._e = [], w.ready = function (t) { w._e.push(t) }, w) }(document, "script", "twitter-wjs")</script><a href="https://www.periscope.tv/daniel_4" class="periscope-on-air" data-size="large">@Daniel_4</a>
         <br />
        <asp:Label ID ="lblCourseDesc" runat="server" Text="Course Description: " CssClass="labels">
        </asp:Label>
        <br />
            <asp:Textbox ID="txtCourseDes" runat="server" TextMode ="MultiLine" CssClass="textarea"></asp:Textbox>

        <br />
        
                 <br />
        
    </div>
         
        <div style="float:right; margin-right: 3%; margin-top:-45%;">

        <iframe id="myIframe"
  width="400"
  height="400"
  frameborder="0" style="border:0" runat="server"
  src="https://www.google.com/maps/embed/v1/place?key=AIzaSyBZi6ob0guXfcA9OV2j1fKMhKDJIP7upHE
    &q=Words_Beats_Life_Inc" allowfullscreen>
    </iframe>
            </div>
    </form>


</asp:Content>

