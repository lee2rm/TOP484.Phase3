<%@ Page Title="" Language="C#" MasterPageFile="~/InstructorMasterPage.master" AutoEventWireup="true" CodeFile="Instructor.ViewEvaluations.aspx.cs" Inherits="Instructor_ViewEvaluations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">

    <form id="form1" runat="server">
    <div class="formE" style="width:70%">
        <h3 ID="lblHeader" runat="server" >Your Class Evaluation</h3>
        <br />

        <asp:Label ID="lblQuestion1" runat="server" Text="1. What is your Name? " CssClass="labels">
        <asp:TextBox ID="txtQuestion1" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <br />

        <asp:Label ID="lblQuestion2" runat="server" Text="2. How did you hear about this class? " CssClass="labels">
        <asp:TextBox ID="txtQuestion2" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <br />

        <asp:Label ID="lblQuestion3" runat="server" Text="3. Do you feel safe/comfortable in class? " CssClass="labels">
        <asp:TextBox ID="txtQuestion3" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <br />
        
        <asp:Label ID="lblQuestion4" runat="server" Text="4. If you answered sometimes or never, what needs to change to make you feel safe/comfortable always or most of the time?" CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtQuestion4" runat="server"  TextMode="MultiLine" CssClass="textarea"></asp:TextBox><br />
        <br />

        <asp:Label ID="lblQuestion5" runat="server" Text="5. What skills have you developed in this class? "></asp:Label>
        <asp:TextBox ID="txtQuestion5" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox><br />
        <br />
        </div>
       <br />
        <asp:Label ID="lblQuestion6" runat="server" Text="6. In Class I get to.... " CssClass="labels" style="width:100%;float:left"></asp:Label>
            <asp:Table ID="Table1" runat="server" Width="504px" BorderStyle="Dotted" GridLines="Horizontal" style="display:inline-block"> 
                <asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell1" runat="server" Wrap="False">Question</asp:TableCell>
                    <asp:TableCell ID="TableCell2" runat="server">Student's Response</asp:TableCell>
                    </asp:TableRow>
                <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center">
                    <%--<asp:TableCell ID="TableCell7" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell8" runat="server"> 1</asp:TableCell>
                    <asp:TableCell ID="TableCell9" runat="server"> 2</asp:TableCell>
                    <asp:TableCell ID="TableCell10" runat="server"> 3</asp:TableCell>
                    <asp:TableCell ID="TableCell11" runat="server"> 4</asp:TableCell>
                    <asp:TableCell ID="TableCell12" runat="server"> 5</asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow3" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell13" runat="server">Try New Things:</asp:TableCell>
                    <asp:TableCell ID="TableCell14" runat="server"></asp:TableCell>
                    <%--<asp:TableCell ID="TableCell15" runat="server"></asp:TableCell>--%>
                    <%--<asp:TableCell ID="TableCell16" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell17" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell18" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow4" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell19" runat="server">Learn what it takes to be an artists:</asp:TableCell>
                    <asp:TableCell ID="TableCell20" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell21" runat="server"></asp:TableCell>--%>
                    <%--<asp:TableCell ID="TableCell22" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell23" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell24" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow5" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell25" runat="server">Use Different Art Mediums:</asp:TableCell>
                    <asp:TableCell ID="TableCell26" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell27" runat="server"></asp:TableCell>--%>
                    <%--<asp:TableCell ID="TableCell28" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell29" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell30" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow6" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell31" runat="server">Make Friends:</asp:TableCell>
                    <asp:TableCell ID="TableCell32" runat="server"></asp:TableCell>
                  <%--  <asp:TableCell ID="TableCell33" runat="server"></asp:TableCell>--%>
                   <%-- <asp:TableCell ID="TableCell34" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell35" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell36" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
            </asp:Table>
        <br />
                <asp:Label ID="lblQuestion7" runat="server" Text="7. This Class has helped me to.... " CssClass="labels"></asp:Label>
                <asp:Table ID="Table2" runat="server" Width="504px" BorderStyle="Dotted" GridLines="Horizontal" style="display:inline-block">
                    <asp:TableRow ID="TableRow7" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell37" runat="server">Question</asp:TableCell>
                        <asp:TableCell ID="TableCell38" runat="server">Student's Response</asp:TableCell>
                        <%--<asp:TableCell ID="TableCell39" runat="server">Disagree</asp:TableCell>
                        <asp:TableCell ID="TableCell40" runat="server">Neither Agree Nor Disagree</asp:TableCell>
                        <asp:TableCell ID="TableCell41" runat="server">Agree</asp:TableCell>
                        <asp:TableCell ID="TableCell42" runat="server">Completely Agree</asp:TableCell>--%>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow8" runat="server" HorizontalAlign="Center">
                       <%-- <asp:TableCell ID="TableCell43" runat="server"></asp:TableCell>--%>
                       <%-- <asp:TableCell ID="TableCell44" runat="server"> 1</asp:TableCell>
                        <asp:TableCell ID="TableCell45" runat="server"> 2</asp:TableCell>
                        <asp:TableCell ID="TableCell46" runat="server"> 3</asp:TableCell>
                        <asp:TableCell ID="TableCell47" runat="server"> 4</asp:TableCell>
                        <asp:TableCell ID="TableCell48" runat="server"> 5</asp:TableCell>--%>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow9" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell49" runat="server">Be motivated to learn new things:</asp:TableCell>
                        <asp:TableCell ID="TableCell50" runat="server"></asp:TableCell>
                        <%--<asp:TableCell ID="TableCell51" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell52" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell53" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell54" runat="server"></asp:TableCell>--%>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow10" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell55" runat="server">Feel happy with myself:</asp:TableCell>
                        <asp:TableCell ID="TableCell56" runat="server"></asp:TableCell>
                        <%--<asp:TableCell ID="TableCell57" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell58" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell59" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell60" runat="server"></asp:TableCell>--%>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow11" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell61" runat="server">Feel positive about my future:</asp:TableCell>
                        <asp:TableCell ID="TableCell62" runat="server"></asp:TableCell>
                        <%--<asp:TableCell ID="TableCell63" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell64" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell65" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell66" runat="server"></asp:TableCell>--%>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow12" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell67" runat="server">Work with other young artists like me:</asp:TableCell>
                        <asp:TableCell ID="TableCell68" runat="server"></asp:TableCell>
                        <%--<asp:TableCell ID="TableCell69" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell70" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell71" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell72" runat="server"></asp:TableCell>--%>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow13" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell73" runat="server">Use my art to deal with stress:</asp:TableCell>
                        <asp:TableCell ID="TableCell74" runat="server"></asp:TableCell>
                       <%-- <asp:TableCell ID="TableCell75" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell76" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell77" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell78" runat="server"></asp:TableCell>--%>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow14" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell79" runat="server">Respect people who are different than me:</asp:TableCell>
                        <asp:TableCell ID="TableCell80" runat="server"></asp:TableCell>
                        <%--<asp:TableCell ID="TableCell81" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell82" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell83" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell84" runat="server"></asp:TableCell>--%>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow15" runat="server" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell85" runat="server">Resist negativity or negative peer influences:</asp:TableCell>
                        <asp:TableCell ID="TableCell86" runat="server"></asp:TableCell>
                       <%-- <asp:TableCell ID="TableCell87" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell88" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell89" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell90" runat="server"></asp:TableCell>--%>
                    </asp:TableRow>
                </asp:Table>
         <asp:Label ID="lblQuestion7a" runat="server" Text="8. By participating in class...  " CssClass="labels"></asp:Label>
            <asp:Table ID="Table5" runat="server" Width="504px" BorderStyle="Dotted" GridLines="Horizontal" style="display:inline-block">
                <asp:TableRow ID="TableRow33" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell193" runat="server">Question</asp:TableCell>
                    <asp:TableCell ID="TableCell194" runat="server">Student's Response</asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell195" runat="server">Student'S Response</asp:TableCell>--%>
                    <%--<asp:TableCell ID="TableCell196" runat="server">Neither Agree Nor Disagree</asp:TableCell>
                    <asp:TableCell ID="TableCell197" runat="server">Agree</asp:TableCell>
                    <asp:TableCell ID="TableCell198" runat="server">Completely Agree</asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow34" runat="server" HorizontalAlign="Center">
<%--                    <asp:TableCell ID="TableCell199" runat="server"></asp:TableCell>--%>
                   <%-- <asp:TableCell ID="TableCell200" runat="server"> 1</asp:TableCell>
                    <asp:TableCell ID="TableCell201" runat="server"> 2</asp:TableCell>
                    <asp:TableCell ID="TableCell202" runat="server"> 3</asp:TableCell>
                    <asp:TableCell ID="TableCell203" runat="server"> 4</asp:TableCell>
                    <asp:TableCell ID="TableCell204" runat="server"> 5</asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow35" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell205" runat="server">I feel comfortable being creative around my peers:</asp:TableCell>
                    <asp:TableCell ID="TableCell206" runat="server"></asp:TableCell>
                    <%--<asp:TableCell ID="TableCell207" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell208" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell209" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell210" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow36" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell211" runat="server">I can talk about careers I'm interested in:</asp:TableCell>
                    <asp:TableCell ID="TableCell212" runat="server"></asp:TableCell>
                    <%--<asp:TableCell ID="TableCell213" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell214" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell215" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell216" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow37" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell217" runat="server">I know the steps needed to reach my career goals:</asp:TableCell>
                    <asp:TableCell ID="TableCell218" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell219" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell220" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell221" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell222" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                 <asp:TableRow ID="TableRow38" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell223" runat="server">I better understand the importance of helping others in the community:</asp:TableCell>
                    <asp:TableCell ID="TableCell224" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell225" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell226" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell227" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell228" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
            </asp:Table>

            <asp:Label ID="lblQuestion8" runat="server" Text="8. I am sure that I will...  " CssClass="labels"></asp:Label>
            <asp:Table ID="Table3" runat="server" Width="504px" BorderStyle="Dotted" GridLines="Horizontal" style="display:inline-block">
                <asp:TableRow ID="TableRow16" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell91" runat="server">Question</asp:TableCell>
                    <asp:TableCell ID="TableCell92" runat="server">Student's Response</asp:TableCell>
                 <%--   <asp:TableCell ID="TableCell93" runat="server">Student's Response</asp:TableCell>--%>
                   <%-- <asp:TableCell ID="TableCell94" runat="server">Neither Agree Nor Disagree</asp:TableCell>
                    <asp:TableCell ID="TableCell95" runat="server">Agree</asp:TableCell>
                    <asp:TableCell ID="TableCell96" runat="server">Completely Agree</asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow17" runat="server" HorizontalAlign="Center">
                   <%-- <asp:TableCell ID="TableCell97" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell98" runat="server"> 1</asp:TableCell>
                    <asp:TableCell ID="TableCell99" runat="server"> 2</asp:TableCell>
                    <asp:TableCell ID="TableCell100" runat="server"> 3</asp:TableCell>
                    <asp:TableCell ID="TableCell101" runat="server"> 4</asp:TableCell>
                    <asp:TableCell ID="TableCell102" runat="server"> 5</asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow18" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell103" runat="server">Continue growing as an artist</asp:TableCell>
                    <asp:TableCell ID="TableCell104" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell105" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell106" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell107" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell108" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow19" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell109" runat="server">Finish school (High-School/College)</asp:TableCell>
                    <asp:TableCell ID="TableCell110" runat="server"></asp:TableCell>
                    <%--<asp:TableCell ID="TableCell111" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell112" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell113" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell114" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow20" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell115" runat="server">Be able to find and do well in a job that I enjoy:</asp:TableCell>
                    <asp:TableCell ID="TableCell116" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell117" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell118" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell119" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell120" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
            </asp:Table>
        <br />
        <br />
        <h3>Teacher Evaluations</h3>
        <div class="formE">
        <br />
        <asp:Label ID="lblQuestion1t" runat="server" Text="1. What is the teacher's name?  " CssClass="labels">
        <asp:TextBox ID="txtQuestion9a" runat="server" CssClass="textbox"></asp:TextBox></asp:Label><br />
        <asp:Table ID="Table4" runat="server" Width="504px" BorderStyle="Dotted" GridLines="Horizontal" style="display:inline-block">
                <asp:TableRow ID="TableRow21" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell121" runat="server">Question</asp:TableCell>
                    <asp:TableCell ID="TableCell122" runat="server">Student's Response</asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell123" runat="server">Needs Improvement</asp:TableCell>
                    <asp:TableCell ID="TableCell124" runat="server">Meets Expectations</asp:TableCell>
                    <asp:TableCell ID="TableCell125" runat="server">Exceeds Expectations</asp:TableCell>
                    <asp:TableCell ID="TableCell126" runat="server">Exceptional</asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow22" runat="server" HorizontalAlign="Center">
                   <%-- <asp:TableCell ID="TableCell127" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell128" runat="server"> 1</asp:TableCell>
                    <asp:TableCell ID="TableCell129" runat="server"> 2</asp:TableCell>
                    <asp:TableCell ID="TableCell130" runat="server"> 3</asp:TableCell>
                    <asp:TableCell ID="TableCell131" runat="server"> 4</asp:TableCell>
                    <asp:TableCell ID="TableCell132" runat="server"> 5</asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow23" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell133" runat="server">Teacher regularly shows up for class:</asp:TableCell>
                    <asp:TableCell ID="TableCell134" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell135" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell136" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell137" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell138" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow24" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell139" runat="server">Teacher is consistently on time:</asp:TableCell>
                    <asp:TableCell ID="TableCell140" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell141" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell142" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell143" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell144" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow25" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell145" runat="server">Teacher managed students well and maintained the learning environment:</asp:TableCell>
                    <asp:TableCell ID="TableCell146" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell147" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell148" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell149" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell150" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow26" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell151" runat="server">Teacher was organized:</asp:TableCell>
                    <asp:TableCell ID="TableCell152" runat="server"></asp:TableCell>
                    <%--<asp:TableCell ID="TableCell153" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell154" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell155" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell156" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow27" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell157" runat="server">Teacher offered me clear feedback on how I could improve:</asp:TableCell>
                    <asp:TableCell ID="TableCell158" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell159" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell160" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell161" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell162" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow28" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell163" runat="server">Teacher fostered a safe and welcoming environment:</asp:TableCell>
                    <asp:TableCell ID="TableCell164" runat="server"></asp:TableCell>
                    <%--<asp:TableCell ID="TableCell165" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell166" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell167" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell168" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
                <asp:TableRow ID="TableRow29" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell169" runat="server">Teacher challenged me to learn and develop skills:</asp:TableCell>
                    <asp:TableCell ID="TableCell170" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell171" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell172" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell173" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell174" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
            <asp:TableRow ID="TableRow30" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell175" runat="server">Activities were planned:</asp:TableCell>
                    <asp:TableCell ID="TableCell176" runat="server"></asp:TableCell>
                   <%-- <asp:TableCell ID="TableCell177" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell178" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell179" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell180" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
            <asp:TableRow ID="TableRow31" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell181" runat="server">Teacher did their job well</asp:TableCell>
                    <asp:TableCell ID="TableCell182" runat="server"></asp:TableCell>
                    <%--<asp:TableCell ID="TableCell183" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell184" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell185" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell186" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
            <asp:TableRow ID="TableRow32" runat="server" HorizontalAlign="Center">
                    <asp:TableCell ID="TableCell187" runat="server">Teacher was supportive of my development as a young artist:</asp:TableCell>
                    <asp:TableCell ID="TableCell188" runat="server"></asp:TableCell>
                    <%--<asp:TableCell ID="TableCell189" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell190" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell191" runat="server"></asp:TableCell>
                    <asp:TableCell ID="TableCell192" runat="server"></asp:TableCell>--%>
                </asp:TableRow>
            </asp:Table>
        <br />
        <asp:Label ID="lblQuestion2t" runat="server" Text="2. What are this teacher's strengths?" CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtQuestion2t" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox><br />
        <br />
        <asp:Label ID="lblQuestion3t" runat="server" Text="3. What are the teacher's areas for growth and improvement?" CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtQuestion3t" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox><br />
        <br />
        <asp:Label ID="lblQuestion4t" runat="server" Text="4. Is there anything else you would like to comment on?" CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtQuestion4t" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox><br />
        <br />
        <asp:Label ID="lblQuestion5t" runat="server" Text="5. Is this class taught by an additional teacher?" CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtQuestion5t" runat="server" cssclass="textarea"></asp:TextBox><br />
        <br />
        <br />
        <h3>Self Evaluation</h3>
        <br />
        <asp:Label ID="lblQuestion1s" runat="server" Text="1. How would you describe your participation in class? " CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtQuestion1s" runat="server" cssClass="textbox"></asp:TextBox><br />
        <br />
        <asp:Label ID="lblQuestion2s" runat="server" Text="2. Did you complete a final piece of work for All City? " CssClass="labels"></asp:Label><br />
        <asp:TextBox ID="txtQuestion2s" runat="server" CssClass="textbox"></asp:TextBox><br />
    </div>
            </form>

</asp:Content>

