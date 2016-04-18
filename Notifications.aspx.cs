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

public partial class Notifications : System.Web.UI.Page
{
    String quick;
    String description;
    String type;
    DateTime date;

    protected void Page_Load(object sender, EventArgs e)
    {
        form1.Style.Add("margin", "0px 0px 0px 200px");
        GetNotificationData();
        switch (type)
        {
            case "User":
                //UserDisplay();
                break;
            default:
                StandardDisplay();
                break;
        }
    }

    protected void GetNotificationData()
    {
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString.Keys[0] == "NotificationID")
            {
                try
                {

                    SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
                    SqlCommand query = new SqlCommand();

                    sc.Open();

                    Debug.WriteLine(Request.QueryString["NotificationID"]);
                    query.Connection = sc;
                    query.CommandText = "Select NotificationText, BriefDescription, NotificationDate, NotificationType From Notifications where NotificationID=  " + Request.QueryString[0].ToString();// Gathers all notifications for specific user
                    SqlDataReader read = query.ExecuteReader();

                    while (read.Read())
                    {
                        Debug.WriteLine(read.GetString(0));

                        description = read.GetString(0);
                        quick = read.GetString(1);
                        date = read.GetDateTime(2);
                        type = read.GetString(3);
                    }
                    sc.Close();
                }
                catch (SqlException SQLe)
                {
                    System.Diagnostics.Debug.Write(SQLe.ToString());

                }

            }
        }
    }

    protected void StandardDisplay()
    {
        Debug.WriteLine(quick);
        Debug.WriteLine(description);
        Debug.WriteLine(date.ToString());


        notifHeader.InnerText = quick;
        txtNotif.InnerText = description;
        lblDate.InnerText = date.ToString();
    }
}