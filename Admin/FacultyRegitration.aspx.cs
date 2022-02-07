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

public partial class Administrator_FacultyRegitration : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    public string s3;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
        lblDept.Visible = false;
        if (!IsPostBack)
        {

          
            facultyId();
        }
    }

    private void facultyId()
    {
        try
        {
            cmd = new SqlCommand("select max(FacultyId) from Faculty_Details", con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            if (s == "")
            {
              s3 = "Fac1";
            }
            else
            {
                string s1 = s.Substring(0, 3);
                string s2 = s.Substring(3);
                int i = Convert.ToInt32(s2);
                i = i + 1;
                s3 = s1 + i.ToString();

            }

            con.Close();
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }


    }


    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {   
            SqlDataReader dr;
            con.Close();
            if (RadioButtonList2.SelectedItem.Text == "B.Tech" || RadioButtonList2.SelectedItem.Text == "M.Tech")
            {
                cmd = new SqlCommand("Select FacultyName from Faculty_Details where CourseName='" + RadioButtonList2.SelectedItem.Text + "' and Department='" + DDLDept.SelectedItem.Text + "' and FacultyName='"+ TBName.Text +"'", con);
                con.Open();
                 dr = cmd.ExecuteReader();
               
            }
            else
            {
                cmd = new SqlCommand("Select FacultyName from Faculty_Details where CourseName='" + RadioButtonList2.SelectedItem.Text + "' and Department='" + lblDept.Text + "' and FacultyName='" + TBName.Text + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                
            }
            if (dr.Read())
            {
                con.Close();
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Already Existed Plz Change Name')", true);

            }
            else
            {
                con.Close();
                if (RadioButtonList2.SelectedItem.Text == "B.Tech" || RadioButtonList2.SelectedItem.Text == "M.Tech")
                {
                    string CName = RadioButtonList2.SelectedItem.Text;
                    cmd = new SqlCommand("insert into Faculty_Details values('" + TBName.Text + "','" + CName + "','" + s3 + "','" + DDLDept.SelectedItem.Text + "','" + TBAddress.Text + "','" + TBEmailId.Text + "','" + TBMobile.Text + "','" + TBRemarks.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    reset();
                    con.Close();
                    facultyId();
                    store();
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully')", true);


                }
                else
                {
                    string CName1 = RadioButtonList2.SelectedItem.Text;
                    cmd = new SqlCommand("insert into Faculty_Details values('" + s3 + "','" + CName1 + "','" + TBName.Text + "','" + lblDept.Text + "','" + TBAddress.Text + "','" + TBEmailId.Text + "','" + TBMobile.Text + "','" + TBRemarks.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    reset();
                    con.Close();
                    facultyId();
                    store();
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully')", true);

                }

            }
        }
        catch (Exception e1)
        {
           // ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Already Existed Plz Change Name')", true);

            
        }
    
    }

    private void reset()
    {
        TBName.Text = "";
        TBAddress.Text = "";
        TBEmailId.Text = ""; 
        TBMobile.Text = "";
        TBRemarks.Text = "";
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (RadioButtonList2.SelectedItem.Text == "B.Tech" || RadioButtonList2.SelectedItem.Text == "M.Tech")
            {
                lblMessage1.Visible = false;
                DDLDept.Visible = true;
                lblDept.Visible = false;
                da = new SqlDataAdapter("Select Distinct(BranchName) from Course_Details where CourseName='" + RadioButtonList2.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                DDLDept.DataTextField = "BranchName";
                DDLDept.DataValueField = "BranchName";
                DDLDept.DataSource = ds.Tables[0];
                DDLDept.DataBind();
                DDLDept.Items.Insert(0, new ListItem("Select", ""));
                con.Close();

            }
            else if (RadioButtonList2.SelectedItem.Text == "MCA")
            {
                DDLDept.Visible = false;
                lblDept.Visible = true;
                lblDept.Text = "MCA";
                facdetails();
            }
            else
            {
                DDLDept.Visible = false;
                lblDept.Visible = true;
                lblDept.Text = "MBA";
                facdetails();
            }
          
        }
        catch (Exception e1)
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
    }

    private void facdetails()
    {
        lblMessage1.Visible = true;
        GridView1.Visible = true;
        da = new SqlDataAdapter("Select FacultyName,CourseName,Department,Address,EmailId,Mobile,Remarks from Faculty_Details where CourseName='" + RadioButtonList2.SelectedItem.Text + "'", con);
        con.Open();
        ds = new DataSet();
        da.Fill(ds, "Semister");
        da.Fill(ds, "courses");
        DataTable data = ds.Tables[0];// Utils.DataManager.ExecuteQuery(query);
        if (data.Rows.Count == 0)
        {
            GridView1.Visible = false;
            lblMessage1.Text = "No Members found..";
        }
        else
        {

            int i = data.Rows.Count;
            lblMessage1.Text = i + "  Member(s) found..";
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            con.Close();
        }
    }
    protected void Reset_Click(object sender, EventArgs e)
    {
        DDLDept.Visible = true;
        RadioButtonList2.ClearSelection();
        reset();
    }
    protected void DDLDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        store();
    }

    private void store()
    {
        lblMessage1.Visible = true;
        GridView1.Visible = true;
        da = new SqlDataAdapter("Select FacultyName,CourseName,Department,Address,EmailId,Mobile,Remarks from Faculty_Details where CourseName='" + RadioButtonList2.SelectedItem.Text + "' and Department='" + DDLDept.SelectedItem.Text + "'", con);
        con.Open();
        ds = new DataSet();
        da.Fill(ds, "Semister");
        da.Fill(ds, "courses");
        DataTable data = ds.Tables[0];// Utils.DataManager.ExecuteQuery(query);
        if (data.Rows.Count == 0)
        {
            GridView1.Visible = false;
            lblMessage1.Text = "No Members found..";
        }
        else
        {

            int i = data.Rows.Count;
            lblMessage1.Text = i + "  Member(s) found..";
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            con.Close();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
     
       
           try
            {  string s1 = e.CommandName;
            if (s1 == "Delete")
            {
                int i = Convert.ToInt32(e.CommandArgument.ToString());
                con.Close();
                string s = GridView1.Rows[i].Cells[1].Text;
                string s5 = GridView1.Rows[i].Cells[3].Text;
                cmd = new SqlCommand("delete from Faculty_Details where FacultyName='" + s + "' and Department='" + s5 + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                store();
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Successfully Deleted')", true);
            }
           }
            catch (Exception e1)
            {
                 ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
            }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
}
