using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;

public partial class Parent_EmailInstructor : System.Web.UI.Page
{
    private ArrayList students;
    private ArrayList profs;
    protected void Page_Load(object sender, EventArgs e)
    {
        WebActivity.LogActivity("Parent emailed instructor", true);
        if (!IsPostBack)
        {

            Debug.WriteLine(Session["UserID"].ToString());
            students = QueryHandler.GetStudents(Session["UserID"].ToString());
            PopStudDropDown(students);
            ddlStudent.DataBind();
        }
    }
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        /// send email code
    }
   
    //Try to make dynamic by returning a drop down list
    public void PopStudDropDown(ArrayList info)
    {
        ddlStudent.Items.Clear();
        int count = 1;
        int size = (info.Count) / 3;
        ddlStudent.Items.Insert(0, new ListItem("Please Select"));

        for (int i = 0; i < size; i += 3)
        {
            String name = (String)info[i + 1] + " " + (String)info[i + 2];
            ddlStudent.Items.Insert(count, new ListItem(name, info[i].ToString()));
            count++;
        }
    }

    public void PopProfDropDown(ArrayList info)
    {
        ddlProf.Items.Clear();
        int count = 1;
        int size = (info.Count) / 3;
        ddlProf.Items.Insert(0, new ListItem("Please Select"));

        for (int i = 0; i < size; i += 3)
        {
            String name = (String)info[i + 1] + " " + (String)info[i + 2];
            ddlProf.Items.Insert(count, new ListItem(name, (String)info[i]));
            count++;
        }
    }

    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlStudent.SelectedValue.ToString().Equals("Please Select"))
        {
            Session["studentID"] = ddlStudent.SelectedValue.ToString();
            Console.WriteLine(Session["studentID"].ToString());
            profs = QueryHandler.GetProfessors(Session["studentID"].ToString());
            PopProfDropDown(profs);
        }
    }
    protected void ddlProf_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["profID"] = ddlProf.SelectedValue.ToString();
    }
}
