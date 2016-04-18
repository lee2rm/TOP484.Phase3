using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Parent_EncouragementLetter : System.Web.UI.Page
{
    //string userID = Session["UserID"].ToString();
    string userID = "Elexia.Parent@gmail.com";


    protected void Page_Load(object sender, EventArgs e)
    {
      

        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText6 = "select StudentEmailAddress from ParentStudent where ParentEmailAddress='"
            +userID+"'";
        SqlCommand cmd6 = new SqlCommand(cmdText6, connection);
        cmd6.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd6);
        adp.Fill(dt);
        


        if (!IsPostBack)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string email = dt.Rows[i][0].ToString();
                ddlStudent.Items.Insert(i, new ListItem(email));
                ddlStudent.DataBind();
                

            }
            ddlStudent.Items.Insert(0, new ListItem("Select child's email"));
        }
        connection.Close();
    }

    protected void btnSendLetter_Click(object sender, EventArgs e)
    {
        string letterSubject = txtLetterSubject.Text;
        string letterDescription = txtLetterDescription.Text;
        string studentEmail = ddlStudent.SelectedValue;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "Update ParentStudent set LetterTitle=@LetterTitle,LetterText=@LetterText,LetterDate=@LetterDate where StudentEmailAddress=@StudentEmailAddress";
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@LetterTitle", letterSubject);
        cmd.Parameters.AddWithValue("@LetterText", letterDescription);
        cmd.Parameters.AddWithValue("@LetterDate", DateTime.Now);
        cmd.Parameters.AddWithValue("@StudentEmailAddress", studentEmail);

        cmd.ExecuteNonQuery();
        connection.Close();
    }
}
