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

public partial class Administrator_Home : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter da;
    DataSet ds;
    

    protected void Page_Load(object sender, EventArgs e)
    {
     //   con = new SqlConnection("user id =sa;password=sa;database=StudentFeedbackSystem");
      con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
        da = new SqlDataAdapter("select CollegeName from College_Details", con);
        con.Open();
        ds = new DataSet();
        da.Fill(ds);
        //Label2.Text = ds.Tables[0].Rows[0][0].ToString();
        Label2.Text = "Student Feedback System";
        con.Close();
    }
}
