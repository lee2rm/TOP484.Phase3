using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


public partial class Admin_AddUser : System.Web.UI.Page
{
    //TODO: When Admin creates a user, an email should be sent to them prompting them to change their password
    // ^^ need this to be specific to the type of user
    // ^^^ whenever this happens change @ActivatedBool paramter back to 0
    // Once this email strategy is created, take out the set Activated = 1 query
    // TODO: figure out why Relationship isnt entering to DB when adding parents

    protected void Page_Load(object sender, EventArgs e)
    {
        switch (ddlUserType.Text)
        {
            case "Parent":
                lblRelation.Visible = true;
                txtRelation.Visible = true;
                break;
            case "Staff":
                lblStaffType.Visible = true;
                ddlStaffType.Visible = true;
                lblSpecialty.Visible = true;
                txtSpecialty.Visible = true;
                lblHireDate.Visible = true;
                txtHireDate.Visible = true;
                break;
            case "Administrator":
                lblHireDate.Visible = true;
                txtHireDate.Visible = true;
                lblAdminTitle.Visible = true;
                txtAdminTitle.Visible = true;
                lblManagerEmail.Visible = true;
                txtManagerEmail.Visible = true;
                break;
            default:
                lblRelation.Visible = false;
                txtRelation.Visible = false;
                lblStaffType.Visible = false;
                ddlStaffType.Visible = false;
                lblSpecialty.Visible = false;
                txtSpecialty.Visible = false;
                lblHireDate.Visible = false;
                txtHireDate.Visible = false;
                lblAdminTitle.Visible = false;
                txtAdminTitle.Visible = false;
                lblManagerEmail.Visible = false;
                txtManagerEmail.Visible = false;
                break;
        }


    }
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            connection.Open();
            string cmdText = "Insert INTO GeneralUser(EmailAddress, FirstName, LastName, Gender, HomePhone, HomeAddress, City, State," +
                        "ZIP, DOB, Password, UserType, PasswordHash, ShirtSize, UserPermission, LastLogin, Race, CellPhone, JoinDate," +
                        "ActivatedBool) Values(@EmailAddress, @FirstName, @LastName, @Gender, @HomePhone, @HomeAddress, @City, @State," +
                        "@ZIP, @DOB, @Password, @UserType, @PasswordHash, @ShirtSize, @UserPermission, @LastLogin, @Race, @CellPhone," +
                        "@JoinDate, @Activated)";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtfName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtlName.Text);
            cmd.Parameters.AddWithValue("@Gender", ddlGender.Text);
            if (txtHome.Text.Trim().Equals("") || txtHome.Text == null)
                cmd.Parameters.AddWithValue("@HomePhone", System.DBNull.Value);
            else cmd.Parameters.AddWithValue("@HomePhone", txtHome.Text);
            cmd.Parameters.AddWithValue("@HomeAddress", txtAddress.Text);
            cmd.Parameters.AddWithValue("@City", txtCity.Text);
            cmd.Parameters.AddWithValue("@State", txtState.Text);
            cmd.Parameters.AddWithValue("@ZIP", txtZip.Text);
            cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@UserType", ddlUserType.Text);
            int permission = 0;
            if (ddlUserType.Text == "Administrator")
            {
                permission = 5;
            }
            if (ddlUserType.Text == "Staff")
            {
                permission = 4;
            }
            if (ddlUserType.Text == "Student")
            {
                permission = 3;
            }
            if (ddlUserType.Text == "Parent")
            {
                permission = 2;
            }
            if (ddlUserType.Text == "Cipher")
            {
                permission = 1;
            }
            string passHash = SimpleHash.ComputeHash(txtPassword.Text, "MD5", null);

            cmd.Parameters.AddWithValue("@PasswordHash", passHash);
            cmd.Parameters.AddWithValue("@ShirtSize", ddlShirtSize.Text); //Need Shirt Size Text Box
            Debug.WriteLine(permission);
            cmd.Parameters.AddWithValue("@UserPermission", permission);
            cmd.Parameters.AddWithValue("@LastLogin", System.DBNull.Value);

            List<String> selectedValues = cblRace.Items.Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(li => li.Value)
                .ToList();
            String races = "";
            foreach (String item in selectedValues)
            {
                races += item + ", ";
            }
            
            if (races.Trim().Equals(""))
            { cmd.Parameters.AddWithValue("@Race", System.DBNull.Value); }
            else
            { cmd.Parameters.AddWithValue("@Race", races); }
            cmd.Parameters.AddWithValue("@CellPhone", txtCell.Text);
            DateTime today = DateTime.Now;
            cmd.Parameters.AddWithValue("@JoinDate", today);
            cmd.Parameters.AddWithValue("@Activated", 1);

            cmd.ExecuteNonQuery();


            if (ddlUserType.Text == "Administrator")
            {
                insertAdmin();
            }
            if (ddlUserType.Text == "Staff")
            {
                insertStaff();
            }
            if (ddlUserType.Text == "Student")
            {
                insertStudent();
            }
            if (ddlUserType.Text == "Parent")
            {
                insertParent();
            }
            if (ddlUserType.Text == "Cipher")
            {
                insertCipher();
            }
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }
        Response.Redirect("Admin.ManageAccounts.aspx");
        MessageBox.Show("User has been added! Please activate their account and set permission");
    }

    private void insertAdmin()
    {
        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Insert Into Administrator(EmailAddress, ManagerEmail, AdminTitle, HireDate) Values (@EmailAddress, @ManagerEmail, @AdminTitle, @HireDate)";

            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.Parameters.AddWithValue("@ManagerEmail", "Mazi@WBL.org");
            query.Parameters.AddWithValue("@AdminTitle", txtAdminTitle.Text);
            query.Parameters.AddWithValue("@HireDate", txtHireDate.Text);
            

            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "update dbo.GeneralUser set ActivatedBool = 1 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "update dbo.GeneralUser set UserPermission = 4 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();


            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }
    }

    private void insertStaff()
    {
        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Insert Into Staff(EmailAddress, AdminEmailAddress, HireDate, StaffType, Specialty) Values (@EmailAddress, @AdminEmailAddress, @HireDate, @StaffType, @Specialty)";

            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.Parameters.AddWithValue("@AdminEmailAddress", "Mazi@WBL.org");
            query.Parameters.AddWithValue("@StaffType", ddlStaffType.Text);
            query.Parameters.AddWithValue("@HireDate", txtHireDate.Text);
            query.Parameters.AddWithValue("@Specialty", txtSpecialty.Text);

            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "update dbo.GeneralUser set ActivatedBool = 1 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "update dbo.GeneralUser set UserPermission = 4 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "insert into Evaluatee (EvaluateeEmail, StaffEmailAddress) values (@EmailAddress, @StaffEmailAddress)";
            query.Parameters.AddWithValue("@EvaluateeEmail", txtEmail.Text);
            query.Parameters.AddWithValue("@StaffEmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "insert into Respondent (RespondentEmail, StaffEmailAddress) values (@RespondentEmail, @StaffEmailAddress)";
            query.Parameters.AddWithValue("@RespondentEmail", txtEmail.Text);
            query.Parameters.AddWithValue("@StaffEmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();

            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }
    }

    private void insertStudent()
    {
        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Insert Into Student(EmailAddress) Values(@EmailAddress)";

            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "update dbo.GeneralUser set ActivatedBool = 1 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "update dbo.GeneralUser set UserPermission = 3 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "insert into Evaluatee (EvaluateeEmail, StudentEmailAddress) values (@EmailAddress, @StudentEmailAddress)";
            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.Parameters.AddWithValue("@StudentEmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "insert into Respondent (RespondentEmail, StudentEmailAddress) values (@RespondentEmail, @StudentEmailAddress)";
            query.Parameters.AddWithValue("@RespondentEmail", txtEmail.Text);
            query.Parameters.AddWithValue("@StudentEmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();


            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }
    }

    private void insertParent()
    {
        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Insert Into Parent(EmailAddress, LetterCount, Relationship) Values(@EmailAddress, @LetterCount, @Relationship)";

            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.Parameters.AddWithValue("@LetterCount", 0);
            query.Parameters.AddWithValue("@Relationship", txtRelation.Text);
            Debug.WriteLine("@Relationship = " + txtRelation.Text);
            
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "update dbo.GeneralUser set ActivatedBool = 1 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "update dbo.GeneralUser set UserPermission = 2 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();

            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }
    }

    private void insertCipher()
    {
        try
        {
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Insert Into Cipher(EmailAddress, BoolPaid) Values(@EmailAddress, @BoolPaid)";

            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.Parameters.AddWithValue("@BoolPaid", 1);
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "update dbo.GeneralUser set ActivatedBool = 1 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();

            query.CommandText = "update dbo.GeneralUser set UserPermission = 1 where EmailAddress = @EmailAddress";
            query.Parameters.AddWithValue("@EmailAddress", txtEmail.Text);
            query.ExecuteNonQuery();


            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }
    }
}