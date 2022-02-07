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

public partial class Administrator_AssignSubject : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    SqlDataReader dr;
  

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
        if (!IsPostBack)
        {
           
            GridView1.Visible = false;
            lblBranch.Visible = false;

            DDLBName.Visible = false;
            Label49.Visible = false;
        }

    }

    private void ayear()
    {

        try
        {


            da = new SqlDataAdapter("Select Distinct(AcademicYear) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "EstablishedYear");
            DDLYear0.DataSource = ds.Tables[0];
            DDLYear0.DataTextField = "AcademicYear";
            DDLYear0.DataValueField = "AcademicYear";
            DDLYear0.DataBind();
            DDLYear0.Items.Insert(0, new ListItem("Select", ""));
            con.Close();
        }





        catch (Exception e1)
        {
            string er = e1.Message;

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
        }
    }
    private void ayear1()
    {

        try
        {


            da = new SqlDataAdapter("Select Distinct(AcademicYear) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='Regular'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "EstablishedYear");
            DDLYear0.DataSource = ds.Tables[0];
            DDLYear0.DataTextField = "AcademicYear";
            DDLYear0.DataValueField = "AcademicYear";
            DDLYear0.DataBind();
            DDLYear0.Items.Insert(0, new ListItem("Select", ""));
            con.Close();
        }





        catch (Exception e1)
        {
            string er = e1.Message;

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            Regulation();
            DDLSemester.SelectedIndex = 0;
            DDLSection.Items.Clear();
            DDLSection.Items.Insert(0, new ListItem("Select", ""));
            DDLBName.Items.Clear();
            DDLBName.Items.Insert(0, new ListItem("Select", ""));
            lblBranch.Visible = false;
            DDLSubject.Items.Clear();
            DDLSubject.Items.Insert(0, new ListItem("Select", ""));
            DDLFName.Items.Clear();
            DDLFName.Items.Insert(0, new ListItem("Select", ""));
            DDLBName.Visible = false;
            Label49.Visible = false;
       
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
              
                RequiredFieldValidator25.Visible = true;
            
                Department();
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 4; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
                ayear1();
            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
             
                lblsem.Visible = true;
                DDLSemester.Visible = true;
                lblBranch.Visible = false;
                Department();
                RequiredFieldValidator25.Visible = true;
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 2; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
                ayear();

            }
            else if (RadioButtonList1.SelectedItem.Text == "MCA")
            {
               
                lblBranch.Text = "";
                lblsem.Visible = true;
                DDLSemester.Visible = true;
                RequiredFieldValidator25.Visible = false;
                Section1();
                Department();
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 3; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
                ayear();

            }
            else if (RadioButtonList1.SelectedItem.Text == "MBA")
            {
               
                lblBranch.Text = "";
                lblsem.Visible = true;
                DDLSemester.Visible = true;
                RequiredFieldValidator25.Visible = false;
                Section1();
                Department();
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 2; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
                ayear();
            }
           
        }
        catch (Exception e1)
        {
            string er = e1.Message;

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
        }

    }

    private void Department()
    {
        try
        {
            
                
                da = new SqlDataAdapter("Select Distinct(BranchName) from Course_Details", con);
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
        catch (Exception e1)
        {
            string er = e1.Message;

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
        }
    }

    private void Regulation()
    {
        try
        {
            da = new SqlDataAdapter("Select Distinct(Regulation) from Subject_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            DDLReg.DataTextField = "Regulation";
            DDLReg.DataValueField = "Regulation";
            DDLReg.DataSource = ds.Tables[0];
            DDLReg.DataBind();
            DDLReg.Items.Insert(0, new ListItem("Select", ""));
            con.Close();
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }

    private void Faculty1()
    {
        try
        {
            da = new SqlDataAdapter("Select Distinct(FacultyName) from Faculty_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            DDLFName.DataTextField = "FacultyName";
            DDLFName.DataValueField = "FacultyName";
            DDLFName.DataSource = ds.Tables[0];
            DDLFName.DataBind();
            DDLFName.Items.Insert(0, new ListItem("Select", ""));
            con.Close();
        }
        catch (Exception e1)
        {
            string er = e1.Message;

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
        }
    }

    private void Section()
    {
        try
        {
            da = new SqlDataAdapter("Select Distinct(Section) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='"+ DDLBName.SelectedItem.Text +"' and AcademicYear='"+ DDLYear0.SelectedItem.Text +"'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            DDLSection.DataTextField = "Section";
            DDLSection.DataValueField = "Section";
            DDLSection.DataSource = ds.Tables[0];
            DDLSection.DataBind();
            DDLSection.Items.Insert(0, new ListItem("Select", ""));
            con.Close();
        }
        catch (Exception e1)
        {
            string er = e1.Message;

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
        }
    }
    private void Section1()
    {
        try
        {
            da = new SqlDataAdapter("Select Distinct(Section) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            DDLSection.DataTextField = "Section";
            DDLSection.DataValueField = "Section";
            DDLSection.DataSource = ds.Tables[0];
            DDLSection.DataBind();
            DDLSection.Items.Insert(0, new ListItem("Select", ""));
            con.Close();
        }
        catch (Exception e1)
        {
            string er = e1.Message;

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
        }
    }
    private void branch()
    {
        try
        {
            if (RadioButtonList1.SelectedItem.Text == "B.Tech" || RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                lblBranch.Visible = false;

                DDLBName.Visible = true;
                Label49.Visible = true;
                da = new SqlDataAdapter("Select Distinct(BranchName) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
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
            else if (RadioButtonList1.SelectedItem.Text == "MCA")
            {
                DDLBName.Visible = false;
                Label49.Visible = true;
                lblBranch.Visible = true;
                da = new SqlDataAdapter("Select Distinct(BranchName) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblBranch.Text = "MCA is Not Registered in this Academic Year";
                }
                else
                {

                    lblBranch.Text = ds.Tables[0].Rows[0][0].ToString();
                    Section1();
                }
                con.Close();
            }
            else if (RadioButtonList1.SelectedItem.Text == "MBA")
            {
                DDLBName.Visible = false;
                Label49.Visible = true;
                lblBranch.Visible = true;
                da = new SqlDataAdapter("Select Distinct(BranchName) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblBranch.Text = "MBA is Not Registered in this Academic Year";
                }
                else
                {
                    lblBranch.Text = ds.Tables[0].Rows[0][0].ToString();
                    con.Close();
                    Section1();
                }

            }
        }
        catch (Exception e1)
        {

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
    }
    protected void DDLBName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Subject();
       // year1();
        Faculty();
        DDLSubject.Items.Clear();
        DDLSubject.Items.Insert(0, new ListItem("Select", ""));
        DDLYear.SelectedIndex = 0;
        DDLSemester.SelectedIndex = 0;
        try
        {

            DDLFName.Items.Clear();
            DDLFName.Items.Insert(0, new ListItem("Select", ""));
            DDLYear.SelectedIndex = 0;
            if (DDLYear0.SelectedItem.Text == "Select")
            {

                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Academic Year')", true);
            }
            else if (DDLBName.SelectedItem.Text == "Select")
            {

                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select BranchName')", true);
            }
            else
            {
                da = new SqlDataAdapter("Select Distinct(Section) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                DDLSection.DataTextField = "Section";
                DDLSection.DataValueField = "Section";
                DDLSection.DataSource = ds.Tables[0];
                DDLSection.DataBind();
                DDLSection.Items.Insert(0, new ListItem("Select", ""));
                con.Close();
            }
        }
        catch (Exception e1)
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }

    }

    private void Faculty()
    {

        try
        {
            if (RadioButtonList1.SelectedItem.Text == "B.Tech" || RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                da = new SqlDataAdapter("Select Distinct(FacultyName) from Faculty_Details where Department='" + DDLDept.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                DDLFName.DataTextField = "FacultyName";
                DDLFName.DataValueField = "FacultyName";
                DDLFName.DataSource = ds.Tables[0];
                DDLFName.DataBind();
                DDLFName.Items.Insert(0, new ListItem("Select", ""));
                con.Close();

            }
            else
            {
                da = new SqlDataAdapter("Select Distinct(FacultyName) from Faculty_Details where Department='" + DDLDept.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                DDLFName.DataTextField = "FacultyName";
                DDLFName.DataValueField = "FacultyName";
                DDLFName.DataSource = ds.Tables[0];
                DDLFName.DataBind();
                DDLFName.Items.Insert(0, new ListItem("Select", ""));
                con.Close();
            }
        }
        catch (Exception e1)
        {
            string er = e1.Message;

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
        }
   
    }
    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DDLSubject.Items.Clear();
            DDLSubject.Items.Insert(0, new ListItem("Select", ""));
            ArrayList sem = new ArrayList();
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {

                if (DDLYear.SelectedValue == "1")
                {
                 
                    DDLSemester.Visible = false;
                    lblsem.Visible = false;
                    RFVSem.Visible = false;
                    Subject();
                    View1();
                    
                }
                else
                {
                    RFVSem.Visible = true;
                    DDLSemester.Visible = true;
                    lblsem.Visible = true;
                    for (int j = 1; j <= 2; j++)
                    {
                        sem.Add(j);

                    }
                    DDLSemester.DataSource = sem;
                    DDLSemester.DataBind();
                    DDLSemester.Items.Insert(0, new ListItem("Select", ""));
                }

            }
            else
            {
                RFVSem.Visible = true;
                DDLSemester.Visible = true;
                lblsem.Visible = true;
                for (int j = 1; j <= 2; j++)
                {
                    sem.Add(j);

                }
                DDLSemester.DataSource = sem;
                DDLSemester.DataBind();
                DDLSemester.Items.Insert(0, new ListItem("Select", ""));

            }
        }
        catch (Exception e1)
        {
            string er = e1.Message;

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
        }

    }

    private void Subject()
    {
        try
        {
            con.Close();
            if (DDLBName.SelectedItem.Text == "Select")
            {

                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select BranchName')", true);
                //MessageBox.Show("Plz Select BranchName", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);
   
            }
            else
            {

                da = new SqlDataAdapter("Select Distinct(Subject) from Subject_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Year='"+ DDLYear.SelectedItem.Text +"' and Regulation='"+ DDLReg.SelectedItem.Text +"'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                DDLSubject.DataTextField = "Subject";
                DDLSubject.DataValueField = "Subject";
                DDLSubject.DataSource = ds.Tables[0];
                DDLSubject.DataBind();
                DDLSubject.Items.Insert(0, new ListItem("Select", ""));
                con.Close();
            }
        }
        catch (Exception e1)
        {
            string er = e1.Message;

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
        }
    }


    protected void DDLSemester_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (RadioButtonList1.SelectedItem.Text == "B.Tech" || RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                if (DDLYear.SelectedItem.Text == "Select")
                {

                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Year')", true);
             
        
                }

                else
                {
                    da = new SqlDataAdapter("Select Distinct(Subject) from Subject_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Regulation='" + DDLReg.SelectedItem.Text + "'", con);
                    con.Open();
                    ds = new DataSet();
                    da.Fill(ds, "Coursename");
                    DDLSubject.DataTextField = "Subject";
                    DDLSubject.DataValueField = "Subject";
                    DDLSubject.DataSource = ds.Tables[0];
                    DDLSubject.DataBind();
                    DDLSubject.Items.Insert(0, new ListItem("Select", ""));
                    con.Close();
                }


            }
            else
            {
                da = new SqlDataAdapter("Select Distinct(Subject) from Subject_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + lblBranch.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Regulation='" + DDLReg.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                DDLSubject.DataTextField = "Subject";
                DDLSubject.DataValueField = "Subject";
                DDLSubject.DataSource = ds.Tables[0];
                DDLSubject.DataBind();
                DDLSubject.Items.Insert(0, new ListItem("Select", ""));
                con.Close();
                View2();
            }
            if (RadioButtonList1.SelectedItem.Text == "B.Tech" || RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                if (DDLYear.SelectedItem.Text != "1")
                {
                    View3();
                }
            }
           
        }

        catch (Exception e1)
        {
            string er = e1.Message;

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
        }

    }
    protected void DDLReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLBName.SelectedIndex = 0;
        DDLYear.SelectedIndex = 0;
        DDLSemester.SelectedIndex = 0;
        DDLSubject.Items.Clear();
        DDLSubject.Items.Insert(0, new ListItem("Select", ""));
        
    }


    protected void ButtSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                if (DDLYear.SelectedValue == "1")
                {
                    cmd = new SqlCommand("Select Subject from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Branch_Name='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Subject='" + DDLSubject.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Regulation='"+ DDLReg.SelectedItem.Text +"'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        

                     ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Already Assigned')", true);
  
                   //     MessageBox.Show("Already Assigned ", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        con.Close();
                        string s = RadioButtonList1.SelectedItem.Text;
                        cmd = new SqlCommand("insert into Assigned_Details values('" + s + "','" + DDLBName.SelectedItem.Text + "','" + DDLSection.SelectedItem.Text + "','" + DDLYear.SelectedItem.Text + "','NA','" + DDLFName.SelectedItem.Text + "','" + DDLSubject.SelectedItem.Text + "','" + DDLYear0.SelectedItem.Text + "','" + DDLReg.SelectedItem.Text + "','" + DDLDept.SelectedItem.Text + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //   Update();

                        ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Assigned Successfully')", true);
  
                        //MessageBox.Show("Assigned successfully..", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        View1();
                        // Response.Redirect("~/Administrator/AdminHome.aspx");

                    }

                }
                else
                {
                    cmd = new SqlCommand("Select FacultyName from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Branch_Name='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Subject='" + DDLSubject.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Already Assigned')", true);
  
                    }
                    else
                    {
                        con.Close();
                        string s = RadioButtonList1.SelectedItem.Text;
                        cmd = new SqlCommand("insert into Assigned_Details values('" + s + "','" + DDLBName.SelectedItem.Text + "','" + DDLSection.SelectedItem.Text + "','" + DDLYear.SelectedItem.Text + "','" + DDLSemester.SelectedItem.Text + "','" + DDLFName.SelectedItem.Text + "','" + DDLSubject.SelectedItem.Text + "','" + DDLYear0.SelectedItem.Text + "','" + DDLReg.SelectedItem.Text + "','" + DDLDept.SelectedItem.Text + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //   Update();

                        ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Assigned Successfully')", true);
                        View3();
                        // Response.Redirect("~/Administrator/AdminHome.aspx");

                    }
                }


            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                cmd = new SqlCommand("Select FacultyName from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Branch_Name='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Subject='" + DDLSubject.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Already Assigned')", true);
  
                    //MessageBox.Show("Already Assigned ", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    con.Close();
                    string s = RadioButtonList1.SelectedItem.Text;
                    cmd = new SqlCommand("insert into Assigned_Details values('" + s + "','" + DDLBName.SelectedItem.Text + "','" + DDLSection.SelectedItem.Text + "','" + DDLYear.SelectedItem.Text + "','" + DDLSemester.SelectedItem.Text + "','" + DDLFName.SelectedItem.Text + "','" + DDLSubject.SelectedItem.Text + "','" + DDLYear0.SelectedItem.Text + "','" + DDLReg.SelectedItem.Text + "','" + DDLDept.SelectedItem.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //   Update();

                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Assigned Successfully')", true);
  
                    //   MessageBox.Show("Assigned successfully..", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    View3();
                    // Response.Redirect("~/Administrator/AdminHome.aspx");

                }
            }
            else
            {
                cmd = new SqlCommand("Select FacultyName,Branch_Name,Section,Year from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Branch_Name='" + lblBranch.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Subject='" + DDLSubject.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Already Assigned')", true);
  
  //                  MessageBox.Show("Already Assigned ", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    con.Close();
                    string s = RadioButtonList1.SelectedItem.Text;
                    cmd = new SqlCommand("insert into Assigned_Details values('" + s + "','" + lblBranch.Text + "','" + DDLSection.SelectedItem.Text + "','" + DDLYear.SelectedItem.Text + "','" + DDLSemester.SelectedItem.Text + "','" + DDLFName.SelectedItem.Text + "','" + DDLSubject.SelectedItem.Text + "','" + DDLYear0.SelectedItem.Text + "','" + DDLReg.SelectedItem.Text + "','" + DDLDept.SelectedItem.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //   Update();

                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Assigned Successfully')", true);
  
                    //  MessageBox.Show("Assigned successfully..", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    View2();
                }

            }
        }
        catch (Exception e1)
        {

            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
  
            // MessageBox.Show("Abnormal Termination", "student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
    private void View3()
    {
        try
        {
            GridView1.Visible = true;
            da = new SqlDataAdapter("Select FacultyName,Department,Branch_Name,Section,Subject,AcademicYear from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Branch_Name='" + DDLBName.SelectedItem.Text + "' and Semester='"+ DDLSemester.SelectedItem.Text +"' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Regulation='"+ DDLReg.SelectedItem.Text +"'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            con.Close();
        }
        catch (Exception e1)
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    private void View1()
    {
        try
        {
            GridView1.Visible = true;
            da = new SqlDataAdapter("Select FacultyName,Department,Branch_Name,Section,Subject,AcademicYear from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Branch_Name='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Regulation='" + DDLReg.SelectedItem.Text + "'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            con.Close();
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    private void View2()
    {
        try
        {
            GridView1.Visible = true;
            da = new SqlDataAdapter("Select FacultyName,Department,Branch_Name,Section,Subject,AcademicYear from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Branch_Name='" + lblBranch.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "'  and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Regulation='" + DDLReg.SelectedItem.Text + "'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            con.Close();
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
  
    protected void ButtReset_Click(object sender, EventArgs e)
    {
        DDLBName.Visible = false;
        Label49.Visible = false;
        lblBranch.Visible = false;
        RadioButtonList1.ClearSelection();
        DDLBName.SelectedIndex = 0;
        DDLYear0.SelectedIndex = 0;
        DDLDept.SelectedIndex = 0;
        DDLFName.SelectedIndex = 0;
        DDLReg.SelectedIndex = 0;
        DDLSection.SelectedIndex = 0;
        DDLSemester.SelectedIndex = 0;
        DDLSubject.SelectedIndex = 0;
        DDLYear.SelectedIndex = 0;
       
    }
   
    protected void DDLDept_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Faculty();
       
        

    }
   
    protected void DDLSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLYear.SelectedIndex = 0;

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
                string d = GridView1.Rows[i].Cells[2].Text;
                cmd = new SqlCommand("delete from Assigned_Details where FacultyName='" + s + "' and Department='"+ d +"' and AcademicYear='"+ DDLYear0.SelectedItem.Text +"'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Successfully Deleted')", true);
                if (RadioButtonList1.SelectedItem.Text == "B.Tech")
                {
                    if (DDLYear.SelectedValue == "1")
                    {
                        View1();
                    }
                    else
                    {
                        View2();
                    }
                }
                else
                {
                    View2();
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
    protected void DDLAYear_SelectedIndexChanged(object sender, EventArgs e)
    {
       // Section();
    }
    protected void DDLYear0_SelectedIndexChanged(object sender, EventArgs e)
    {
        branch();
    }
}
