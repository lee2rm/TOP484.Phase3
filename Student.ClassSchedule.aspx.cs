using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_ClassSchedule : System.Web.UI.Page
{
    //TODO: track bucks thru attendance 
    // 
    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateTable();
    }

    private void GenerateTable()
    {
        DataTable dt = CreateDataTable();
        ViewState["dt"] = (DataTable)dt;
        Table table = new Table();
        GridView grid = new GridView();
        TableRow row = null;
        table.CellSpacing = 20;
        table.CellPadding = 10;
        table.GridLines = GridLines.Vertical;

        // Add Row for column header
        row = new TableRow();
        for (int j = 0; j < dt.Columns.Count; j++)
        {
            // Assign desired Table Names to query table resultset
            if (dt.Columns[j].ColumnName == "CourseName")
            {
                TableHeaderCell className = new TableHeaderCell();
                className.Text = "Class Name";
                row.Cells.Add(className);
            }
            if (dt.Columns[j].ColumnName == "Semester")
            {
                TableHeaderCell semester = new TableHeaderCell();
                semester.Text = "Semester";
                row.Cells.Add(semester);
            }
            if (dt.Columns[j].ColumnName == "CourseTime")
            {
                TableHeaderCell semester = new TableHeaderCell();
                semester.Text = "Class Meeting Time";
                row.Cells.Add(semester);
            }
            if (dt.Columns[j].ColumnName == "Location")
            {
                TableHeaderCell courseLocation = new TableHeaderCell();
                courseLocation.Text = "Class Location";
                row.Cells.Add(courseLocation);
            }
            if (dt.Columns[j].ColumnName == "EmailAddress")
            {
                TableHeaderCell courseLocation = new TableHeaderCell();
                courseLocation.Text = "Instructor Email";
                row.Cells.Add(courseLocation);
            }
            
        }
        // Add Title row with column headers to the table
        table.Rows.Add(row);

        //Add each row in the DataTable
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            row = new TableRow();
            // add the column for each row
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                //System.Diagnostics.Debug.WriteLine(dt.Columns[j].ColumnName);
                if (dt.Columns[j].ColumnName == "CourseName")
                {
                    TableCell nameCell = new TableCell();
                    nameCell.Text = dt.Rows[i][j].ToString();
                    row.Cells.Add(nameCell);

                }
                if (dt.Columns[j].ColumnName == "Semester")
                {
                    TableCell semester = new TableCell();
                    semester.Text = dt.Rows[i][j].ToString();
                    row.Cells.Add(semester);
                }
                if (dt.Columns[j].ColumnName == "CourseTime")
                {
                    TableCell courseTime = new TableCell();
                    courseTime.Text = dt.Rows[i][j].ToString();
                    row.Cells.Add(courseTime);
                }
                if (dt.Columns[j].ColumnName == "Location")
                {
                    TableCell courseLoc = new TableCell();
                    courseLoc.Text = dt.Rows[i][j].ToString();
                    row.Cells.Add(courseLoc);
                }
                if (dt.Columns[j].ColumnName == "EmailAddress")
                {
                        TableCell email = new TableCell();
                        LinkButton link = new LinkButton();
                        link.Text = dt.Rows[i][j].ToString();
                        link.Click += email_Click; // assign event action, link_click method below
                        link.CommandArgument = dt.Rows[i][j].ToString(); // Assign the e-mail address of this row to the arguments passed when the linkbutton is clicked
                        email.Controls.Add(link);
                        row.Cells.Add(email);
                }

            }
            
            table.Rows.Add(row);
            form1.Controls.Add(table);

        }
    }

    private void email_Click(object sender, EventArgs e)
    {
        //System.Diagnostics.Debug.WriteLine("send email clicked");
        LinkButton btn = (LinkButton)(sender);
        string teacherID = btn.CommandArgument;
        Session["emailAddress"] = teacherID;
        //System.Diagnostics.Debug.WriteLine(Session["emailAddress"].ToString());
        Response.Redirect("SendEmail.aspx", false);
    }

    private DataTable CreateDataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Name")
        {
            sortBy = "ORDER BY CourseName";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Day of the Week")
        {
            sortBy = "ORDER BY CourseTime";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Location")
        {
            sortBy = "ORDER BY Location";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Semester")
        {
            sortBy = "ORDER BY Semester";
        }
        string studentID = Session["UserID"].ToString();
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select dbo.Course.CourseName, (dbo.Enrollment.EmailAddress) AS StudentID, dbo.Enrollment.SectionID, dbo.Section.CourseID, dbo.Section.CourseTime, dbo.Section.Semester, dbo.Section.Location, dbo.SectionStaff.EmailAddress from dbo.Enrollment inner join dbo.Section ON dbo.Enrollment.SectionID=dbo.Section.SectionID inner join dbo.Course ON dbo.Course.CourseID = dbo.Section.CourseID inner join dbo.SectionStaff ON dbo.SectionStaff.SectionID=dbo.Enrollment.SectionID WHERE dbo.Enrollment.EmailAddress ='" + studentID + "' " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        
        cmd.ExecuteNonQuery();
        
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }

    // ondayrender for each day (e.cell) as calendar is being constructed
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Calendar Day: " + e.Day.Date.DayOfWeek.ToString());
        e.Cell.Attributes.Add("OnClick", e.SelectUrl);
        if (e.Day.IsToday)
        {
            // Outline today's date cell
            e.Cell.BorderColor = System.Drawing.Color.Black;
            e.Cell.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            e.Cell.BorderStyle = BorderStyle.Solid;
            e.Cell.BorderWidth = 2;
        }

        if (ViewState["dt"] != null)
        {
            // get datatable from page load
            DataTable dt = (DataTable)ViewState["dt"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string courseTime = dt.Rows[i][4].ToString();
                string sectionID = dt.Rows[i][2].ToString();
                System.Diagnostics.Debug.WriteLine(courseTime);
                int index = courseTime.IndexOf(' ');
                System.Diagnostics.Debug.WriteLine(index);
                string dayOfWeek = courseTime.Substring(0, index);
                System.Diagnostics.Debug.WriteLine(dayOfWeek);
                string meetTime = courseTime.Substring(index + 1);
                // If an EventDate from our datatable is equal to each day's date as its being rendered
                if (e.Day.Date.DayOfWeek.ToString() == dayOfWeek)
                {
                    // DateTime variable to recognize each day that has an event
                    DateTime thisDay = e.Day.Date;
                    // break line to place text under datecell number
                    Literal ltrl = new Literal();
                    ltrl.Text = "<BR />";
                    e.Cell.Controls.Add(ltrl);

                    // outline the datecell where an event is taking place
                    e.Cell.BorderColor = System.Drawing.Color.Aqua;
                    e.Cell.BackColor = System.Drawing.Color.Gray;
                    e.Cell.BorderStyle = BorderStyle.Solid;
                    e.Cell.BorderWidth = 2;
                    

                    // Label for going to a specific event to view or edit it
                    Label b = new Label();
                    b.Font.Size = 12;
                    b.Font.Bold = true;
                    b.ForeColor = System.Drawing.Color.MediumVioletRed;
                    b.Text = dt.Rows[i][0].ToString() + " @ " + meetTime;
                    e.Cell.Controls.Add(b);

                    Literal ltrl2 = new Literal();
                    ltrl2.Text = "<BR/><a style='font-size:8' href='ViewClass.aspx?SectionID=" + sectionID + "'>Course Details</a>";  
                    e.Cell.Controls.Add(ltrl2);
                }
            }
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
    }
    protected void btnHide_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = false;
    }
}