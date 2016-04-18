<%@ Page Title="" Language="C#" MasterPageFile="StudentMasterPage.master" AutoEventWireup="true" CodeFile="Student.ViewEvaluations.aspx.cs" Inherits="Student_ViewEvaluations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
      <form id="form1" runat="server">
          <div class="formE">
             <h3>WBL Student/Student Skill Evaluation</h3>

              <asp:Label ID="lblQuestion1" runat="server" Text="1. Student's Email: " CssClass="labels">
             
              <asp:TextBox ID="txtQuestion1" runat="server" CssClass="textbox"></asp:TextBox></asp:Label>

              <asp:Table ID="Table2" runat="server" Width="100%" BorderStyle="Dotted" GridLines="Horizontal" HorizontalAlign="Right" style="display:inline-block">    
                  <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Right">
                      <asp:TableCell ID="TableCell7" runat="server"><b><u>Question</u></b></asp:TableCell>
                      <asp:TableCell ID="TableCell8" runat="server"><b><u>Instructor's Response</u></b></asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow ID="TableRow3" runat="server">
                      <asp:TableCell ID="TableCell13" HorizontalAlign="Right" runat="server">Student regularly shows up to class: </asp:TableCell>
                      <asp:TableCell ID="TableCell14" runat="server"><%--<input type="radio" id ="rb1Row1" name="q1row1" value="1"/>--%></asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow ID="TableRow4" runat="server" HorizontalAlign="Right">
                      <asp:TableCell ID="TableCell19" runat="server">Student is consistently on time: </asp:TableCell>
                      <asp:TableCell ID="TableCell20" runat="server"><%--<input type="radio" name="q1row2" value="1"/>--%></asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow ID="TableRow5" runat="server" HorizontalAlign="Right">
                      <asp:TableCell ID="TableCell25" runat="server">Student was able to help contribute to the learning environment by assisting others: </asp:TableCell>
                      <asp:TableCell ID="TableCell26" runat="server"><%--<input type="radio" name="q1row3" value="1"/>--%></asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow ID="TableRow6" runat="server" HorizontalAlign="Right">
                      <asp:TableCell ID="TableCell31" runat="server">Student responded well to constructive criticism: </asp:TableCell>
                      <asp:TableCell ID="TableCell32" runat="server"><%--<input type="radio" name="q1row4" value="1"/>--%></asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow ID="TableRow7" runat="server" HorizontalAlign="Right">
                      <asp:TableCell ID="TableCell37" runat="server">Student maintained a positive attitude both in and out of class: </asp:TableCell>
                      <asp:TableCell ID="TableCell38" runat="server"><%--<input type="radio" name="q1row5" value="1"/>--%></asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow ID="TableRow8" runat="server" HorizontalAlign="Right">
                      <asp:TableCell ID="TableCell43" runat="server">Student was motivated to learn: </asp:TableCell>
                      <asp:TableCell ID="TableCell44" runat="server"><%--<input type="radio" name="q1row6" value="1"/>--%></asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow ID="TableRow9" runat="server" HorizontalAlign="Right">
                      <asp:TableCell ID="TableCell49" runat="server">Student was able to produce a final project or skill presentation: </asp:TableCell>
                      <asp:TableCell ID="TableCell50" runat="server"><%--<input type="radio" name="q1row7" value="1"/>--%></asp:TableCell>
                  </asp:TableRow>
                  <asp:TableRow ID="TableRow10" runat="server" HorizontalAlign="Right">
                      <asp:TableCell ID="TableCell55" runat="server">Student was engaged in other components of Words Beats and Life: </asp:TableCell>
                      <asp:TableCell ID="TableCell56" runat="server"><%--<input type="radio" name="q1row8" value="1"/>--%></asp:TableCell>
                  </asp:TableRow>
              </asp:Table>
              <br />
              <asp:Label ID="lblQuestion2" runat="server" Text="2. What are the student's strengths? " CssClass="labels"></asp:Label>

           
              <asp:TextBox ID="txtQuestion2" runat="server" TextMode="MultiLine" cssclass="textarea"></asp:TextBox>
        
              <asp:Label ID="lblQuestion3" runat="server" Text="3. What are the student's areas for growth and improvement? "></asp:Label>
           
            
              <asp:TextBox ID="txtQuestion3" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
       
              <asp:Label ID="lblQuestion4" runat="server" Text="4. Is there anything else you would like to comment on? " CssClass="labels"></asp:Label>

            
              <asp:TextBox ID="txtQuestion4" runat="server" cssclass="textarea" TextMode="MultiLine"></asp:TextBox>

          </div>
      </form>
</asp:Content>

