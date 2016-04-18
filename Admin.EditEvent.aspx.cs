

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditEvent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0) // if there is a query string, meaning if there is a variable in the EventDateTime= link 
            {
                if (Request.QueryString.Keys[0] == "EventID") // if the first value of the query string is EventDateTime
                {
                    string id = Request.QueryString["EventID"].ToString();
                    System.Diagnostics.Debug.WriteLine(id);
                    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
                    connection.Open();
                    string cmdText = "select * from dbo.WBLEvent where EventID='" + id + "'"; 
                    SqlCommand cmd = new SqlCommand(cmdText, connection);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
                    DataTable dt = new DataTable(); // create data table for sql query
                    adp.Fill(dt);
                    // For loop to populate textboxes from event(s)
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        txtEventName.Text = dt.Rows[0][1].ToString();
                        ddlElement.SelectedValue = dt.Rows[0][2].ToString();
                        txtDescription.Text = dt.Rows[0][3].ToString();
                        txtDate.Text = dt.Rows[0][4].ToString();
                        txtLocation.Text = dt.Rows[0][5].ToString();
                        txtPCName.Text = dt.Rows[0][6].ToString();
                        txtPCEmail.Text = dt.Rows[0][7].ToString();
                        txtPCPhone.Text = dt.Rows[0][8].ToString();
                        
                    }

                }
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string id = Session["EventID"].ToString();
        string eName = txtEventName.Text;
        string type = ddlElement.SelectedValue;
        string desc = txtDescription.Text;
        DateTime date = Convert.ToDateTime(txtDate.Text);
        string loc = txtLocation.Text;
        string pcName = txtPCName.Text;
        string pcPhone = txtPCPhone.Text;
        string pcEmail = txtPCEmail.Text;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "update dbo.WBLEvent set EventName = @EventName, EventType=@EventType, EventDescription=@EventDescription, EventDateTime=@EventDateTime, EventLocation=@EventLocation, PrimaryContact=@PrimaryContact, PCPhone=@PCPhone, PCEmail=@PCEmail where EventID=@EventID";
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@EventName", eName);
        cmd.Parameters.AddWithValue("@EventType", type);
        cmd.Parameters.AddWithValue("@EventDescription", desc);
        cmd.Parameters.AddWithValue("@EventDateTime", date);
        cmd.Parameters.AddWithValue("@EventLocation", loc);
        cmd.Parameters.AddWithValue("@PrimaryContact", pcName);
        cmd.Parameters.AddWithValue("@PCPhone", pcPhone);
        cmd.Parameters.AddWithValue("@PCEmail", pcEmail);
        cmd.Parameters.AddWithValue("@EventID", id); 

        cmd.ExecuteNonQuery();
        Response.Redirect("Admin.ManageEvents.aspx");

    }
    protected void cldEditEvent_SelectionChanged(object sender, EventArgs e)
    {
        // When user changes the calendar date, this method puts their selection in the textbox and hides the calendar
        txtDate.Text = cldEditEvent.SelectedDate.ToString();
        cldEditEvent.Visible = false;

    }
    protected void btnDate_Click(object sender, EventArgs e)
    {
        cldEditEvent.Visible = true;
    }
}