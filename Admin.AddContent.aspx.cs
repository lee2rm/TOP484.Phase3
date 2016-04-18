using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Admin_AddContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fuAdminAddContent.HasFile)
        {
            string filename = System.IO.Path.GetFileName(fuAdminAddContent.FileName);
            //fuAdminAddContent.SaveAs("~/download/" + filename); // used this filepath to save on my desktop
            int lastSlash = filename.LastIndexOf("\\");
            string trailingPath = filename.Substring(lastSlash + 1);
            string fullPath = Server.MapPath(" ") + "\\" + trailingPath;
            fuAdminAddContent.PostedFile.SaveAs(fullPath);
            
            /*Uploaded file path*/
            /*******************************************/
            /*Code to save the file path into data base??*/
            /*******************************************/
            MessageBox.Show("File upload successful!");
            // need to tie the file uploaded to the selected student's folder
            // need to add event handler for publishing file to community wall if user selects check box
        }
        else
        {
            Response.Write("Error: Please select a file");
        }
    }
}