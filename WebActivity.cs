using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for Activity
/// </summary>
public class WebActivity
{
	  public static void LogActivity(string activity, bool recordPageUrl)
      {

            
            //string currentUser = (string)System.Web.HttpContext.Current.Session["userID"];
            //string userType = (string)System.Web.HttpContext.Current.Session["userType"];
          string currentUser = "Lee@WBL.org";
          string userType = "Administrator";
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

        }

                