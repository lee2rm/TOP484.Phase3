using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SendEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //int userType = 0;
        //if (Session["permission"] != null)
        //{
        //    userType = Int32.Parse(Session["permission"].ToString());
        //}
        //switch (userType)
        //{
        //    case 1:
        //        // display cipher menu
        //        adminPanel1.Style["display"] = "none";

        //        parentPanel1.Style["display"] = "none";


        //        studentPanel1.Style["display"] = "none";

        //        instructorPanel1.Style["display"] = "none";

        //        break;
        //    case 2:
        //        // display parent menu
        //        adminPanel1.Style["display"] = "none";

        //        cipherPanel1.Style["display"] = "none";

        //        studentPanel1.Style["display"] = "none";

        //        instructorPanel1.Style["display"] = "none";

        //        break;
        //    case 3:
        //        // display student menu
        //        adminPanel1.Style["display"] = "none";

        //        cipherPanel1.Style["display"] = "none";

        //        parentPanel1.Style["display"] = "none";

        //        instructorPanel1.Style["display"] = "none";

        //        break;
        //    case 4:
        //        // display instructor menu
        //        adminPanel1.Style["display"] = "none";

        //        cipherPanel1.Style["display"] = "none";

        //        parentPanel1.Style["display"] = "none";

        //        studentPanel1.Style["display"] = "none";

        //        break;
        //    case 5:
        //        // display admin menu
        //        cipherPanel1.Style["display"] = "none";

        //        parentPanel1.Style["display"] = "none";

        //        studentPanel1.Style["display"] = "none";

        //        instructorPanel1.Style["display"] = "none";
        //        break;
        //    default:
        //        // Display no menus since user has no permission (has applied, but has not been approved by admin yet

        //        adminPanel1.Style["display"] = "none";

        //        cipherPanel1.Style["display"] = "none";

        //        parentPanel1.Style["display"] = "none";

        //        studentPanel1.Style["display"] = "none";

        //        instructorPanel1.Style["display"] = "none";
        //        break;
        //}

        // Determine if the user is sending an email to a bulk group of users
        
        if (!IsPostBack)
        {
            string email = Session["emailAddress"].ToString();
            txtRecipient.Text = email;
            // Set textbox to read only if Admin is emailing bulk group of users
            switch (email)
            {
                case "All":
                    txtRecipient.ReadOnly = true;
                    break;
                case "Students":
                    txtRecipient.ReadOnly = true;
                    break;
                case "Parents":
                    txtRecipient.ReadOnly = true;
                    break;
                case "Cipher":
                    txtRecipient.ReadOnly = true;
                    break;
                case "Instructors / Interns":
                    txtRecipient.ReadOnly = true;
                    break;
                case "Administrators":
                    txtRecipient.ReadOnly = true;
                    break;
                case "Applicants":
                    txtRecipient.ReadOnly = true;
                    break;
                default:
                    
                    break;
            }
        }
    }
    #region Event Handler for Send button
    protected void btnSend_Click(object sender, EventArgs e)
    {
        
        string recipientEmail = txtRecipient.Text;
        // Switch statement to ensure bulk categories are recognized
        Debug.WriteLine(recipientEmail);
        switch (recipientEmail)
        {
            case "All":
                bulkLoop(recipientEmail);
                break;
            case "Students":
                bulkLoop(recipientEmail);
                break;
            case "Parents":
                bulkLoop(recipientEmail);
                break;
            case "Cipher":
                bulkLoop(recipientEmail);
                break;
            case "Instructors / Interns":
                bulkLoop(recipientEmail);
                break;
            case "Administrators":
                bulkLoop(recipientEmail);
                break;
            case "Applicants":
                bulkLoop(recipientEmail);
                break;
            default:
                sendSingleUserEmail(recipientEmail);
                break;
        }
       
    }
    #endregion

    #region Send a specific user an email
    private void sendSingleUserEmail(string recipientEmail)
    {
        MailMessage message = new MailMessage();
        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;

        message.From = new MailAddress("top484.wordsbeatslifeproject@gmail.com"); // where activation email is being sent FROM
        // TODO: ^^ change this line to send email from a user's individual email?
        message.To.Add(recipientEmail); // where activation email is sent to user-supplied email address.
        // TODO: ^^ validate this textbox is in E-mail format
        message.Subject = txtSubject.Text; // Subject of activation email
        message.Body = txtMessage.Text;
        message.IsBodyHtml = true; // message contained in html body
        client.EnableSsl = true; // secure connection
        client.UseDefaultCredentials = true; // have to set up credentials as true
        client.Credentials = new System.Net.NetworkCredential("top484.wordsbeatslifeproject@gmail.com", "wordsbeatslife"); // user and PW for some client, replace this with user-supplied email/pw
        client.Send(message);
        Response.Redirect("Admin.ManageAccounts.aspx");

    }
    #endregion

    #region Send email to a specific group of users or all users
    private void bulkLoop(string recipientEmail)
    {
        string memberType = recipientEmail;
        // Unfiltered query to email all general users
        if (memberType == "All")
        {
            DataTable dtAll = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            connection.Open();
            string cmdText = "select EmailAddress from dbo.GeneralUser";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
            adp.Fill(dtAll);
            // Send an email to each EmailAddress in the resulting query
            Parallel.ForEach(dtAll.AsEnumerable(), row =>
                {
                    sendBulkUserEmail(row["EmailAddress"].ToString());
                });
        }
        // Filtered queries for specific user types
        if (memberType == "Applicants")
        {
            DataTable dt = new DataTable();
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            con2.Open();
            string cmdText2 = "select EmailAddress from dbo.GeneralUser where UserType = 'Student'";
            SqlCommand cmd2 = new SqlCommand(cmdText2, con2);
            Debug.WriteLine(cmdText2);
            cmd2.ExecuteNonQuery();
            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2); // read in data from query results
            adp2.Fill(dt);

            // Send an email to each EmailAddress in the resulting query
            foreach (DataRow row in dt.Rows)
            {
                Debug.WriteLine(row["EmailAddress"].ToString());
                sendBulkUserEmail(row["EmailAddress"].ToString());
            }
            Response.Redirect("Admin.ManageAccounts.aspx");
        }
        if (memberType == "Instructors / Interns")
        {
            DataTable dt = new DataTable();
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            con2.Open();
            string cmdText2 = "select EmailAddress from dbo.GeneralUser where UserType = 'Staff'";
            SqlCommand cmd2 = new SqlCommand(cmdText2, con2);
            Debug.WriteLine(cmdText2);
            cmd2.ExecuteNonQuery();
            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2); // read in data from query results
            adp2.Fill(dt);

            // Send an email to each EmailAddress in the resulting query
            foreach (DataRow row in dt.Rows)
            {
                Debug.WriteLine(row["EmailAddress"].ToString());
                sendBulkUserEmail(row["EmailAddress"].ToString());
            }
            Response.Redirect("Admin.ManageAccounts.aspx");
        }
        if (memberType == "Ciphers")
        {
            DataTable dt = new DataTable();
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            con2.Open();
            string cmdText2 = "select EmailAddress from dbo.GeneralUser where UserType = 'Cipher'";
            SqlCommand cmd2 = new SqlCommand(cmdText2, con2);
            Debug.WriteLine(cmdText2);
            cmd2.ExecuteNonQuery();
            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2); // read in data from query results
            adp2.Fill(dt);

            // Send an email to each EmailAddress in the resulting query
            foreach (DataRow row in dt.Rows)
            {
                Debug.WriteLine(row["EmailAddress"].ToString());
                sendBulkUserEmail(row["EmailAddress"].ToString());
            }
            Response.Redirect("Admin.ManageAccounts.aspx");
        }
        if (memberType == "Administrators")
        {
            DataTable dt = new DataTable();
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            con2.Open();
            string cmdText2 = "select EmailAddress from dbo.GeneralUser where UserType = 'Administrator'";
            SqlCommand cmd2 = new SqlCommand(cmdText2, con2);
            Debug.WriteLine(cmdText2);
            cmd2.ExecuteNonQuery();
            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2); // read in data from query results
            adp2.Fill(dt);

            // Send an email to each EmailAddress in the resulting query
            foreach (DataRow row in dt.Rows)
            {
                Debug.WriteLine(row["EmailAddress"].ToString());
                sendBulkUserEmail(row["EmailAddress"].ToString());
            }
            Response.Redirect("Admin.ManageAccounts.aspx");
        }
        if (memberType == "Students")
        {
            DataTable dt = new DataTable();
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            con2.Open();
            string cmdText2 = "select EmailAddress from dbo.GeneralUser where UserType = 'Student'";
            SqlCommand cmd2 = new SqlCommand(cmdText2, con2);
            Debug.WriteLine(cmdText2);
            cmd2.ExecuteNonQuery();
            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2); // read in data from query results
            adp2.Fill(dt);

            // Send an email to each EmailAddress in the resulting query
            foreach (DataRow row in dt.Rows)
            {
                Debug.WriteLine(row["EmailAddress"].ToString());
                sendBulkUserEmail(row["EmailAddress"].ToString());
            }
            Response.Redirect("Admin.ManageAccounts.aspx");
        }
        if (memberType == "Parents")
        {
            DataTable dt = new DataTable();
            SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            con2.Open();
            string cmdText2 = "select EmailAddress from dbo.GeneralUser where UserType = 'Parent'";
            SqlCommand cmd2 = new SqlCommand(cmdText2, con2);
            Debug.WriteLine(cmdText2);
            cmd2.ExecuteNonQuery();
            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2); // read in data from query results
            adp2.Fill(dt);

            // Send an email to each EmailAddress in the resulting query
            foreach (DataRow row in dt.Rows)
            {
                Debug.WriteLine(row["EmailAddress"].ToString());
                sendBulkUserEmail(row["EmailAddress"].ToString());
            }
            Response.Redirect("Admin.ManageAccounts.aspx");
        }
    }

    private void sendBulkUserEmail(string recipientEmail)
    {
        Debug.WriteLine("sendUserEmail method entered");
        Debug.WriteLine("Parameter passed: " + recipientEmail);
        MailMessage message = new MailMessage();
        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;

        message.From = new MailAddress("top484.wordsbeatslifeproject@gmail.com"); // where activation email is being sent FROM
        // TODO: ^^ change this line to send email from a user's individual email?
        message.To.Add(recipientEmail); // where activation email is sent to user-supplied email address.
        // TODO: ^^ validate this textbox is in E-mail format
        message.Subject = txtSubject.Text; // Subject of activation email
        message.Body = txtMessage.Text;
        message.IsBodyHtml = true; // message contained in html body
        client.EnableSsl = true; // secure connection
        client.UseDefaultCredentials = true; // have to set up credentials as true
        client.Credentials = new System.Net.NetworkCredential("top484.wordsbeatslifeproject@gmail.com", "wordsbeatslife"); // user and PW for some client, replace this with user-supplied email/pw
        client.Send(message);
        //Response.Redirect("Admin.ManageAccounts.aspx");


    }
    #endregion
}