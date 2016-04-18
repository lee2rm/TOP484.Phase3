<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>

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
<title>Words Beats & Life Registration</title>

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
				background-image:url(img/6.jpg);
                z-index: -100;
                background-repeat: no-repeat;
                background-size: 100%;
                height: 100%;
                box-shadow: 0 3px 5px #888888;
                
			}
        #regContainer {
            background-color:rgba(8, 8, 8, 0.2);
            z-index: 50;
                width: 100%;
                padding: 0;
                margin: 0;
                height: 590px;
                color: white;
        }
        #regForm {

            width: 70%;
            z-index: 100;
            margin-left: 15%;
            position: absolute;
            margin-top: 2%;
            box-shadow: 5px 5px 5px grey;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            border: 3px solid white;
            background:rgba(51, 51, 51, 0.69);
            -webkit-box-shadow: #949494 10px 10px 10px;
            -moz-box-shadow: #949494 10px 10px 10px; 
            box-shadow: #949494 10px 10px 10px;
            padding: 0px 15px 15px 15px;

        }
        h3 {
           text-decoration: none;
            color: white;
        }
        h2 {
            text-align: center;
        }
        #regFooter {
        margin-top: 0;
        }
        #branding {
            padding: 15px 15px 0 15px;
        }
        input {
            margin-top: 5px;
        }
        label, a {
            color: white !important;
        }
        #reg, #signUp {
            background-color: transparent;
            border: 2px solid white;
        }

        .buttons {
          width: 40%;
          margin-left: 30%;
          margin-top: 2%;
          height: 35px;
		  background-color: #22EECF;
		  color: black;
          -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
          border: 2px solid white;
          box-shadow: 3px 3px 5px grey;
        }
        td {
            padding-left: 7px;
        }
        .dropdown {
            width: 100%;
            margin-top: 5px;
        }

          input {
        color: black;
        }
        

    </style>

</head>
<body>
    
    
<div class="container" id="regContainer" >



    <div id="formss">

        
          <form id="regForm" class="form-signin" runat="server">
            
              <h3 style="text-align:center;">Join the Community!</h3>
          
          
          <div id="allInfo" runat="server">
                <h3>User Information</h3>
              <table>
                  <tr>
                      <td>
                          <asp:Label ID="lblfName" runat="server" Text="First Name: " ></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="txtfName" runat="server" ></asp:TextBox>
                      </td>
                      <td>
                       <asp:Label ID="lbllName" runat="server" Text="Last Name: " ></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="txtlName" runat="server" ></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td>
                 <asp:Label ID="lblEmail" runat="server" Text="E-mail Address: "></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                      </td>
                      <td><asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label></td>
                      <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                      <td><asp:Label ID="lblPassword2" runat="server" Text="Confirm Password: "></asp:Label></td>
                      <td><asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="lblDOB" runat="server" Text="Date of Birth: "></asp:Label></td>
                      <td><asp:TextBox ID="txtDOB" runat="server" ></asp:TextBox><asp:CompareValidator 
                            ID="cpvDOB" 
                            ControlToValidate ="txtDOB"
                            Operator="DataTypeCheck"
                            Type="Date"
                            runat="server" 
                            ErrorMessage="Invalid Date"
                            CssClass="warning" 
                            ValidationGroup="insEmp"/>
                        <asp:RequiredFieldValidator 
                            ID="rfvDOB"
                            ControlToValidate ="txtDOB" 
                            runat="server" 
                            ErrorMessage="(Required Field)"
                            CssClass="warning" 
                            ValidationGroup="insEmp"/>
                        <asp:CompareValidator 
                            ID="cvYDOB" 
                            ControlToValidate="txtDOB" 
                            Type="Date" 
                            Operator="LessThan"
                            ErrorMessage="(Invalid age!)"
                            Display="Dynamic" 
                            runat="server"
                            ValidationGroup="insEmp"/>
                        <asp:CompareValidator 
                            ID="cvODOB" 
                            ControlToValidate="txtDOB" 
                            Type="Date" 
                            Operator="Greaterthan"
                            ErrorMessage="(Over 100 years Old)" 
                            Display="Dynamic"
                            runat="server"
                            ValidationGroup="insEmp"/></td>
                      <td><asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label></td>
                      <td><asp:DropDownList ID="ddlGender" runat="server" CssClass="dropdown" style="color:black;">
                                <asp:ListItem>Female</asp:ListItem>
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Trans/Transgender</asp:ListItem>
                                <asp:ListItem>Genderqueer</asp:ListItem>
                                <asp:ListItem>Prefer not to say</asp:ListItem>
                            </asp:DropDownList></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="lblAddress" runat="server" Text="Address: "></asp:Label></td>
                      <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                      <td><asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label></td>
                      <td><asp:TextBox ID="txtCity" runat="server" ></asp:TextBox></td>
                      <td><asp:Label ID="lblState" runat="server" Text="State: "></asp:Label></td>
                      <td><asp:TextBox ID="txtState" runat="server" ></asp:TextBox></td>
                  </tr>
                  <tr>
                      <td><asp:Label ID="lblZip" runat="server" Text="Zip: "></asp:Label></td>
                      <td><asp:TextBox ID="txtZip" runat="server" ></asp:TextBox></td>
                      <td><asp:Label ID="lblHome" runat="server" Text="Home Phone #: "></asp:Label></td>
                      <td><asp:TextBox ID="txtHome" runat="server" ></asp:TextBox></td>
                      <td><asp:Label ID="lblCell" runat="server" Text="Cell Phone #: "></asp:Label></td>
                      <td><asp:TextBox ID="txtCell" runat="server" CssClass="textbox"></asp:TextBox></td>
                   </tr>
                  <tr>
                      <td> <asp:Label ID="lblShirtSize" runat="server" Text="Shirt Size" ></asp:Label></td>
                      <td><asp:DropDownList ID="ddlShirtSize" runat="server" CssClass="dropdown" style="color:black;">
                                <asp:ListItem Text ="XS">XS</asp:ListItem>
                                <asp:ListItem Text ="S">S</asp:ListItem>
                                <asp:ListItem Text ="M">M</asp:ListItem>
                                <asp:ListItem Text ="L">L</asp:ListItem>
                                <asp:ListItem Text ="XL">XL</asp:ListItem>
                                <asp:ListItem Text ="XXL">XXL</asp:ListItem>
                            </asp:DropDownList></td>
                      </tr>
                  <tr>
                      <td><asp:Label ID="lblRace" runat="server" Text="Race: "></asp:Label></td>
                  </tr>
                  <tr>
                       <asp:CheckBoxList ID="cblRace" runat="server">   
                        <asp:ListItem  runat="server" Value="American India or Alaskan Native" cssClass="radioButtons"/>
                        <asp:ListItem  runat="server" Value="Asian or Pacific Islander" cssClass="radioButtons"/>
                        <asp:ListItem  runat="server" Value="Black or African American" cssClass="radioButtons"/>
                        <asp:ListItem  runat="server" Value="Latino/Latina" cssClass="radioButtons"/>
                        <asp:ListItem  runat="server" Value="White" cssClass="radioButtons"/>
                        <asp:ListItem  runat="server" Value="Other" cssClass="radioButtons"/>
                    </asp:CheckBoxList>
                  </tr>

              </table>
                        
                        
            
                       
                            
                 
                   

                <asp:Button ID="btnSignUpAllInfo" runat="server" Text="Sign Up"  CssClass="buttons" OnClick="btnSignUp_Click" /><br /> 
                 </div>
          
          
                   <!-- Parent additional information -->
    <div id="parentAdditions" runat="server">
             <div id="parentBlock" runat="server">

                   <h3>Student Confirmation Page</h3>
                 <span>Please confirm the following information for your children.</span><br />
                 <h4> Student 1 Information: </h4>
                 <table>
                     <tr>
                         <td><asp:Label ID="lblChildsFName" runat="server" Text="First Name:"></asp:Label></td>
                         <td><asp:TextBox ID="txtChildLName" runat="server"></asp:TextBox></td>
                         <td><asp:Label ID="lblChildsLName" runat="server" Text="Last Name:"></asp:Label></td>
                         <td><asp:TextBox ID="txtChildFName" runat="server"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td><asp:Label ID="lblChildsEmail" runat="server" Text="E-Mail:"></asp:Label></td>
                         <td><asp:TextBox ID="txtChildEmail" runat="server"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td><asp:Label ID="lblChildsBirthday" runat="server" Text="Birthdate:"></asp:Label></td>
                         <td> <asp:TextBox ID="txtChildDOB" runat="server"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td><asp:Label ID="lblParentRelationship" runat="server" Text="Relationship to student:"></asp:Label></td>
                         <td><asp:TextBox ID="txtParentRelationship" runat="server"></asp:TextBox></td>
                     </tr>
                 </table>
            <asp:Button ID="btnparentStudentConfirmation" runat="server" Text="Confirm Student" onclick="parentStudentConfirmation_Click" cssclass="buttons"  />

                       </div>
                    


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
     
            </div>

    
    <footer>
        <div class="footer" id="regFooter"><!--starting tag for footer-->
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
