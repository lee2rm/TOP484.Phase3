using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cipher_MakeADonation : System.Web.UI.Page
{


    // Add tabs to donate to different elements
    // Add master donate button to master page for general donation to WBL
    // Put paypalprocess.PNG in the img folder to make this page work
    protected void Page_Load(object sender, EventArgs e)
    {
       // string loc = Server.MapPath("~/img/paypalprocess.PNG");
        //Response.WriteFile(loc);
        //Response.ContentType = "image/png";
    }
    //public string MakeImageSrcData(string filename)
    //{
    //    FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
    //    byte[] filebytes = new byte[fs.Length];
    //    fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
    //    return "data:image/png;base64," +
    //    Convert.ToBase64String(filebytes, Base64FormattingOptions.None);
    //}
}