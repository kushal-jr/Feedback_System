using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;


public partial class Login : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection con;
    SqlDataReader dr;
    //SqlDataAdapter da;
    //DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
      

        //if (Request.QueryString["msg"] != null)
        //{
        //    Response.Cache.SetExpires(DateTime.Now);
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //}

    }

    protected void ButtLogon_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("select StudentId,Password,BranchName,Year,Semester,Section,CourseName,AcademicYear,AdmissionType from Student_Details where StudentId='" + TBRNo.Text + "' and Password='" + TBPWord.Text + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session["CurrentUser"] = TBRNo.Text;
                Session["BranchName"] = dr.GetValue(2).ToString();
                Session["Year"] = dr.GetValue(3).ToString();
                Session["Semester"] = dr.GetValue(4).ToString();
                Session["Section"] = dr.GetValue(5).ToString();
                Session["CourseName"] = dr.GetValue(6).ToString();
                Session["AYear"] = dr.GetValue(7).ToString();
                Session["AType"] = dr.GetValue(8).ToString();
              //  Session["Regulation"] = dr.GetValue(9).ToString();
                Response.Redirect("~/Stud/Home.aspx");

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Access Denied.....You Are Entered Wrong UserId or Password')", true);

               // MessageBox.Show("Access Denied.....You Are Entered Wrong UserId or Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        catch (Exception)
        {
            //MessageBox.Show(e1.Message, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        con.Close();
    }
}
