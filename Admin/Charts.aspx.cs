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


public partial class Administrator_Charts : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    SqlDataReader dr;
    static string facId;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
    
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Regulation();
          //  Panel1.Visible = false;
          //  GridView1.Visible = false;
            lblsem.Visible = true;
            DDLSemester.Visible = true;
            DDLSemester.SelectedIndex = 0;
            DDLSection.Items.Clear();
            DDLBName.Items.Clear();
            DDLSemester.Items.Clear();
            DDLYear.Items.Clear();
            DDLSection.Items.Insert(0, new ListItem("Select", ""));
            DDLSemester.Items.Insert(0, new ListItem("Select", ""));
            DDLSubject.Items.Clear();
            DDLSubject.Items.Insert(0, new ListItem("Select", ""));
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                lblBranch.Visible = false;
                branch();
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 4; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));

            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                lblBranch.Visible = false;
                branch();
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 2; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));


            }
            else if (RadioButtonList1.SelectedItem.Text == "MCA")
            {
                lblBranch.Visible = true;
                DDLBName.Visible = false;
                lblBranch.Text = "MCA";
                Section1();
                Faculty1();
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 3; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));

            }
            else if (RadioButtonList1.SelectedItem.Text == "MBA")
            {
                lblBranch.Visible = true;

                lblBranch.Text = "MBA";
                Section1();
                Faculty1();

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
            DDLBName.Visible = true;
            da = new SqlDataAdapter("Select Distinct(BranchName) from Course_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "'", con);
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
        catch (Exception e1)
        {

             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

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
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }

    protected void DDLBName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           
            da = new SqlDataAdapter("Select Distinct(Section) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "'", con);
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
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    private void Subject()
    {
        try
        {
            if (DDLBName.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select BranchName')", true);
               // MessageBox.Show("Plz Select BranchName", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (DDLReg.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Regulation')", true);
             
                //  MessageBox.Show("Plz Select Regulation", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {

                da = new SqlDataAdapter("Select Distinct(Subject) from Subject_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Regulation='"+ DDLReg.SelectedItem.Text +"'", con);
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
                    Subject();
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
    protected void DDLSemester_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (RadioButtonList1.SelectedItem.Text == "B.Tech" || RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                if (DDLYear.SelectedItem.Text == "Select")
                {

                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Year')", true);
             
                    //MessageBox.Show("PLz Select Year ", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (DDLReg.SelectedItem.Text == "Select")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Regulation')", true);
             
                    //MessageBox.Show("PLz Select Regulation ", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

  
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
            }
        }

        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    protected void DDLReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedItem.Text == "MCA" || RadioButtonList1.SelectedItem.Text == "MBA")
            {
                DDLYear.SelectedIndex = 0;
                DDLSemester.SelectedIndex = 0;
                DDLSubject.Items.Clear();
                DDLSubject.Items.Insert(0, new ListItem("Select", ""));
            }
            else
            {
                DDLBName.SelectedIndex = 0;
                DDLYear.SelectedIndex = 0;
                DDLSemester.SelectedIndex = 0;
                DDLSubject.Items.Clear();
                DDLSubject.Items.Insert(0, new ListItem("Select", ""));
            }
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }

    }
    protected void ButtSave_Click(object sender, EventArgs e)
    {

    }
    protected void DDLSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedItem.Text == "B.Tech")
        { 
            if (DDLBName.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select BranchName')", true);
             
                // MessageBox.Show("Plz Select BranchName", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
              else if (DDLYear.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Year')", true);
             
                  // MessageBox.Show("Plz Select Year", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (DDLYear.SelectedValue == "1")
            {
                Faculty1();
            }
            else
            {
                if (DDLSemester.SelectedItem.Text == "Select")
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
        else if(RadioButtonList1.SelectedItem.Text=="M.Tech")
        {
            if (DDLBName.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select BranchName')", true);
             
                // MessageBox.Show("Plz Select BranchName", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (DDLYear.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Year')", true);
             
            //    MessageBox.Show("Plz Select Year", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if(DDLSemester.SelectedItem.Text == "Select")
            {
               ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select semester')", true);
            
               // MessageBox.Show("Plz Select Semester", "Student FeedBack System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                Faculty2();
            }
                    
        }
        else 
        {
           
           if (DDLYear.SelectedItem.Text == "Select")
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
               Faculty3();
           }
           
        }
       
    }
    private void Faculty3()
    {
        try
        {
            da = new SqlDataAdapter("Select Distinct(FacultyName) from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and  BranchName='" + lblBranch.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "'", con);
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
            da = new SqlDataAdapter("Select Distinct(FacultyName) from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and  BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='"+ DDLSemester.SelectedItem.Text +"'", con);
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
    private void Faculty1()
    {
        try
        {
            da = new SqlDataAdapter("Select Distinct(FacultyName) from Assigned_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and  BranchName='"+ DDLBName.SelectedItem.Text +"' and Year='"+ DDLYear.SelectedItem.Text +"'", con);
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

}
