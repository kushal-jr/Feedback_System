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

public partial class Administrator_Section : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    SqlDataReader dr;
    public string sid4;
    string AYear;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);

        if (!IsPostBack)
        {
            lblBranch.Visible = false;
            DDLBName.Visible = false;
            Label55.Visible = false;
            Panel1.Visible = false;
            lblnstud.Visible = false;
            lbltotal.Visible = false;
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
          //  DDLYear.SelectedIndex = 0;
            lbltotal.Visible = false;
            lblnstud.Visible = false;
            RadioButtonList2.ClearSelection();
          //  DDLYear0.SelectedIndex = 0;
            DDLYear0.Items.Clear();
            DDLYear0.Items.Insert(0, new ListItem("Select", ""));
            lblBranch.Visible = false;
            DDLBName.Visible = false;
            Label55.Visible = false;
            DDLSection.SelectedIndex = 0;
            TBStud.Text = "";
            DDLBName.Items.Clear();
            DDLBName.Items.Insert(0, new ListItem("Select", ""));
           
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                RequiredFieldValidator34.Visible = true;
              //  branch();
                Panel1.Visible = true;
              

            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
               // branch();
                RequiredFieldValidator34.Visible = true;
                Panel1.Visible = false;
                ayear();
            }
            else if (RadioButtonList1.SelectedItem.Text == "MCA")
            {
                RequiredFieldValidator34.Visible = false;
                
               // lblBranch.Visible = true;
              //  DDLBName.Visible = false;
               // lblBranch.Text = "MCA";
                Panel1.Visible = false;
                ayear();

            }
            else if (RadioButtonList1.SelectedItem.Text == "MBA")
            {
                RequiredFieldValidator34.Visible = false;
              //  lblBranch.Visible = true;
              //  DDLBName.Visible = false;
               // lblBranch.Text = "MBA";
                Panel1.Visible = false;
                ayear();
             


            }

        }
        catch (Exception e1)
        {
            // ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }

    }

    private void students()
    {
        try
        {
            lblnstud.Visible = true;
            lbltotal.Visible = true;
            cmd = new SqlCommand("select count(StudentId) from Student_Details where Section='NA' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            lbltotal.Text = s;
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
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                lblBranch.Visible = false;

                DDLBName.Visible = true;
                Label55.Visible = true;
                da = new SqlDataAdapter("Select Distinct(BranchName) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and AdmissionType='"+ RadioButtonList2.SelectedItem.Text +"'", con);
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
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                lblBranch.Visible = false;

                DDLBName.Visible = true;
                Label55.Visible = true;
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
                Label55.Visible = true;
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

                }
                con.Close();
                count();
            }
            else if (RadioButtonList1.SelectedItem.Text == "MBA")
            {
                DDLBName.Visible = false;
                Label55.Visible = true;
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

                }
                count();
            }

        }
        catch (Exception e1)
        {
            ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }

    }    

    protected void DDLBName_SelectedIndexChanged1(object sender, EventArgs e)
    {
      
        count();


    }
  
    protected void ButtSave_Click(object sender, EventArgs e)
    {

        try
        {
            int tn = Convert.ToInt32(TBStud.Text);
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {
                if (RadioButtonList2.SelectedItem.Text == "Lateral Entry" || RadioButtonList2.SelectedItem.Text == "Transfer")
                {
                    cmd = new SqlCommand("select Min(StudentId) from Student_details where AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Section='NA' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'  and Year='2'", con);
                    con.Open();
                    string studentId = cmd.ExecuteScalar().ToString();
                    string sid1 = studentId.Substring(8, 2);
                    int sid2 = Convert.ToInt32(sid1);
                    int sid3 = sid2 + tn;
                    sid4 = studentId.Substring(0, 8);

                    for (int i = 0; i < tn; i++)
                    {
                        if (sid2 < 09)
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid2 = sid2 + 1;
                            studentId = sid4 + "0" + sid2;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                        else
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid2 = sid2 + 1;
                            studentId = sid4 + sid2;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                    }
                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Successfully allotted...')", true);

                    //  MessageBox.Show("Successfully allotted", "Student Feedback System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // DDLBName.SelectedIndex = 0;
                    DDLSection.SelectedIndex = 0;
                    TBStud.Text = "";
                    count();

                }

                else
                {
                    for (int i = 0; i < tn; i++)
                    {

                        cmd = new SqlCommand("select Min(StudentId) from Student_details where AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Section='NA' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Year='1'", con);
                        con.Open();
                        string studentId = cmd.ExecuteScalar().ToString();
                        string sid5 = studentId.Substring(0, 8);
                        string sid1 = studentId.Substring(8, 2);
                        string sid9 = sid1.Substring(0, 1);
                        string sid10 = sid1.Substring(1, 1);
                        int sid11 = Convert.ToInt32(sid10);


                        if (sid9 == "A")
                        {

                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "B")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "C")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "D")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "E")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "F")
                        {

                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "G")
                        {

                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "H")
                        {

                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "I")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "J")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "'  and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "K")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "L")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "M")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "N")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "O")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "P")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "Q")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "R")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "'  and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "S")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "T")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "'and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "U")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "V")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "W")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "X")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "'  and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "Y")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else if (sid9 == "Z")
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                            sid11 = sid11 + 1;
                            studentId = sid5 + sid9 + sid11;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            int sid2 = Convert.ToInt32(sid1);
                            int sid3 = sid2 + tn;
                            // string sid4 = studentId.Substring(0, 8);


                            if (sid2 < 09)
                            {
                                con.Close();
                                cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                                sid2 = sid2 + 1;
                                studentId = sid4 + "0" + sid2;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                            }
                            else
                            {
                                con.Close();
                                cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                                sid2 = sid2 + 1;
                                studentId = sid4 + sid2;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();

                            }

                        }

                    }

                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Successfully allotted...')", true);

                   // MessageBox.Show("Successfully allotted", "Student Feedback System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // DDLBName.SelectedIndex = 0;
                    DDLSection.SelectedIndex = 0;
                    TBStud.Text = "";
                    count();


                }



            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                for (int i = 0; i < tn; i++)
                {

                    cmd = new SqlCommand("select Min(StudentId) from Student_details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='NA' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='1' and semester='1'", con);
                    con.Open();
                    string studentId = cmd.ExecuteScalar().ToString();
                    string sid5 = studentId.Substring(0, 8);
                    string sid1 = studentId.Substring(8, 2);
                    string sid9 = sid1.Substring(0, 1);
                    string sid10 = sid1.Substring(1, 1);
                    int sid11 = Convert.ToInt32(sid10);


                    if (sid9 == "A")
                    {

                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "B")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and  AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "C")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and  CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "D")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "E")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "F")
                    {

                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "G")
                    {

                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "H")
                    {

                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "I")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "J")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "K")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "L")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "M")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "N")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "O")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "P")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "Q")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "R")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "S")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "T")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "U")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "V")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "W")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "X")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "Y")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "Z")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        int sid2 = Convert.ToInt32(sid1);
                        int sid3 = sid2 + tn;
                        // string sid4 = studentId.Substring(0, 8);


                        if (sid2 < 09)
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            sid2 = sid2 + 1;
                            studentId = sid4 + "0" + sid2;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                        else
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + DDLBName.SelectedItem.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            sid2 = sid2 + 1;
                            studentId = sid4 + sid2;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }

                    }
                }
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Successfully allotted...')", true);


               // MessageBox.Show("Successfully allotted", "Student Feedback System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblBranch.Visible = false;
                DDLSection.SelectedIndex = 0;
                TBStud.Text = "";
               // RadioButtonList1.ClearSelection();
                lbltotal.Visible = false;
                lblnstud.Visible = false;
                DDLBName.Visible = true;
                count();
               // DDLBName.SelectedIndex = 0;
            }
            else
            {
                //   int tn = Convert.ToInt32(TBStud.Text);
                for (int i = 0; i < tn; i++)
                {

                    cmd = new SqlCommand("select Min(StudentId) from Student_details where BranchName='" + lblBranch.Text + "' and Section='NA' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Year='1' and semester='1' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                    con.Open();
                    string studentId = cmd.ExecuteScalar().ToString();
                    string sid5 = studentId.Substring(0, 8);
                    string sid1 = studentId.Substring(8, 2);
                    string sid9 = sid1.Substring(0, 1);
                    string sid10 = sid1.Substring(1, 1);
                    int sid11 = Convert.ToInt32(sid10);


                    if (sid9 == "A")
                    {

                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "B")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "C")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "D")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "E")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "F")
                    {

                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "G")
                    {

                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "H")
                    {

                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "I")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "J")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "K")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "L")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "M")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "N")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "O")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "P")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "Q")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "R")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "S")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "T")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "U")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "V")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "W")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "X")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "Y")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (sid9 == "Z")
                    {
                        con.Close();
                        cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        sid11 = sid11 + 1;
                        studentId = sid5 + sid9 + sid11;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        int sid2 = Convert.ToInt32(sid1);
                        int sid3 = sid2 + tn;
                        // string sid4 = studentId.Substring(0, 8);


                        if (sid2 < 09)
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            sid2 = sid2 + 1;
                            studentId = sid4 + "0" + sid2;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                        else
                        {
                            con.Close();
                            cmd = new SqlCommand("Update Student_Details set Section='" + DDLSection.SelectedItem.Text + "' where BranchName='" + lblBranch.Text + "' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and StudentId='" + studentId + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            sid2 = sid2 + 1;
                            studentId = sid4 + sid2;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }

                    }
                }

                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Successfully allotted...')", true);

               // MessageBox.Show("Successfully allotted", "Student Feedback System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblBranch.Visible = false;
                DDLSection.SelectedIndex = 0;
                TBStud.Text = "";
                //RadioButtonList1.ClearSelection();
                lbltotal.Visible = false;
                lblnstud.Visible = false;
                DDLBName.Visible = true;
                count();
                //DDLBName.SelectedIndex = 0;
            }
        }

        catch (Exception e1)
        {

             ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
        }
       
    }
    

    protected void ButtReset_Click(object sender, EventArgs e)
    {
        RadioButtonList1.ClearSelection();
        RadioButtonList2.ClearSelection();
        DDLBName.SelectedIndex = 0;
        DDLSection.SelectedIndex = 0;
        TBStud.Text = "";
        DDLYear0.SelectedIndex = 0;
    }
    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        branch();
       
    }

    private void count()
    {
          if (RadioButtonList1.SelectedItem.Text == "B.Tech")
        {
            if (RadioButtonList2.SelectedIndex == -1)
            {
                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Plz Select Admission Type and BranhName')", true);

     
            }
            else
            {
                try
                {
                    lblnstud.Visible = true;
                    lbltotal.Visible = true;
                    cmd = new SqlCommand("select count(StudentId) from Student_Details where AdmissionType='" + RadioButtonList2.SelectedItem.Text + "' and BranchName='" + DDLBName.SelectedItem.Text + "' and Section='NA' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                    con.Open();
                    string s = cmd.ExecuteScalar().ToString();
                    con.Close();
                    lbltotal.Text = s;
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
                lblnstud.Visible = true;
                lbltotal.Visible = true;
                cmd = new SqlCommand("select count(StudentId) from Student_Details where AdmissionType='Regular' and BranchName='" + DDLBName.SelectedItem.Text + "' and Section='NA' and CourseName='" + RadioButtonList1.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                con.Open();
                string s = cmd.ExecuteScalar().ToString();
                con.Close();
                lbltotal.Text = s;
            }
            catch (Exception e1)
            {

                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('Abnormal Termination')", true);
            }
        }
        else
        {
            lblnstud.Visible = true;
            lbltotal.Visible = true;
            students();
        }

    }

    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DDLBName.SelectedIndex = 0;
        DDLBName.Items.Clear();
        DDLBName.Items.Insert(0, new ListItem("Select", ""));
   
        lblnstud.Visible = false;
        lbltotal.Visible = false;
        ayear1();
    }
    private void ayear1()
    {

        try
        {


            da = new SqlDataAdapter("Select Distinct(AcademicYear) from Student_Details where CourseName='" + RadioButtonList1.SelectedItem.Text + "' and Admissiontype='"+ RadioButtonList2.SelectedItem.Text +"'", con);
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

    
}