using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Parent_ViewStudentContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebActivity.LogActivity("Parent Viewed Student Content", true);
    }
}