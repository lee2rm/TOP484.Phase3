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

public partial class Student_ClassEvaluation : System.Web.UI.Page
{
    string section = "";
    string emailAddress = "";
    bool addTeacher = false;
    string[] rdoValues = new string[22];
    //string[] rdoValues2 = new string[18];
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["EvalID"] = "2";
        Session["RespondentID"] = Session["UserID"].ToString();

        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        // Query for finding each class a student is enrolled in
        string cmdText = "select Course.CourseName, Enrollment.SectionID, Enrollment.CourseID from Enrollment inner join Section on Enrollment.SectionID = Section.SectionID inner join Course  on Section.CourseID = Course.CourseID where Enrollment.EmailAddress ='" + (String)Session["RespondentID"] + "'";
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        // Populate class list drop down when the page loads
        if (!IsPostBack)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // Populating class name drop down for a specific student
                string className = dt.Rows[i][0].ToString();
                section = dt.Rows[i][1].ToString();
                ddClassName.Items.Insert(i + 1, new ListItem(className, section));
                ddClassName.DataBind();
            }
        }
        System.Diagnostics.Debug.WriteLine(ddClassName.Text);
    }
     
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        string selectedEmail = ddInstructorName.SelectedValue;
        //int emailIndex = selectedEmail.IndexOf(emailAddress.ToString());
        //System.Diagnostics.Debug.WriteLine(emailIndex);
        //emailAddress = selectedEmail.Substring(emailIndex);
        Session["EvaluateeID"] = selectedEmail;
        System.Diagnostics.Debug.WriteLine(Session["EvaluateeID"].ToString());

        ArrayList answers = GatherAnswers();
        ArrayList questions = GatherQuestions();
        SubmitEval(questions, answers);
        //get student Id from Session Variable
    }

    /*
     * Method gathers all answers from the evaluation form 
     * @return result, arraylist containing all user answers
     */

    protected ArrayList GatherAnswers()
    {
        ArrayList result = new ArrayList();

        if (rdoFB.Checked)
        {
            result.Add(rdoFB.Text);
            rdoValues[0] = rdoFB.Text;
        }
        else if (rdoTwitter.Checked)
        {
            result.Add(rdoTwitter.Text);
            rdoValues[0] = rdoTwitter.Text;
        }
        else if (rdoFriend.Checked)
        {
            result.Add(rdoFriend.Text);
            rdoValues[0] = rdoFriend.Text;
        }
        else if (rdoParent.Checked)
        {
            result.Add(rdoParent.Text);
            rdoValues[0] = rdoParent.Text;
        }
        else if (rdoTeacher.Checked)
        {
            result.Add(rdoTeacher.Text);
            rdoValues[0] = rdoTeacher.Text;
        }
        else if (rdoNotSure.Checked)
        {
            result.Add(rdoNotSure.Text);
            rdoValues[0] = rdoNotSure.Text;
        }
        else if (rdoOther.Checked)
        {
            result.Add(txtOther.Text);
            rdoValues[0] = rdoOther.Text;
        }

        if (rdoAlways.Checked)
        {
            result.Add(rdoAlways.Text);
            rdoValues[1] = rdoAlways.Text;
        
        }
        else if (rdoMost.Checked)
        {
            result.Add(rdoMost.Text);
            rdoValues[1] = rdoMost.Text;
        }
        else if (rdoSome.Checked)
        {
            result.Add(rdoSome.Text);
            rdoValues[1] = rdoSome.Text;
        }
        else if (rdoNever.Checked)
        {
            result.Add(rdoNever.Text);
            rdoValues[1] = rdoNever.Text;
        }
        result.Add(txtQuestion4.Text);
        rdoValues[2] = txtQuestion4.Text;
        result.Add(txtQuestion5.Text);
        rdoValues[3] = txtQuestion5.Text;
        result.Add(Request.Form["q6row1"].ToString());
        rdoValues[4] = Request.Form["q6row1".ToString()];
        result.Add(Request.Form["q6row2"].ToString());
        rdoValues[5] = Request.Form["q6row2".ToString()];
        result.Add(Request.Form["q6row3"].ToString());
        rdoValues[6] = Request.Form["q6row3".ToString()];
        result.Add(Request.Form["q6row4"].ToString());
        rdoValues[7] = Request.Form["q6row4".ToString()];
        result.Add(Request.Form["q7row1"].ToString());
        rdoValues[8] = Request.Form["q7row1".ToString()];
        result.Add(Request.Form["q7row2"].ToString());
        rdoValues[9] = Request.Form["q7row2".ToString()];
        result.Add(Request.Form["q7row3"].ToString());
        rdoValues[10] = Request.Form["q7row3".ToString()];
        result.Add(Request.Form["q7row4"].ToString());
        rdoValues[11] = Request.Form["q7row4".ToString()];
        result.Add(Request.Form["q7row5"].ToString());
        rdoValues[12] = Request.Form["q7row5".ToString()];
        result.Add(Request.Form["q7row6"].ToString());
        rdoValues[13] = Request.Form["q7row6".ToString()];
        result.Add(Request.Form["q7row7"].ToString());
        rdoValues[14] = Request.Form["q7row7".ToString()];
        result.Add(Request.Form["q10row2"].ToString());
        rdoValues[15] = Request.Form["q10row2".ToString()];
        result.Add(Request.Form["q10row3"].ToString());
        rdoValues[16] = Request.Form["q10row3".ToString()];
        result.Add(Request.Form["q10row4"].ToString());
        rdoValues[17] = Request.Form["q10row4".ToString()];
        result.Add(Request.Form["q10row5"].ToString());
        rdoValues[18] = Request.Form["q10row5".ToString()];
        result.Add(Request.Form["q8row1"].ToString());
        rdoValues[19] = Request.Form["q8row1".ToString()];
        result.Add(Request.Form["q8row2"].ToString());
        rdoValues[20] = Request.Form["q8row2".ToString()];
        result.Add(Request.Form["q8row3"].ToString());
        rdoValues[21] = Request.Form["q8row3".ToString()];
        result.Add(Request.Form["q9row1"].ToString());
        result.Add(Request.Form["q9row2"].ToString());
        result.Add(Request.Form["q9row3"].ToString());
        result.Add(Request.Form["q9row4"].ToString());
        result.Add(Request.Form["q9row5"].ToString());
        result.Add(Request.Form["q9row6"].ToString());
        result.Add(Request.Form["q9row7"].ToString());
        result.Add(Request.Form["q9row8"].ToString());
        result.Add(Request.Form["q9row9"].ToString());
        result.Add(Request.Form["q9row10"].ToString());
        
        result.Add(txtQuestion2t.Text);
        result.Add(txtQuestion3t.Text);
        result.Add(txtQuestion4t.Text);


        ViewState["class"] = rdoValues;

        if (rdoYes.Checked)
        {
            result.Add(rdoYes.Text);
            addTeacher = true;
        }
        else if (rdoNo.Checked)
        {
            result.Add(rdoNo.Text);
        }

        if (rdoSelf1a.Checked)
        {
            result.Add(rdoSelf1a.Text);
        }
        else if (rdoSelf1b.Checked)
        {
            result.Add(rdoSelf1b.Text);
        }
        else if (rdoSelf1c.Checked)
        {
            result.Add(rdoSelf1c.Text);
        }
        if (rdoSelf2a.Checked)
        {
            result.Add(rdoSelf2a.Text);
        }
        else if (rdoSelf2b.Checked)
        {
            result.Add(rdoSelf2b.Text);
        }

        return result;

    }

    protected ArrayList GatherQuestions()
    {
        ArrayList result = new ArrayList();
        //int count = 0;
        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select QuestionID From QuestionOrder Where EvalID = " + (String)Session["EvalID"];// session variable eval
            SqlDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                result.Add(read[0]);
                //count++;
            }
            sc.Close();

        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }

        return result;

    }

    private void secondProf()
    {

        System.Windows.Forms.MessageBox.Show("You must submit an additional Evaluation for the Second Professor.");
        divClassEval.Visible = false;
        btnSubmit2.Visible = true;
    }


    protected void SubmitEval(ArrayList q, ArrayList a)
    {
        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            SqlCommand insert = new SqlCommand();
            DateTime date = DateTime.Now;

            sc.Open();

            insert.Connection = sc;
            insert.CommandText = "Insert INTO EvalResponse(RespondentEmail, EvalID, EvaluateeEmail, ResponseDate, CourseID)" +
                " Values(@RespondentEmail, @EvalID, @EvaluateeEmail, @Date, @CourseID)";
            insert.Parameters.AddWithValue("@RespondentEmail", (String)Session["RespondentID"]);
            insert.Parameters.AddWithValue("@EvalID", (String)Session["EvalID"]);
            insert.Parameters.AddWithValue("@EvaluateeEmail", (String)Session["EvaluateeID"]);
            insert.Parameters.AddWithValue("@Date", date);
            System.Diagnostics.Debug.WriteLine("session courseID is: " + Session["courseID"].ToString());
            insert.Parameters.AddWithValue("@CourseID", (String)Session["courseID"]);
            insert.ExecuteNonQuery();



            insert.CommandText = "SELECT EvalResponseID FROM EvalResponse WHERE EvalResponseID = (SELECT IDENT_CURRENT('EvalResponse'))";
            Debug.WriteLine(insert.CommandText);
            SqlDataReader read = insert.ExecuteReader();
            read.Read();
            int evalResponse = read.GetInt32(0);
            read.Close();

            Debug.WriteLine(a.Count);
            Debug.WriteLine(q.Count);

            for (int i = 0; i < q.Count; i++)
            {
                insert.Parameters.Clear();
                insert.CommandText = "Insert INTO Response(RespondentEmail, EvalResponseID, ResponseText, QuestionID)" +
                    "Values(@RespondentID, @EvalResponseID, @ResponseText, @QuestionID)";


                insert.Parameters.AddWithValue("@RespondentID", (String)Session["RespondentID"]);
                insert.Parameters.AddWithValue("@EvalResponseID", evalResponse);
                if (a[i] != null)
                {
                    insert.Parameters.AddWithValue("@ResponseText", (String)a[i]);
                }
                else
                {
                    insert.Parameters.AddWithValue("@ResponseText", System.DBNull.Value);
                }
                insert.Parameters.AddWithValue("@QuestionID", q[i]);

                insert.ExecuteNonQuery();

            }


            sc.Close();
            if (addTeacher == true)
            {
                secondProf();

            }

        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }

    }
    protected void btnSubmit2_Click(object sender, EventArgs e)
    {
        ArrayList answers = GatherAnswers2();
        ArrayList questions = GatherQuestions();
        SubmitEval(questions, answers);
        //get student Id from Session Variable
    }

    protected ArrayList GatherAnswers2()
    {
        rdoValues = (string[])ViewState["class"];
        ArrayList result = new ArrayList();
        for (int j = 0; j <=21; j++)
        {
            result.Add(rdoValues[j]);
            Debug.WriteLine(rdoValues[j]);
        }
        result.Add(Request.Form["q9row1"].ToString());
        result.Add(Request.Form["q9row2"].ToString());
        result.Add(Request.Form["q9row3"].ToString());
        result.Add(Request.Form["q9row4"].ToString());
        result.Add(Request.Form["q9row5"].ToString());
        result.Add(Request.Form["q9row6"].ToString());
        result.Add(Request.Form["q9row7"].ToString());
        result.Add(Request.Form["q9row8"].ToString());
        result.Add(Request.Form["q9row9"].ToString());
        result.Add(Request.Form["q9row10"].ToString());

        result.Add(txtQuestion2t.Text);
        result.Add(txtQuestion3t.Text);
        result.Add(txtQuestion4t.Text);

        if (rdoYes.Checked)
        {
            result.Add(rdoYes.Text);
        }
        else if (rdoNo.Checked)
        {
            result.Add(rdoNo.Text);
        }

        if (rdoSelf1a.Checked)
        {
            result.Add(rdoSelf1a.Text);
        }
        else if (rdoSelf1b.Checked)
        {
            result.Add(rdoSelf1b.Text);
        }
        else if (rdoSelf1c.Checked)
        {
            result.Add(rdoSelf1c.Text);
        }

        if (rdoSelf2a.Checked)
        {
            result.Add(rdoSelf2a.Text);
        }
        else if (rdoSelf2b.Checked)
        {
            result.Add(rdoSelf2b.Text);
        }
        return result;

    }



    protected void ddClassName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddInstructorName.Items.Clear();

        string section = ddClassName.SelectedValue;
        System.Diagnostics.Debug.WriteLine("Section selected is: " + section);

        DataTable dt2 = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText2 = "select (FirstName + ' '+ LastName) As fullName, GeneralUser.EmailAddress from GeneralUser inner join Staff on GeneralUser.EmailAddress = Staff.EmailAddress inner join SectionStaff on Staff.EmailAddress = SectionStaff.EmailAddress where SectionStaff.SectionID = '" + section + "'";
        System.Diagnostics.Debug.WriteLine(cmdText2);
        SqlCommand cmd2 = new SqlCommand(cmdText2, connection);
        cmd2.ExecuteNonQuery();
        SqlDataAdapter adp2 = new SqlDataAdapter(cmd2); // read in data from query results
        adp2.Fill(dt2);

        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            string instructor = dt2.Rows[i][0].ToString();
            string emailAddress = dt2.Rows[i][1].ToString();
            System.Diagnostics.Debug.WriteLine("Test email is: " + emailAddress);
            System.Diagnostics.Debug.WriteLine("Test instructor is: " + instructor);
            ddInstructorName.Items.Insert(i, new ListItem(instructor, emailAddress));
        }
        DataTable dt3 = new DataTable();
        string cmdText3 = "select Course.CourseID, Enrollment.SectionID from Course inner join Enrollment ON Course.CourseID = Enrollment.CourseID where Enrollment.SectionID = '" + ddClassName.Text.ToString() + "'";
        System.Diagnostics.Debug.WriteLine(cmdText3);
        SqlCommand cmd3 = new SqlCommand(cmdText3, connection);
        cmd3.ExecuteNonQuery();
        SqlDataAdapter adp3 = new SqlDataAdapter(cmd3); // read in data from query results
        adp3.Fill(dt3);
        Session["courseID"] = dt3.Rows[0][0].ToString();
        System.Diagnostics.Debug.WriteLine(Session["courseID"].ToString());

    }
}