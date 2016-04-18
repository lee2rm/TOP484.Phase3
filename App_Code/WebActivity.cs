using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using Twilio;

/// <summary>
/// Summary description for Activity
/// </summary>
public class WebActivity
{
    public static void LogActivity(string activity, bool recordPageUrl)
    {


        //string currentUser = (string)System.Web.HttpContext.Current.Session["userID"];
        //string userType = (string)System.Web.HttpContext.Current.Session["userType"];
        string currentUser = HttpContext.Current.Session["UserID"].ToString();
        //string userType = "Administrator";
        // Get information about the currently logged on user

        if (currentUser != null)
        {

            // Log the activity in the database
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "dbo.LogUserActivity";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@UserId", currentUser);
                cmd.Parameters.AddWithValue("@Activity", activity);
                if (recordPageUrl)
                {
                    cmd.Parameters.AddWithValue("@PageUrl", System.Web.HttpContext.Current.Request.RawUrl);
                }

                else
                {
                    cmd.Parameters.AddWithValue("@PageUrl", DBNull.Value);
                }
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
    //Method for sending text message to users
    public static void sendText(string message)
    {
        string AccountSid = "AC9096edb734a78078ee28b5bd13273756";
        string AuthToken = "6b1a0e00aa260ba6f3bd8b483aed30a9";
        Twilio.TwilioRestClient client = new Twilio.TwilioRestClient(AccountSid, AuthToken);


        
        // ACCOUNT_SID and ACCOUNT_TOKEN are from your Twilio account
        var result = client.SendMessage("+12403033815", "+17039739495", message);
        if (result.RestException != null)
        {
            Debug.WriteLine(result.RestException.Message);
        }
    }
}

