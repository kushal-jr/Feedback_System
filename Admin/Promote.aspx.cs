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

public partial class Administrator_Promote : System.Web.UI.Page
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
            Panel1.Visible = false;
            ButtPromote1.Visible = false;
            GridView1.Visible = false;
            ButtPromote2.Visible = false;
            Panel2.Visible = false;
            
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
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Label49.Visible = false;
            DDLBName.Visible = false;
            lblBranch.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = false;
            GridView1.Visible = false;
            lblsem.Visible = true;
            DDLSemester.Visible = true;
            DDLSemester.SelectedIndex = 0;
            DDLSection.Items.Clear();
            DDLBName.Items.Clear();
            DDLSemester.Items.Clear();
            DDLYear.Items.Clear();
            DDLSection.Items.Insert(0, new ListItem("Select", ""));
            DDLSemester.Items.Insert(0, new ListItem("Select", ""));
            DDLYear0.ClearSelection();
            DDLYear0.Items.Insert(0, new ListItem("Select", ""));
            RadioButtonList2.ClearSelection();
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
               // lblBranch.Visible = false;
               // branch();
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 4; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
                Panel2.Visible = true;
                
            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
              //  lblBranch.Visible = false;
              //  branch();
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 2; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
                Panel2.Visible = false;
                ayear();
            }
            else if (RadioButtonList1.SelectedItem.Text == "MCA")
            {
               // lblBranch.Visible = true;
               // DDLBName.Visible = false;
                lblBranch.Text = "";
                //lblBranch.Text = "MCA";
               // Section1();
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 3; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
                Panel2.Visible = false;
                ayear();
            }
            else if (RadioButtonList1.SelectedItem.Text == "MBA")
            {
                lblBranch.Visible = true;
                lblBranch.Text = "";
               // lblBranch.Text = "MBA";
              //  Section1();
                            
                ArrayList year = new ArrayList();
                for (int i = 1; i <= 2; i++)
                {
                    year.Add(i);
                }
                DDLYear.DataSource = year;
                DDLYear.DataBind();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
                ayear();
                Panel2.Visible = false;
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
        try
        {


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
    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
            LBLMessage.Visible = false;
            Panel1.Visible = true;
            ButtPromote1.Visible = true;
            GridView1.Visible = true;
            ButtPromote2.Visible = true;
           
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {

                if (DDLYear.SelectedValue == "1")
                {
                    RequiredFieldValidator32.Enabled = false;
                    Studentdetails();
                }
                else
                {
                    Studentdetails1();
                }


            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                Studentdetails2();
            }
            else
            {
                RequiredFieldValidator25.Enabled = false;
                Studentdetails3();
            }


        }
        catch (Exception)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }

    private void Studentdetails3()
    {
        try
        {
            da = new SqlDataAdapter("Select StudentId,CourseName,BranchName,Year,Semester,Section from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "'  and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            con.Close();
            cmd = new SqlCommand("select count(StudentId) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "'  and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "'", con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            LBLMessage0.Text = s + " Records Found...";
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }

    private void Studentdetails2()
    {
        try
        {
            da = new SqlDataAdapter("Select StudentId,CourseName,BranchName,Year,Semester,Section from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            con.Close();
            cmd = new SqlCommand("select count(StudentId) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
           
            LBLMessage0.Text = s + " Records Found...";
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }

    private void Studentdetails1()
    {
        try
        {
            da = new SqlDataAdapter("Select StudentId,CourseName,BranchName,Year,Semester,Section from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            con.Close();
            cmd = new SqlCommand("select count(StudentId) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "'", con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            LBLMessage0.Text = s + " Records Found...";

        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }

    private void Studentdetails()
    {
        try
        {

            da = new SqlDataAdapter("Select StudentId,CourseName,BranchName,Year,Section,Semester from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and AdmissionType='"+ RadioButtonList2.SelectedItem.Text +"'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            con.Close();
            cmd = new SqlCommand("select count(StudentId) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "'", con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            LBLMessage0.Text = s + " Records Found...";
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                if (DDLYear.SelectedValue == "1")
                {
                    GridView1.PageIndex = e.NewPageIndex;
                    Studentdetails();

                }
                else
                {
                    GridView1.PageIndex = e.NewPageIndex;
                    Studentdetails1();
                }
            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                GridView1.PageIndex = e.NewPageIndex;
                Studentdetails2();
            }
            else
            {
                GridView1.PageIndex = e.NewPageIndex;
                Studentdetails3();
            }


        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    protected void Reset_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        RadioButtonList2.ClearSelection();
        DDLYear0.SelectedIndex = 0;
        DDLBName.Visible = false;
        DDLBName.Items.Clear();
        RadioButtonList1.ClearSelection();
        DDLYear0.Items.Clear();
        DDLYear0.Items.Insert(0, new ListItem("Select", ""));
        Label49.Visible = false;
        lblBranch.Visible = false;
        DDLSemester.Visible = true;
        DDLSemester.ClearSelection();
        DDLSemester.Items.Insert(0, new ListItem("Select", ""));
        if (RadioButtonList1.SelectedIndex == -1)
        {
           // DDLBName.SelectedIndex = 0;
          //  DDLBName.Items.Clear();
          //  DDLBName.Items.Insert(0, new ListItem("Select", ""));
            DDLSection.SelectedIndex = 0;
            DDLSection.Items.Clear();
            DDLSection.Items.Insert(0, new ListItem("Select", ""));
            DDLSemester.SelectedIndex = 0;
            DDLSemester.Items.Clear();
            DDLSemester.Items.Insert(0, new ListItem("Select", ""));
            DDLYear.SelectedIndex = 0;
            DDLYear.Items.Clear();
            DDLYear.Items.Insert(0, new ListItem("Select", ""));
        }
        else
        {
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                if (DDLYear.SelectedValue == "1")
                {

                  //  RadioButtonList1.ClearSelection();
                   // DDLBName.SelectedIndex = 0;
                 //   DDLBName.Items.Clear();
                //    DDLBName.Items.Insert(0, new ListItem("Select", ""));
                    DDLSection.SelectedIndex = 0;
                    DDLSection.Items.Clear();
                    DDLSection.Items.Insert(0, new ListItem("Select", ""));
                    DDLSemester.Visible = true;
                    lblsem.Visible = true;
                    DDLYear.SelectedIndex = 0;
                    DDLYear.Items.Clear();
                    DDLYear.Items.Insert(0, new ListItem("Select", ""));

                }
                else
                {
               //     RadioButtonList1.ClearSelection();
              //      DDLBName.SelectedIndex = 0;
              //      DDLBName.Items.Clear();
              //      DDLBName.Items.Insert(0, new ListItem("Select", ""));
                    DDLSection.SelectedIndex = 0;
                    DDLSection.Items.Clear();
                    DDLSection.Items.Insert(0, new ListItem("Select", ""));
                    DDLSemester.SelectedIndex = 0;
                    DDLSemester.Items.Clear();
                    DDLSemester.Items.Insert(0, new ListItem("Select", ""));
                    DDLYear.SelectedIndex = 0;
                    DDLYear.Items.Clear();
                    DDLYear.Items.Insert(0, new ListItem("Select", ""));
                }
            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
             //   RadioButtonList1.ClearSelection();
             //   DDLBName.SelectedIndex = 0;
             //   DDLBName.Items.Clear();
                //DDLBName.Items.Insert(0, new ListItem("Select", ""));
                DDLSection.SelectedIndex = 0;
                DDLSection.Items.Clear();
                DDLSection.Items.Insert(0, new ListItem("Select", ""));
                DDLSemester.SelectedIndex = 0;
                DDLSemester.Items.Clear();
                DDLSemester.Items.Insert(0, new ListItem("Select", ""));
                DDLYear.SelectedIndex = 0;
                DDLYear.Items.Clear();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));
            }
            else
            {
              //  RadioButtonList1.ClearSelection();
            //    DDLBName.Visible = true;
          //      lblBranch.Visible = false;
                DDLSection.SelectedIndex = 0;
                DDLSection.Items.Clear();
                DDLSection.Items.Insert(0, new ListItem("Select", ""));
                DDLSemester.SelectedIndex = 0;
                DDLSemester.Items.Clear();
                DDLSemester.Items.Insert(0, new ListItem("Select", ""));
                DDLYear.SelectedIndex = 0;
                DDLYear.Items.Clear();
                DDLYear.Items.Insert(0, new ListItem("Select", ""));

            }

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            LBLMessage.Text = "";
            LBLMessage.Visible = true;
            foreach (GridViewRow row in GridView1.Rows)
            {
                // int index = row.RowIndex;
                ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked = true;
            }
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            LBLMessage.Text = "";
            LBLMessage.Visible = true;
            foreach (GridViewRow row in GridView1.Rows)
            {
                // int index = row.RowIndex;
                ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked = false;
            }
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    protected void ButtPromote1_Click(object sender, EventArgs e)
    {

        
      Promote();
  
    }
    private void Promote()
    {
        try
        {
            int count = 0;
            string sno = "";
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                if (DDLYear.SelectedValue == "1")
                {

                   
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        //int index=row.RowIndex;

                        bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                        if (isChecked)
                        {
                            count++;
                            sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                            SqlCommand cmd = new SqlCommand("update Student_Details set Year='2', Semester='1' where BranchName='" + DDLBName.SelectedItem.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='"+ DDLYear0.SelectedItem.Text +"'", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                else
                {
                    
                    if (DDLSemester.SelectedValue == "1")
                    {
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            //int index=row.RowIndex;

                            bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                            if (isChecked)
                            {
                                count++;
                                sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                                SqlCommand cmd = new SqlCommand("update Student_Details set Semester='2' where BranchName='" + DDLBName.SelectedItem.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }

                    }
                    else
                    {
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            //int index=row.RowIndex;
                            int Year12 =Convert.ToInt32(DDLYear.SelectedValue.ToString());
                            Year12 = Year12 + 1;
                            bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                            if (isChecked)
                            {
                                count++;
                                sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                                SqlCommand cmd = new SqlCommand("update Student_Details set Year='" + Year12 + "',Semester='1' where BranchName='" + DDLBName.SelectedItem.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    
                    }

                }
                
            }
            else if(RadioButtonList1.SelectedItem.Text=="M.Tech")
            {
                if (DDLSemester.SelectedValue == "1")
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        //int index=row.RowIndex;

                        bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                        if (isChecked)
                        {
                            count++;
                            sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                            SqlCommand cmd = new SqlCommand("update Student_Details set Semester='2' where BranchName='" + DDLBName.SelectedItem.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }
                else
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        //int index=row.RowIndex;
                        int Year12 = Convert.ToInt32(DDLYear.SelectedValue.ToString());
                        Year12 = Year12 + 1;
                        bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                        if (isChecked)
                        {
                            count++;
                            sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                            SqlCommand cmd = new SqlCommand("update Student_Details set Year='" + Year12 + "',Semester='1' where BranchName='" + DDLBName.SelectedItem.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }

            }
            else
            {
                if (DDLSemester.SelectedValue == "1")
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        //int index=row.RowIndex;

                        bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                        if (isChecked)
                        {
                            count++;
                            sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                            SqlCommand cmd = new SqlCommand("update Student_Details set Semester='2' where BranchName='" + lblBranch.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }
                else
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        //int index=row.RowIndex;
                        int Year12 = Convert.ToInt32(DDLYear.SelectedValue.ToString());
                        Year12 = Year12 + 1;
                        bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                        if (isChecked)
                        {
                            count++;
                            sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                            SqlCommand cmd = new SqlCommand("update Student_Details set Year='" + Year12 + "',Semester='1' where BranchName='" + lblBranch.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }

            }
                                   
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                if (DDLYear.SelectedValue == "1")
                {
                    
                    Studentdetails();

                }
                else
                {
                   Studentdetails1();
                }
            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
              
                Studentdetails2();
            }
            else
            {
                
                Studentdetails3();
            }
            LBLMessage.Visible = true;
            LBLMessage.Text = count + " Student(s) Promoted...";
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    protected void ButtPromote2_Click(object sender, EventArgs e)
    {
      
           Promote();
       
    }

    protected void DDLYear0_SelectedIndexChanged(object sender, EventArgs e)
    {
        branch();
    }
    protected void BtnDelete1_Click(object sender, EventArgs e)
    {
        Delete();
    }
    private void Delete()
    {
        try
        {
            int count = 0;
            string sno = "";
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
               // if (DDLYear.SelectedValue == "1")
              //  {


                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        //int index=row.RowIndex;

                        bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                        if (isChecked)
                        {
                            count++;
                            sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                            SqlCommand cmd = new SqlCommand("delete from Student_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
              //  }
                //else
                //{

                //    if (DDLSemester.SelectedValue == "1")
                //    {
                //        foreach (GridViewRow row in GridView1.Rows)
                //        {
                //            //int index=row.RowIndex;

                //            bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                //            if (isChecked)
                //            {
                //                count++;
                //                sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                //                SqlCommand cmd = new SqlCommand("update Student_Details set Semester='2' where BranchName='" + DDLBName.SelectedItem.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                //                con.Open();
                //                cmd.ExecuteNonQuery();
                //                con.Close();
                //            }
                //        }

                //    }
                    //else
                    //{
                    //    foreach (GridViewRow row in GridView1.Rows)
                    //    {
                    //        //int index=row.RowIndex;
                    //        int Year12 = Convert.ToInt32(DDLYear.SelectedValue.ToString());
                    //        Year12 = Year12 + 1;
                    //        bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                    //        if (isChecked)
                    //        {
                    //            count++;
                    //            sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                    //            SqlCommand cmd = new SqlCommand("update Student_Details set Year='" + Year12 + "',Semester='1' where BranchName='" + DDLBName.SelectedItem.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                    //            con.Open();
                    //            cmd.ExecuteNonQuery();
                    //            con.Close();
                    //        }
                    //    }

                    //}

                }

            
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                //if (DDLSemester.SelectedValue == "1")
              //  {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        //int index=row.RowIndex;

                        bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                        if (isChecked)
                        {
                            count++;
                            sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                            SqlCommand cmd = new SqlCommand("delete from Student_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

            //    }
            //    else
            //    {
            //        foreach (GridViewRow row in GridView1.Rows)
            //        {
            //            //int index=row.RowIndex;
            //            int Year12 = Convert.ToInt32(DDLYear.SelectedValue.ToString());
            //            Year12 = Year12 + 1;
            //            bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
            //            if (isChecked)
            //            {
            //                count++;
            //                sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
            //                SqlCommand cmd = new SqlCommand("update Student_Details set Year='" + Year12 + "',Semester='1' where BranchName='" + DDLBName.SelectedItem.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
            //                con.Open();
            //                cmd.ExecuteNonQuery();
            //                con.Close();
            //            }
            //        }

            //    }

            //}
            //else
            //{
            //    if (DDLSemester.SelectedValue == "1")
            //    {
            //        foreach (GridViewRow row in GridView1.Rows)
            //        {
            //            //int index=row.RowIndex;

            //            bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
            //            if (isChecked)
            //            {
            //                count++;
            //                sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
            //                SqlCommand cmd = new SqlCommand("update Student_Details set Semester='2' where BranchName='" + lblBranch.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
            //                con.Open();
            //                cmd.ExecuteNonQuery();
            //                con.Close();
            //            }
            //        }

            //    }
            }
                else
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        //int index=row.RowIndex;
                        int Year12 = Convert.ToInt32(DDLYear.SelectedValue.ToString());
                        Year12 = Year12 + 1;
                        bool isChecked = ((System.Web.UI.WebControls.CheckBox)row.FindControl("chkbox")).Checked;
                        if (isChecked)
                        {
                            count++;
                            sno = (row.FindControl("lblSid") as System.Web.UI.WebControls.Label).Text;
                            SqlCommand cmd = new SqlCommand("delete from Student_Details where BranchName='" + lblBranch.Text + "' and StudentId='" + sno + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }

            

            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                if (DDLYear.SelectedValue == "1")
                {

                    Studentdetails();

                }
                else
                {
                    Studentdetails1();
                }
            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {

                Studentdetails2();
            }
            else
            {

                Studentdetails3();
            }
            LBLMessage.Visible = true;
            LBLMessage.Text = count + " Student(s) Deleted...";
        }
        catch (Exception e1)
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    protected void BtnDelete2_Click(object sender, EventArgs e)
    {
        Delete();
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ayear1();
        DDLBName.ClearSelection();
        DDLBName.Items.Insert(0,new ListItem("Select",""));
        DDLYear.SelectedIndex = 0;
        DDLSemester.SelectedIndex = 0;
        DDLSection.SelectedIndex = 0;
    }

    private void ayear1()
    {
        try
        {


            da = new SqlDataAdapter("Select Distinct(AcademicYear) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Admissiontype='" + RadioButtonList2.SelectedItem.Text + "'", con);
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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
