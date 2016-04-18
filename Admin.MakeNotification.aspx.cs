using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

public partial class Admin_MakeNotification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtText.Style.Add("margin", "0px 0px 0px 24px");
        txtHeader.Style.Add("width", "500px");
        txtText.Style.Add("width", "500px");
        txtText.Style.Add("height", "300px");
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        ArrayList users = new ArrayList();
        DateTime date = DateTime.Now;
        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            
            
            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select EmailAddress From " + ddlUser.SelectedValue.ToString();// Gathers all users of specific type
            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
                users.Add(read.GetString(0));
                Debug.WriteLine(read.GetString(0));
            }
            read.Close();

            for (int i = 0; i < users.Count; i++)
            {
                query.CommandText = "Insert into Notifications(EmailAddress, NotificationType, NotificationDate, NotificationText, BriefDescription)" +
                    " Values(@EmailAddress, @Announcement, @Date, @Text, @Brief)";
                query.Parameters.AddWithValue("@EmailAddress", users[i]);
                query.Parameters.AddWithValue("@Announcement", "Announcement");
                query.Parameters.AddWithValue("@Date", date);
                query.Parameters.AddWithValue("@Text", txtText.Text);
                query.Parameters.AddWithValue("@Brief", txtHeader.Text);

                query.ExecuteNonQuery();
            }

            sc.Close();

        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }

        // Clear fields
        ddlUser.SelectedIndex = 0;
        txtHeader.Text = "";
        txtText.Text = "";


    }
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        ArrayList users = new ArrayList();
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now.AddDays(14);
        ArrayList events = new ArrayList();

        Debug.WriteLine(DateTime.Now);
        Debug.WriteLine(DateTime.Now.AddDays(14));
        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();



            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select EmailAddress From " + ddlUser.SelectedValue.ToString();// Gathers all users of specific type
            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
                users.Add(read.GetString(0));
            }

            query.CommandText = "select * from WBLEvent where  EventDateTime between '" +
                startDate + "' and '" + endDate + "' Order by EventType;";

            read = query.ExecuteReader();
            

            sc.Close();

        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }
    }
}