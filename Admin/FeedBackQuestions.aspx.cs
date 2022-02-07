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

public partial class Administrator_AddFeedBackSystem : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
        if (!IsPostBack)
        {
            store();
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
        cmd = new SqlCommand("select Max(QuestionNo) from Question_Details", con);
        con.Open();
        string s = cmd.ExecuteScalar().ToString();
        if (s == "")
        {
            s = "1";
        }
        else
        {
            
            int i = Convert.ToInt32(s);
            i = i + 1;
            s =i.ToString();
          
        }

        con.Close();
       
            cmd = new SqlCommand("insert into Question_Details values('"+ s +"','" + TextBox2.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            TextBox2.Text = "";
            ClientScript.RegisterStartupScript(GetType(), "Onload", "confirm('Registerd Successfully...')", true);
       
             con.Close();
            store();
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }

    private void store()
    {
        try
        {
            da = new SqlDataAdapter("Select Question from Question_Details",con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Semister");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            con.Close();

        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }


  
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string s1 = e.CommandName;
        if (s1 == "Delete")
            try
            {
                int i = Convert.ToInt32(e.CommandArgument.ToString());
                con.Close();
                string s = GridView1.Rows[i].Cells[1].Text;
                cmd =new SqlCommand("delete from Question_Details where question='" + s + "'",con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                store();
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Successfully Deleted')", true);

               
            }
            catch (Exception e1)
            {
                 ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
            }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        TextBox2.Text = "";
    }
}
