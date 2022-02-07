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

public partial class Administrator_Subjest : System.Web.UI.Page
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
            RequiredFieldValidator25.Visible = false;
            lblBranch.Visible = false;
        }
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            branch();
            if (RadioButtonList2.SelectedItem.Text == "B.Tech")
            {
                RequiredFieldValidator25.Visible = true;
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 4; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));

            }
            else if (RadioButtonList2.SelectedItem.Text == "M.Tech")
            {
                RequiredFieldValidator25.Visible = true;
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 2; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
            }
            else if (RadioButtonList2.SelectedItem.Text == "MCA")
            {
                RequiredFieldValidator25.Visible = false;
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 3; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
            }

            else
            {
                RequiredFieldValidator25.Visible = false;
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 2; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
            }

        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
        
    }

    private void branch()
    {

        try
        {
            if (RadioButtonList2.SelectedItem.Text == "B.Tech" || RadioButtonList2.SelectedItem.Text == "M.Tech")
            {
                DDLBName.Visible = true;
                lblBranch.Visible = false;
                da = new SqlDataAdapter("Select Distinct(BranchName) from Course_Details where CourseName='" + RadioButtonList2.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                DDLBName.DataTextField = "BranchName";
                DDLBName.DataValueField = "BranchName";
                DDLBName.DataSource = ds.Tables[0];
                DDLBName.DataBind();
                DDLBName.Items.Insert(0, new ListItem("Select", ""));
                con.Close();

            }
            else if (RadioButtonList2.SelectedItem.Text == "MCA")
            {
                DDLBName.Visible = false;
                lblBranch.Visible = true;
                lblBranch.Text = "MCA";
            }
            else
            {
                DDLBName.Visible = false;
                lblBranch.Visible = true;
                lblBranch.Text = "MBA";
            }
        }
        catch (Exception e1)
        {
            
               ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
 
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ArrayList sem = new ArrayList();
        if (RadioButtonList2.SelectedItem.Text == "B.Tech")
        {
         
            if (DDLYear.SelectedValue == "1")
            {
                DDLSem.Visible = false;
                Lblsem.Visible = false;

            }
            else
            {
                DDLSem.Visible = true;
                Lblsem.Visible = true;
                for (int j = 1; j <= 2; j++)
                {
                    sem.Add(j);
                    
                }
                DDLSem.DataSource = sem;
                DDLSem.DataBind();
                DDLSem.Items.Insert(0, new ListItem("Select", ""));
            }
                  
        }
            else
        {
            DDLSem.Visible = true;
            Lblsem.Visible = true;
             for (int j = 1; j <= 2; j++)
                {
                    sem.Add(j);
                    
                }
                DDLSem.DataSource = sem;
                DDLSem.DataBind();
                DDLSem.Items.Insert(0, new ListItem("Select", ""));

            }
    }



    protected void ButtSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList2.SelectedItem.Text == "B.Tech")
            {
                if (DDLYear.SelectedValue == "1")
                {
                    string CName = RadioButtonList2.SelectedItem.Text;
                    cmd = new SqlCommand("insert into Subject_Details values('" + TBSCode.Text + "','" + TBSName.Text + "','" + CName + "','" + DDLYear.SelectedItem.Text + "','NA','" + DDLBName.SelectedItem.Text + "','" + TBReg.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    TBSName.Text = "";
                    TBSCode.Text = "";
                     ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);
 
                }
                else
                {
                    string CName = RadioButtonList2.SelectedItem.Text;
                    cmd = new SqlCommand("insert into Subject_Details values('" + TBSCode.Text + "','" + TBSName.Text + "','" + CName + "','" + DDLYear.SelectedItem.Text + "','" + DDLSem.Text + "','" + DDLBName.SelectedItem.Text + "','" + TBReg.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    TBSName.Text = "";
                    TBSCode.Text = "";
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);

                }
            }
            else if(RadioButtonList2.SelectedItem.Text=="M.Tech")
            {
                string CName = RadioButtonList2.SelectedItem.Text;
                cmd = new SqlCommand("insert into Subject_Details values('" + TBSCode.Text + "','" + TBSName.Text + "','" + CName + "','" + DDLYear.SelectedItem.Text + "','" + DDLSem.Text + "','" + DDLBName.SelectedItem.Text + "','" + TBReg.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                TBSName.Text = "";
                TBSCode.Text = "";
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);

            }
            
           else
            {
                string CName1 = RadioButtonList2.SelectedItem.Text;
                cmd = new SqlCommand("insert into Subject_Details values('" + TBSCode.Text + "','" + TBSName.Text + "','" + CName1 + "','" + DDLYear.SelectedItem.Text + "','" + DDLSem.Text + "','" + lblBranch.Text + "','" + TBReg.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                TBSName.Text = "";
                TBSCode.Text = "";
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);

            }


        }
        catch (Exception e1)
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Code is Already Existed...')", true);

            // MessageBox.Show("Code is Already Existed", "Student Feedack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
    protected void ButtReset_Click(object sender, EventArgs e)
    {
        reset();
    }

    private void reset()
    {
        TBReg.Text = "";
        TBSName.Text = "";
        TBSCode.Text = "";
        DDLBName.SelectedIndex = 0;
        DDLSem.SelectedIndex = 0;
        DDLYear.SelectedIndex = 0;
        RadioButtonList2.ClearSelection();
    }
}
