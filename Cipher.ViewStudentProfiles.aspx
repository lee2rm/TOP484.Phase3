<%@ Page Title="" Language="C#" MasterPageFile="~/CipherMasterPage.master" AutoEventWireup="true" CodeFile="Cipher.ViewStudentProfiles.aspx.cs" Inherits="Cipher_ViewStudentProfiles" %>


<asp:Content ID="headContent" ContentPlaceHolderID="headContent" runat="server">
     <meta charset="utf-8">
    <meta name="description" content="Free Web tutorials">
    <meta name="keywords" content="HTML,CSS,XML,JavaScript">
    <meta name="author" content="Hege Refsnes">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

            
        <!-- Bootstrap CSS -->
        <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="screen">

        <!-- Cutstom CSS -->
        <link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">

        <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
            <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
            <!--[if lt IE 9]>
              <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
              <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
            <![endif]-->

    <style type="text/css">
        .col-sm-2 {
        width: 30%;
        height: 55%;
        }
        a.btn.btn-primary {
        width: 150px;
        margin-bottom: 2%;
        margin-left: 10%;
        margin-right: auto;
        }
        a.btn.btn-default {
        width: 150px;
        margin-left: 10%;
        margin-right: auto;
        }
        #body_Panel4 img {
            height: 90%;
            width: 90%;
        }
        #body_Panel4 a {
            color: white !important;
        }
 
    </style>

</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
    <h3>Student Profiles</h3>


      <div class="col-sm-2">
    <div class="thumbnail">
      <img src="img/lex.jpg" alt="BBoy Bridge">
      <div class="caption">
        <h3>Elexia A.</h3>
        <p>Elexia is a recent High School graduate. She is a member of the DC Youth Slam Team, FRESHH (Females Representing Every Side of Hip Hop), and writes and models for LOVE Girls Magazine. She has trained in dance for 14 years and . . .</p>
        <p> <a href="https://pathbrite.com/portfolio/PpXH1PIET/elexia-alleyne" class="btn btn-default" role="button">View Portfolio</a></p>
      </div>
    </div>
  </div>

<div class="col-sm-2">
    <div class="thumbnail">
      <img src="img/chess.jpg" alt="BBoy Bridge">
      <div class="caption">
        <h3>Andrew W.</h3>
        <p>Andrew W. is a 12 year old Chess student from Washington D.C. He began learning the game with his father, but it was his teacher, . . .</p>
        <p><a href="https://pathbrite.com/portfolio/PpXHlPwbT/andrew-waring-apprentice-portfolio" class="btn btn-default" role="button">View Portfolio</a></p>
      </div>
    </div>
  </div>

<div class="col-sm-2">
    <div class="thumbnail">
      <img src="img/GB.jpg" alt="BBoy Bridge">
      <div class="caption">
        <h3>Gabriel B.</h3>
        <p>Gabriel B. is 13 years old and in the 7th grade. He was born and raised in Washington, D.C. His interests include sports, music, and art. He is especially interested in photography, because he enjoys using the camera and . . .</p>
        <p><a href="https://pathbrite.com/portfolio/PpXHlPiDT/gabriel-benn-digital-media" class="btn btn-default" role="button">View Portfolio</a></p>
      </div>
    </div>
  </div>



</asp:Content>

