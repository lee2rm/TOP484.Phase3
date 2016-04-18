using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageContent : System.Web.UI.Page
{

    // TODO: Switch the table to sub categories, most important at the top (portfolios, lesson plans, evaluations)
    // TODO: direct to a yes / no approval page where file downloads for review
    // TODO: figure out how to delete an item
    // TODO: Turn file name column into clickable links that downloads file
    // Need a better way to search through and find content
    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateTable();
    }

    private void GenerateTable()
    {
        DataTable dt = CreateDataTable();
        ViewState["excelDataTable"] = (DataTable)dt;
        Table table = new Table();
        GridView grid = new GridView();
        TableRow row = null;
        table.CellSpacing = 20;
        table.CellPadding = 10;
        table.GridLines = GridLines.Vertical;


        // Add row for the Table Headers        
        row = new TableRow();
        for (int j = 0; j < dt.Columns.Count; j++)
        {
            if (dt.Columns[j].ColumnName == "StudentEmailAddress")
            {
                TableHeaderCell owner = new TableHeaderCell();
                owner.Text = "Owner Email Address";
                row.Cells.Add(owner);
            }
            if (dt.Columns[j].ColumnName == "ContentLink")
            {
                TableHeaderCell fileName = new TableHeaderCell();
                fileName.Text = "File Name";
                row.Cells.Add(fileName);
            }
            if (dt.Columns[j].ColumnName == "ContentType")
            {
                TableHeaderCell fileType = new TableHeaderCell();
                fileType.Text = "File Type";
                row.Cells.Add(fileType);
            }
            if (dt.Columns[j].ColumnName == "ApprovedBool")
            {
                TableHeaderCell approval = new TableHeaderCell();
                approval.Text = "Approval Status";
                row.Cells.Add(approval);
            }
        }

        TableHeaderCell deleteContent = new TableHeaderCell();
        deleteContent.Text = "Delete Content Below";
        row.Cells.Add(deleteContent);

        table.Rows.Add(row);


        //Add each row in the DataTable to the ASP table
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            row = new TableRow();
            // add the column for each row
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                System.Diagnostics.Debug.WriteLine(dt.Columns[j].ColumnName);
                if (dt.Columns[j].ColumnName == "StudentEmailAddress")
                {
                    TableCell cell = new TableCell();
                    LinkButton link = new LinkButton();
                    link.Text = dt.Rows[i][j].ToString();
                    link.Click += email_Click; // assign event action, link_click method below
                    link.CommandArgument = dt.Rows[i][j].ToString(); // Assign the e-mail address of this row to the arguments passed when the linkbutton is clicked
                    cell.Controls.Add(link);
                    row.Cells.Add(cell);
                }
      
                //System.Diagnostics.Debug.WriteLine(dt.Columns[j].ColumnName);
                if (dt.Columns[j].ColumnName == "ContentLink")
                {
                    TableCell textCell = new TableCell();
                    //System.Diagnostics.Debug.WriteLine(dt.Rows[i][j].ToString());
                    textCell.Text = dt.Rows[i][j].ToString();
                    row.Cells.Add(textCell);
                }
                if (dt.Columns[j].ColumnName == "ContentType")
                {
                    TableCell memberCell = new TableCell();
                    memberCell.Text = dt.Rows[i][j].ToString();
                    row.Cells.Add(memberCell);
                }
                if (dt.Columns[j].ColumnName == "ApprovedBool")
                {
                    if (dt.Rows[i][j].ToString() == "False")
                    {
                        LinkButton link = new LinkButton();
                        link.Text = "Needs Approval";
                        link.Click += approval_Click;
                        link.CommandArgument = dt.Rows[i][0].ToString(); // Assign the e-mail address of this row to the arguments passed when the linkbutton is clicked

                        TableCell submission = new TableCell();
                        submission.Text = dt.Rows[i][j].ToString();
                        submission.Controls.Add(link);

                        row.Cells.Add(submission);
                    }
                    else
                    {
                        DataTable dt2 = new DataTable();
                        // Second data table to indicate date and time approved once Admin clicks through approval
                        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
                        connection.Open();
                        string cmdText = "select PortfolioID, StudentEmailAddress, DateApproved from dbo.Portfolio"; //need to figure out how to show all general users with matching applicant ID's where applicable
                        // How can we replaced "Approved on 'approvalDate'" with black space if theres no matching value in applicant table?
                        SqlCommand cmd = new SqlCommand(cmdText, connection);
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
                        adp.Fill(dt2);
                        string approvalDate = dt2.Rows[i][2].ToString(); // this needs to change so not all approved row values show up, only those who were actually approved
                        TableCell approved = new TableCell();
                        approved.Text = "Approved on " + approvalDate;
                        row.Cells.Add(approved);
                    }
                }

            
        
            
            
            // Populate 1st non-DB column for linking cell to edit user page

            // Add the TableRow to the Table
            
            }
            TableCell deleteCell = new TableCell();
            LinkButton deleteLink = new LinkButton();
            deleteLink.Text = "Delete Item";
            deleteLink.CommandArgument = dt.Rows[i][3].ToString();
            System.Diagnostics.Debug.WriteLine(dt.Rows[i][3].ToString());
            //deleteLink.Click += deleteLink_Click;
            deleteCell.Controls.Add(deleteLink);
            row.Cells.Add(deleteCell);

            table.Rows.Add(row);
        }
        
        form1.Controls.Add(table);
    
    }


    private void approval_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        string pID = btn.CommandArgument;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "update dbo.Portfolio set ApprovedBool='1' where PortfolioID=@PortfolioID";
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.Parameters.AddWithValue("@PortfolioID", pID); 
        cmd.ExecuteNonQuery();
        Response.ContentType = "Application/jpq";
        Response.AppendHeader("Content-Disposition", "attachment; filename=img.jpg");
        Response.TransmitFile(Server.MapPath("~/upload/img.jpg"));
        Response.End(); 
    }

    private void deleteLink_Click(object sender, EventArgs e)
    {
        // Verify that a user wants to delete this item
        // sql statement to delete from portfolio where portfolio ID = @value of deleteLink's command argument
    }

    private void email_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("send email clicked");
        LinkButton btn = (LinkButton)(sender);
        string userID = btn.CommandArgument;
        Session["emailAddress"] = userID;
        System.Diagnostics.Debug.WriteLine(Session["emailAddress"].ToString());
        Response.Redirect("SendEmail.aspx", false);
    }

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();

        if (ddlContentType.SelectedValue.ToString() == "All")
        {
            dt = CreateAllDataTable();
        }
        if (ddlContentType.SelectedValue.ToString() == "Word")
        {
            dt = CreateWordDataTable();
        }
        if (ddlContentType.SelectedValue.ToString() == "PDF")
        {
            dt = CreatePDFDataTable();
        }
        if (ddlContentType.SelectedValue.ToString() == "MP3")
        {
            dt = CreateMP3DataTable();
        }
        if (ddlContentType.SelectedValue.ToString() == "MP4")
        {
            dt = CreateMP4DataTable();
        }
        return dt;
    }

    private DataTable CreateAllDataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Owner")
        {
            sortBy = "ORDER BY StudentEmailAddress";
        }
        if (ddlSortBy.SelectedValue.ToString() == "File Type")
        {
            sortBy = "ORDER BY ContentType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "File Name")
        {
            sortBy = "ORDER BY ContentLink";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Approval Status")
        {
            sortBy = "ORDER BY DateApproved";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "Select PortfolioID, StudentEmailAddress, ContentLink, ContentType, ApprovedBool, DateApproved from dbo.Portfolio " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }
    private DataTable CreateWordDataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Owner")
        {
            sortBy = "ORDER BY StudentEmailAddress";
        }
        if (ddlSortBy.SelectedValue.ToString() == "File Type")
        {
            sortBy = "ORDER BY ContentType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "File Name")
        {
            sortBy = "ORDER BY ContentLink";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Approval Status")
        {
            sortBy = "ORDER BY ApprovalDate";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "Select PortfolioID, StudentEmailAddress, ContentLink, ContentType, ApprovedBool, DateApproved from dbo.Portfolio where ContentType='Word' " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }
    private DataTable CreatePDFDataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Owner")
        {
            sortBy = "ORDER BY StudentEmailAddress";
        }
        if (ddlSortBy.SelectedValue.ToString() == "File Type")
        {
            sortBy = "ORDER BY ContentType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "File Name")
        {
            sortBy = "ORDER BY ContentLink";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Approval Status")
        {
            sortBy = "ORDER BY ApprovalDate";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "Select PortfolioID, StudentEmailAddress, ContentLink, ContentType, ApprovedBool, DateApproved from dbo.Portfolio where ContentType='PDF' " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }
    private DataTable CreateMP3DataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Owner")
        {
            sortBy = "ORDER BY StudentEmailAddress";
        }
        if (ddlSortBy.SelectedValue.ToString() == "File Type")
        {
            sortBy = "ORDER BY ContentType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "File Name")
        {
            sortBy = "ORDER BY ContentLink";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Approval Status")
        {
            sortBy = "ORDER BY ApprovalDate";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "Select PortfolioID, StudentEmailAddress, ContentLink, ContentType, ApprovedBool, DateApproved from dbo.Portfolio where ContentType='MP3' " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }
    private DataTable CreateMP4DataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Owner")
        {
            sortBy = "ORDER BY StudentEmailAddress";
        }
        if (ddlSortBy.SelectedValue.ToString() == "File Type")
        {
            sortBy = "ORDER BY ContentType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "File Name")
        {
            sortBy = "ORDER BY ContentLink";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Approval Status")
        {
            sortBy = "ORDER BY ApprovalDate";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "Select PortfolioID, StudentEmailAddress, ContentLink, ContentType, ApprovedBool, DateApproved from dbo.Portfolio where ContentType='MP4' " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }


    protected void btnAddContent_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.AddContent.aspx");
    }
}
