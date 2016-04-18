<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Hub.aspx.cs" Inherits="Hub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
  
    <style type="text/css">
        .container {
            width: 100%;
            max-width: 100%;
            padding: 0;
            margin: 0;
        }
        aside {
        display: none;
        }
        #bShade {
            background-color: black;
        }
        #jssor_1 {
            opacity: 0.7;
        }
        body {
            background-color: rgba(47,79,90,1);
        }
        #vimeo {
            position: relative;
            margin-left: 0;
            padding-top: 2%;
            padding-bottom: 2%;
        }
        #vimeoBar {
            position: relative;
            margin-left: 3%;
            
        }
        #vimeoStuff {

            background-color: grey;
            height: 680px;
            box-shadow: 7px 7px 7px #333
        }
        #instaa {
            margin-left: 11%;
            padding-left: 5px;
            padding-top: 8px;
        }
        #twitter {
            margin-left: 50%;
            padding-top: 5px;
        }
        #faceB {
            margin-left: 11%;
            }
        #blogg {
            margin-left: 11%;
            margin-right: 11%;
            padding-bottom: 10px;
                }
        #faceB {
            float: right;
            display: inline;
            margin-right: 5%;
        }
        h3 {
            padding-top: 20px;
        margin-left: 11%;
        color: white;
        margin-right: 11%
        }
        #soundCould {
            margin-top: 5px;
            margin-bottom: 1%;
        }
        #blogg a {
            color: black !important;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="foobar" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foo" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="body" Runat="Server">

    
    <script type="text/javascript" src="js/jquery-1.9.1.min3.js"></script>
    <script type="text/javascript" src="js/jssor.slider.mini3.js"></script>
    <!-- use jssor.slider.debug.js instead for debug -->
    <script>
        jQuery(document).ready(function ($) {

            var jssor_1_SlideoTransitions = [
              [{ b: 5500, d: 3000, o: -1, r: 240, e: { r: 2 } }],
              [{ b: -1, d: 1, o: -1, c: { x: 51.0, t: -51.0 } }, { b: 0, d: 1000, o: 1, c: { x: -51.0, t: 51.0 }, e: { o: 7, c: { x: 7, t: 7 } } }],
              [{ b: -1, d: 1, o: -1, sX: 9, sY: 9 }, { b: 1000, d: 1000, o: 1, sX: -9, sY: -9, e: { sX: 2, sY: 2 } }],
              [{ b: -1, d: 1, o: -1, r: -180, sX: 9, sY: 9 }, { b: 2000, d: 1000, o: 1, r: 180, sX: -9, sY: -9, e: { r: 2, sX: 2, sY: 2 } }],
              [{ b: -1, d: 1, o: -1 }, { b: 3000, d: 2000, y: 180, o: 1, e: { y: 16 } }],
              [{ b: -1, d: 1, o: -1, r: -150 }, { b: 7500, d: 1600, o: 1, r: 150, e: { r: 3 } }],
              [{ b: 10000, d: 2000, x: -379, e: { x: 7 } }],
              [{ b: 10000, d: 2000, x: -379, e: { x: 7 } }],
              [{ b: -1, d: 1, o: -1, r: 288, sX: 9, sY: 9 }, { b: 9100, d: 900, x: -1400, y: -660, o: 1, r: -288, sX: -9, sY: -9, e: { r: 6 } }, { b: 10000, d: 1600, x: -200, o: -1, e: { x: 16 } }]
            ];

            var jssor_1_options = {
                $AutoPlay: true,
                $SlideDuration: 800,
                $SlideEasing: $Jease$.$OutQuint,
                $CaptionSliderOptions: {
                    $Class: $JssorCaptionSlideo$,
                    $Transitions: jssor_1_SlideoTransitions
                },
                $ArrowNavigatorOptions: {
                    $Class: $JssorArrowNavigator$
                },
                $BulletNavigatorOptions: {
                    $Class: $JssorBulletNavigator$
                }
            };

            var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

            //responsive code begin
            //you can remove responsive code if you don't want the slider scales while window resizing
            function ScaleSlider() {
                var refSize = jssor_1_slider.$Elmt.parentNode.clientWidth;
                if (refSize) {
                    refSize = Math.min(refSize, 1920);
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
        
        /* jssor slider bullet navigator skin 05 css */
        /*
        .jssorb05 div           (normal)
        .jssorb05 div:hover     (normal mouseover)
        .jssorb05 .av           (active)
        .jssorb05 .av:hover     (active mouseover)
        .jssorb05 .dn           (mousedown)
        */
        .jssorb05 {
            position: absolute;
        }
        .jssorb05 div, .jssorb05 div:hover, .jssorb05 .av {
            position: absolute;
            /* size of bullet elment */
            width: 16px;
            height: 16px;
            background: url('img/b05.png') no-repeat;
            overflow: hidden;
            cursor: pointer;
        }
        .jssorb05 div { background-position: -7px -7px; }
        .jssorb05 div:hover, .jssorb05 .av:hover { background-position: -37px -7px; }
        .jssorb05 .av { background-position: -67px -7px; }
        .jssorb05 .dn, .jssorb05 .dn:hover { background-position: -97px -7px; }

        /* jssor slider arrow navigator skin 22 css */
        /*
        .jssora22l                  (normal)
        .jssora22r                  (normal)
        .jssora22l:hover            (normal mouseover)
        .jssora22r:hover            (normal mouseover)
        .jssora22l.jssora22ldn      (mousedown)
        .jssora22r.jssora22rdn      (mousedown)
        */
        .jssora22l, .jssora22r {
            display: block;
            position: absolute;
            /* size of arrow element */
            width: 40px;
            height: 58px;
            cursor: pointer;
            background: url('img/a22.png') center center no-repeat;
            overflow: hidden;
        }
        .jssora22l { background-position: -10px -31px; }
        .jssora22r { background-position: -70px -31px; }
        .jssora22l:hover { background-position: -130px -31px; }
        .jssora22r:hover { background-position: -190px -31px; }
        .jssora22l.jssora22ldn { background-position: -250px -31px; }
        .jssora22r.jssora22rdn { background-position: -310px -31px; }
    </style>

   <h3 style="position: absolute; margin-left:25%; margin-top:13%; z-index: 100; font-size: 2.5em; text-shadow: 5px 5px 5px grey; width: 800px; height: 120px; font-weight:bold; font-size: 50px; color: #ffffff; line-height: 60px;">WELCOME TO THE HUB</h3>


    <div id="bShade">
    <div id="jssor_1" style="position: relative; margin: 0 auto; left: 0px; margin-top: -80px;  width: 1300px; height: 500px; overflow: hidden; visibility: hidden;">
        <!-- Loading Screen -->
        <div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
            <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
            <div style="position:absolute;display:block;background:url('img/loading.gif') no-repeat center center;top:0px;left:0px;width:100%;height:100%;"></div>
        </div>
        <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 1300px; height: 500px; overflow: hidden;">
            <div data-p="225.00" style="display: none;">
                <img data-u="image" src="img/1.jpg" />
            </div>
            <div data-p="225.00" style="display: none;">
                <img data-u="image" src="img/6.jpg" />
            </div>
            <div data-p="225.00" style="display: none;">
                <img data-u="image" src="img/5.jpg" />
            </div>
			<div data-p="225.00" style="display: none;">
                <img data-u="image" src="img/4.jpg" />
            </div>
			<div data-p="225.00" style="display: none;">
                <img data-u="image" src="img/2.jpg" />
            </div>
			<div data-p="225.00" style="display: none;">
                <img data-u="image" src="img/3.jpg" />
            </div>
        
        </div>
        <!-- Bullet Navigator -->
        <div data-u="navigator" class="jssorb05" style="bottom:16px;right:16px;" data-autocenter="1">
            <!-- bullet navigator item prototype -->
            <div data-u="prototype" style="width:16px;height:16px;"></div>
        </div>
        <!-- Arrow Navigator -->
        <span data-u="arrowleft" class="jssora22l" style="top:0px;left:12px;width:40px;height:58px;" data-autocenter="2"></span>
        <span data-u="arrowright" class="jssora22r" style="top:0px;right:12px;width:40px;height:58px;" data-autocenter="2"></span>
    </div>
        </div>
    <!-- #endregion Jssor Slider End -->

   <div id="soundCloud">
             <iframe width="100%" height="166" scrolling="no" background-color: "darkgrey" frameborder="no" src="https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/143741131&amp;color=ff5500&amp;auto_play=false&amp;hide_related=false&amp;show_comments=true&amp;show_user=true&amp;show_reposts=false"></iframe>
        </div>

   <div id="vimeoStuff">

       <p style="margin-left: 11%; margin-top: 5%; margin-bottom: -2%; color: white; font-size: 2em; font-weight: bold;">Featured Content</p>

       <%--VIMEO--%>
       <div id="vimeo">
    <iframe id="vimeoFrame" src="//player.vimeo.com/hubnut/album/3892866?color=44bbff&amp;background=000000&amp;slideshow=1&amp;video_title=1&amp;video_byline=1" width="100%" height="400" frameborder="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>   
    </div>


        <style id="Style1">
 /* You can modify these CSS styles */
 .vimeoBadge { margin: 0; padding: 0; font: normal 11px verdana,sans-serif; }
 .vimeoBadge img { border: 0; }
 .vimeoBadge a, .vimeoBadge a:link, .vimeoBadge a:visited, .vimeoBadge a:active { color: #3A75C4; text-decoration: none; cursor: pointer; }
 .vimeoBadge a:hover { color:#00CCFF; }
 .vimeoBadge #vimeo_badge_logo { margin-top:10px; width: 57px; height: 16px; }
 .vimeoBadge .credit { font: normal 11px verdana,sans-serif; }
 .vimeoBadge .clip { padding:0; float:left; margin:0 10px 10px 0; line-height:0; }
 .vimeoBadge.vertical .clip { float: none; }
 .vimeoBadge .caption { font: normal 11px verdana,sans-serif; overflow:hidden; width: auto; height: 40px; }
 .vimeoBadge .clear { display: block; clear: both; visibility: hidden; }
 .vimeoBadge .s160 { width: 160px; } .vimeoBadge .s80 { width: 80px; } .vimeoBadge .s100 { width: 100px; } .vimeoBadge .s200 { width: 200px; }
 </style>

   <div id="vimeoBar" class="vimeoBadge horizontal">
<script src="https://vimeo.com/user50958423/badgeo/?script=1&badge_layout=horizontal&badge_quantity=6&badge_size=200&badge_stream=album&show_titles=yes&badge_album=3892866"></script>

</div>

   </div>

    <p style="margin-left: 11%; color: white; font-size: 2em; font-weight: bold;">Stay Connected</p>

        <div id="instaa">
            <div class="ig-root ak8E48 clearfix"> </div>
                <script>
                    scripts = [];
                    host = 'http://www.uptsi.com';
                    js = document.createElement('script');
                    js.src = host + "/tools/widgets/b/29bQ05624f56WPl871ekb45J6d6i2E4iI188R6HU3291Tf45a7g1AaLY7438c57ZkghdNG";
                    scripts[0] = js;
                    for (i = 0; i < scripts.length; i++) { document.getElementsByTagName("HEAD")[0].appendChild(scripts[i]); }
                </script>
        </div>
        

    <div id="twitter">

            <%--TWITTER--%>
            <a class="twitter-timeline" href="https://twitter.com/WordsBeatsLife" data-widget-id="718852033067896832">Tweets by @WordsBeatsLife</a>
            <script type="text/javascript" async src="https://platform.twitter.com/widgets.js"></script>

          <a class="twitter-mention-button"
            href="https://twitter.com/intent/tweet?screen_name=WordsBeatsLife">
            Tweet to @WordsBeatsLife</a>
          <script>window.twttr = (function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0],
      t = window.twttr || {};
    if (d.getElementById(id)) return t;
    js = d.createElement(s);
    js.id = id;
    js.src = "https://platform.twitter.com/widgets.js";
    fjs.parentNode.insertBefore(js, fjs);

    t._e = [];
    t.ready = function (f) {
        t._e.push(f);
    };

    return t;
}(document, "script", "twitter-wjs"));</script>


        </div>
 

    <div id="blogg">
<!-- Begin Comments JavaScript Code --><script type="text/javascript" async>function ajaxpath_570dc0d5c43cf(url) { return window.location.href == '' ? url : url.replace('&s=', '&s=' + escape(window.location.href)); } (function () { document.write('<div id="fcs_div_570dc0d5c43cf"><a title="free comment script" href="http://www.freecommentscript.com">&nbsp;&nbsp;<b>Free HTML User Comments</b>...</a></div>'); fcs_570dc0d5c43cf = document.createElement('script'); fcs_570dc0d5c43cf.type = "text/javascript"; fcs_570dc0d5c43cf.src = ajaxpath_570dc0d5c43cf((document.location.protocol == "https:" ? "https:" : "http:") + "//www.freecommentscript.com/GetComments2.php?p=570dc0d5c43cf&s=&Size=10#!570dc0d5c43cf"); setTimeout("document.getElementById('fcs_div_570dc0d5c43cf').appendChild(fcs_570dc0d5c43cf)", 1); })();</script><noscript><div><a href="http://www.freecommentscript.com" title="Leave Your Comments">Comment Here!</a></div></noscript><!-- End Comments JavaScript Code -->

        </div>




</asp:Content>

