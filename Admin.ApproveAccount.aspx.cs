using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ApproveAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        populateApplication();
    }

    public void populateApplication()
    {
        string applicantID = Session["applicantID"].ToString();

        System.Diagnostics.Debug.WriteLine(applicantID);
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select FirstName, LastName, EmailAddress, DOB, CellPhone, UserType from dbo.GeneralUser where EmailAddress='" + applicantID + "'";
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        DataTable dt = new DataTable(); // create data table for sql query
        adp.Fill(dt);
        txtfName.Text = dt.Rows[0][0].ToString();
        txtfName.ReadOnly = true;
        txtlName.Text = dt.Rows[0][1].ToString();
        txtlName.ReadOnly = true;
        txtEmail.Text = dt.Rows[0][2].ToString();
        txtEmail.ReadOnly = true;
        txtDOB.Text = dt.Rows[0][3].ToString();
        txtDOB.ReadOnly = true;
        txtCellPhone.Text = dt.Rows[0][4].ToString();
        txtCellPhone.ReadOnly = true;
        txtUserType.Text = dt.Rows[0][5].ToString();
        txtUserType.ReadOnly = true;
   
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string applicantID = Session["applicantID"].ToString();

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "update dbo.Applicant set Approved = 'True' where EmailAddress='" + applicantID + "'";
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        DateTime approvalDate = new DateTime();
        approvalDate = DateTime.Now;
        cmdText = "update dbo.Applicant set DateApproved = '" + approvalDate + "' where EmailAddress = '" + applicantID + "'";
        SqlCommand cmd2 = new SqlCommand(cmdText, connection);
        cmd2.ExecuteNonQuery();
        // need to code a SQL statement to get the profile type of the approved user
        // base the kind of email sent on this
        ActivateAccount(Session["applicantID"].ToString());
        sendActivationEmail(Session["applicantID"].ToString());
        Response.Redirect("Admin.ManageAccounts.aspx");
    }


    #region add Record to proper table
    protected void ActivateAccount(String applicantID)
    {
        String accountType = "";

        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select RequestedAccountType From Applicant Where EmailAddress = @EmailAddress";

            query.Parameters.AddWithValue("@EmailAddress", applicantID);
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + applicantID);
            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
                accountType = read.GetString(0);

            }
            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }
        switch (accountType)
        {
            case "Cipher":
                AddCipher(applicantID);
                DropApplicant(applicantID);
                break;
            case "Parent":
                AddParent(applicantID);
                DropApplicant(applicantID);
                break;
            case "Student":
                
                SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
                SqlCommand query = new SqlCommand();

                sc.Open();

                query.Connection = sc;
                query.CommandText = "insert into Student (EmailAddress, TotalBucks, StudentLevel) values (@EmailAddress, @TotalBucks, @StudentLevel)";
                query.Parameters.AddWithValue("@EmailAddress", applicantID);
                query.Parameters.AddWithValue("@TotalBucks", "0");
                query.Parameters.AddWithValue("@StudentLevel", "Sojourner");
                query.ExecuteNonQuery();
                query.Parameters.Clear();
                
                
                query.CommandText = "insert into Evaluatee (EvaluateeEmail, StudentEmailAddress) values (@EvaluateeEmail, @StudentEmailAddress)";
                query.Parameters.AddWithValue("@EvaluateeEmail", applicantID);
                query.Parameters.AddWithValue("@StudentEmailAddress", applicantID);
                query.ExecuteNonQuery();
                query.Parameters.Clear();

                query.CommandText = "insert into Respondent (RespondentEmail, StudentEmailAddress) values (@RespondentEmail, @StudentEmailAddress)";
                query.Parameters.AddWithValue("@RespondentEmail", applicantID);
                query.Parameters.AddWithValue("@StudentEmailAddress", applicantID);
                query.ExecuteNonQuery();
                query.Parameters.Clear();
                DropApplicant(applicantID);

                query.CommandText = "update GeneralUser set ActivatedBool = 1 where EmailAddress = @EmailAddress";
                query.Parameters.AddWithValue("@EmailAddress", applicantID);
                query.ExecuteNonQuery();
                //EmailStudent(applicantID);
                //Send email to student to get the rest of their details
                break;
        }

    }



    protected void AddCipher(String applicantID)
    {
        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Insert Into Cipher(EmailAddress, BoolPaid) Values(@EmailAddress, @BoolPaid)";

            query.Parameters.AddWithValue("@EmailAddress", applicantID);
            query.Parameters.AddWithValue("@BoolPaid", 1);
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + applicantID);
            query.ExecuteNonQuery();
            query.Parameters.Clear();

            query.CommandText = "update GeneralUser set ActivatedBool = 1 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", applicantID);
            query.ExecuteNonQuery();
            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }

    }

    protected void AddParent(String applicantID)
    {
        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();
            String[] student;
            student = GetStudentInfo(applicantID);


            //Add Parent Record

            query.Connection = sc;
            query.CommandText = "Insert Into Parent(EmailAddress, LetterCount, Relationship) Values(@EmailAddress, @LetterCount, @Relationship)";

            query.Parameters.AddWithValue("@EmailAddress", applicantID);
            query.Parameters.AddWithValue("@LetterCount", 0);
            query.Parameters.AddWithValue("@Relationship", student[4]);
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + applicantID);
            query.ExecuteNonQuery();
            // compare student

            if (VerifyStudent(student))
            {
                // add parent student
                query.Connection = sc;
                query.CommandText = "Insert Into ParentStudent(StudentEmailAddress, ParentEmailAddress, LetterTitel, LetterText, LetterDate) " +
                "Values(@StudentEmailAddress, @ParentEmailAddress, @LetterTitel, @LetterText, @LetterDate)";

                query.Parameters.AddWithValue("@StudentEmailAddress", student[0]);
                query.Parameters.AddWithValue("@ParentEmailAddress", applicantID);
                query.Parameters.AddWithValue("@LetterTitel", System.DBNull.Value);
                query.Parameters.AddWithValue("@LetterText", System.DBNull.Value);
                query.Parameters.AddWithValue("@LetterDate", System.DBNull.Value);

                Debug.WriteLine(query.CommandText);
                Debug.WriteLine("Where @EmailAddress = " + applicantID);
                query.ExecuteNonQuery();
            }
            query.Parameters.Clear();
            query.CommandText = "update GeneralUser set ActivatedBool = 1 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", applicantID);
            query.ExecuteNonQuery();



            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }
    }

    protected bool VerifyStudent(String[] student)
    {
        bool result = false;

        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            VerifyStudent(student);
            // txtChildEmail.Text + "," + txtChildFName.Text + "," + txtChildLName.Text + "," + txtChildDOB.Text + "," + txtParentRelationship.Text
            query.Connection = sc;
            query.CommandText = "Select from GeneralUser Where EmailAddress = @EmailAddress AND FirstName = @FName AND LastName = @LName and DOB = @DOB";

            query.Parameters.AddWithValue("@EmailAddress", student[0]);
            query.Parameters.AddWithValue("@FName", student[1]);
            query.Parameters.AddWithValue("@LName", student[2]);
            query.Parameters.AddWithValue("@DOB", student[3]);
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + student[0]);
            SqlDataReader read = query.ExecuteReader();

            if (read.Read())
            {
                result = true;
            }

            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }

        return result;
    }

    protected String[] GetStudentInfo(String applicantID)
    {


        String info = "";
        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select StudentInfo From Applicant Where EmailAddress = @EmailAddress";

            query.Parameters.AddWithValue("@EmailAddress", applicantID);
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + applicantID);
            SqlDataReader read = query.ExecuteReader();

            read.Read();
            info = read.GetString(0);



            sc.Close();


        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }
        char[] delimiterChars = { ',' };
        String[] result = info.Split(delimiterChars);

        return result;

    }

    protected void DropApplicant(String applicantID)
    {
        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Drop From Applicant Where EmailAddress = @EmailAddress";

            query.Parameters.AddWithValue("@EmailAddress", applicantID);
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + applicantID);
            query.ExecuteNonQuery();

            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }

    }

    #endregion

    #region Event Handler for "Deny" button
    protected void btnDeny_Click(object sender, EventArgs e)
    {
        string applicantID = Session["applicantID"].ToString();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "delete from dbo.Applicant where AppEmailAddress='" + applicantID + "'";
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
    }
    #endregion

    #region Method for sending activation email to newly approved users

    public void sendActivationEmail(string email)
    {
        String accountType = "";
        string applicantID = Session["applicantID"].ToString();
        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select RequestedAccountType From Applicant Where EmailAddress = @EmailAddress";

            query.Parameters.AddWithValue("@EmailAddress", applicantID);
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + applicantID);
            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
                accountType = read.GetString(0);

            }
            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }
        // Setting up an e-mail message, establishing the credentials for the email address it is coming from and the email address it is going to
        MailMessage message = new MailMessage();
        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        // LOCALHOST NUMBER SHOULD MATCH YOUR BROWSERS
        // run any webpage and copy the number over to debug
        string userActivation = "http://localhost:55789/Top484CS-masterFinal/Log-In.aspx"; // TODO: change this to WBL admin email

        message.From = new MailAddress("top484.wordsbeatslifeproject@gmail.com"); // where activation email is being sent FROM
        message.To.Add(email); // where activation email is sent to user-supplied email address.
        // TODO: ^^ validate this textbox is in E-mail format
        message.Subject = "Account Activation"; // Subject of activation email
        message.Body = "Hello! </br></br>Your Words Beats and Life profile has now been approved. Your account activation link is here: </br></br> <a href = '" + userActivation + "'> Activate your account now to join the community!</a>";
        message.Body += "</br></br>Have a nice day!</br> ~WBL Staff~";
        message.IsBodyHtml = true; // message contained in html body
        client.EnableSsl = true; // secure connection
        client.UseDefaultCredentials = true; // have to set up credentials as true
        client.Credentials = new System.Net.NetworkCredential("top484.wordsbeatslifeproject@gmail.com", "wordsbeatslife"); // user and PW for some client, replace this with user-supplied email/pw
        client.Send(message);
    }

    #endregion

}