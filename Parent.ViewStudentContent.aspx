<%@ Page Title="" Language="C#" MasterPageFile="~/ParentMasterPage.master" AutoEventWireup="true" CodeFile="Parent.ViewStudentContent.aspx.cs" Inherits="Parent_ViewStudentContent" %>


<asp:Content ID="ContentHeader" runat="server" ContentPlaceHolderID="contentHeader">
    <meta charset="utf-8">
    <meta name="description" content="Free Web tutorials">
    <meta name="keywords" content="HTML,CSS,XML,JavaScript">
    <meta name="author" content="Hege Refsnes">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

           <!-- <Bootstrap CSS>--> 
        <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="screen">

        <!-- Cutstom CSS-->
        <link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">

        <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
            <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
            <!--[if lt IE 9]>
              <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
              <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
            <![endif]-->

    <style type="text/css">
        .col-sm-2 {
        width: 800px;
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
        h3#name {
        margin: 0 auto;
        text-align: center;
        }
        .col-sm-8 {
        margin-left: 17%;
        margin-bottom: 5%;
        }
        img {
            margin: 0 auto;
        }
        .thumbnail {
            margin-left: 15%;
        }
    </style>

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
        
        </style>

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
    <h3>Your Student's Content</h3>


      <div class="col-sm-2">
    <div class="thumbnail">
      <img src="img/lex.jpg" alt="BBoy Bridge">
      <div class="caption">
        <h3 id="name">Elexia A.</h3>
        <p>Elexia is a recent High School graduate. She is a member of the DC Youth Slam Team, FRESHH (Females Representing Every Side of Hip Hop), and writes and models for LOVE Girls Magazine. She has trained in dance for 14 years and performed on stages everywhere from DC to Martha’s Vineyard. She enjoys interacting with the youth in her community and empowering their voices through the use of natural talent. Lexi felt that poetry was never her hobby, but her culture and method of communication. She aspires to become a speech therapist and a published poet. She lives by the values of respect and love which are reinforced by her favorite quote by Audre Lorde: “Caring about myself is not an act of self- indulgence but an act of self- preservation; and that, is a method of political warfare.”
        </p>      </div>
    </div>
  </div>


    

     <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 5%; margin-bottom: 5%; width: 809px; height: 150px; box-shadow: 7px 7px 5px grey; overflow: hidden; visibility: hidden;">
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




</asp:Content>

