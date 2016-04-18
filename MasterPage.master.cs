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


public partial class MasterPage : System.Web.UI.MasterPage
{
    private bool announce = false;
    private bool user = false;
    private bool events = false;
    private bool content = false;
    private bool forum = false;

    string eventName = "";
    string eventLoc = "";
    DateTime eventDate;
    int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {


        GetEventData();

       

       Response.Cache.SetNoStore();

        String userType = GetUserType();
        switch (userType)
        {
            case "Administrator":
                LoadAdminNotifications();
                break;
            case "Staff":
                LoadInstructorNotifications();
                break;
            case "Student":
                LoadStudentNotifications();
                break;
            case "Cipher":
                LoadCipherNotifications();
                break;
            case "Parent":
                LoadParentNotifications();
                break;
        }

    }

    //protected void btnLogOut_Click(object sender, EventArgs e)
    //{
    //    //FormsAuthentication.SignOut();
    //    System.Diagnostics.Debug.WriteLine("log out pressed");
    //    Session.Abandon();
    //    Session.Clear();
    //    Response.Redirect("Log-In.aspx");
    //}


    /*
     * Gets user type 
     */
    protected String GetUserType()
    {
        String user = "";

        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select UserType From GeneralUser where EmailAddress=  '" + (String)Session["UserID"] + "'";// Gathers all notifications for specific user
            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
                user = read.GetString(0);
            }
            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }

        return user;
    }

    #region Admin Notifications
    /*
     * Method Dynamically Loads Drop Down of Unread Admin Notifications for User
     * 
     */
    protected void LoadAdminNotifications()
    {
        announce = false;
        user = false;
        events = false;
        content = false;
        forum = false;
        
        ArrayList result = new ArrayList();
        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select NotificationID, NotificationType, NotificationDate, BriefDescription " +
                "From Notifications where EmailAddress=  '" + (String)Session["UserID"] + "' Order By NotificationDate";// Gathers all notifications for specific user
            SqlDataReader read = query.ExecuteReader();


            int count = 0;
            bool hasNotifs = false;

            if (read.HasRows)
            {
                hasNotifs = true;
            }

            while (read.Read())
            {
                result.Add(read.GetInt32(0));
                result.Add(read.GetString(1));
                result.Add(read.GetDateTime(2));
                result.Add(read.GetString(3));

                count++;
            }

            if(hasNotifs)
            {
                redIcon.Attributes["style"] = "color:red;";
                redText.Attributes["style"] = "color:red;";
                numNotif.Attributes["style"] = "color:red;";
                numNotif.InnerText = count.ToString();
            }

            sc.Close();

            for (int i = 0; i < result.Count; i += 4) //Find what types of Notifications User has
            {
                String type = result[i + 1].ToString();
                if (type.Equals("Announcement"))
                {
                    announce = true;
                }
                else if (type.Equals("User"))
                {
                    user = true;
                }
                else if (type.Equals("Event"))
                {
                    events = true;
                }
                else if (type.Equals("Content"))
                {
                    content = true;
                }
            }

            HtmlGenericControl li;
            HtmlGenericControl anchor;
            HtmlGenericControl icon;

            if (announce) //Populate Announcment Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                anchor = new HtmlGenericControl("a");

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-bullhorn";
                icon.InnerText = "Announcements";
                li.Controls.Add(icon);



                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Announcement"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }
            
            if (user) //Populate User Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                anchor = new HtmlGenericControl("a");

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-users";
                icon.InnerText = "Users";
                li.Controls.Add(icon);



                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("User"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }

            if (events) //Populate Event Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-calendar";
                li.Controls.Add(icon);

                icon.InnerText = "Events";

                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Event"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }


            if (content)//Populate Content Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-file-text-o";
                icon.InnerText = "Content";
                li.Controls.Add(icon);



                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Content"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }

    }

    #endregion

    #region Instructor Notifications

    protected void LoadInstructorNotifications()
    {
        announce = false;
        events = false;
        content = false;
        forum = false;

        ArrayList result = new ArrayList();
        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select NotificationID, NotificationType, NotificationDate, BriefDescription " +
                "From Notifications where EmailAddress=  '" + (String)Session["UserID"] + "' Order By NotificationDate";// Gathers all notifications for specific user
            SqlDataReader read = query.ExecuteReader();

            int count = 0;
            bool hasNotifs = false;

            if (read.HasRows)
            {
                hasNotifs = true;
            }

            while (read.Read())
            {
                result.Add(read.GetInt32(0));
                result.Add(read.GetString(1));
                result.Add(read.GetDateTime(2));
                result.Add(read.GetString(3));

                count++;
            }

            if (hasNotifs)
            {
                redIcon.Attributes["style"] = "color:red;";
                redText.Attributes["style"] = "color:red;";
                numNotif.Attributes["style"] = "color:red;";
                numNotif.InnerText = count.ToString();
            }

            sc.Close();

            for (int i = 0; i < result.Count; i += 4) //Find what types of Notifications User has
            {
                String type = result[i + 1].ToString();
                if (type.Equals("Announcement"))
                {
                    announce = true;
                }
                else if (type.Equals("Event"))
                {
                    events = true;
                }
                else if (type.Equals("Content"))
                {
                    content = true;
                }
            }

            HtmlGenericControl li;
            HtmlGenericControl anchor;
            HtmlGenericControl icon;

            if (announce) //Populate Announcment Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                anchor = new HtmlGenericControl("a");

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-bullhorn";
                icon.InnerText = "Announcements";
                li.Controls.Add(icon);



                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Announcement"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }

            if (events) //Populate Event Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-calendar";
                li.Controls.Add(icon);

                icon.InnerText = "Events";

                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Event"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }


            if (content)//Populate Content Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-file-text-o";
                icon.InnerText = "Content";
                li.Controls.Add(icon);



                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Content"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }

        /*<li><i class="fa fa-comments"></i>Forum</li>
            <li class="ui-branch"><p>Flagged: </p>Post Title</li>*/

    }


    #endregion

    #region Student Notifications

    protected void LoadStudentNotifications()
    {
        announce = false;
        events = false;
        content = false;
        forum = false;
        
        ArrayList result = new ArrayList();
        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select NotificationID, NotificationType, NotificationDate, BriefDescription " +
                "From Notifications where EmailAddress=  '" + (String)Session["UserID"] + "' Order By NotificationDate";// Gathers all notifications for specific user
            SqlDataReader read = query.ExecuteReader();

            int count = 0;
            bool hasNotifs = false;

            if (read.HasRows)
            {
                hasNotifs = true;
            }

            while (read.Read())
            {
                result.Add(read.GetInt32(0));
                result.Add(read.GetString(1));
                result.Add(read.GetDateTime(2));
                result.Add(read.GetString(3));

                count++;
            }

            if (hasNotifs)
            {
                redIcon.Attributes["style"] = "color:red;";
                redText.Attributes["style"] = "color:red;";
                numNotif.Attributes["style"] = "color:red;";
                numNotif.InnerText = count.ToString();
            }

            sc.Close();

            for (int i = 0; i < result.Count; i += 4) //Find what types of Notifications User has
            {
                String type = result[i + 1].ToString();
                if (type.Equals("Announcement"))
                {
                    announce = true;
                }
                else if (type.Equals("Event"))
                {
                    events = true;
                }
                else if (type.Equals("Content"))
                {
                    content = true;
                }
            }

            HtmlGenericControl li;
            HtmlGenericControl anchor;
            HtmlGenericControl icon;

            if (announce) //Populate Announcment Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                anchor = new HtmlGenericControl("a");

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-bullhorn";
                icon.InnerText = "Announcements";
                li.Controls.Add(icon);



                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Announcement"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString() +
                            "&NotificationType=" + result[i + 1].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }

            if (events) //Populate Event Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-calendar";
                li.Controls.Add(icon);

                icon.InnerText = "Events";

                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Event"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }


            if (content)//Populate Content Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-file-text-o";
                icon.InnerText = "Content";
                li.Controls.Add(icon);



                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Content"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }

        /*<li><i class="fa fa-comments"></i>Forum</li>
            <li class="ui-branch"><p>Flagged: </p>Post Title</li>*/

    }

    #endregion

    #region Cipher Notifications

    protected void LoadCipherNotifications()
    {
        announce = false;
        events = false;
        forum = false;
        
        ArrayList result = new ArrayList();
        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select NotificationID, NotificationType, NotificationDate, BriefDescription " +
                "From Notifications where EmailAddress=  '" + (String)Session["UserID"] + "' Order By NotificationDate";// Gathers all notifications for specific user
            SqlDataReader read = query.ExecuteReader();

            int count = 0;
            bool hasNotifs = false;

            if (read.HasRows)
            {
                hasNotifs = true;
            }

            while (read.Read())
            {
                result.Add(read.GetInt32(0));
                result.Add(read.GetString(1));
                result.Add(read.GetDateTime(2));
                result.Add(read.GetString(3));

                count++;
            }

            if (hasNotifs)
            {
                redIcon.Attributes["style"] = "color:red;";
                redText.Attributes["style"] = "color:red;";
                numNotif.Attributes["style"] = "color:red;";
                numNotif.InnerText = count.ToString();
            }

            sc.Close();

            for (int i = 0; i < result.Count; i += 4) //Find what types of Notifications User has
            {
                String type = result[i + 1].ToString();
                if (type.Equals("Announcement"))
                {
                    announce = true;
                }
                else if (type.Equals("Event"))
                {
                    events = true;
                }
            }

            HtmlGenericControl li;
            HtmlGenericControl anchor;
            HtmlGenericControl icon;

            if (announce) //Populate Announcment Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                anchor = new HtmlGenericControl("a");

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-bullhorn";
                icon.InnerText = "Announcements";
                li.Controls.Add(icon);



                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Announcement"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString() +
                            "&NotificationType=" + result[i + 1].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }

            if (events) //Populate Event Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-calendar";
                li.Controls.Add(icon);

                icon.InnerText = "Events";

                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Event"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }

        /*<li><i class="fa fa-comments"></i>Forum</li>
            <li class="ui-branch"><p>Flagged: </p>Post Title</li>*/

    }

    #endregion

    #region Parent Notifications

    protected void LoadParentNotifications()
    {
        announce = false;
        
        ArrayList result = new ArrayList();
        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select NotificationID, NotificationType, NotificationDate, BriefDescription " +
                "From Notifications where EmailAddress=  '" + (String)Session["UserID"] + "' Order By NotificationDate";// Gathers all notifications for specific user
            SqlDataReader read = query.ExecuteReader();

            int count = 0;
            bool hasNotifs = false;

            if (read.HasRows)
            {
                hasNotifs = true;
            }

            while (read.Read())
            {
                result.Add(read.GetInt32(0));
                result.Add(read.GetString(1));
                result.Add(read.GetDateTime(2));
                result.Add(read.GetString(3));

                count++;
            }

            if (hasNotifs)
            {
                redIcon.Attributes["style"] = "color:red;";
                redText.Attributes["style"] = "color:red;";
                numNotif.Attributes["style"] = "color:red;";
                numNotif.InnerText = count.ToString();
            }

            sc.Close();

            for (int i = 0; i < result.Count; i += 4) //Find what types of Notifications User has
            {
                String type = result[i + 1].ToString();
                if (type.Equals("Announcement"))
                {
                    announce = true;
                }
            }

            HtmlGenericControl li;
            HtmlGenericControl anchor;
            HtmlGenericControl icon;

            if (announce) //Populate Announcment Notifications
            {
                li = new HtmlGenericControl("li");
                notif.Controls.Add(li);

                anchor = new HtmlGenericControl("a");

                icon = new HtmlGenericControl("i"); //adds user icon to list
                icon.Attributes["class"] = "fa fa-bullhorn";
                icon.InnerText = "Announcements";
                li.Controls.Add(icon);



                for (int i = 0; i < result.Count; i += 4)
                {
                    if (result[i + 1].ToString().Equals("Announcement"))
                    {
                        li = new HtmlGenericControl("li");
                        anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", "Notifications.aspx?NotificationID=" + result[i].ToString() +
                            "&NotificationType=" + result[i + 1].ToString());
                        anchor.InnerText = "New: " + result[i + 3].ToString();
                        li.Controls.Add(anchor);
                        notif.Controls.Add(li);
                    }
                }
            }
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }

        /*<li><i class="fa fa-comments"></i>Forum</li>
            <li class="ui-branch"><p>Flagged: </p>Post Title</li>*/

        /*
         * Give a unique experience for each type of user
         * Students upload profile pictures and shit
         * Make design flashy as possible 
         * More color
         * 
         *
         * 
         */
    }

    #endregion

    private void GetEventData()
    {
        try
        {

            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString); // connection string is in web config
            SqlCommand query = new SqlCommand();

            sc.Open();

            //Debug.WriteLine(Request.QueryString["NotificationID"]);
            query.Connection = sc;
            query.CommandText = "select EventName, EventLocation, EventDateTime from wblevent where EventDateTime > GetDate() order by EventDateTime ASC";// Gathers all notifications for specific user
            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
               // Debug.WriteLine(read.GetString(0));

                eventName = read.GetString(0);
                eventLoc = read.GetString(1);
                eventDate = read.GetDateTime(2);

                StandardDisplay();
                i++;
            }
            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());

        }
    }


    protected void StandardDisplay()
    {
        Debug.WriteLine(eventName);
        Debug.WriteLine(eventLoc);
        Debug.WriteLine(eventDate.ToString());

        if (i == 0)
        {
            event1.InnerText = eventName + '\n' + eventLoc + '\n' + eventDate.ToString();
        }
        else if (i == 1)
            event2.InnerText = eventName + '\n' + eventLoc + '\n' + eventDate.ToString();
        else if (i == 2)
        {
            event3.InnerText = eventName + '\n' + eventLoc + '\n' + eventDate.ToString();
            i = 0;
        }
    }

}
