using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Instructor_EvaluationHomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // comment session variable back in after testing
        string teacherID = Session["UserID"].ToString();
        System.Diagnostics.Debug.WriteLine(teacherID);
        System.Diagnostics.Debug.WriteLine(Session["UserID"].ToString());
        // need to pass in the email address of whichever student is logged in to see their own evaluations
        GenerateTable(teacherID);

    }

    private void GenerateTable(string teacherID)
    {
        string ID = teacherID;

        DataTable dt = CreateDataTable1(ID);
        
        Table table = new Table();
        GridView grid = new GridView();
        TableRow row = null;
        table.CellSpacing = 20;
        table.CellPadding = 10;
        table.GridLines = GridLines.Vertical;

        // Add the Headers
        row = new TableRow();
        TableHeaderCell course = new TableHeaderCell();
        course.Text = "Class Name";
        row.Cells.Add(course);
        TableHeaderCell viewEval = new TableHeaderCell();
        viewEval.Text = "View Evaluation";
        row.Cells.Add(viewEval);
        table.Rows.Add(row);

        int rowCount = dt.Rows.Count;
        System.Diagnostics.Debug.WriteLine(rowCount);
        for (int i = 0; i < rowCount; i++)
        {
            System.Diagnostics.Debug.WriteLine(dt.Rows[i][0].ToString());
            System.Diagnostics.Debug.WriteLine(dt.Rows[i][1].ToString());
            

            // Row containing the class names that the studentID passed in has taken (EvaluateeEmail to see how many evaluations have been filled out ABOUT a student)
            row = new TableRow();
            TableCell courseName = new TableCell();
            courseName.Text = dt.Rows[i][0].ToString();
            row.Cells.Add(courseName);

            TableCell eval = new TableCell();
            LinkButton evalLink = new LinkButton();
            evalLink.Text = "View This Evaluation";
            evalLink.Click += evalLink_Click;
            evalLink.CommandArgument = dt.Rows[i][2].ToString();
            eval.Controls.Add(evalLink);
            row.Cells.Add(eval);
            table.Rows.Add(row);

        }
        form1.Controls.Add(table);
    }

    private void evalLink_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        string evalResponseID = btn.CommandArgument;
        Session["EvalResponseID"] = evalResponseID;
        System.Diagnostics.Debug.WriteLine(Session["EvalResponseID"].ToString());
        Response.Redirect("Instructor.ViewEvaluations.aspx", false);
    }

    // This method creates a data table containing all the evaluations that have been filled out ABOUT a particular student
    // "and not respondentEmail = ..." is in the query so that evaluations filled out BY students do not get returned
    private DataTable CreateDataTable1(string ID)
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select Course.CourseName, EvalResponse.CourseID, EvalResponse.EvalResponseID, EvalResponse.EvaluateeEmail from Course inner join EvalResponse ON EvalResponse.CourseID = Course.CourseID where EvaluateeEmail='" + Session["UserID"].ToString() + "'";
        System.Diagnostics.Debug.WriteLine(cmdText);
        // ^^^ TODO: change this query to accept the session variable of the student email that is passed in (replace testStud@WBL.org)
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);

        return dt;
    }
}