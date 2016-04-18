using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // TODO: insert actual pro pic links in student table

        int userType = 0;
        if (Session["permission"] != null)
        {
            userType = Int32.Parse(Session["permission"].ToString());
        }
        switch (userType)
        {
            case 1:
                // display cipher menu
                adminPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";

                btnViewProfile.Style["display"] = "none";

                break;
            case 2:
                // display parent menu
                adminPanel1.Style["display"] = "none";

                cipherPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";

                btnViewProfile.Style["display"] = "none";

                break;
            case 3:
                // display student menu
                adminPanel1.Style["display"] = "none";

                cipherPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";

                break;
            case 4:
                // display instructor menu
                adminPanel1.Style["display"] = "none";

                cipherPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";

                btnViewProfile.Style["display"] = "none";

                break;
            case 5:
                // display admin menu
                cipherPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";

                btnViewProfile.Style["display"] = "none";
                
                break;
            default:
                // ?? display error?
                break;
        }

        if (Session["permission"].ToString() == "3")
        {
            string userID = Session["UserID"].ToString();
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            connection.Open();
            string cmdText = "select (FirstName + ' ' + LastName) as FullName, Student.StudentLevel, Student.TotalBucks, Student.SignedWaiver, Student.ProfilePicture from dbo.GeneralUser inner join dbo.Student on GeneralUser.EmailAddress = Student.EmailAddress where Student.EmailAddress = '" + Session["UserID"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
            adp.Fill(dt);
            //imgProfile.ImageUrl = dt.Rows[0][4].ToString();
            txtName.Text = dt.Rows[0][0].ToString();
            txtLevel.Text = dt.Rows[0][1].ToString();
            txtBucks.Text = "$ " + dt.Rows[0][2].ToString();
            if (dt.Rows[0][3].ToString() == "True")
            {
                txtWaiver.Text = "Complete";
            }
            else
            {
                txtWaiver.Text = "Incomplete";
            }
        }
        else
        {
            string userID = Session["UserID"].ToString();
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            connection.Open();
            string cmdText = "select (FirstName + ' ' + LastName) as FullName from dbo.GeneralUser where EmailAddress = '" + Session["UserID"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
            adp.Fill(dt);
            txtName.Text = dt.Rows[0][0].ToString();
            lblLevel.Visible = false;
            txtLevel.Visible = false;
            lblWaiver.Visible = false;
            txtWaiver.Visible = false;
            lblBucks.Visible = false;
            txtBucks.Visible = false;
            btnDownloadWaiver.Visible = false;
            btnShop.Visible = false;
            btnViewSchedule.Visible = false;
            btnEditInfo.Visible = false;
            imgProfile.Visible = false;
        }




    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }
    protected void btnViewProfile_Click(object sender, EventArgs e)
    {
        // link to student's profile page using session variable
    }
    protected void btnEditInfo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.EditUser.aspx");
    }
    protected void btnDownloadWaiver_Click(object sender, EventArgs e)
    {
        Response.ContentType = "Application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=RequiredWaivers.pdf");
        Response.TransmitFile(Server.MapPath("~/upload/Academy Parent Forms.pdf"));
        Response.End();
    }
    protected void btnViewSchedule_Click(object sender, EventArgs e)
    {
        Response.Redirect("Student.ClassSchedule.aspx");
    }
}