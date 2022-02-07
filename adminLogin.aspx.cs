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

public partial class adminLogin : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection con;
    SqlDataReader dr;
    //SqlDataAdapter da;
    //DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
        
    }
    protected void ButtLogin_Click(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("select CollegeCode from College_Details", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                cmd = new SqlCommand("select UserName,Password from Admin_Details where UserName='" + TBName.Text + "' and Password='" + TBPwd.Text + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Session["Admin"] = TBName.Text;
                    con.Close();
                    Response.Redirect("~/Admin/Home.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Access Denied.....You Are Entered Wrong UserId or Password')", true);
                }
            }
            else
            {
                Response.Redirect("~/Admin/CollegeRegistration.aspx");
            }
        }
        catch (Exception)
        {
           //  ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }

     }
}
