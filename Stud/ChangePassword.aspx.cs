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

public partial class Student_ChangePassword : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    //DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
    
    }
    protected void ButtSave_Click(object sender, EventArgs e)
    {
        string UserId = Session["CurrentUser"].ToString();
        string oldPassword = txtOldPassword.Text.Replace("'", "''");
        string newPassword = txtNewPassword.Text.Replace("'", "''");
        string confirmPassword = txtConfirmPassword.Text.Replace("'", "''");
        try
        {
            da = new SqlDataAdapter("SELECT StudentId,Password FROM Student_Details where Password = '" + oldPassword + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "UserProfile");
            DataTable table = ds.Tables[0];
            if (table.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Old Password You Entered is not Correct')", true);

               // MessageBox.Show("The Old Password you entered is not correct.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cmd = new SqlCommand("UPDATE Student_Details set Password = '" + newPassword + "' where StudentId = '" + UserId + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Password Changed Successfully')", true);

            // MessageBox.Show("Password Changed Successfully", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Response.Redirect("~/Stud/Home.aspx");
            con.Close();
        }
        catch (Exception )
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
    }
}
