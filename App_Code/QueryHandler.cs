using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;

/// <summary>
/// Summary description for QueryHandler
/// </summary>
public class QueryHandler
{
    public static ArrayList GetStudents(String parentID)
    {
        ArrayList studs = new ArrayList();

        try
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand query = new SqlCommand();

            sc.ConnectionString = @"Server = DESKTOP-QEKTMG0\LOCALHOST; Database = WBLDB; Trusted_Connection = Yes;";
            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select FirstName, LastName, EmailAddress " + 
                "FROM GeneralUser " +
                "Where EmailAddress = (" + 
                "Select StudentEmailAddress from ParentStudent Where ParentEmailAddress = @ParentEmailAddress)";

            query.Parameters.AddWithValue("@ParentEmailAddress", parentID);
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + parentID);
            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
                studs.Add(read.GetString(2));
                studs.Add(read.GetString(0));
                studs.Add(read.GetString(1));
            
            }
            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }

        return studs;
    }
    
    
    public static ArrayList GetProfessors(String studentID)
    {
        ArrayList studs = new ArrayList();

        try
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand query = new SqlCommand();

            sc.ConnectionString = @"Server = DESKTOP-QEKTMG0\LOCALHOST; Database = WBLDB; Trusted_Connection = Yes;";
            sc.Open();

            query.Connection = sc;
            query.CommandText = "Select EmailAddress, FirstName, LastName From GeneralUser Where" +
                " EmailAddress = (Select EmailAddress From CourseStaff Where CourseID = (Select CourseID " +
                "From Course Where CourseID = (Select CourseID From Attendance Where " +
                "EmailAddress = @EmailAddress )))";

            query.Parameters.AddWithValue("@EmailAddress", studentID);
            Debug.WriteLine(query.CommandText);
            Debug.WriteLine("Where @EmailAddress = " + studentID);
            SqlDataReader read = query.ExecuteReader();

            while (read.Read())
            {
                studs.Add(read.GetString(2));
                studs.Add(read.GetString(0));
                studs.Add(read.GetString(1));

            }
            sc.Close();
        }
        catch (SqlException SQLe)
        {
            System.Diagnostics.Debug.Write(SQLe.ToString());
        }

        return studs;
    }
    public static DropDownList PopDropDown(ArrayList info)
    {
        DropDownList ddl = new DropDownList();
        int count = 0;
        int size = (info.Count + 1) / 3;
        for (int i = 0; i < size; i += 3)
        {
            String name = (String)info[i + 1] + " " + (String)info[i + 2];
            ddl.Items.Insert(count, new ListItem(name, (String)info[i]));
            count++;
        }
        
        return ddl;
    }
}