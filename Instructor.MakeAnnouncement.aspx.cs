using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

public partial class Instructor_MakeAnnouncement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtText.Style.Add("margin", "0px 0px 0px 24px");
        txtHeader.Style.Add("width", "500px");
        txtText.Style.Add("width", "500px");
        txtText.Style.Add("height", "300px");
        
        Session["UserID"] = "Matam.Pages@gmail.com";
        
        PopDropDown();
        
    }

    protected void PopDropDown()
    {
        ArrayList courses = new ArrayList();
        ArrayList users = new ArrayList();
        DateTime date = DateTime.Now;
        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();



            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select Course.CourseName, Enrollment.CourseID from SectionStaff " +
	            "Inner Join Section  on SectionStaff.SectionID = Section.SectionID " +
	            "Inner Join Enrollment on Section.SectionID = Enrollment.SectionID " +
	            "Inner Join Course on Enrollment.CourseID = Course.CourseID " +
	            "Where SectionStaff.EmailAddress = '" + Session["UserID"].ToString() + "'";// Gathers all users of specific type
            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
                courses.Add(read.GetString(0));
                courses.Add(read.GetInt32(1));
            }


            sc.Close();

            ddlCourses.Items.Insert(0, "Please Select");
            for(int i = 0; i < courses.Count; i += 2)
            {
                ddlCourses.Items.Add(new ListItem(courses[i].ToString(), courses[i + 1].ToString()));
            }


        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }
        
    }
    protected void btnSendAnnounce_Click(object sender, EventArgs e)
    {
        ArrayList users = new ArrayList();
        DateTime date = DateTime.Now;
        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();



            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select EmailAddress From Enrollment Where CourseID = " + ddlCourses.SelectedValue.ToString();// Gathers all users of specific type
            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
                users.Add(read.GetString(0));
            }

            for (int i = 0; i < users.Count; i++)
            {
                query.CommandText = "Insert into Notifications(EmailAddress, NotificationType, NotificationDate, NotificationText, BriefDescription)" +
                    " Values(@EmailAddress, Announcement, @Date, @Text, @Brief)";
                query.Parameters.AddWithValue("@EmailAddress", users[i]);
                query.Parameters.AddWithValue("@Date", date);
                query.Parameters.AddWithValue("@Text", txtText.Text);
                query.Parameters.AddWithValue("@Brief", txtHeader.Text);

                query.ExecuteNonQuery();
            }

            sc.Close();

        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }
    }
}