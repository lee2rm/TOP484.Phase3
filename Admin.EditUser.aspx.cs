using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditUser : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            populateUserInfo();
        }
    }

    public void populateUserInfo()
    {
        string userID = Session["emailAddress"].ToString();

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select FirstName, LastName, EmailAddress, CellPhone, HomePhone, DOB, ShirtSize, Gender, Race, HomeAddress, City, State, Zip from dbo.GeneralUser where EmailAddress='" + userID + "'";
        System.Diagnostics.Debug.WriteLine(cmdText);
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        DataTable dt = new DataTable(); // create data table for sql query
        adp.Fill(dt);
        txtfName.Text = dt.Rows[0][0].ToString();
        txtlName.Text = dt.Rows[0][1].ToString();
        txtEmail.Text = dt.Rows[0][2].ToString();
        txtEmail.ReadOnly = true; // Set to un-editable since this will violate FK, Admin shouldnt be able to change this anyways?

        txtCellPhone.Text = dt.Rows[0][3].ToString();
        txtHomePhone.Text = dt.Rows[0][4].ToString();
        txtDOB.Text = dt.Rows[0][5].ToString();
        txtShirt.Text = dt.Rows[0][6].ToString();
        txtGender.Text = dt.Rows[0][7].ToString();
        txtRace.Text = dt.Rows[0][8].ToString();
        txtHomeAddress.Text = dt.Rows[0][9].ToString();
        txtCity.Text = dt.Rows[0][10].ToString();
        txtState.Text = dt.Rows[0][11].ToString();
        txtZip.Text = dt.Rows[0][12].ToString();

    }
    protected void btnEditUser_Click(object sender, EventArgs e)
    {
        ViewState["fName"] = txtfName.Text;
        ViewState["lName"] = txtlName.Text;

        string email = Session["emailAddress"].ToString();
        //String email = "testAdmin@WBL.org";
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "update dbo.GeneralUser set FirstName = @FirstName, LastName = @LastName, CellPhone = @CellPhone, HomePhone = @HomePhone, DOB = @DOB, ShirtSize = @ShirtSize, Gender = @Gender, Race = @Race, HomeAddress = @HomeAddress, City = @City, State = @State, Zip = @Zip where EmailAddress = @EmailAddress";
        System.Diagnostics.Debug.WriteLine(cmdText);
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@FirstName", ViewState["fName"]);
        cmd.Parameters.AddWithValue("@LastName", ViewState["lName"]);
        cmd.Parameters.AddWithValue("@EmailAddress", email);
        cmd.Parameters.AddWithValue("@CellPhone", txtCellPhone.Text);
        cmd.Parameters.AddWithValue("@HomePhone", txtHomePhone.Text);
        cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
        cmd.Parameters.AddWithValue("@ShirtSize", txtShirt.Text);
        cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
        cmd.Parameters.AddWithValue("@Race", txtRace.Text);
        cmd.Parameters.AddWithValue("@HomeAddress", txtHomeAddress.Text);
        cmd.Parameters.AddWithValue("@City", txtCity.Text);
        cmd.Parameters.AddWithValue("@State", txtState.Text);
        cmd.Parameters.AddWithValue("@Zip", txtZip.Text);

        cmd.ExecuteNonQuery();
        Response.Redirect("Admin.ManageAccounts.aspx", false);
    }
}