using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCalendar : System.Web.UI.Page
{

    //TODO: add in email notifications for upcoming events or anything that has been updated that week
    // Weekly email that says what has changed
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            // Get all calendar-worthy data from Event Table
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            connection.Open();
            string cmdText = "select EventName, EventType, EventDateTime from dbo.WBLEvent";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
            adp.Fill(dt);
            ViewState["dt"] = dt;
            Calendar1.Visible = false;

        }
        
        GenerateTable();


    }

    #region Calendar Creation
    // ondayrender for each day (e.cell) as calendar is being constructed
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Cell.Attributes.Add("OnClick", e.SelectUrl);
        if (e.Day.IsToday)
        {
            // Outline today's date cell
            e.Cell.BorderColor = System.Drawing.Color.Black;
            e.Cell.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            e.Cell.BorderStyle = BorderStyle.Solid;
            e.Cell.BorderWidth = 2;
        }

        if (ViewState["dt"] != null)
        {
            // get datatable from page load
            DataTable dt = (DataTable)ViewState["dt"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                // If an EventDate from our datatable is equal to each day's date as its being rendered
                if (Convert.ToDateTime(dt.Rows[i][2]).ToString("dd-MM-yyyy") == e.Day.Date.ToString("dd-MM-yyyy"))
                {
                    // DateTime variable to recognize each day that has an event
                    DateTime thisDay = e.Day.Date;
                    // break line to place text under datecell number
                    Literal ltrl = new Literal();
                    ltrl.Text = "<BR />";
                    e.Cell.Controls.Add(ltrl);

                    // outline the datecell where an event is taking place
                    e.Cell.BorderColor = System.Drawing.Color.Aqua;
                    e.Cell.BackColor = System.Drawing.Color.LightGray;
                    e.Cell.BorderStyle = BorderStyle.Solid;
                    e.Cell.BorderWidth = 2;

                    // Label for going to a specific event to view or edit it
                    Label b = new Label();
                    b.Font.Size = 12;
                    b.Font.Bold = true;
                    b.ForeColor = System.Drawing.Color.MediumVioletRed;
                    b.Text = dt.Rows[i][0].ToString();
                    e.Cell.Controls.Add(b);

                    Literal ltrl2 = new Literal();
                    ltrl2.Text = "<BR/><a style='font-size:8' href='ViewEvent.aspx?EventDateTime=" + thisDay + "'>View Event</a>";    //?ID=" + wblEvent["ID"].ToString() + "'>View Address</a>";
                    // TODO: code the logic for editing the event from the page this links to
                    e.Cell.Controls.Add(ltrl2);
                }

            }
        }
    }
    #endregion

    #region Generate ASP Table dynamically from Database Table
    private void GenerateTable()
    {
        DataTable dt2 = CreateDataTable();
        Session["excelDataTable"] = (DataTable)dt2;

        Table table = new Table();
        GridView grid = new GridView();
        TableRow row = null;
        table.CellSpacing = 20;
        table.CellPadding = 10;
        table.GridLines = GridLines.Vertical;


        //Add the Headers
        row = new TableRow();
        for (int j = 0; j < dt2.Columns.Count; j++)
        {
            if (dt2.Columns[j].ColumnName == "EventName")
            {
                TableHeaderCell eventName = new TableHeaderCell();
                eventName.Text = "Event Name";
                row.Cells.Add(eventName);
            }
            if (dt2.Columns[j].ColumnName == "EventType")
            {
                TableHeaderCell eventType = new TableHeaderCell();
                eventType.Text = "Event Type";
                row.Cells.Add(eventType);
            }
            if (dt2.Columns[j].ColumnName == "EventDescription")
            {
                TableHeaderCell eDesc = new TableHeaderCell();
                eDesc.Text = "Description";
                row.Cells.Add(eDesc);
            }
            if (dt2.Columns[j].ColumnName == "EventDateTime")
            {
                TableHeaderCell eDate = new TableHeaderCell();
                eDate.Text = "Date";
                row.Cells.Add(eDate);
            }
            if (dt2.Columns[j].ColumnName == "EventLocation")
            {
                TableHeaderCell eLocation = new TableHeaderCell();
                eLocation.Text = "Location";
                row.Cells.Add(eLocation);
            }
            if (dt2.Columns[j].ColumnName == "PCEmail")
            {
                TableHeaderCell eLocation = new TableHeaderCell();
                eLocation.Text = "Primary Contact Email";
                row.Cells.Add(eLocation);
            }
            
        }

        TableHeaderCell eEdit = new TableHeaderCell();
        eEdit.Text = "Click to Edit";
        row.Cells.Add(eEdit);

        table.Rows.Add(row);

        //Add each row in the DataTable
        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            row = new TableRow();
            // add the column for each row
            for (int j = 0; j < dt2.Columns.Count; j++)
            {
                System.Diagnostics.Debug.WriteLine(dt2.Columns[j].ColumnName);
                if (dt2.Columns[j].ColumnName == "EventName")
                {
                    TableCell eName = new TableCell();
                    System.Diagnostics.Debug.WriteLine(dt2.Rows[i][j].ToString());
                    eName.Text = dt2.Rows[i][j].ToString();
                    row.Cells.Add(eName);

                }
                if (dt2.Columns[j].ColumnName == "EventType")
                {
                    TableCell eType = new TableCell();
                    eType.Text = dt2.Rows[i][j].ToString();
                    row.Cells.Add(eType);

                }
                if (dt2.Columns[j].ColumnName == "EventDescription")
                {
                    TableCell eDesc = new TableCell();
                    eDesc.Text = dt2.Rows[i][j].ToString();
                    row.Cells.Add(eDesc);
                }
                if (dt2.Columns[j].ColumnName == "EventDateTime")
                {
                    TableCell eDate = new TableCell();
                    eDate.Text = dt2.Rows[i][j].ToString();
                    row.Cells.Add(eDate);
                }
                if (dt2.Columns[j].ColumnName == "EventLocation")
                {
                    TableCell eLocation = new TableCell();
                    eLocation.Text = dt2.Rows[i][j].ToString();
                    row.Cells.Add(eLocation);
                }
                if (dt2.Columns[j].ColumnName == "PCEmail")
                {
                    LinkButton link = new LinkButton();
                    link.Text = dt2.Rows[i][j].ToString();
                    link.Click += sendEmail;
                    link.CommandArgument = dt2.Rows[i][j].ToString(); // Assign the e-mail address of this row to the arguments passed when the linkbutton is clicked

                    TableCell eContact = new TableCell();
                    eContact.Text = dt2.Rows[i][j].ToString();
                    eContact.Controls.Add(link);
                    row.Cells.Add(eContact);
                }
            }
            // Populate 1st non-DB column for linking cell to edit user page
            TableCell editCell = new TableCell();
            LinkButton editLink = new LinkButton();
            editLink.Text = "Edit Event";
            editLink.CommandArgument = dt2.Rows[i][6].ToString();
            System.Diagnostics.Debug.WriteLine(dt2.Rows[i][6].ToString());
            editLink.Click += editLink_Click;
            editCell.Controls.Add(editLink);
            row.Cells.Add(editCell);


            // Add the TableRow to the Table
            table.Rows.Add(row);
        }
        // Add the the Table in the Form
        form1.Controls.Add(table);
    }


    
    #endregion

    #region Generate SQL Server Database Table
    private DataTable CreateDataTable()
    {

        DataTable dt = new DataTable();
        if (ddlMemberType.SelectedValue.ToString() == "All")
        {
            dt = CreateAllDataTable();
        }
        if (ddlMemberType.SelectedValue.ToString() == "Classes")
        {
            dt = CreateClassDataTable();
        }
        if (ddlMemberType.SelectedValue.ToString() == "Fundraisers")
        {
            dt = CreateFundRaiserDataTable();
            
        }
        if (ddlMemberType.SelectedValue.ToString() == "Service Events")
        {
            dt = CreateServiceEventDataTable();
        }
        if (ddlMemberType.SelectedValue.ToString() == "ShowCases")
        {
            dt = CreateShowCaseDataTable();
        }
        if (ddlMemberType.SelectedValue.ToString() == "Jam Sessions")
        {
            dt = CreateJamDataTable();
        }
        if (ddlMemberType.SelectedValue.ToString() == "Other")
        {
            dt = CreateOtherDataTable();
        }

        

        return dt;
    }
    #endregion

    #region DataTable creation depending on dropdown selections
    private DataTable CreateOtherDataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Date (Soonest)")
        {
            sortBy = "ORDER BY EventDateTime";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Name")
        {
            sortBy = "ORDER BY EventName";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Type")
        {
            sortBy = "ORDER BY EventType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Location")
        {
            sortBy = "ORDER BY EventLocation";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select EventName, EventType, EventDescription, EventDateTime, EventLocation, PCEmail, EventID from WBLEvent where EventType='Other' " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }

    private DataTable CreateJamDataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Date (Soonest)")
        {
            sortBy = "ORDER BY EventDateTime";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Name")
        {
            sortBy = "ORDER BY EventName";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Type")
        {
            sortBy = "ORDER BY EventType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Location")
        {
            sortBy = "ORDER BY EventLocation";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select EventName, EventType, EventDescription, EventDateTime, EventLocation, PCEmail, EventID from WBLEvent where EventType='Jam Session' " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }

    private DataTable CreateShowCaseDataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Date (Soonest)")
        {
            sortBy = "ORDER BY EventDateTime";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Name")
        {
            sortBy = "ORDER BY EventName";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Type")
        {
            sortBy = "ORDER BY EventType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Location")
        {
            sortBy = "ORDER BY EventLocation";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select EventName, EventType, EventDescription, EventDateTime, EventLocation, PCEmail, EventID from WBLEvent where EventType='Showcase' " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }

    private DataTable CreateServiceEventDataTable()
    {
        
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Date (Soonest)")
        {
            sortBy = "ORDER BY EventDateTime";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Name")
        {
            sortBy = "ORDER BY EventName";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Type")
        {
            sortBy = "ORDER BY EventType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Location")
        {
            sortBy = "ORDER BY EventLocation";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select EventName, EventType, EventDescription, EventDateTime, EventLocation, PCEmail, EventID from WBLEvent where EventType='Service' " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }

    private DataTable CreateFundRaiserDataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Date (Soonest)")
        {
            sortBy = "ORDER BY EventDateTime";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Name")
        {
            sortBy = "ORDER BY EventName";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Type")
        {
            sortBy = "ORDER BY EventType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Location")
        {
            sortBy = "ORDER BY EventLocation";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select EventName, EventType, EventDescription, EventDateTime, EventLocation, PCEmail, EventID from WBLEvent where EventType='Fundraiser' " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }

    private DataTable CreateClassDataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Date (Soonest)")
        {
            sortBy = "ORDER BY EventDateTime";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Name")
        {
            sortBy = "ORDER BY EventName";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Type")
        {
            sortBy = "ORDER BY EventType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Location")
        {
            sortBy = "ORDER BY EventLocation";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select EventName, EventType, EventDescription, EventDateTime, EventLocation, PCEmail, EventID from WBLEvent where EventType='Class' " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }

    private DataTable CreateAllDataTable()
    {
        string sortBy = "";
        if (ddlSortBy.SelectedValue.ToString() == "Date (Soonest)")
        {
            sortBy = "ORDER BY EventDateTime";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Name")
        {
            sortBy = "ORDER BY EventName";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Type")
        {
            sortBy = "ORDER BY EventType";
        }
        if (ddlSortBy.SelectedValue.ToString() == "Location")
        {
            sortBy = "ORDER BY EventLocation";
        }
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        connection.Open();
        string cmdText = "select EventName, EventType, EventDescription, EventDateTime, EventLocation, PCEmail, EventID from WBLEvent " + sortBy;
        SqlCommand cmd = new SqlCommand(cmdText, connection);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd); // read in data from query results
        adp.Fill(dt);
        return dt;
    }
    #endregion

    #region Event Handlers for buttons
    
    protected void btnAddEvent_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.AddEvent.aspx");
    }
    
    protected void btnViewCalendar_Click(object sender, EventArgs e)
    {
        //button for listview not used yet
        Calendar1.Visible = true;
    }
    
    protected void btnCalView_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewCalendar.aspx");
    }
    
    protected void btnViewList_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = false;
    }
    
    protected void btnExport_Click(object sender, EventArgs e)
    {
        SendToExcel((DataTable)ViewState["excelDataTable"]);
    }
    
    public void SendToExcel(DataTable dtdata)
    {
        string attach = "attachment;filename=WBLDataTable.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attach);
        Response.ContentType = "application/ms-excel";
        if (dtdata != null)
        {
            foreach (DataColumn dc in dtdata.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            foreach (DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
    
    private void editLink_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("edit event clicked");
        LinkButton btn = (LinkButton)(sender);
        string eventID = btn.CommandArgument;
        Session["eventID"] = eventID;
        System.Diagnostics.Debug.WriteLine(Session["eventID"].ToString());
        Response.Redirect("Admin.EditEvent.aspx?EventID=" + Session["eventID"].ToString(), false);
    }
    
    private void sendEmail(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("send email clicked");
        LinkButton btn = (LinkButton)(sender);
        string contactID = btn.CommandArgument;
        Session["emailAddress"] = contactID;
        System.Diagnostics.Debug.WriteLine(Session["emailAddress"].ToString());
        Response.Redirect("SendEmail.aspx", false);
    }
    
    #endregion
}