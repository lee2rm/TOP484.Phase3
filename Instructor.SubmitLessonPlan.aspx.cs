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
using System.Windows.Forms;

public partial class Instructor_SubmitLessonPlan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText6 = "Select CourseName from Course";
        SqlCommand cmd6 = new SqlCommand(cmdText6, connection);
        cmd6.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd6);
        adp.Fill(dt);
        if (!IsPostBack)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string course = dt.Rows[i][0].ToString();
                ddlClasses.Items.Insert(i, new ListItem(course));
                ddlClasses.DataBind();

            }
        }
    }
    protected void btnSendLetter_Click(object sender, EventArgs e)
    {

        if (fLessonPlan.HasFile)
        {
            string filename = System.IO.Path.GetFileName(fLessonPlan.FileName);
            //fuAdminAddContent.SaveAs("~/download/" + filename); // used this filepath to save on my desktop
            int lastSlash = filename.LastIndexOf("\\");
            string trailingPath = filename.Substring(lastSlash + 1);
            string fullPath = Server.MapPath(" ") + "\\" + trailingPath;
            fLessonPlan.PostedFile.SaveAs(fullPath);

            /*Uploaded file path*/
            /*******************************************/
            /*Code to save the file path into data base??*/
            /*******************************************/
            MessageBox.Show("File upload successful!");
            // need to tie the file uploaded to the selected student's folder
            // need to add event handler for publishing file to community wall if user selects check box
        }
        else
        {
            Response.Write("Error: Please select a file");
        }
    }
}