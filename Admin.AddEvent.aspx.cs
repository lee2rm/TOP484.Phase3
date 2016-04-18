using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddEvent : System.Web.UI.Page
{
    // TO DO: Add in event image and see if last email address column in event table is necessary
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDate_Click(object sender, EventArgs e)
    {
        // Date button to make calendar visible
        cldNewEvent.Visible = true;
    }
    protected void cldNewEvent_SelectionChanged(object sender, EventArgs e)
    {
        // When user changes the calendar date, this method puts their selection in the textbox and hides the calendar
        txtDate.Text = cldNewEvent.SelectedDate.ToString();
        cldNewEvent.Visible = false;
    }
    protected void btnAddEvent_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "INSERT INTO dbo.WBLEvent (EventName, EventType, EventDescription, EventDateTime, EventLocation, PrimaryContact, PCEmail, PCPhone) VALUES (@EventName, @EventType, @EventDescription, @EventDateTime, @EventLocation, @PrimaryContact, @PCEmail, @PCPhone)"; // @EventLocation, @PrimaryContact, @PCEmail, @PCPhone, @EventImage, @SponsorEMail, @EmailAddress)";
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@EventName", txtEventName.Text);
        cmd.Parameters.AddWithValue("@EventType", ddlElement.SelectedValue);
        cmd.Parameters.AddWithValue("@EventDescription", txtDescription.Text);
        cmd.Parameters.AddWithValue("@EventDateTime", txtDate.Text);
        cmd.Parameters.AddWithValue("@EventLocation", txtLocation.Text);
        cmd.Parameters.AddWithValue("@PrimaryContact", txtPCName.Text);
        cmd.Parameters.AddWithValue("@PCEmail", txtPCEmail.Text);
        cmd.Parameters.AddWithValue("@PCPhone", txtPCPhone.Text);

        // need event image
        // Need to figure out how to store event photo
        cmd.ExecuteNonQuery();
        Response.Redirect("Admin.ManageEvents.aspx");

                        
    }
}