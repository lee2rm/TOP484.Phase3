using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewEvent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
                // Set fields un-editable if user is not an admin
                txtEventName.ReadOnly = true;
                ddlElement.Enabled = false;
                txtDescription.ReadOnly = true;
                txtDate.ReadOnly = true;
                txtLocation.ReadOnly = true;
                txtPCName.ReadOnly = true;
                txtPCPhone.ReadOnly = true;
                txtPCEmail.ReadOnly = true;
                break;
            case 2:
                // display parent menu
                adminPanel1.Style["display"] = "none";

                cipherPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";
                // Set fields un-editable if user is not an admin
                txtEventName.ReadOnly = true;
                ddlElement.Enabled = false;
                txtDescription.ReadOnly = true;
                txtDate.ReadOnly = true;
                txtLocation.ReadOnly = true;
                txtPCName.ReadOnly = true;
                txtPCPhone.ReadOnly = true;
                txtPCEmail.ReadOnly = true;

                break;
            case 3:
                // display student menu
                adminPanel1.Style["display"] = "none";

                cipherPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";
                // Set fields un-editable if user is not an admin
                txtEventName.ReadOnly = true;
                ddlElement.Enabled = false;
                txtDescription.ReadOnly = true;
                txtDate.ReadOnly = true;
                txtLocation.ReadOnly = true;
                txtPCName.ReadOnly = true;
                txtPCPhone.ReadOnly = true;
                txtPCEmail.ReadOnly = true;


                break;
            case 4:
                // display instructor menu
                adminPanel1.Style["display"] = "none";

                cipherPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";
                // Set fields un-editable if user is not an admin
                txtEventName.ReadOnly = true;
                ddlElement.Enabled = false;
                txtDescription.ReadOnly = true;
                txtDate.ReadOnly = true;
                txtLocation.ReadOnly = true;
                txtPCName.ReadOnly = true;
                txtPCPhone.ReadOnly = true;
                txtPCEmail.ReadOnly = true;


                break;
            case 5:
                // display admin menu
                cipherPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";
                break;
            default:
                // ?? display error?
                break;
        }



        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0) // if there is a query string, meaning if there is a variable in the EventDateTime= link 
            {
                if (Request.QueryString.Keys[0] == "EventDateTime") // if the first value of the query string is EventDateTime
                {
                    string date = Request.QueryString["EventDateTime"].ToString();
                    System.Diagnostics.Debug.WriteLine(date);
                    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
                    connection.Open();
                    string cmdText = "select * from dbo.WBLEvent where EventDateTime='" + date + "'"; // need to figure out how to put multiple parameter in query string from view calendar page
                    //this will not work for a day where there is more than one event, see comment on above line
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
                        txtPCPhone.Text = dt.Rows[0][8].ToString();
                        txtPCEmail.Text = dt.Rows[0][7].ToString();
                    }
                    myIframe.Attributes["src"] = "https://www.google.com/maps/embed/v1/place?key=AIzaSyBZi6ob0guXfcA9OV2j1fKMhKDJIP7upHE&q=" + txtLocation.Text;
                }
            }
        }
    }
}