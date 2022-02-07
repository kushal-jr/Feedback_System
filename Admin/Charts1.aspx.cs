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


public partial class Admin_Charts1 : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
       

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DDLQuestion.Items.Clear();
            DDLQuestion.Items.Insert(0, new ListItem("Select", ""));
            DDLFName.SelectedIndex = 0;
            DDLFName.Items.Clear();
            DDLFName.Items.Insert(0, new ListItem("Select", ""));
            DDLsubject.Items.Clear();
            DDLsubject.Items.Insert(0, new ListItem("Select", ""));
            lblsem.Visible = true;
            DDLSemester.Visible = true;
            DDLSemester.SelectedIndex = 0;
            DDLSection.Items.Clear();
            DDLBName.Visible = false;
            Label49.Visible = false;
            lblBranch.Visible = false;
            DDLSemester.Items.Clear();
            DDLYear.Items.Clear();
            DDLSection.Items.Insert(0, new ListItem("Select", ""));
            DDLSemester.Items.Insert(0, new ListItem("Select", ""));
            DDLQuestion.SelectedIndex = 0;
            DDLQuestion.Items.Clear();
            DDLQuestion.Items.Insert(0, new ListItem("Select", ""));
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                
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
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
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
   
    private void ayear()
    {
        try
        {
           

                da = new SqlDataAdapter("Select Distinct(AcademicYear) from Student_Details where CourseName='"+ RadioButtonList1.SelectedItem.Text +"'", con);
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
            else if(RadioButtonList1.SelectedItem.Text=="MCA")
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
            else if(RadioButtonList1.SelectedItem.Text == "MBA")
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

    private void Section1()
    {
        try
        {
            if (DDLYear0.SelectedItem.Text == "Select")
            {

                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Academic Year')", true);
            }

            else
            {
                con.Close();
                da = new SqlDataAdapter("Select Distinct(Section) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
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
    protected void DDLBName_SelectedIndexChanged(object sender, EventArgs e)
    {
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
    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            ArrayList sem = new ArrayList();
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {

                if (DDLYear.SelectedValue == "1")
                {
                    
                    DDLSemester.Visible = false;
                    lblsem.Visible = false;
                  
                }
                else
                {
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

             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
    }

    private void Faculty1()
    {
        
        try
        {
            if (DDLBName.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select BranchName')", true);

                //MessageBox.Show("Plz Select BranchName", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (DDLYear0.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Academic Year')", true);

                //MessageBox.Show("Plz Select Section", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                da = new SqlDataAdapter("Select Distinct(FacultyName) from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and  Branch_Name='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "'", con);
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
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    protected void DDLSemester_SelectedIndexChanged(object sender, EventArgs e)
    {

       
       

    }
    private void Faculty3()
    {
        try
        {
            da = new SqlDataAdapter("Select Distinct(FacultyName) from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and  Branch_Name='" + lblBranch.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "'", con);
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
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    private void Faculty2()
    {
        try
        {
            da = new SqlDataAdapter("Select Distinct(FacultyName) from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and  Branch_Name='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Section='"+ DDLSection.SelectedItem.Text +"'", con);
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
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    protected void DDLFName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedItem.Text == "B.Tech")
        {
           // DDLQuestion.SelectedIndex = 0;
            if (DDLYear.SelectedItem.Text == "1")
            {
                try
                {
                    da = new SqlDataAdapter("Select Distinct(Subject) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='"+ DDLYear0.SelectedItem.Text +"'", con);
                    con.Open();
                    ds = new DataSet();
                    da.Fill(ds, "Coursename");
                    DDLsubject.DataTextField = "Subject";
                    DDLsubject.DataValueField = "Subject";
                    DDLsubject.DataSource = ds.Tables[0];
                    DDLsubject.DataBind();
                    DDLsubject.Items.Insert(0, new ListItem("Select", ""));
                //    DDLQuestion.Items.Insert(ds.Tables[0].Rows.Count+1, new ListItem("Select All", ""));
                    con.Close();
                }
                catch (Exception e1)
                {
                     //ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
                }
            }
            else
            {
                try
                {
                    da = new SqlDataAdapter("Select Distinct(Subject) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                    con.Open();
                    ds = new DataSet();
                    da.Fill(ds, "Coursename");
                    DDLsubject.DataTextField = "Subject";
                    DDLsubject.DataValueField = "Subject";
                    DDLsubject.DataSource = ds.Tables[0];
                    DDLsubject.DataBind();
                    DDLsubject.Items.Insert(0, new ListItem("Select", ""));
                    con.Close();
                }
                catch (Exception e1)
                {
                     ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
                }
            }
        }
        else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
        {
            try
            {
                da = new SqlDataAdapter("Select Distinct(Subject) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                DDLsubject.DataTextField = "Subject";
                DDLsubject.DataValueField = "Subject";
                DDLsubject.DataSource = ds.Tables[0];
                DDLsubject.DataBind();
                DDLsubject.Items.Insert(0, new ListItem("Select", ""));
                con.Close();
            }
            catch (Exception e1)
            {
                 ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
            }
        }
        else
        {
            try
            {
                da = new SqlDataAdapter("Select Distinct(Subject) from FeedBack_Details where BranchName='" + lblBranch.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                DDLsubject.DataTextField = "Subject";
                DDLsubject.DataValueField = "Subject";
                DDLsubject.DataSource = ds.Tables[0];
                DDLsubject.DataBind();
                DDLsubject.Items.Insert(0, new ListItem("Select", ""));
                con.Close();
            }
            catch (Exception e1)
            {
                 ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
            }
        }


       
    }
    protected void ButtSubmit_Click(object sender, EventArgs e)
    {
        string ques_name;
        int Ex=0, vg=0, g=0, sat=0, ns=0;
        try
        {
            if (DDLQuestion.SelectedItem.Text == "Select All")
            {
                if (RadioButtonList1.SelectedItem.Text == "B.Tech")
                {
                    if (DDLYear.SelectedValue == "1")
                    {
                        con.Close();
                        da = new SqlDataAdapter("Select Distinct(Question) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='"+ DDLsubject.SelectedItem.Text +"'", con);
                        con.Open();
                        ds = new DataSet();
                        da.Fill(ds);
                    }
                    else
                    {
                        con.Close();
                        da = new SqlDataAdapter("Select Distinct(Question) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "'", con);
                        con.Open();
                        ds = new DataSet();
                        da.Fill(ds);
                    }
                }
                else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
                {
                    con.Close();
                    da = new SqlDataAdapter("Select Distinct(Question) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "'", con);
                    con.Open();
                    ds = new DataSet();
                    da.Fill(ds);
                }
            
                else
                {
                    con.Close();
                    da = new SqlDataAdapter("Select Distinct(Question) from Feedback_Details where BranchName='" + lblBranch.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "'", con);
                    con.Open();
                    ds = new DataSet();
                    da.Fill(ds);
                }
            
                   
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    //con.Close();
                   // cmd = new SqlCommand("Select distinct Question from FeedBack_Details where FacultyName='" + DDLFName.SelectedItem.Text + "'", con);
                    //con.Open();
                   // ques_name = cmd.ExecuteScalar().ToString();
                    ques_name = ds.Tables[0].Rows[k]["Question"].ToString();
                if (RadioButtonList1.SelectedItem.Text == "B.Tech")
                {
                   if (DDLYear.SelectedValue == "1")
                    {
                        con.Close();
                        string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Question='" + ques_name + "' and Subject='" + DDLsubject.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FeedBack=";
                        cmd = new SqlCommand(query + "'Excellent'", con);
                        con.Open();
                        string s = cmd.ExecuteScalar().ToString();
                        Ex =Ex+ Convert.ToInt32(s); 
                        con.Close();
                        cmd = new SqlCommand(query + "'VeryGood'", con);
                        con.Open();
                        string s1= cmd.ExecuteScalar().ToString();
                        vg = vg + Convert.ToInt32(s1);
                        con.Close();
                        cmd = new SqlCommand(query + "'Good'", con);
                        con.Open();
                        string s2= cmd.ExecuteScalar().ToString();
                        g = g + Convert.ToInt32(s2);
                        con.Close();
                        cmd = new SqlCommand(query + "'Satisfactory'", con);
                        con.Open();
                        string s3 = cmd.ExecuteScalar().ToString();
                        sat = sat + Convert.ToInt32(s3);
                        con.Close();
                        cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                        con.Open();
                        string s4 = cmd.ExecuteScalar().ToString();
                        ns = ns + Convert.ToInt32(s4);
                        con.Close();
                        
                    }
                    else
                   {
                       con.Close();
                       string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Question='" + ques_name + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FeedBack=";
                        cmd = new SqlCommand(query + "'Excellent'", con);
                        con.Open();
                        string s = cmd.ExecuteScalar().ToString();
                        Ex = Ex + Convert.ToInt32(s);
                        con.Close();
                        cmd = new SqlCommand(query + "'VeryGood'", con);
                        con.Open();
                        string s1 = cmd.ExecuteScalar().ToString();
                        vg = vg + Convert.ToInt32(s1);
                        con.Close();
                        cmd = new SqlCommand(query + "'Good'", con);
                        con.Open();
                        string s2 = cmd.ExecuteScalar().ToString();
                        g = g + Convert.ToInt32(s2);
                        con.Close();
                        cmd = new SqlCommand(query + "'Satisfactory'", con);
                        con.Open();
                        string s3 = cmd.ExecuteScalar().ToString();
                        sat = sat + Convert.ToInt32(s3);
                        con.Close();
                        cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                        con.Open();
                        string s4 = cmd.ExecuteScalar().ToString();
                        ns = ns + Convert.ToInt32(s4);
                        con.Close();
                      //  Response.Redirect("./Graph.aspx");
                    }

                }
                else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
                {
                    con.Close();
                    string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and Question='" + ques_name + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FeedBack=";
                    cmd = new SqlCommand(query + "'Excellent'", con);
                    con.Open();
                    string s = cmd.ExecuteScalar().ToString();
                    Ex = Ex + Convert.ToInt32(s);
                    con.Close();
                    cmd = new SqlCommand(query + "'VeryGood'", con);
                    con.Open();
                    string s1 = cmd.ExecuteScalar().ToString();
                    vg = vg + Convert.ToInt32(s1);
                    con.Close();
                    cmd = new SqlCommand(query + "'Good'", con);
                    con.Open();
                    string s2 = cmd.ExecuteScalar().ToString();
                    g = g + Convert.ToInt32(s2);
                    con.Close();
                    cmd = new SqlCommand(query + "'Satisfactory'", con);
                    con.Open();
                    string s3 = cmd.ExecuteScalar().ToString();
                    sat = sat + Convert.ToInt32(s3);
                    con.Close();
                    cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                    con.Open();
                    string s4 = cmd.ExecuteScalar().ToString();
                    ns = ns + Convert.ToInt32(s4);
                    con.Close();
                }
                else
                {
                    con.Close();
                    string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + lblBranch.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and Question='" + ques_name + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FeedBack=";
                    cmd = new SqlCommand(query + "'Excellent'", con);
                    con.Open();
                    string s = cmd.ExecuteScalar().ToString();
                    Ex = Ex + Convert.ToInt32(s);
                    con.Close();
                    cmd = new SqlCommand(query + "'VeryGood'", con);
                    con.Open();
                    string s1 = cmd.ExecuteScalar().ToString();
                    vg = vg + Convert.ToInt32(s1);
                    con.Close();
                    cmd = new SqlCommand(query + "'Good'", con);
                    con.Open();
                    string s2 = cmd.ExecuteScalar().ToString();
                    g = g + Convert.ToInt32(s2);
                    con.Close();
                    cmd = new SqlCommand(query + "'Satisfactory'", con);
                    con.Open();
                    string s3 = cmd.ExecuteScalar().ToString();
                    sat = sat + Convert.ToInt32(s3);
                    con.Close();
                    cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                    con.Open();
                    string s4 = cmd.ExecuteScalar().ToString();
                    ns = ns + Convert.ToInt32(s4);
                    con.Close();
                }
                }
                Session["exval"] = Ex;
                Session["vgval"]=vg;
                Session["gval"]=g;
                Session["sval"]=sat;
                Session["nsval"] = ns;
                Response.Redirect("./Graph.aspx");
        }

            
            else
            {
                if (RadioButtonList1.SelectedItem.Text == "B.Tech")
                {
                    if (DDLYear.SelectedValue == "1")
                    {
                        string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and Question='" + DDLQuestion.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "' and Section='"+ DDLSection.SelectedItem.Text +"' and  FeedBack=";
                        cmd = new SqlCommand(query + "'Excellent'", con);
                        con.Open();
                        string s = cmd.ExecuteScalar().ToString();
                        Session["exval"] = Convert.ToInt32(s);
                        con.Close();
                        cmd = new SqlCommand(query + "'VeryGood'", con);
                        con.Open();
                        Session["vgval"] = cmd.ExecuteScalar().ToString();
                        con.Close();
                        cmd = new SqlCommand(query + "'Good'", con);
                        con.Open();
                        Session["gval"] = cmd.ExecuteScalar().ToString();
                        con.Close();
                        cmd = new SqlCommand(query + "'Satisfactory'", con);
                        con.Open();
                        Session["sval"] = cmd.ExecuteScalar().ToString();
                        con.Close();
                        cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                        con.Open();
                        Session["nsval"] = cmd.ExecuteScalar().ToString();
                        con.Close();
                        Response.Redirect("./Graph.aspx");
                    }
                    else
                    {
                        string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and Question='" + DDLQuestion.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FeedBack=";
                        cmd = new SqlCommand(query + "'Excellent'", con);
                        con.Open();
                        string s = cmd.ExecuteScalar().ToString();
                        Session["exval"] = Convert.ToInt32(s);
                        con.Close();
                        cmd = new SqlCommand(query + "'VeryGood'", con);
                        con.Open();
                        Session["vgval"] = cmd.ExecuteScalar().ToString();
                        con.Close();
                        cmd = new SqlCommand(query + "'Good'", con);
                        con.Open();
                        Session["gval"] = cmd.ExecuteScalar().ToString();
                        con.Close();
                        cmd = new SqlCommand(query + "'Satisfactory'", con);
                        con.Open();
                        Session["sval"] = cmd.ExecuteScalar().ToString();
                        con.Close();
                        cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                        con.Open();
                        Session["nsval"] = cmd.ExecuteScalar().ToString();
                        con.Close();
                        Response.Redirect("./Graph.aspx");
                    }

                }
                else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
                {
                    string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and Question='" + DDLQuestion.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FeedBack=";
                    cmd = new SqlCommand(query + "'Excellent'", con);
                    con.Open();
                    string s = cmd.ExecuteScalar().ToString();
                    Session["exval"] = Convert.ToInt32(s);
                    con.Close();
                    cmd = new SqlCommand(query + "'VeryGood'", con);
                    con.Open();
                    Session["vgval"] = cmd.ExecuteScalar().ToString();
                    con.Close();
                    cmd = new SqlCommand(query + "'Good'", con);
                    con.Open();
                    Session["gval"] = cmd.ExecuteScalar().ToString();
                    con.Close();
                    cmd = new SqlCommand(query + "'Satisfactory'", con);
                    con.Open();
                    Session["sval"] = cmd.ExecuteScalar().ToString();
                    con.Close();
                    cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                    con.Open();
                    Session["nsval"] = cmd.ExecuteScalar().ToString();
                    con.Close();
                    Response.Redirect("./Graph.aspx");
                }
                else
                {
                    string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + lblBranch.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and Question='" + DDLQuestion.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FeedBack=";
                    cmd = new SqlCommand(query + "'Excellent'", con);
                    con.Open();
                    string s = cmd.ExecuteScalar().ToString();
                    Session["exval"] = Convert.ToInt32(s);
                    con.Close();
                    cmd = new SqlCommand(query + "'VeryGood'", con);
                    con.Open();
                    Session["vgval"] = cmd.ExecuteScalar().ToString();
                    con.Close();
                    cmd = new SqlCommand(query + "'Good'", con);
                    con.Open();
                    Session["gval"] = cmd.ExecuteScalar().ToString();
                    con.Close();
                    cmd = new SqlCommand(query + "'Satisfactory'", con);
                    con.Open();
                    Session["sval"] = cmd.ExecuteScalar().ToString();
                    con.Close();
                    cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                    con.Open();
                    Session["nsval"] = cmd.ExecuteScalar().ToString();
                    con.Close();
                    Response.Redirect("./Graph.aspx");
                }
            }
          
        }
        catch (Exception e1)
        {
            // ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }

    protected void ButtReset_Click(object sender, EventArgs e)
    {
       
        DDLsubject.Items.Clear();
        DDLsubject.Items.Insert(0, new ListItem("Select All", ""));

        DDLYear0.Items.Clear();
        DDLYear0.Items.Insert(0, new ListItem("Select All", ""));

        DDLBName.Items.Clear();
        DDLBName.Items.Insert(0, new ListItem("Select All", ""));

        DDLFName.Items.Clear();
        DDLFName.Items.Insert(0, new ListItem("Select All", ""));

        DDLQuestion.Items.Clear();
        DDLQuestion.Items.Insert(0, new ListItem("Select All", ""));

        DDLSection.Items.Clear();
        DDLSection.Items.Insert(0, new ListItem("Select All", ""));

        DDLSemester.Items.Clear();
        DDLSemester.Items.Insert(0, new ListItem("Select All", ""));

        DDLYear.Items.Clear();
        DDLYear.Items.Insert(0, new ListItem("Select All", ""));

        RadioButtonList1.ClearSelection();
    }
    protected void DDLYear0_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        
            branch();
       
    }
    protected void DDLSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DDLsubject.SelectedIndex = 0;
            DDLQuestion.SelectedIndex = 0;
            if (RadioButtonList1.SelectedItem.Text == "B.Tech" || RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                if (RadioButtonList1.SelectedItem.Text == "B.Tech" && DDLYear.SelectedItem.Text == "1")
                {
                    Faculty1();
                }
                else
                {

                    if (DDLBName.SelectedItem.Text == "Select")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Branch Name')", true);

                        //MessageBox.Show("Plz Select BranchName", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if (DDLYear.SelectedItem.Text == "Select")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Year')", true);

                        // MessageBox.Show("Plz Select Year", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if (DDLSemester.SelectedItem.Text == "Select")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Semester')", true);


                        //MessageBox.Show("Plz Select Semester", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        Faculty2();
                    }
                }

            }
            else if (RadioButtonList1.SelectedItem.Text == "MCA" || RadioButtonList1.SelectedItem.Text == "MBA")
            {
                if (DDLYear.SelectedItem.Text == "Select")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Year')", true);

                    //MessageBox.Show("Plz Select Year", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (DDLSection.SelectedItem.Text == "Select")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Section')", true);

                    // MessageBox.Show("Plz Select Semester", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    Faculty3();
                }
            }
        }
        catch (Exception e1)
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    protected void DDLQuestion_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DDLsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedItem.Text == "B.Tech")
        {
            if (DDLYear.SelectedItem.Text == "1")
            {
                try
                {
                    da = new SqlDataAdapter("Select Distinct(Question) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='"+ DDLsubject.SelectedItem.Text +"'", con);
                    con.Open();
                    ds = new DataSet();
                    da.Fill(ds, "Coursename");
                    DDLQuestion.DataTextField = "Question";
                    DDLQuestion.DataValueField = "Question";
                    DDLQuestion.DataSource = ds.Tables[0];
                    DDLQuestion.DataBind();
                    DDLQuestion.Items.Insert(0, new ListItem("Select All", ""));
                    //    DDLQuestion.Items.Insert(ds.Tables[0].Rows.Count+1, new ListItem("Select All", ""));
                    con.Close();
                }
                catch (Exception e1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
                }
            }
            else
            {
                try
                {
                    da = new SqlDataAdapter("Select Distinct(Question) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "'", con);
                    con.Open();
                    ds = new DataSet();
                    da.Fill(ds, "Coursename");
                    DDLQuestion.DataTextField = "Question";
                    DDLQuestion.DataValueField = "Question";
                    DDLQuestion.DataSource = ds.Tables[0];
                    DDLQuestion.DataBind();
                    DDLQuestion.Items.Insert(0, new ListItem("Select All", ""));
                    con.Close();
                }
                catch (Exception e1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
                }
            }
        }
        else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
        {
            try
            {
                da = new SqlDataAdapter("Select Distinct(Question) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                DDLQuestion.DataTextField = "Question";
                DDLQuestion.DataValueField = "Question";
                DDLQuestion.DataSource = ds.Tables[0];
                DDLQuestion.DataBind();
                DDLQuestion.Items.Insert(0, new ListItem("Select All", ""));
                con.Close();
            }
            catch (Exception e1)
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
            }
        }
        else
        {
            try
            {
                da = new SqlDataAdapter("Select Distinct(Question) from FeedBack_Details where BranchName='" + lblBranch.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + DDLFName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + DDLsubject.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");
                DDLQuestion.DataTextField = "Question";
                DDLQuestion.DataValueField = "Question";
                DDLQuestion.DataSource = ds.Tables[0];
                DDLQuestion.DataBind();
                DDLQuestion.Items.Insert(0, new ListItem("Select All", ""));
                con.Close();
            }
            catch (Exception e1)
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
            }
        }



    }
}
