using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
public partial class Instructor_ViewEvaluations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
                SqlCommand insert = new SqlCommand();

                insert.Connection = sc;
               insert.CommandText = "Select ResponseText from Response where Response.EvalResponseID = '" + Session["EvalResponseID"].ToString() + "'";
                sc.Open();


                SqlDataReader reader = insert.ExecuteReader();
                int j = 2;
                int k = 2;
                int i = 0;


                while (reader.Read())
                {
                    txtQuestion1.Text = "Anonymous";
                    txtQuestion9a.Text = "";
                    if (i == 0)
                    {
                        txtQuestion2.Text = reader.GetString(0);
                        Debug.Print(txtQuestion2.Text);
                    }
                    else if (i == 1)
                    {
                        txtQuestion3.Text = reader.GetString(0);
                        Debug.Print(txtQuestion3.Text);
                    }
                    else if (i == 2)
                    {
                        txtQuestion4.Text = reader.GetString(0);
                        Debug.Print(txtQuestion4.Text);
                    }
                    else if (i == 3)
                    {
                        txtQuestion5.Text = reader.GetString(0);
                        Debug.Print(txtQuestion5.Text);
                    }
                    //txtQuestion2.Text = reader.GetString(0);
                    //Debug.Print(txtQuestion2.Text);
                    //txtQuestion3.Text = reader.GetString(0);
                    //Debug.Print(txtQuestion3.Text);
                    //txtQuestion4.Text = reader.GetString(0);
                    //Debug.Print(txtQuestion4.Text);
                    //txtQuestion5.Text = reader.GetString(0);
                    //Debug.Print(txtQuestion5.Text);


                    else if (i >= 4 && i < 8)
                    {

                        //     TextBox txt = (TextBox)Table2.Rows[i+2].Cells[1].Controls[0];

                        string txt = "";

                        switch (reader.GetString(0))
                        {
                            case "1":
                                txt = "Completely Disagree";
                                break;
                            case "2":
                                txt = "Disagree";
                                break;
                            case "3":
                                txt = "Neither Agree Nor Disagree";
                                break;
                            case "4":
                                txt = "Agree";
                                break;
                            case "5":
                                txt = "Completely Agree";
                                break;
                        }
                        Debug.Print(Convert.ToString(i));
                        Debug.Print(txt);
                        int f = 1;
                        Table1.Rows[i - 2].Cells[1].Text = txt;

                    }
                    else if (i >= 8 && i < 15)
                    {
                        string txt = "";
                        switch (reader.GetString(0))
                        {
                            case "1":
                                txt = "Completely Disagree";
                                break;
                            case "2":
                                txt = "Disagree";
                                break;
                            case "3":
                                txt = "Neither Agree Nor Disagree";
                                break;
                            case "4":
                                txt = "Agree";
                                break;
                            case "5":
                                txt = "Completely Agree";
                                break;
                        }
                        Debug.Print(Convert.ToString(i));
                        Debug.Print(txt);
                        int f = 1;
                        Table2.Rows[i - 6].Cells[1].Text = txt;
                    }
                    else if (i >= 15 && i < 19)
                    {
                        string txt = "";
                        switch (reader.GetString(0))
                        {
                            case "1":
                                txt = "Completely Disagree";
                                break;
                            case "2":
                                txt = "Disagree";
                                break;
                            case "3":
                                txt = "Neither Agree Nor Disagree";
                                break;
                            case "4":
                                txt = "Agree";
                                break;
                            case "5":
                                txt = "Completely Agree";
                                break;
                        }
                        Debug.Print(Convert.ToString(i));
                        Debug.Print(txt);
                        int f = 1;
                        Table5.Rows[i - 13].Cells[1].Text = txt;
                    }
                    else if (i >= 19 && i < 22)
                    {
                        string txt = "";
                        switch (reader.GetString(0))
                        {
                            case "1":
                                txt = "Completely Disagree";
                                break;
                            case "2":
                                txt = "Disagree";
                                break;
                            case "3":
                                txt = "Neither Agree Nor Disagree";
                                break;
                            case "4":
                                txt = "Agree";
                                break;
                            case "5":
                                txt = "Completely Agree";
                                break;
                        }
                        Debug.Print(Convert.ToString(i));
                        Debug.Print(txt);
                        int f = 1;
                        Table3.Rows[i - 17].Cells[1].Text = txt;
                    }

                    else if (i >= 22 && i < 32)
                    {
                        string txt = "";
                        switch (reader.GetString(0))
                        {
                            case "1":
                                txt = "Unsatisfactory";
                                break;
                            case "2":
                                txt = "Needs Improvement";
                                break;
                            case "3":
                                txt = "Meets Expectations";
                                break;
                            case "4":
                                txt = "Exceeds Expectations";
                                break;
                            case "5":
                                txt = "Exceptional";
                                break;
                        }
                        Debug.Print(Convert.ToString(i));
                        Debug.Print(txt);
                        int f = 1;
                        Table4.Rows[i - 20].Cells[1].Text = txt;
                    }

                    else if (i == 32)
                    {
                        txtQuestion2t.Text = reader.GetString(0);
                        Debug.Print(Convert.ToString(i));
                        Debug.Print(txtQuestion2t.Text);
                        int f = 1;
                    }
                    else if (i == 33)
                    {
                        txtQuestion3t.Text = reader.GetString(0);
                    }
                    else if (i == 34)
                    {
                        txtQuestion4t.Text = reader.GetString(0);
                    }
                    else if (i == 35)
                    {
                        txtQuestion5t.Text = reader.GetString(0);
                    }
                    else if (i == 36)
                    {
                        txtQuestion1s.Text = reader.GetString(0);
                    }
                    else if (i == 37)
                    {
                        txtQuestion2s.Text = reader.GetString(0);
                    }

                    i++;
                    j++;
                }


                System.Diagnostics.Debug.WriteLine(insert.CommandText);
                sc.Close();

            }
            catch (System.Data.SqlClient.SqlException f)
            {

                System.Windows.Forms.MessageBox.Show(f.Message);

            }
        }
    }
}