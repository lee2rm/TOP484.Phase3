using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Instructor_StudentEvaluationHomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string teacherID = Session["UserID"].ToString();
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        // Query for finding every section taught by a specific teacher
        string cmdText = "select Section.SectionID, Section.CourseID, Course.CourseName, SectionStaff.EmailAddress from dbo.Course inner join dbo.Section ON Course.CourseID = dbo.Section.CourseID inner join dbo.SectionStaff ON dbo.Section.SectionID=dbo.SectionStaff.SectionID where EmailAddress = '" + teacherID + "'";
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        // Populate class list drop down when the page loads
        if (!IsPostBack)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string className = dt.Rows[i][2].ToString();
                ddlClasses.Items.Add(className);
            }
        }
        System.Diagnostics.Debug.WriteLine(ddlClasses.Text);
        // only generate table if an actual class is selected
        if (ddlClasses.Text != "--Select a Class--")
        {
            // Assign courseID and sectionID viewstate variables for the class that is selected
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (ddlClasses.Text == dt.Rows[i][2].ToString())
                {
                    ViewState["sectionID"] = dt.Rows[i][0].ToString();
                    ViewState["courseID"] = dt.Rows[i][1].ToString();

                    System.Diagnostics.Debug.WriteLine(ViewState["sectionID"].ToString());
                    System.Diagnostics.Debug.WriteLine(ViewState["courseID"].ToString());

                }
            }
            GenerateTable();
        }
    }

    private void GenerateTable()
    {
        System.Diagnostics.Debug.WriteLine("generate table entered");
        DataTable dt = CreateDataTable();
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
            if (dt.Columns[j].ColumnName == "FullName")
            {
                TableHeaderCell studentName = new TableHeaderCell();
                studentName.Text = "Student Name";
                row.Cells.Add(studentName);
            }
            if (dt.Columns[j].ColumnName == "EmailAddress")
            {
                TableHeaderCell studentName = new TableHeaderCell();
                studentName.Text = "Click to Evaluate";
                row.Cells.Add(studentName);
            }
        }
        table.Rows.Add(row);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            row = new TableRow();
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                if (dt.Columns[j].ColumnName == "FullName")
                {
                    TableCell nameCell = new TableCell();
                    //System.Diagnostics.Debug.WriteLine(dt.Rows[i][j].ToString());
                    nameCell.Text = dt.Rows[i][j].ToString();
                    row.Cells.Add(nameCell);
                }
                if (dt.Columns[j].ColumnName == "EmailAddress")
                {
                    TableCell nameCell = new TableCell();
                    LinkButton evaluateStudent = new LinkButton();
                    evaluateStudent.Click += eval_click;
                    evaluateStudent.CommandArgument = dt.Rows[i][j].ToString();
                    evaluateStudent.Text = "Evaluate this Student!";
                    nameCell.Controls.Add(evaluateStudent);
                    row.Cells.Add(nameCell);
                }
            }
            table.Rows.Add(row);
        }
        form1.Controls.Add(table);
    }

    private void eval_click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        string studentID = btn.CommandArgument;
        Session["EvaluateeID"] = studentID;
        Session["sectionID"] = ViewState["sectionID"].ToString();
        Session["courseID"] = ViewState["courseID"].ToString();
        Response.Redirect("Instructor.StudentEvaluation.aspx", false);
    }

   

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        // query to select alll the students in a given section
        string cmdText = "select (dbo.GeneralUser.FirstName + ' ' + dbo.GeneralUser.LastName) AS FullName, dbo.Enrollment.EmailAddress, dbo.Enrollment.SectionID, dbo.Enrollment.CourseID from dbo.Enrollment INNER JOIN dbo.GeneralUser ON dbo.Enrollment.EmailAddress=dbo.GeneralUser.EmailAddress WHERE Enrollment.SectionID = '" + ViewState["sectionID"].ToString() + "' AND Enrollment.CourseID = '" + ViewState["courseID"].ToString() + "'";
        System.Diagnostics.Debug.WriteLine(cmdText);
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }
    protected void btnSubmitEvaluation_Click(object sender, EventArgs e)
    {

    }
}