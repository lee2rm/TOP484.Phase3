<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

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
<title>Words Beats & Life Change Password</title>

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
                z-index: -100;
                background-repeat: no-repeat;
                background-size: 100%;
                height: 100%;
                box-shadow: 0 3px 5px #888888;
			}
        #loginContainer {
            background-color:rgba(8, 8, 8, 0.2);
            z-index: 50;
                width: 100%;
                padding: 0;
                margin: 0;
                height: 590px;
        }
        #loginForm {
            width: 30%;
            z-index: 100;
            margin-left: 35%;
            position: absolute;
            margin-top: 7%;
            box-shadow: 5px 5px 5px grey;
            -webkit-border-radius: 20px;
            -moz-border-radius: 20px;
            border-radius: 5px;
            border: 3px solid white;
            background:rgba(51,51,51,0.43);
            -webkit-box-shadow: #949494 10px 10px 10px;
            -moz-box-shadow: #949494 10px 10px 10px; 
            box-shadow: #949494 10px 10px 10px;
            padding: 0px 15px 15px 15px;
        }
        h2 {
            text-align: center;
            color: white;
        }
        #loginFooter {
        margin-top: 0;
        }
        #branding {
            padding: 15px 15px 0 15px;
        }
        input {
            margin-top: 5px;
            width: 110%;
            color: black;
            margin-right: 0;
            float: right;
        }
        label{
            margin-top: 5px;
            color: white !important;
            
        }
        #change {
            background-color: transparent;
            border: 2px solid white;
        }
        #change:hover {
                background-color: #2CE3C7;
                color: black;
            }
        table {
        width: 100%;
        }
        td {
            padding: 5px;
        }
      
    </style>

</head>
<body>
    
    
<div class="container" id="loginContainer" >



    <div id="formss">

        
          <form id="loginForm" class="form-signin" runat="server">
            
            <div>
                <h2>Change You Password: </h2>
                <table>
                    <tr>
                        <td><label id="lblConfirmEmail" runat="server"  class="labels" >Confirm Email: </label></td>
                        <td><asp:TextBox ID="txtConfirmEmail" runat="server" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label id="lblNewPass" runat="server"  class="labels">New Password: </label></td>
                        <td><asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label id="lblConfirmPass" runat="server"  class="labels">Confirm Password: </label></td>
                        <td><asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    
                </table>


               
                <asp:Button ID="change" runat="server" text="Change Password" Cssclass="btn btn-lg btn-primary btn-block" OnClick="btnChangePassword_Click" />
            </div>
            </form>

    </div>

  <div id="entireBox" >

          <div id="wrapperHeader">
            <div id="branding">
                <img id="branding-logo" src="img/logo.png" alt="Words Beats & Life Inc. Logo" />
            </div>
             </div>
       


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
