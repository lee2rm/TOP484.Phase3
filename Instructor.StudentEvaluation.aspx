<%@ Page Title="" Language="C#" MasterPageFile="~/InstructorMasterPage.master" AutoEventWireup="true" CodeFile="Instructor.StudentEvaluation.aspx.cs" Inherits="Instructor_StudentEvaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

             <h3>WBL Student Evaluation</h3>

     <form id="form1" runat="server">
    <div class="formE">
        <asp:Label ID="lblQuestion1" runat="server" Text="1. Student's Name: "></asp:Label>
        <asp:TextBox ID="txtQuestion1" runat="server" CssClass="textbox"></asp:TextBox>
        
        <asp:Table ID="Table2" runat="server" Width="504px" BorderStyle="Dotted" GridLines="Horizontal">
                    <asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell1" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell2" runat="server">Unsatisfactory</asp:TableCell>
                        <asp:TableCell ID="TableCell3" runat="server">Needs Improvement</asp:TableCell>
                        <asp:TableCell ID="TableCell4" runat="server">Meets Expectations</asp:TableCell>
                        <asp:TableCell ID="TableCell5" runat="server">Exceeds Expectations</asp:TableCell>
                        <asp:TableCell ID="TableCell6" runat="server">Exceptional</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell7" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell8" runat="server"> 1</asp:TableCell>
                        <asp:TableCell ID="TableCell9" runat="server"> 2</asp:TableCell>
                        <asp:TableCell ID="TableCell10" runat="server"> 3</asp:TableCell>
                        <asp:TableCell ID="TableCell11" runat="server"> 4</asp:TableCell>
                        <asp:TableCell ID="TableCell12" runat="server"> 5</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow3" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell13" runat="server">Student regularly shows up to class</asp:TableCell>
                        <asp:TableCell ID="TableCell14" runat="server"><input type="radio" name="q1row1" value="1"/></asp:TableCell>
                        <asp:TableCell ID="TableCell15" runat="server"><input type="radio" name="q1row1" value="2"/></asp:TableCell>
                        <asp:TableCell ID="TableCell16" runat="server"><input type="radio" name="q1row1" value="3"/></asp:TableCell>
                        <asp:TableCell ID="TableCell17" runat="server"><input type="radio" name="q1row1" value="4"/></asp:TableCell>
                        <asp:TableCell ID="TableCell18" runat="server"><input type="radio" name="q1row1" value="5"/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow4" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell19" runat="server">Student is consistently on time</asp:TableCell>
                        <asp:TableCell ID="TableCell20" runat="server"><input type="radio" name="q1row2" value="1"/></asp:TableCell>
                        <asp:TableCell ID="TableCell21" runat="server"><input type="radio" name="q1row2" value="2"/></asp:TableCell>
                        <asp:TableCell ID="TableCell22" runat="server"><input type="radio" name="q1row2" value="3"/></asp:TableCell>
                        <asp:TableCell ID="TableCell23" runat="server"><input type="radio" name="q1row2" value="4"/></asp:TableCell>
                        <asp:TableCell ID="TableCell24" runat="server"><input type="radio" name="q1row2" value="5"/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow5" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell25" runat="server">Student was able to help contribute to the learning environment by assisting others</asp:TableCell>
                        <asp:TableCell ID="TableCell26" runat="server"><input type="radio" name="q1row3" value="1"/></asp:TableCell>
                        <asp:TableCell ID="TableCell27" runat="server"><input type="radio" name="q1row3" value="2"/></asp:TableCell>
                        <asp:TableCell ID="TableCell28" runat="server"><input type="radio" name="q1row3" value="3"/></asp:TableCell>
                        <asp:TableCell ID="TableCell29" runat="server"><input type="radio" name="q1row3" value="4"/></asp:TableCell>
                        <asp:TableCell ID="TableCell30" runat="server"><input type="radio" name="q1row3" value="5"/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow6" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell31" runat="server">Student responded well to constructive criticism</asp:TableCell>
                        <asp:TableCell ID="TableCell32" runat="server"><input type="radio" name="q1row4" value="1"/></asp:TableCell>
                        <asp:TableCell ID="TableCell33" runat="server"><input type="radio" name="q1row4" value="2"/></asp:TableCell>
                        <asp:TableCell ID="TableCell34" runat="server"><input type="radio" name="q1row4" value="3"/></asp:TableCell>
                        <asp:TableCell ID="TableCell35" runat="server"><input type="radio" name="q1row4" value="4"/></asp:TableCell>
                        <asp:TableCell ID="TableCell36" runat="server"><input type="radio" name="q1row4" value="5"/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow7" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell37" runat="server">Student maintained a positive attitude both in and out of class</asp:TableCell>
                        <asp:TableCell ID="TableCell38" runat="server"><input type="radio" name="q1row5" value="1"/></asp:TableCell>
                        <asp:TableCell ID="TableCell39" runat="server"><input type="radio" name="q1row5" value="2"/></asp:TableCell>
                        <asp:TableCell ID="TableCell40" runat="server"><input type="radio" name="q1row5" value="3"/></asp:TableCell>
                        <asp:TableCell ID="TableCell41" runat="server"><input type="radio" name="q1row5" value="4"/></asp:TableCell>
                        <asp:TableCell ID="TableCell42" runat="server"><input type="radio" name="q1row5" value="5"/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow8" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell43" runat="server">Student was motivated to learn</asp:TableCell>
                        <asp:TableCell ID="TableCell44" runat="server"><input type="radio" name="q1row6" value="1"/></asp:TableCell>
                        <asp:TableCell ID="TableCell45" runat="server"><input type="radio" name="q1row6" value="2"/></asp:TableCell>
                        <asp:TableCell ID="TableCell46" runat="server"><input type="radio" name="q1row6" value="3"/></asp:TableCell>
                        <asp:TableCell ID="TableCell47" runat="server"><input type="radio" name="q1row6" value="4"/></asp:TableCell>
                        <asp:TableCell ID="TableCell48" runat="server"><input type="radio" name="q1row6" value="5"/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow9" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell49" runat="server">Student was able to produce a final project or skill presentation</asp:TableCell>
                        <asp:TableCell ID="TableCell50" runat="server"><input type="radio" name="q1row7" value="1"/></asp:TableCell>
                        <asp:TableCell ID="TableCell51" runat="server"><input type="radio" name="q1row7" value="2"/></asp:TableCell>
                        <asp:TableCell ID="TableCell52" runat="server"><input type="radio" name="q1row7" value="3"/></asp:TableCell>
                        <asp:TableCell ID="TableCell53" runat="server"><input type="radio" name="q1row7" value="4"/></asp:TableCell>
                        <asp:TableCell ID="TableCell54" runat="server"><input type="radio" name="q1row7" value="5"/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow10" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell55" runat="server">Student was engaged in other components of Words Beats and Life</asp:TableCell>
                        <asp:TableCell ID="TableCell56" runat="server"><input type="radio" name="q1row8" value="1"/></asp:TableCell>
                        <asp:TableCell ID="TableCell57" runat="server"><input type="radio" name="q1row8" value="2"/></asp:TableCell>
                        <asp:TableCell ID="TableCell58" runat="server"><input type="radio" name="q1row8" value="3"/></asp:TableCell>
                        <asp:TableCell ID="TableCell59" runat="server"><input type="radio" name="q1row8" value="4"/></asp:TableCell>
                        <asp:TableCell ID="TableCell60" runat="server"><input type="radio" name="q1row8" value="5"/></asp:TableCell>
                    </asp:TableRow>
                </asp:Table><br />
        <asp:Label ID="lblQuestion2" runat="server" Text="2. What are the student's strengths? " CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtQuestion2" runat="server" Height="75px" Width="100%" TextMode="MultiLine" CssClass="textbox"></asp:TextBox><br />
        <br /><br />
        <asp:Label ID="lblQuestion3" runat="server" Text="3. What are the student's areas for growth and improvement? " CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtQuestion3" runat="server" Height="75px" Width="100%" TextMode="MultiLine" CssClass="textbox"></asp:TextBox><br />
        <br /><br />
        <asp:Label ID="lblQuestion4" runat="server" Text="4. Is there anything else you would like to comment on? " CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtQuestion4" runat="server" Height="75px" Width="100%" TextMode="MultiLine" CssClass="textbox"></asp:TextBox><br />
        <asp:Button ID="btnSubmit" runat="server" cssclass="buttons" Text="Submit Evaluation" OnClick="btnSubmit_Click"/>
        <br /><br />
    
    </div>
    </form>


</asp:Content>

