<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Admin.AddUser.aspx.cs" Inherits="Admin_AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <form id="form1" runat="server">
    <div id="userInfo">
            
            <!-- General user form information -->
            <div class="formE" runat="server">
                <h3>Enter New User Information</h3>
                        <asp:Label ID="lblUserType" runat="server" CssClass="labels" Text="Select Member Type: ">
                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="dropdowns" AutoPostBack="true">
                                        <asp:ListItem>Administrator</asp:ListItem>
                                        <asp:ListItem>Staff</asp:ListItem>
                                        <asp:ListItem>Cipher</asp:ListItem>
                                        <asp:ListItem>Parent</asp:ListItem>
                                        <asp:ListItem>Student</asp:ListItem></asp:DropDownList></asp:Label><br />
                <asp:Label ID="lblStaffType" runat="server" Text="Staff Type: " Visible="false" CssClass="labels"><asp:DropDownList ID="ddlStaffType" runat="server" Visible="false" CssClass="dropdowns">
                    <asp:ListItem>Instructor</asp:ListItem>
                    <asp:ListItem>Intern</asp:ListItem>
                    </asp:DropDownList></asp:Label>
                <asp:Label ID="lblSpecialty" CssClass="labels" runat="server" Text="Specialty: " Visible="false"><asp:TextBox ID="txtSpecialty" runat="server" Visible="false" CssClass="textbox"></asp:TextBox></asp:Label><br />
                <asp:Label ID="lblHireDate" CssClass="labels" runat="server" Text="Hire Date: " Visible="false"><asp:TextBox ID="txtHireDate" runat="server" Visible="false" CssClass="textbox"></asp:TextBox></asp:Label><br />
                <asp:Label ID="lblManagerEmail" CssClass="labels" runat="server" Text="Supervisor's Email: " Visible="false"><asp:TextBox ID="txtManagerEmail" runat="server" Visible="false" CssClass="textbox"></asp:TextBox></asp:Label><br />
                <asp:Label ID="lblAdminTitle" CssClass="labels" runat="server" Text="Title: " Visible="false"><asp:TextBox ID="txtAdminTitle" runat="server" Visible="false" CssClass="textbox"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lblRelation" runat="server" Text="Relationship to Student: " CssClass="labels" Visible="false"><asp:TextBox ID="txtRelation" runat="server" CssClass="textbox" Visible="false"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lblfName" runat="server" Text="First Name: " CssClass="labels"><asp:TextBox ID="txtfName" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lbllName" runat="server" Text="Last Name: " CssClass="labels"><asp:TextBox ID="txtlName" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lblEmail" runat="server" Text="E-mail Address: " CssClass="labels"><asp:TextBox ID="txtEmail" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lblPassword" runat="server" Text="Password: " CssClass="labels"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lblPassword2" runat="server" Text="Confirm Password: " CssClass="labels"><asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox></asp:Label><br/>
                        <asp:Label ID="lblDOB" runat="server" Text="Date of Birth: " CssClass="labels"><asp:TextBox ID="txtDOB" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lblAddress" runat="server" Text="Address: " CssClass="labels"><asp:TextBox ID="txtAddress" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lblCity" runat="server" Text="City: " CssClass="labels"><asp:TextBox ID="txtCity" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lblState" runat="server" Text="State: " CssClass="labels"><asp:TextBox ID="txtState" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lblZip" runat="server" Text="Zip: " CssClass="labels"><asp:TextBox ID="txtZip" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lblGender" runat="server" Text="Gender: " CssClass="labels"></asp:Label>
                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="dropdowns">
                                <asp:ListItem>Female</asp:ListItem>
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Trans/Transgender</asp:ListItem>
                                <asp:ListItem>Genderqueer</asp:ListItem>
                                <asp:ListItem>Prefer not to say</asp:ListItem>
                            </asp:DropDownList><br/>
      
                        <asp:Label ID="lblHome" runat="server" Text="Home Phone #: " CssClass="labels"><asp:TextBox ID="txtHome" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
                        <asp:Label ID="lblCell" runat="server" Text="Cell Phone #: " CssClass="labels"><asp:TextBox ID="txtCell" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
                <asp:Label ID="lblShirtSize" runat="server" Text="Shirt Size"></asp:Label>
                            <asp:DropDownList ID="ddlShirtSize" runat="server" CssClass="dropdowns">
                                <asp:ListItem Text ="XS">XS</asp:ListItem>
                                <asp:ListItem Text ="S">S</asp:ListItem>
                                <asp:ListItem Text ="M">M</asp:ListItem>
                                <asp:ListItem Text ="L">L</asp:ListItem>
                                <asp:ListItem Text ="XL">XL</asp:ListItem>
                                <asp:ListItem Text ="XXL">XXL</asp:ListItem>
                            </asp:DropDownList>
                <br />
                <br /><asp:Label ID="lblRace" runat="server" Text="Race: " CssClass="labels"></asp:Label><br />
                        <asp:CheckBoxList ID="cblRace" runat="server" CssClass="checklist">   
                        <asp:ListItem  runat="server" Value="American India or Alaskan Native" cssClass="radioButtons"/>
                        <asp:ListItem  runat="server" Value="Asian or Pacific Islander" cssClass="radioButtons"/>
                        <asp:ListItem  runat="server" Value="Black or African American" cssClass="radioButtons"/>
                        <asp:ListItem  runat="server" Value="Latino/Latina" cssClass="radioButtons"/>
                        <asp:ListItem  runat="server" Value="White" cssClass="radioButtons"/>
                        <asp:ListItem  runat="server" Value="Other" cssClass="radioButtons"/>
                    </asp:CheckBoxList>
                <br />           
                <asp:Button ID="btnSignUpAllInfo" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" CssClass="buttons" /><br /> 
                </div>
        </div>
    </form>

</asp:Content>


