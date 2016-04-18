<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUpDesc.aspx.cs" Inherits="SignUpDesc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="description" content="Free Web tutorials">
    <meta name="keywords" content="HTML,CSS,XML,JavaScript">
    <meta name="author" content="Hege Refsnes">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
<title>Words Beats & Life Login</title>

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



         #entireBox {
				position: relative;
				background-image:url(img/dj_header.jpg);
                background-repeat: no-repeat;
                background-size: 100%;
                height: 100%;
                box-shadow: 0 3px 5px #888888;
                
			}
        #loginContainer {
        width: 100%;
        padding: 0;
        margin: 0;
        height: 590px;
        color: white;
        font-family: "Ovo";
        }
        #studentForm {
            width: 23%;
            margin-left: 12%;
            position: absolute;
            box-shadow: 5px 5px 5px grey;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            border: 3px solid white;
            background:#555;
            -webkit-box-shadow: #949494 10px 10px 10px;
            -moz-box-shadow: #949494 10px 10px 10px; 
            box-shadow: #949494 10px 10px 10px;
            padding: 0px 15px 15px 15px;
            font-family: "Ovo";

        }
        #parentForm {
            width: 23%;
            margin-left: 41%;
            position: absolute;
            box-shadow: 5px 5px 5px grey;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            border: 3px solid white;
            background:#555;
            -webkit-box-shadow: #949494 10px 10px 10px;
            -moz-box-shadow: #949494 10px 10px 10px; 
            box-shadow: #949494 10px 10px 10px;
            padding: 0px 15px 15px 15px;
            font-family: "Ovo";

        }


        #cipherForm {
            width: 23%;
            margin-left: 70%;
            position: absolute;
            box-shadow: 5px 5px 5px grey;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            border: 3px solid white;
            background:#555;
            -webkit-box-shadow: #949494 10px 10px 10px;
            -moz-box-shadow: #949494 10px 10px 10px; 
            box-shadow: #949494 10px 10px 10px;
            padding: 0px 15px 15px 15px;
            font-family: "Ovo";
        }



        #loginFooter {
        margin-top: 0;
        }
        #branding {
            padding: 15px 15px 0 15px;
        }

         .buttons {
          width: 112%;
          margin-left: -6%;
          height: 35px;
		  background-color: #22EECF;
		  color: black;
          -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
          border: 2px solid white;
        }


        #descriptions {
            padding-top: 3%;
        }
        .descriptionTop
        {
            border-top-left-radius: 20px;
            border-top-right-radius: 20px;
            padding: 15px;
        }
        h2 {
            text-align:center;
            font-family: "Skyfall";
        } 

         #studentDescriptionList, #parentDescriptionList, #cipherDescriptionList {
            padding: 5px;
            border-bottom-left-radius: 20px;
            border-bottom-right-radius: 20px;
            height: 20%;
         }
        
         #student {
            width: 25%;
            float: left;
            margin-left: 7%;
            height: 75%;
        }
           #parent {
            width: 25%;
            float: left;
            margin-left: 5%;
            height: 75%;
            display: inline;
        }
         #cipher {
            width: 25%;
            float: right;
            margin-right: 7%;
            height: 75%;
            display: inline;
        }
        p {
            color: white;
        }



    </style>

</head>
<body>
    
    
<div class="container" id="loginContainer" >



  <div id="entireBox" >

          <div id="wrapperHeader">
            <div id="branding">
                <img id="branding-logo" src="img/logo.png" alt="Words Beats & Life Inc. Logo" />
            </div>
             </div>
       

          <form id="form" class="form-signin" runat="server">
          <div id="studentForm">
            <div class="descriptionTop">
            <h2>Student</h2>
            <p>Our Master Arts Instructors guide Academy apprentice students as a learning community working towards realizing success in our five foundational outcomes: Skill-Set Mastery, Employability, the Pursuit of a Post-Secondary Education, Community, and Self Mastery. </p>
                        </div>
            <asp:Button ID="btnStudent" runat="server" Text="Student" CssClass="buttons" OnClick="btnStudent_Click" />
        <div id="studentDescriptionList">
            <asp:BulletedList ID="bLStudentDesc" runat="server">
            <asp:ListItem>Enroll in classes at The Academy</asp:ListItem>
            <asp:ListItem>Master the arts!</asp:ListItem>
            <asp:ListItem>Access to opprotunities in and around the DC area</asp:ListItem>
        </asp:BulletedList>
          
            </div>  
              </div>

              <div id="parentForm">

                   <div class="descriptionTop">
            <h2>Parent</h2>
        <p>Do you have a student in the WBL Academy? Would you like to follow your student's progress? Sign up for your own account and have access to your student's evaluations, content, and the community wall. Follow your child's development and share their work as they develop.</p>
        </div>
            <asp:Button ID="btnParent" runat="server" Text="Parent" CssClass="buttons" OnClick="btnParent_Click" />
        <div id="parentDescriptionList">
            <asp:BulletedList ID="bLParentDescription" runat="server">
            <asp:ListItem>Membership Fee: none</asp:ListItem>
            <asp:ListItem>Acess all student content</asp:ListItem>
                <asp:ListItem>Must have a student registered in the Academy</asp:ListItem>
        </asp:BulletedList>
            </div>

              </div>

              <div id="cipherForm">
                  <div class="descriptionTop">
            <h2>Cipher</h2>
        <p>The Cipher is a sacred circle of interconnectedness whose members are artists, activists, educators, practitioners and scholars. We publish peer-reviewed research and promising practices to make our work as a field more impactful, sustainable and measurable.</p>
        </div>
                <asp:Button ID="btnCipher" runat="server" Text="Cipher" CssClass="buttons" OnClick="btnCipher_Click"/>
        <div id="cipherDescriptionList">
            <asp:BulletedList ID="bLCipherDescList" runat="server">
            <asp:ListItem>Membership Fee: $75 paid annually</asp:ListItem>
            <asp:ListItem>Access to all student content</asp:ListItem>
                <asp:ListItem>FREE WBL Merchandise</asp:ListItem>
            <asp:ListItem>10% off WBL workshops or services</asp:ListItem>
        </asp:BulletedList>
            </div>
           
              </div>


          </form>

      </div>




      </div><!--closing div to tanbox-->



    
    <footer>
        <div class="footer" id="loginFooter"><!--starting tag for footer-->
    <div class="row">
      <div class="col-sm-1"> <img src="img/WBL_LOGO_blk.png" class="img-responsive" alt="small WBL logo"> 
      </div>
      <div class="col-sm-11">
      </div>
      
    </div>  

</div><!--footer div closing div-->
    </footer>
</body>
    
</html>
