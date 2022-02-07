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


public partial class Administrator_CollegeRegistration : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
   protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
      
    }
   
    protected void BttnSave_Click(object sender, EventArgs e)
    {
        try
        {
         
            cmd = new SqlCommand("insert into College_Details values('" + CName.Text + "','" + CCode.Text + "','" + EYear.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            reset();
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully')", true);

          

            Response.Redirect("~/adminLogin.aspx");

        }
        catch (Exception e1)
        {
           //  ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
    }
    private void reset()
    {
        CName.Text = "";
        CCode.Text = "";
        EYear.Text = "";
    }
    protected void ButtClear_Click(object sender, EventArgs e)
    {
        reset();
    }
}
