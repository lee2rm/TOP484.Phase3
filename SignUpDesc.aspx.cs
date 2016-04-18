using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUpDesc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    string userType = "";
    int permission = 0;


    protected void btnStudent_Click(object sender, EventArgs e)
    {
        userType = "Student";
        permission = 3; //should be 3 changed for prototype
        Session["userType"] = userType;
        Session["permission"] = permission;
        Response.Redirect("UserRegistration.aspx");
    }
    protected void btnParent_Click(object sender, EventArgs e)
    {
        userType = "Parent";
        permission = 2;
        Session["userType"] = userType;
        Session["permission"] = permission;
        Response.Redirect("UserRegistration.aspx");

    }
    protected void btnCipher_Click(object sender, EventArgs e)
    {
        userType = "Cipher";
        permission = 1;
        Session["userType"] = userType;
        Session["permission"] = permission;
        Response.Redirect("UserRegistration.aspx");
    }
}