<%@ Page Title="" Language="C#" MasterPageFile="InstructorMasterPage.master" AutoEventWireup="true" CodeFile="Instructor.TakeAttendance.aspx.cs" Inherits="Instructor_TakeAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">


        <form id="form1" runat="server">
            <h3>Class Attendance</h3>
            <div class="formE">
                </br>
                <asp:Label ID="lblAClass" runat="server" Text="Class: " CssClass="labels"></asp:Label>
                <asp:DropDownList 
                    ID="ddlClasses" 
                    runat="server" 
                    cssClass="dropdowns" 
                    DataSourceID="sdsCourse" 
                    DataTextField="CourseName" 
                    DataValueField="CourseName" 
                    AutoPostBack="True"
                    OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged">
                </asp:DropDownList>

                <asp:SqlDataSource 
                    ID="sdsCourse" 
                    runat="server" 
                    ConnectionString="<%$ ConnectionStrings:conString %>" />
                
                </br>
                </br>
                <p>Students</p>
                <asp:CheckBoxList ID="chkStudent" runat="server" ></asp:CheckBoxList>
                <asp:Label ID="lblSuccess" runat="server" Visible="false"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="btnSubmitAttendance" runat="server" Text="Submit" OnClick="btnSubmitAttendance_Click" cssclass="buttons"/>
            </div>
        </form>

</asp:Content>

