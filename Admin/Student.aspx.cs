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

public partial class Administrator_Student : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    public string s3;
    public string CollegeCode;
    public string Period;
    public string BranchCode;
    public string AdmissionCode;
    public string StudentId;
    public string CourseCode;
    public string AYear;
    public int left;
    public string s;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
      
        if (!IsPostBack)
        {
            year();
            AcademicYear();
            AcademicYear1();
            CollegeCode1();
            RequiredFieldValidator39.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }
    }

    private void AcademicYear1()
    {
        try
        {
            da = new SqlDataAdapter("Select EstablishedYear from College_Details", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "EstablishedYear");
            int year = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            ArrayList alyear = new ArrayList();
            int year1 = DateTime.Now.Year;
            for (int i = year; i <= year1; i++)
            {
                alyear.Add(i);
            }

            DDLTYear.DataSource = alyear;
            DDLTYear.DataBind();
            DDLTYear.Items.Insert(0, new ListItem("Select", ""));
            con.Close();

        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
    }

    private void AcademicYear()
    {
        try
        {
            da = new SqlDataAdapter("Select EstablishedYear from College_Details", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "EstablishedYear");
            int year = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            ArrayList alyear = new ArrayList();
            int year1 = DateTime.Now.Year;
            for (int i = year; i <= year1; i++)
            {
                alyear.Add(i);
            }

            DDLLYear.DataSource = alyear;
            DDLLYear.DataBind();
            DDLLYear.Items.Insert(0, new ListItem("Select", ""));
            con.Close();

        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
    }
    private void CollegeCode1()
    {
        try
        {

            da = new SqlDataAdapter("Select CollegeCode from College_Details", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Details");
            Session["CollegeCode"] = ds.Tables[0].Rows[0][0].ToString();
            con.Close();
        }
        catch (Exception e1)
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
             
            //MessageBox.Show("Abnormal Termination", "Student Feedback System", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }

    private void year()
    {
        try
        {
            da = new SqlDataAdapter("Select EstablishedYear from College_Details", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "EstablishedYear");
            int year=Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            ArrayList alyear = new ArrayList();
            int year1=DateTime.Now.Year;
            for (int i = year; i <= year1; i++)
            {
                alyear.Add(i);
            }
            DDLYear.DataSource = alyear;
            DDLYear.DataBind();
            DDLYear.Items.Insert(0, new ListItem("Select", ""));
            con.Close();
           
        }
        catch(Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RadioButtonList2.ClearSelection();
            DDLYear.SelectedIndex = 0;
            DDLTYear.SelectedIndex = 0;
            DDLLYear.SelectedIndex = 0;
            Session["AdmissionCode"] = 0;
            Session["CourseCode"] = 0;
            Session["BranchCode"] = 0;
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                RequiredFieldValidator39.Visible = true;
                Session["CourseCode"] = "A";
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
              //  DDLYear.SelectedIndex = 0;
              

            }
            else if(RadioButtonList1.SelectedItem.Text=="M.Tech")
            {
                RequiredFieldValidator39.Visible = true;
                Session["AdmissionCode"] = "1";
                Session["CourseCode"] = "D";
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
                Panel4.Visible = false;
               // DDLLYear.SelectedIndex = 0;
             
            }
            else if (RadioButtonList1.SelectedItem.Text == "MCA")
            {
                RequiredFieldValidator39.Visible = false;
                Session["AdmissionCode"] = "1";
                Session["CourseCode"] = "F";
                Session["BranchCode"] = "00";
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
                Panel4.Visible = false;
                //DDLYear.SelectedIndex = 0;
           

            }
            else if (RadioButtonList1.SelectedItem.Text == "MBA")
            {
                //DDLYear.SelectedIndex = 0;
                RequiredFieldValidator39.Visible = false;
                Session["AdmissionCode"] = "1";
                Session["CourseCode"] = "E";
                Session["BranchCode"] = "00";
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
                Panel4.Visible = false;
          
                

            }
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
        branch();
    }

    private void branch()
    {
        try
        {
            if (RadioButtonList1.SelectedItem.Text == "B.Tech" || RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                DDLBName.Visible = true;
                lblBranch.Visible = false;
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
            else if (RadioButtonList1.SelectedItem.Text == "MCA")
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
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["AdmissionCode"] = 0;
        if (RadioButtonList2.SelectedItem.Text == "Regular")
        {
            Session["AdmissionCode"] = "1";
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }
        else if (RadioButtonList2.SelectedItem.Text == "Lateral Entry")
        {
            branch1();
            Session["AdmissionCode"] = "5";
            Panel2.Visible = false;
            Panel3.Visible = true;
            Panel4.Visible = false;
        }
        else
        {
            branch2();
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = true;
        }

    }

    private void branch2()
    {
        try
        {
            da = new SqlDataAdapter("Select Distinct(BranchName) from Course_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            DDLTBName.DataTextField = "BranchName";
            DDLTBName.DataValueField = "BranchName";
            DDLTBName.DataSource = ds.Tables[0];
            DDLTBName.DataBind();
            DDLTBName.Items.Insert(0, new ListItem("Select", ""));
            con.Close();
        }

        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
    }

    private void branch1()
    {
        try
        {
            da = new SqlDataAdapter("Select Distinct(BranchName) from Course_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "'", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "Coursename");
            DDLLBName.DataTextField = "BranchName";
            DDLLBName.DataValueField = "BranchName";
            DDLLBName.DataSource = ds.Tables[0];
            DDLLBName.DataBind();
            DDLLBName.Items.Insert(0, new ListItem("Select", ""));
            con.Close();
        }
                  
       catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
        
    }
    protected void ButtRSave_Click(object sender, EventArgs e)
    {
        int cont;
      
        try
        {
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                da = new SqlDataAdapter("select Count(StudentId) from Student_Details where AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + Session["AYear"] + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Details");
                cont = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                con.Close();
                left = 359 - cont;
            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                da = new SqlDataAdapter("select Count(StudentId) from Student_Details where AdmissionType='Regular' and AcademicYear='" + Session["AYear"] + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Details");
                cont = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                con.Close();
                left = 359 - cont;
            }
            else if (RadioButtonList1.SelectedItem.Text == "MCA" || RadioButtonList1.SelectedItem.Text == "MBA")
            {

                da = new SqlDataAdapter("select Count(StudentId) from Student_Details where AcademicYear='" + Session["AYear"] + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and BranchName='" + lblBranch.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Details");
                cont = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                con.Close();
                left = 359 - cont;
            }
            int student = Convert.ToInt32(TBStud.Text);
            if (student <= left)
            {

                Period = DDLYear.SelectedItem.Text;
                string s2 = Period.Substring(2, 2);
                StudentId = s2 +Session["CollegeCode"] +Session["AdmissionCode"] + Session["CourseCode"] + Session["BranchCode"];
                int NS = Convert.ToInt32(TBStud.Text);
                for (int j = 0; j < NS; j++)
                {
                    con.Close();
                    if (RadioButtonList1.SelectedItem.Text == "B.Tech" )
                    {
                        cmd = new SqlCommand("select max(StudentId) from Student_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + Session["AYear"] + "'", con);
                        con.Open();
                        s = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }
                    else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
                    {
                        cmd = new SqlCommand("select max(StudentId) from Student_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + Session["AYear"] + "'", con);
                        con.Open();
                        s = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }
                    else if (RadioButtonList1.SelectedItem.Text == "MCA" || RadioButtonList1.SelectedItem.Text == "MBA")
                    {
                        cmd = new SqlCommand("select max(StudentId) from Student_Details where BranchName='" + lblBranch.Text + "' and AcademicYear='" + Session["AYear"] + "'", con);
                        con.Open();
                        s = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }

                    if (s == "")
                    {

                        s3 = StudentId + "01";
                        insertdata(s3);

                    }
                    else
                    {

                        string s5 = s.Substring(0, 8);
                        string sn = s.Substring(8, 2);
                        string sn9 = sn.Substring(0, 1);
                        if (sn.Equals("99"))
                        {
                            string sid = "A0";
                            string s7 = sid.ToString();
                            s3 = s5 + s7;
                            insertdata(s3);

                        }
                        else if (sn9 == "A")
                        {
                            if (sn == "A9")
                            {
                                string sid = "B0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "A" + sn3;
                                insertdata(s3);
                            }

                        }
                        else if (sn9 == "B")
                        {
                            if (sn == "B9")
                            {
                                string sid = "C0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "B" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "C")
                        {
                            if (sn == "C9")
                            {
                                string sid = "D0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "C" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "D")
                        {
                            if (sn == "D9")
                            {
                                string sid = "E0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "D" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "E")
                        {
                            if (sn == "E9")
                            {
                                string sid = "F0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "E" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "F")
                        {
                            if (sn == "F9")
                            {
                                string sid = "G0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "F" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "G")
                        {
                            if (sn == "G9")
                            {
                                string sid = "H0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "G" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "H")
                        {
                            if (sn == "H9")
                            {
                                string sid = "I0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "H" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "I")
                        {
                            if (sn == "I9")
                            {
                                string sid = "J0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "I" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "J")
                        {
                            if (sn == "J9")
                            {
                                string sid = "K0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "J" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "K")
                        {
                            if (sn == "K9")
                            {
                                string sid = "L0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "K" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "L")
                        {
                            if (sn == "L9")
                            {
                                string sid = "M0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "L" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "M")
                        {
                            if (sn == "M9")
                            {
                                string sid = "N0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "M" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "N")
                        {
                            if (sn == "N9")
                            {
                                string sid = "O0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "N" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "O")
                        {
                            if (sn == "O9")
                            {
                                string sid = "P0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "O" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "P")
                        {
                            if (sn == "P9")
                            {
                                string sid = "Q0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "P" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "Q")
                        {
                            if (sn == "Q9")
                            {
                                string sid = "R0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "Q" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "R")
                        {
                            if (sn == "R9")
                            {
                                string sid = "S0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "R" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "S")
                        {
                            if (sn == "S9")
                            {
                                string sid = "T0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "S" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "T")
                        {
                            if (sn == "T9")
                            {
                                string sid = "U0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "T" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "U")
                        {
                            if (sn == "U9")
                            {
                                string sid = "V0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "U" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "V")
                        {
                            if (sn == "V9")
                            {
                                string sid = "W0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "V" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "W")
                        {
                            if (sn == "W9")
                            {
                                string sid = "X0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "W" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "X")
                        {
                            if (sn == "X9")
                            {
                                string sid = "Y0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "X" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "Y")
                        {
                            if (sn == "Y9")
                            {
                                string sid = "Z0";
                                string s7 = sid.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {
                                string sn2 = sn.Substring(1, 1);
                                int sn3 = Convert.ToInt32(sn2);
                                sn3 = sn3 + 1;
                                s3 = s5 + "Y" + sn3;
                                insertdata(s3);
                            }
                        }
                        else if (sn9 == "Z")
                        {

                            string sn2 = sn.Substring(1, 1);
                            int sn3 = Convert.ToInt32(sn2);
                            sn3 = sn3 + 1;
                            s3 = s5 + "Z" + sn3;
                            insertdata(s3);

                        }
                        else if (sn9 == "0")
                        {

                            int i = Convert.ToInt32(sn);
                            if (i == 9)
                            {
                                i = i + 1;
                                string s7 = i.ToString();
                                s3 = s5 + s7;
                                insertdata(s3);
                            }
                            else
                            {

                                i = i + 1;
                                string s7 = i.ToString();

                                s3 = s5 + "0" + s7;
                                insertdata(s3);
                            }
                        }
                        else
                        {
                            int i = Convert.ToInt32(sn);
                            i = i + 1;
                            string s7 = i.ToString();

                            s3 = s5 + s7;
                            insertdata(s3);
                        }

                    }
                    con.Close();
                }
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully')", true);

                //  ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);
                //DropDownList1.SelectedIndex = 0;
                TBStud.Text = "";

            }
            else
            {
                if (left != 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Not Available,select below' + left)", true);

                    // MessageBox.Show("Not Available,Select below " + left, "Student Feedback System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Students Already Filled')", true);

                    // MessageBox.Show("Students Already Filled", "Student Feedback System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }
        catch (Exception e1)
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }

    }
    private void insertdata(string s3)
    {
       
        try
        {
            if (RadioButtonList1.SelectedItem.Text == "B.Tech" )
            {
                cmd = new SqlCommand("insert into Student_Details values('" + s3 + "','" + s3 + "','" + RadioButtonList1.SelectedItem.Text + "','" + DDLBName.SelectedItem.Text + "','" + RadioButtonList2.SelectedItem.Text + "','" + Session["AYear"] + "','1','NA','NA')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                s3 = "";
                TBStud.Text = "";
                con.Close();
            }
            else if(RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                cmd = new SqlCommand("insert into Student_Details values('" + s3 + "','" + s3 + "','" + RadioButtonList1.SelectedItem.Text + "','" + DDLBName.SelectedItem.Text + "','Regular','" + Session["AYear"] + "','1','1','NA')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                s3 = "";
                TBStud.Text = "";
                con.Close();
            }
            else if (RadioButtonList1.SelectedItem.Text == "MCA" || RadioButtonList1.SelectedItem.Text == "MBA")
            {
                con.Close();
                cmd = new SqlCommand("insert into Student_Details values('" + s3 + "','" + s3 + "','" + RadioButtonList1.SelectedItem.Text + "','" + lblBranch.Text + "',' Regular ','" + Session["AYear"] + "','1','1','NA')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                TBStud.Text = "";
                s3 = "";
                con.Close();
            }

        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }
        //  //  MessageBox.Show("Registered successfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    protected void DDLBName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Session["BranchCode"] = 0;
            if (DDLBName.SelectedItem.Text == "Select")
            {
               // ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select...')", true);

                //  MessageBox.Show("Plz Select..", "Student Feedback System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                da = new SqlDataAdapter("Select BranchCode from Course_Details Where BranchName='" + DDLBName.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Details");
                Session["BranchCode"] = ds.Tables[0].Rows[0][0].ToString();
                con.Close();
            }
        }
        catch (Exception e1)
        {
         //   ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select...')", true);

        }
    }
    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
      


       try
       {
           string Year = DDLYear.SelectedItem.Text;
           int year1 = Convert.ToInt32(Year);
           Session["AYear"] = 0;
           if (RadioButtonList1.SelectedItem.Text == "B.Tech")
           {
               year1 = year1 + 4;
               Session["AYear"] = Year +"-"+ year1;

           }
           else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
           {
               year1 = year1 + 2;
               Session["AYear"] = Year + "-" + year1;
           }
           else if (RadioButtonList1.SelectedItem.Text == "MCA")
           {
               year1 = year1 + 3;
               Session["AYear"] = Year + "-" + year1;
           }
           else if (RadioButtonList1.SelectedItem.Text == "MBA")
           {
               year1 = year1 + 2;
               Session["AYear"] = Year + "-" + year1;
           }
       }
       catch (Exception e1)
       {

           // ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
       }
    }
    protected void ButtLSave_Click(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("insert into Student_Details values('" + TBSID.Text + "','" + TBSID.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DDLLBName.SelectedItem.Text + "','" + RadioButtonList2.SelectedItem.Text + "','" + Session["AYear"] + "','2','1','NA')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);

            // ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);
          
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);

        }

    }
    protected void DDLLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
       


        try
        {
            string Year = DDLLYear.SelectedItem.Text;
            int year1 = Convert.ToInt32(Year);
            Session["AYear"] = 0;
            if (RadioButtonList2.SelectedItem.Text == "Lateral Entry")
            {
                year1 = year1 + 3;
                Session["AYear"] = Year + "-" + year1;

            }
        
        }
        catch (Exception e1)
        {
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
    }
    protected void ButttSave_Click(object sender, EventArgs e)
    {
        try
        {
            string ay1, ay2, ay3,ay5,ay8;
            int ay4, ay7, ay6;
            int AYear1 =Convert.ToInt32(DDLTYear.SelectedItem.Text);
            int dtime = Convert.ToInt32(DateTime.Now.Year);
            ay1 = TBTSId.Text;
            ay2 = ay1.Substring(0, 2);
            ay3 = ay1.Substring(2, 8);
            ay4 = Convert.ToInt32(ay2);
            ay6 = 20;
           
            ay8 = ay6.ToString() + ay2;
            ay7 =Convert.ToInt32(ay8) + 4;
            ay5 = ay8 + "-" + ay7;
            int diff =AYear1-Convert.ToInt32(ay8);

            if (diff == 0)
            {

                cmd = new SqlCommand("insert into Student_Details values('" + TBTSId.Text + "','" + TBTSId.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DDLTBName.SelectedItem.Text + "','" + RadioButtonList2.SelectedItem.Text + "','" + ay5 + "','1','NA','NA')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                 ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);

            }
            else if(diff==1)
            {
                cmd = new SqlCommand("insert into Student_Details values('" + TBTSId.Text + "','" + TBTSId.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DDLTBName.SelectedItem.Text + "','" + RadioButtonList2.SelectedItem.Text + "','" + ay5 + "','2','1','NA')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                 ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);

            }
            else if (diff == 2)
            {
                cmd = new SqlCommand("insert into Student_Details values('" + TBTSId.Text + "','" + TBTSId.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DDLTBName.SelectedItem.Text + "','" + RadioButtonList2.SelectedItem.Text + "','" + ay5 + "','3','1','NA')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                 ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);

            }
            else if (diff == 3)
            {
                cmd = new SqlCommand("insert into Student_Details values('" + TBTSId.Text + "','" + TBTSId.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DDLTBName.SelectedItem.Text + "','" + RadioButtonList2.SelectedItem.Text + "','" + ay5 + "','4','1','NA')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                 ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Registered Successfully...')", true);

            }
           
        }
        catch (Exception e1)
        {
            string exp = e1.Message;
             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('exp')", true);

        }
    }
    protected void DDLTYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        


    }
    protected void ButtReset_Click(object sender, EventArgs e)
    {
        DDLTBName.SelectedIndex = 0;
        DDLTYear.SelectedIndex = 0;
        TBTSId.Text = "";
    }
    protected void ButtLReset_Click(object sender, EventArgs e)
    {
        DDLLBName.SelectedIndex = 0;
        DDLLYear.SelectedIndex = 0;
        TBSID.Text = "";
    }
    protected void ButtRReset_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedItem.Text == "B.Tech" || RadioButtonList1.SelectedItem.Text == "M.Tech")
        {

            DDLBName.SelectedIndex = 0;
            DDLYear.SelectedIndex = 0;
            TBStud.Text = "";
        }
        else
        {  
            DDLYear.SelectedIndex = 0;
            TBStud.Text = "";
        }

    }
    protected void TBStud_TextChanged(object sender, EventArgs e)
    {
        int stud = Convert.ToInt32(TBStud.Text);
        int stud1=359;

        if (stud > stud1)
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Enter >= 359')", true);
            TBStud.Text = "";
        }
    
    }
}
