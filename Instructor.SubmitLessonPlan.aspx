<%@ Page Title="" Language="C#" MasterPageFile="~/InstructorMasterPage.master" AutoEventWireup="true" CodeFile="Instructor.SubmitLessonPlan.aspx.cs" Inherits="Instructor_SubmitLessonPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

        <form id="form1" runat="server">
            <h3>Submit a Lesson Plan</h3>
    <div class="formE">


         <asp:Label ID="lblAClass" runat="server" Text="Class: " CssClass="labels"></asp:Label>
            <asp:DropDownList ID="ddlClasses" runat="server" cssClass="dropdowns">
                <asp:ListItem id="list1" runat="server">
                    
                </asp:ListItem>
            </asp:DropDownList><br />
        <!--<p>USE THE SAME CODE HERE YOU DID FOR THE CLASSES IN THE TAKE ATTENDANCE DROP DOWN (MAKE SURE IT POPULATES ONLY THE CLASSES THIS SPECIFIC TEACHER IS TEACHING (SHOULD BE BASED ON SESSION ID)</p>
        -->
        <asp:Label ID="lblLessonPlanUpload" runat="server" Text="Upload a File: " CssClass="labels"><asp:FileUpload ID="fLessonPlan" runat="server" /></asp:Label><br />
    
        <asp:Label ID="lblLPSubject" runat="server" Text="Subject: " CssClass="labels"><asp:TextBox ID="txtLPSubject" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />

        <asp:Label ID="lblLPDescription" runat="server" Text="Description: " CssClass="labels"></asp:Label><br /><asp:TextBox ID="txtLPDescription" runat="server" TextMode="MultiLine" cssclass="textarea"></asp:TextBox><br />
        <asp:Button ID="btnSubmitLP" runat="server" Text="Submit Lesson Plan" OnClick="btnSendLetter_Click" cssclass="buttons"/>


         </div>
    </form>


</asp:Content>

