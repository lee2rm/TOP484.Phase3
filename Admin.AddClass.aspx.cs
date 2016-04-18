using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;

public partial class Admin_AddClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText6 = "select EmailAddress from Staff where StaffType = 'Intern'";
        SqlCommand cmd6 = new SqlCommand(cmdText6, connection);
        cmd6.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd6);
        adp.Fill(dt);
        if (!IsPostBack)
        {
            for( int i = 0; i <dt.Rows.Count; i++)
            {
                string email = dt.Rows[i][0].ToString();
                ddIntern.Items.Insert(i + 2, new ListItem(email));
                ddIntern.DataBind();
                 
            }
        }


    }

    protected void btnAddClass_Click(object sender, EventArgs e)
    {
        string newSectionID = "";
        string semester = ddSemester.SelectedValue + " " + txtYear.Text;

        string courseTime = "";
       
        courseTime = ddWeekDay1.SelectedValue + " from " + txtStartTime.Text + " - " + txtEndTime.Text;
       
       

        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            connection.Open();
            string cmdText = "INSERT INTO dbo.Course (CourseID, CourseName, CourseElement, CourseDescription) VALUES (@CourseID, @CourseName, @CourseElement, @CourseDescription)";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@CourseID", Convert.ToInt32(txtCourseID.Text));
            cmd.Parameters.AddWithValue("@CourseName", txtCourseName.Text);
            cmd.Parameters.AddWithValue("@CourseElement", ddCourseElement.SelectedValue);
            cmd.Parameters.AddWithValue("@CourseDescription", txtCourseDes.Text);
            //cmd.Parameters.AddWithValue("@LessonPlan", txtLocation.Text);
            // need LESSON PLAN
            // Need to figure out how to store LESSON PLAN
            cmd.ExecuteNonQuery();

            string cmdText2 = "Insert into dbo.Section (CourseID, Capacity, CourseTime, Semester, Location) VALUES (@CourseID, @Capacity, @CourseTime, @Semester, @Location)";
            SqlCommand cmd2 = new SqlCommand(cmdText2, connection);
            cmd2.Parameters.AddWithValue("@CourseID", Convert.ToInt32(txtCourseID.Text));
            cmd2.Parameters.AddWithValue("@Capacity", Convert.ToInt32(txtCapacity.Text));
            cmd2.Parameters.AddWithValue("@CourseTime", courseTime);
            cmd2.Parameters.AddWithValue("@Semester", semester);
            cmd2.Parameters.AddWithValue("@Location", ddLocation.SelectedValue);
            cmd2.ExecuteNonQuery();
            string cmdText5 = "Select MAX (SectionID) from Section";
            SqlCommand cmd5 = new SqlCommand(cmdText5, connection);
            //SqlDataReader reader = cmd5.ExecuteReader();
            newSectionID = cmd5.ExecuteScalar().ToString();
          



            String cmdText3 = "Insert into dbo.SectionStaff (EmailAddress, SectionID, CourseID) Values (@EmailAddress, @SectionID, @CourseID)";
            SqlCommand cmd3 = new SqlCommand(cmdText3, connection);
            cmd3.Parameters.AddWithValue("@EmailAddress", ddInstrutor.SelectedValue);
            cmd3.Parameters.AddWithValue("@SectionID", Convert.ToInt32(newSectionID));
            cmd3.Parameters.AddWithValue("@CourseID", Convert.ToInt32(txtCourseID.Text));
            cmd3.ExecuteNonQuery();


            if (ddIntern.SelectedIndex != 1)
            {
                String cmdText4 = "Insert into dbo.SectionStaff (EmailAddress, SectionID, CourseID) Values (@EmailAddress, @SectionID, @CourseID)";
                SqlCommand cmd4 = new SqlCommand(cmdText4, connection);
                cmd4.Parameters.AddWithValue("@EmailAddress", ddIntern.SelectedValue);
                cmd4.Parameters.AddWithValue("@SectionID", Convert.ToInt32(newSectionID));
                cmd4.Parameters.AddWithValue("@CourseID", Convert.ToInt32(txtCourseID.Text));
                cmd4.ExecuteNonQuery();
            }

            System.Windows.Forms.MessageBox.Show("You have successfully added a class to the calendar.");

        }
        catch (System.Data.SqlClient.SqlException f)
        {

            System.Windows.Forms.MessageBox.Show(f.Message);

        }
    }
}