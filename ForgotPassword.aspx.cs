using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnForgotEmail_Click(object sender, EventArgs e)
    {
        Session["forgottenPasswordEmail"] = txtForgotEmail.Text;
        string resetQuery = "select FirstName, EmailAddress from dbo.GeneralUser where EmailAddress='" + Session["forgottenPasswordEmail"].ToString() + "'";
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
        connection.Open();
        SqlCommand cmd = new SqlCommand(resetQuery, connection);
        cmd.ExecuteNonQuery();// execute select statement
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        DataTable dt = new DataTable(); // create data table for sql query
        adp.Fill(dt); // populate datatable with query results
        System.Diagnostics.Debug.WriteLine(dt.Rows[0][0].ToString());
        int no = dt.Rows.Count; // number of rows in data table
        if (no > 0)
        {
            string fName = dt.Rows[0][0].ToString();
            sendResetEmail(Session["forgottenPasswordEmail"].ToString(), fName);
        }
    }

    public void sendResetEmail(string userEmail, string firstName)
    {
        // Setting up an e-mail message, establishing the credentials for the email address it is coming from and the email address it is going to
        MailMessage message = new MailMessage();
        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;

        string resetLink = "http://localhost:62112/ChangePassword.aspx"; // TODO: change this to WBL admin email

        message.From = new MailAddress("ryan.michael.leee@gmail.com"); // where activation email is being sent FROM
        message.To.Add(userEmail); // where activation email is sent to user-supplied email address.
        // TODO: ^^ validate this textbox is in E-mail format
        message.Subject = "WBL Password Reset"; // Subject of activation email
        message.Body = "Hi " + firstName + ", Click this link to confirm your e-mail address and change password: </br></br> <a href = '" + resetLink + "'> Reset your password!";
        message.IsBodyHtml = true; // message contained in html body
        client.EnableSsl = true; // secure connection
        client.UseDefaultCredentials = true; // have to set up credentials as true
        client.Credentials = new System.Net.NetworkCredential("ryan.michael.leee@gmail.com", "ryancatie2"); // user and PW for some client, replace this with user-supplied email/pw
        client.Send(message);
    }
}