using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;



public partial class Instructor_TakeAttendance : System.Web.UI.Page
{

    private ArrayList studs;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopDropDown();
        }
        if (ddlClasses.SelectedItem.Value.ToString().Equals("Please select"))
        {
            chkStudent.Items.Clear();


        }


    }



    protected void PopDropDown()
    {
        ArrayList result = new ArrayList();
        ArrayList courses = new ArrayList();
        try
        {
            SqlCommand query = new SqlCommand();
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);

            sc.Open();

            query.Connection = sc;
            query.CommandText = "SELECT Section.CourseID, Course.CourseName FROM SectionStaff " +
                "LEFT JOIN Section INNER JOIN Course ON Section.CourseID = Course.CourseID " +
                "ON Section.SectionID = SectionStaff.SectionID Where SectionStaff.EmailAddress = '" +
                Session["UserID"].ToString() + "'";
            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
                result.Add(read.GetInt32(0));
                result.Add(read.GetString(1));
            }

            sc.Close();

            ddlClasses.Items.Insert(0, "Please select");
            int count = 1;
            for (int i = 0; i < result.Count; i += 2)
            {
                //Debug.WriteLine(i);
                ddlClasses.Items.Insert(count, new ListItem(result[i + 1].ToString(), result[i].ToString()));
                count++;
            }

        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString() + "line 84");
        }
    }


    protected ArrayList GetStudents()
    {
        ArrayList result = new ArrayList();
        String courseID = ddlClasses.SelectedValue.ToString();

        try
        {
            SqlCommand query = new SqlCommand();
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);

            sc.Open();

            query.Connection = sc;
            query.CommandText = "SELECT GeneralUser.FirstName, GeneralUser.LastName, GeneralUser.EmailAddress  FROM Section " +
                "Left JOIN Enrollment Inner JOIN GeneralUser ON Enrollment.EmailAddress = GeneralUser.EmailAddress " +
                "ON Enrollment.SectionID = Section.SectionID Where Section.CourseID = " + courseID;

            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
                result.Add(read.GetString(0));
                result.Add(read.GetString(1));
                result.Add(read.GetString(2));
            }
            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }

        return result;
    }

    protected void PopChkBox(ArrayList info)
    {
        //chkStudent.
        int size = (info.Count);
        //RadioButtonList rblStudent = new RadioButtonList();
        for (int i = 0; i < size; i += 3)
        {
            String name = info[i].ToString() + " " + info[i + 1].ToString();
            chkStudent.Items.Add(new ListItem(name, info[i + 2].ToString()));

        }
    }
    protected void btnSubmitAttendance_Click(object sender, EventArgs e)
    {
        //insert accident into db

        DateTime today = DateTime.Now;

        try
        {
            //Creates a new sql connection and links the application to the DB
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);

            //Opens the sql connection
            sc.Open();

            //user stored procedures to avoid SQL injection
            SqlCommand update = new SqlCommand();
            update.Connection = sc;
            update.CommandType = CommandType.StoredProcedure;
            update.CommandText = "AttendanceProcedure";

            Debug.WriteLine("Button Clicked");
            int size = chkStudent.Items.Count;

            for (int i = 0; i < size; i++)
            {
                if (chkStudent.Items[i].Selected)
                {
                    update.Parameters.AddWithValue("@CourseID", ddlClasses.SelectedValue);
                    update.Parameters.AddWithValue("@EmailAddress", chkStudent.Items[i].Value.ToString());
                    update.Parameters.AddWithValue("@AttendanceDate", today);
                    update.Parameters.AddWithValue("@PresentBool", 1);

                    update.ExecuteNonQuery();

                    update.Parameters.Clear();
                    SqlCommand updateBucks = new SqlCommand();
                    updateBucks.Connection = sc;
                    updateBucks.CommandText = "update Student set TotalBucks = TotalBucks + .05 where EmailAddress = '" + chkStudent.Items[i].Value.ToString() + "'";
                    updateBucks.ExecuteNonQuery();

                    Debug.WriteLine("Present");
                }
                else
                {
                    update.Parameters.AddWithValue("@CourseID", ddlClasses.SelectedValue);
                    update.Parameters.AddWithValue("@EmailAddress", chkStudent.Items[i].Value.ToString());
                    update.Parameters.AddWithValue("@AttendanceDate", today);
                    update.Parameters.AddWithValue("@PresentBool", 0);
                    update.ExecuteNonQuery();

                    update.Parameters.Clear();


                    Debug.WriteLine("Absent");
                    Debug.WriteLine(chkStudent.Items[i].Value.ToString());
                }
            }
            sc.Close();

            chkStudent.Items.Clear();
            lblSuccess.Visible = true;
            HtmlGenericControl h3 = new HtmlGenericControl("h3");
            h3.InnerText = "Attendance for " + ddlClasses.SelectedItem.Text + " taken successfully!";
            lblSuccess.Controls.Add(h3);
            btnSubmitAttendance.Visible = false;
        }
        catch (SqlException s)
        //shows an error message if there is a problem connecting to the DB.
        {
            Debug.WriteLine(s.Message + "line 253" + "\n" + s.ToString());
        }


    }
    protected void ddlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblSuccess.Visible = false;
        btnSubmitAttendance.Visible = true;

        if (ddlClasses.SelectedIndex != 0)
        {
            chkStudent.Items.Clear();
            studs = GetStudents();
            PopChkBox(studs);
        }
    }
}
