using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Inventory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int userType = 0;
        if (Session["permission"] != null)
        {
            userType = Int32.Parse(Session["permission"].ToString());
        }
        switch (userType)
        {
            case 1:
                // display cipher menu
                adminPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";

                break;
            case 2:
                // display parent menu
                adminPanel1.Style["display"] = "none";

                cipherPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";
                // Set fields un-editable if user is not an admin

                break;
            case 3:
                // display student menu
                adminPanel1.Style["display"] = "none";

                cipherPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";


                break;
            case 4:
                // display instructor menu
                adminPanel1.Style["display"] = "none";

                cipherPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";


                break;
            case 5:
                // display admin menu
                cipherPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";
                break;
            default:
                adminPanel1.Style["display"] = "none";

                cipherPanel1.Style["display"] = "none";

                parentPanel1.Style["display"] = "none";

                studentPanel1.Style["display"] = "none";

                instructorPanel1.Style["display"] = "none";

                break;
        }
    }
    public void btnBuy()
    {
        MessageBox.Show("Your order has been placed! The bucks will be deducted from your account, please be on the lookout for a confirmation e-mail with more details.");
    }
}


// For scope:
// Key Key course stuff
// What a teacher and student sees
// Have "something" for evaluations
// flexible on some stuff since they dont know what they want
// for friday: key functionality top to bottom
// whats process for applicant to become a student electronically
// will people want to come back
// ignoring cipher would be deduction
// 40 points for c#, any piece is probably only a 1-2 point deduction (these can be fixed the following week)
// database is a huge piece





