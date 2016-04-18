using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_EvaluationHomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // comment session variable back in after testing
        string studentID = Session["UserID"].ToString();
        System.Diagnostics.Debug.WriteLine(studentID);
        System.Diagnostics.Debug.WriteLine(Session["UserID"].ToString());
        // need to pass in the email address of whichever student is logged in to see their own evaluations
        GenerateTable(studentID);
    
    }

    private void GenerateTable(string studentID)
    {
        string ID = studentID;

        DataTable dt = CreateDataTable1(ID);
        //DataTable dt2 = CreatDataTable2();
        //DataTable dtBoth = myJoinMethod(dt, dt2, "EvalResponseID", "CourseID");

        //System.Diagnostics.Debug.WriteLine(dt.Rows[0][0].ToString());
        //System.Diagnostics.Debug.WriteLine(dt.Rows[0][1].ToString());
        //System.Diagnostics.Debug.WriteLine(dt.Rows[0][2].ToString());
        //System.Diagnostics.Debug.WriteLine(dt.Rows[0][3].ToString());
        //System.Diagnostics.Debug.WriteLine(dt.Rows[0][4].ToString());





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
        // determine which datatable has more rows so for loop captures everything
        int rowCount = dt.Rows.Count;
        System.Diagnostics.Debug.WriteLine(rowCount);
        for (int i = 0; i < rowCount; i++)
        {
            System.Diagnostics.Debug.WriteLine(dt.Rows[i][1].ToString());
            System.Diagnostics.Debug.WriteLine(dt.Rows[i][4].ToString());
           
            // Row containing the class names that the studentID passed in has taken (EvaluateeEmail to see how many evaluations have been filled out ABOUT a student)
            row = new TableRow();
            TableCell courseName = new TableCell();
            courseName.Text = dt.Rows[i][0].ToString();
            row.Cells.Add(courseName);

            TableCell eval = new TableCell();
            LinkButton evalLink = new LinkButton();
            evalLink.Text = "View This Evaluation";
            evalLink.Click += evalLink_Click;
            evalLink.CommandArgument = dt.Rows[i][5].ToString();
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
        Response.Redirect("Student.ViewEvaluations.aspx", false);
    }

    // This method creates a data table containing all the evaluations that have been filled out ABOUT a particular student
    // "and not respondentEmail = ..." is in the query so that evaluations filled out BY students do not get returned
    private DataTable CreateDataTable1(string ID)
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select Course.CourseName, Enrollment.CourseID, Enrollment.EmailAddress, Enrollment.SectionID, Enrollment.InstructorEvalBool, EvalResponse.EvalResponseID from Course inner join Enrollment ON Course.CourseID = Enrollment.CourseID inner join Student on Enrollment.EmailAddress = Student.EmailAddress inner Join Evaluatee on Student.EmailAddress = Evaluatee.EvaluateeEmail inner join EvalResponse on Evaluatee.EvaluateeEmail = EvalResponse.EvaluateeEmail where EvalResponse.EvaluateeEmail = '" + Session["UserID"].ToString() + "' AND Enrollment.InstructorEvalBool = '1' AND EvalResponse.CourseID = Course.CourseID";
        System.Diagnostics.Debug.WriteLine(cmdText);
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);

        return dt;
    }

    // this method returns all the classes and the teachers that teach them
    //private DataTable CreatDataTable2()
    //{
    //    DataTable dt = new DataTable();
    //    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    //    connection.Open();
    //    string cmdText = "Select CourseName from Section inner Join Course on Section.CourseID = Course.CourseID inner join Enrollment on Section.SectionID = Enrollment.SectionID";
    //    SqlCommand cmd = new SqlCommand(cmdText, connection);
    //    cmd.ExecuteNonQuery();
    //    SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
    //    adp.Fill(dt);

    //    return dt;
    //}

    //public DataTable myJoinMethod(DataTable LeftTable, DataTable RightTable,
    //        String LeftPrimaryColumn, String RightPrimaryColumn)
    //{
    //    //first create the datatable columns 
    //    DataSet mydataSet = new DataSet();
    //    mydataSet.Tables.Add("  ");
    //    DataTable myDataTable = mydataSet.Tables[0];

    //    //add left table columns 
    //    DataColumn[] dcLeftTableColumns = new DataColumn[LeftTable.Columns.Count];
    //    LeftTable.Columns.CopyTo(dcLeftTableColumns, 0);

    //    foreach (DataColumn LeftTableColumn in dcLeftTableColumns)
    //    {
    //        if (!myDataTable.Columns.Contains(LeftTableColumn.ToString()))
    //            myDataTable.Columns.Add(LeftTableColumn.ToString());
    //    }

    //    //now add right table columns 
    //    DataColumn[] dcRightTableColumns = new DataColumn[RightTable.Columns.Count];
    //    RightTable.Columns.CopyTo(dcRightTableColumns, 0);

    //    foreach (DataColumn RightTableColumn in dcRightTableColumns)
    //    {
    //        if (!myDataTable.Columns.Contains(RightTableColumn.ToString()))
    //        {
    //            if (RightTableColumn.ToString() != RightPrimaryColumn)
    //                myDataTable.Columns.Add(RightTableColumn.ToString());
    //        }
    //    }

    //    //add left-table data to mytable 
    //    foreach (DataRow LeftTableDataRows in LeftTable.Rows)
    //    {
    //        myDataTable.ImportRow(LeftTableDataRows);
    //    }

    //    ArrayList var = new ArrayList(); //this variable holds the id's which have joined 

    //    ArrayList LeftTableIDs = new ArrayList();
    //    LeftTableIDs = this.DataSetToArrayList(0, LeftTable);

    //    //import righttable which having not equal Id's with lefttable 
    //    foreach (DataRow rightTableDataRows in RightTable.Rows)
    //    {
    //        if (LeftTableIDs.Contains(rightTableDataRows[0]))
    //        {
    //            string wherecondition = "[" + myDataTable.Columns[0].ColumnName + "]='"
    //                    + rightTableDataRows[0].ToString() + "'";
    //            DataRow[] dr = myDataTable.Select(wherecondition);
    //            int iIndex = myDataTable.Rows.IndexOf(dr[0]);

    //            foreach (DataColumn dc in RightTable.Columns)
    //            {
    //                if (dc.Ordinal != 0)
    //                    myDataTable.Rows[iIndex][dc.ColumnName.ToString().Trim()] =
    //            rightTableDataRows[dc.ColumnName.ToString().Trim()].ToString();
    //            }
    //        }
    //        else
    //        {
    //            int count = myDataTable.Rows.Count;
    //            DataRow row = myDataTable.NewRow();
    //            row[0] = rightTableDataRows[0].ToString();
    //            myDataTable.Rows.Add(row);
    //            foreach (DataColumn dc in RightTable.Columns)
    //            {
    //                if (dc.Ordinal != 0)
    //                    myDataTable.Rows[count][dc.ColumnName.ToString().Trim()] =
    //            rightTableDataRows[dc.ColumnName.ToString().Trim()].ToString();
    //            }
    //        }
    //    }

    //    return myDataTable;
    //}

    private ArrayList DataSetToArrayList(int p, DataTable dataTable)
    {
        ArrayList output = new ArrayList();

        foreach (DataRow row in dataTable.Rows)
            output.Add(row[p]);

        return output;
    }


}