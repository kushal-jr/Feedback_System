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

public partial class Administrator_Branch : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
     
    }
    
      protected void ButtSave_Click(object sender, EventArgs e)
    {
        try
        {
                cmd = new SqlCommand("select BranchName from Course_Details where BranchName='" + BName.Text + "' and CourseName='"+ RadioButtonList1.SelectedItem.Text +"'", con);
                con.Open();    
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Branch Name is Already Existed')", true);
                
                }
                else
                {
                    con.Close();
                    string s = RadioButtonList1.SelectedItem.Text;
                    cmd = new SqlCommand("insert into Course_Details values('" + BCode.Text + "','" + BName.Text + "','" + s + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BCode.Text = "";
                    BName.Text = "";
                    Store();
                 
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);
                   
                }
        }
        catch (Exception )
        {
          
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Branch code is Already Existed')", true);
                  
       
        }
    }
    private void reset()
    {
        RadioButtonList1.ClearSelection();
        BCode.Text = "";
        BName.Text="";
        
    }
    protected void ButtReset_Click(object sender, EventArgs e)
    {
        reset();
       
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Store();
    }
    private void Store()
    {
        try
        {
            con.Close();
            GridView1.Visible = true;
            da = new SqlDataAdapter("Select * from Course_Details where CourseName='"+ RadioButtonList1.SelectedItem.Text +"'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Semister");
            da.Fill(ds, "courses");
            DataTable data = ds.Tables[0];// Utils.DataManager.ExecuteQuery(query);
            if (data.Rows.Count == 0)
            {
                GridView1.Visible = false;
                lblMessage1.Text = "No Branches Available.";
            }
            else
            {

                int i = data.Rows.Count;
                lblMessage1.Text = i+ "  Branch(s) Available.";
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                con.Close();
            }

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
                cmd = new SqlCommand("delete from Course_Details where BranchCode='" + s + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Store();
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
}
