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
using System.Text;

public partial class Student_FeedBack : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection con;
    SqlDataReader dr;
    SqlDataAdapter da;
    SqlDataAdapter da1;
    public DataSet ds1=null;
    DataSet ds;
    public int count;
    string at;
    string at1;
    int at2;
    int at3;
    string at4;
    string at5;
    string ay;
    string dept;
    public int pos;
    public int cnt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
            con.Open();

            ay = Session["CurrentUSer"].ToString();
            at = Session["AYear"].ToString();
            if (Session["AType"].ToString() == "Lateral Entry")
            {
                at1 = at.Substring(0, 4);
                at4 = at.Substring(4, at1.Length + 1);
                at2 = Convert.ToInt32(at1);
                at3 = at2 - 1;
                at5 = at3 + at4;
            }
            else
            {
                at5 = at;
            }
            if (!IsPostBack)
            {
                Session["pos"] = 0;
                LblBranch.Text = Session["BranchName"].ToString();
                LblSection.Text = Session["Section"].ToString();
                Panel1.Visible = false;
                ButtNext.Visible = false;
                studentdetails();
                FacultyDetails();
                questions1();
            }

            FacultyDetails1();

        }
        catch (Exception)
        {
            
        }
    }

    private void FacultyDetails1()
    {
        try
        {
            da1 = new SqlDataAdapter("Select FacultyName,Subject,Department from Assigned_Details Where Branch_Name='" + Session["BranchName"].ToString() + "' and Year='" + Session["Year"].ToString() + "' and Semester='" + Session["Semester"].ToString() + "' and Section='" + Session["Section"] + "' and CourseName='" + Session["CourseName"] + "' and AcademicYear='" + at5 + "'", con);
            ds1 = new DataSet();
            da1.Fill(ds1, "question");
        }

        catch
        {
        }
    }
    private void FacultyDetails()
    {
        try
        {
            da1 = new SqlDataAdapter("Select FacultyName,Subject,Department from Assigned_Details Where Branch_Name='" + Session["BranchName"].ToString() + "' and Year='" + Session["Year"].ToString() + "'and semester='" + Session["Semester"].ToString() + "' and Section='" + Session["Section"] + "' and CourseName='" + Session["CourseName"] + "' and AcademicYear='" + at5 + "'", con);
            ds1 = new DataSet();
            da1.Fill(ds1, "Faculty");
            cnt = ds1.Tables[0].Rows.Count;
            Session["cnt"] = cnt;
            if (cnt == 0)
            {
                Panel1.Visible = false;
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Temporarely Data Unavailable')", true);
            }
            else
            {
                ButtNext.Visible = true;
                Label4.Visible = true;
                LblFName.Visible = true;
                LblFName.Text = ds1.Tables[0].Rows[0][0].ToString();
                LblSubj.Text = ds1.Tables[0].Rows[0][1].ToString();
            }

        }
        catch (Exception)
        {
            

        }
    }
    private void studentdetails()
    {
        try
        {
            cmd = new SqlCommand("Select StudentId from Feedback_Details where StudentId='" + Session["CurrentUser"].ToString() + "' and BranchName='" + Session["BranchName"].ToString() + "' and Year='" + Session["Year"].ToString() + "' and Semester='" + Session["Semester"].ToString() + "' and Section='" + Session["Section"].ToString() + "' and CourseName='" + Session["CourseName"].ToString() + "' and AcademicYear='" + at5 + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Panel1.Visible = false;
                ButtNext.Visible = false;
                Label3.Text = "You are Allready Submitted";
            }
            else
            {
                Panel1.Visible = true;
                ButtNext.Visible = true;
            }
            dr.Close();

        }
        catch (Exception)
        {
            

        }
    }

    private void questions1()
    {
        try
        {
            da = new SqlDataAdapter("Select Question from Question_Details", con);
            ds = new DataSet();
            da.Fill(ds, "question");
            if (!IsPostBack)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }

        }
        catch (Exception)
        {
            
            
        }
    }
    public void loadfaculty(int pos1)
    {
        try
        {
            LblFName.Text = ds1.Tables[0].Rows[pos1][0].ToString();
            LblSubj.Text = ds1.Tables[0].Rows[pos1][1].ToString();

        }
        catch (Exception)
        {
            

        }
    }

    protected void ButtNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                RadioButtonList rb = null;
                da = new SqlDataAdapter("Select Distinct(Department) from Assigned_Details Where FacultyName='" + LblFName.Text + "' and Branch_Name='" + Session["BranchName"].ToString() + "' and Year='" + Session["Year"].ToString() + "' and Section='" + Session["Section"] + "' and CourseName='" + Session["CourseName"] + "' and AcademicYear='" + at5 + "'", con);
                ds = new DataSet();
                da.Fill(ds, "Faculty");
                dept = ds.Tables[0].Rows[0][0].ToString();
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    rb = gvr.FindControl("rblChoices") as RadioButtonList;
                    string ques = gvr.Cells[0].Text;
                    cmd = new SqlCommand("insert into FeedBack_Details values('" + ques + "','" + LblFName.Text + "','" + LblBranch.Text + "','" + LblSubj.Text + "','" + rb.SelectedValue + "','" + Session["Year"] + "','" + Session["Semester"] + "','" + Session["Section"] + "','" + Session["CurrentUSer"].ToString() + "','" + dept + "','" + at5 + "','" + Session["CourseName"].ToString() + "')", con);
                    cmd.ExecuteNonQuery();
                    rb.ClearSelection();
                }
                if (ButtNext.Text == "Submit")
                {
                    Session["pos"] = 0;
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('FeedBack Submitted')", true);
                    Panel1.Visible = false;
                    Label3.Text = "FeedBack Submitted Successfully";
                }
                else
                {
                    int temp = Convert.ToInt32(Session["pos"]);
                    Session["pos"] = ++temp;
                    loadfaculty(temp);
                    int p = Convert.ToInt32(Session["cnt"]);
                    int q = Convert.ToInt32(Session["pos"]);
                    if (p == q + 1)
                    {
                        ButtNext.Text = "Submit";
                    }
                }
            }
        }
        catch (Exception e8)
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert("+e8.Message+")", true);
        }
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
