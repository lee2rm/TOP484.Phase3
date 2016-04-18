using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        string userEmail = txtConfirmEmail.Text;
        if (txtNewPass.ToString() == txtConfirmPass.ToString())
        {
            string password = txtNewPass.Text;
            string passwordHashNew = SimpleHash.ComputeHash(password, "MD5", null);
            string changePWQuery = "update dbo.GeneralUser set PasswordHash = '" + passwordHashNew + "' where EmailAddress = '" + userEmail + "'";
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            connection.Open();
            SqlCommand cmd = new SqlCommand(changePWQuery, connection);
            cmd.ExecuteNonQuery();// execute update statement
            Response.Redirect("Log-In.aspx"); // return user to log in page after password is updated
            
        }
    }
}