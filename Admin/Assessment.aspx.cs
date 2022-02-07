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

public partial class Admin_Assessment : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    float temp = 0;
    string fname;
    string BName;
    string Section2;
    string Year;
    string subject;
    string Semester;
    public string final;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["sfs"].ConnectionString);
        if (!IsPostBack)
        {
            GridView1.Visible = false;
            Label57.Visible = false;
            DDLBName.Visible = false;
            lblBranch.Visible = false;
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
            Label57.Visible = false;
            DDLBName.Visible = false;
            lblBranch.Visible = false;
            Clear();
            GridView1.Visible = false;
            DDLSemester.SelectedIndex = 0;
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {

                RequiredFieldValidator4.Visible = true;
                RequiredFieldValidator4.Enabled = true;
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
                ayear1();

            }
            else if (RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                RequiredFieldValidator4.Visible = true;
                RequiredFieldValidator4.Enabled = true;
                lblBranch.Visible = false;
                DDLSemester.Visible = true;
                lblsem.Visible = true;
                branch();
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
                RequiredFieldValidator4.Visible = false;
                RequiredFieldValidator4.Enabled = false;
                DDLSemester.Visible = true;
                lblsem.Visible = true;
                RequiredFieldValidator6.Enabled = true;
                lblBranch.Visible = true;
                DDLBName.Visible = false;
                lblBranch.Text = "";
               // Section1();
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

                RequiredFieldValidator4.Visible = false;
                RequiredFieldValidator4.Enabled = false;
                DDLSemester.Visible = true;
                lblsem.Visible = true;
                RequiredFieldValidator6.Enabled = true;
                lblBranch.Visible = true;
                DDLBName.Visible = false;
                lblBranch.Text = "";
                //Section1();
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
    private void branch()
    {
        try
        {
            if (RadioButtonList1.SelectedItem.Text == "B.Tech" || RadioButtonList1.SelectedItem.Text == "M.Tech")
            {
                lblBranch.Visible = false;

                DDLBName.Visible = true;
                Label57.Visible = true;
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
                Label57.Visible = true;
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
                Label57.Visible = true;
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
    private void Section()
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
        Clear();
     
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
            Clear();
            GridView1.Visible = false;
            ArrayList sem = new ArrayList();
            DDLSection.SelectedIndex = 0;
            if (RadioButtonList1.SelectedItem.Text == "B.Tech")
            {

                if (DDLYear.SelectedValue == "1")
                {
                    RequiredFieldValidator6.Enabled = false;
                    DDLSemester.Visible = false;
                    lblsem.Visible = false;
                  
                }
                else
                {
                    RequiredFieldValidator6.Enabled = true;
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
                RequiredFieldValidator6.Enabled = true;
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

    private void Clear()
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
    }
    protected void ButtSubmit_Click(object sender, EventArgs e)
    {

        
       
        int count_ques=0;
        int exval;
        int vgud;
        int gud;
        int sat;
        int nsat;
        float count_StudId=0;
       
        
        DataTable myDataTable = new DataTable();
        DataColumn myDataColumn = new DataColumn();
        myDataColumn = new DataColumn();
        myDataColumn.ColumnName = "FacultyName";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.ColumnName = "Department";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.ColumnName = "Section";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.ColumnName = "Year";
        myDataTable.Columns.Add(myDataColumn);


        myDataColumn = new DataColumn();
        myDataColumn.ColumnName = "Semester";
        myDataTable.Columns.Add(myDataColumn);



        myDataColumn = new DataColumn();
        myDataColumn.ColumnName = "Subject";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.ColumnName = "Percentage";
        myDataTable.Columns.Add(myDataColumn);

        
        if (RadioButtonList1.SelectedItem.Text == "B.Tech")
        {
            if (DDLYear.SelectedValue == "1")
            {
                try
                {  

                    GridView1.Visible = true;
                        da = new SqlDataAdapter("Select Distinct(FacultyName),BranchName,Department,Section,Year,Subject from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='"+ DDLYear.SelectedItem.Text +"' and AcademicYear='"+ DDLYear0.SelectedItem.Text +"'", con);
                        con.Open();
                        ds = new DataSet();
                        da.Fill(ds, "Coursename");

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        { 
                        con.Close();
                        temp = 0;
                        fname = ds.Tables[0].Rows[i]["FacultyName"].ToString();
                        BName = ds.Tables[0].Rows[i]["Department"].ToString();
                        Section2 = ds.Tables[0].Rows[i][3].ToString();
                        Year = ds.Tables[0].Rows[i][4].ToString();
                        subject = ds.Tables[0].Rows[i][5].ToString();
                        con.Close();
                        SqlDataAdapter da1 = new SqlDataAdapter("Select distinct(question) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Subject='" + subject + "' and FacultyName='" + fname + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        con.Open();
                       DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        count_ques=ds1.Tables[0].Rows.Count;
                        for (int k = 0; k < count_ques; k++)
                        {
                          //  con.Close();
                            //cmd = new SqlCommand("Select distinct Question from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and FacultyName='" + fname + "'", con);
                           // con.Open();
                            string ques_name = ds1.Tables[0].Rows[k]["Question"].ToString(); 
                            con.Close();
                            cmd = new SqlCommand("Select count(StudentId) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and FacultyName='" + fname + "' and Question='" + ques_name + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='"+ subject +"'", con);
                            con.Open();
                            count_StudId = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                            con.Close();
                            string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and FacultyName='" + fname + "'and Section='" + DDLSection.SelectedItem.Text + "' and Question='" + ques_name + "' and Year='" + DDLYear.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and Subject='" + subject + "' and FeedBack=";
                            cmd = new SqlCommand(query + "'Excellent'", con);
                            con.Open();
                            string s = cmd.ExecuteScalar().ToString();
                            exval = Convert.ToInt32(s);
                            con.Close();
                            cmd = new SqlCommand(query + "'VeryGood'", con);
                            con.Open();
                            vgud = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                           
                            con.Close();
                            cmd = new SqlCommand(query + "'Good'", con);
                            con.Open();
                            gud =Convert.ToInt32(cmd.ExecuteScalar().ToString());
                      
                            con.Close();
                            cmd = new SqlCommand(query + "'Satisfactory'", con);
                            con.Open();
                            sat =Convert.ToInt32(cmd.ExecuteScalar().ToString());
                           
                            con.Close();
                             cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                            con.Open();
                            nsat =Convert.ToInt32(cmd.ExecuteScalar().ToString());
                           
                            con.Close();

                            float tot_ns = exval*10 + vgud*8 + gud*6 + sat*4 + nsat*2;

                            float total = ((tot_ns *100)/(count_StudId*10));
                                //double total=in_perct* 100;
                            temp = temp + total;
                           



                        }
                       
                        float percent = temp / count_ques;
                        string percent1 = percent.ToString();
                        int n1 = Convert.ToInt32(percent1.Length);
                        if (n1 > 5)
                        {
                            final = percent1.Substring(0, 5).ToString();
                        }
                        else
                        {
                            final = percent1;
                        }
                        DataRow dataRow = myDataTable.NewRow();
                        dataRow["FacultyName"] = fname.ToString();
                        dataRow["Department"] = BName.ToString();
                        dataRow["Section"] = Section2.ToString();
                        dataRow["Year"] = Year.ToString();
                        dataRow["subject"] = subject.ToString();
                        dataRow["Percentage"] = final.ToString();
                        myDataTable.Rows.Add(dataRow);
                        GridView1.DataSource = myDataTable;
                        GridView1.DataBind();

                        con.Close();
                    }

                   
                }

                catch (Exception e1)
                {
                    string er = e1.Message;

                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
                }
            }
            else
            {
                try
                {
                    GridView1.Visible = true;
                    da = new SqlDataAdapter("Select Distinct(FacultyName),Department,Section,Year,Subject,Semester from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                    con.Open();
                    ds = new DataSet();
                    da.Fill(ds, "Coursename");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        con.Close();
                        temp = 0;
                        fname = ds.Tables[0].Rows[i][0].ToString();
                        BName = ds.Tables[0].Rows[i][1].ToString();
                        Section2 = ds.Tables[0].Rows[i][2].ToString();
                        Year = ds.Tables[0].Rows[i][3].ToString();
                        subject = ds.Tables[0].Rows[i][4].ToString();
                        Semester = ds.Tables[0].Rows[i][5].ToString();
                        con.Close();
                        SqlDataAdapter da1 = new SqlDataAdapter("Select distinct(question) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and FacultyName='" + fname + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        con.Open();
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        count_ques = ds1.Tables[0].Rows.Count;
                        for (int k = 0; k < count_ques; k++)
                        {
                            //con.Close();
                            //cmd = new SqlCommand("Select distinct Question from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "'and FacultyName='" + fname + "'", con);
                            //con.Open();
                            string ques_name = ds1.Tables[0].Rows[k]["Question"].ToString(); 
                            con.Close();
                            cmd = new SqlCommand("Select count(distinct StudentId) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and FacultyName='" + fname + "' and Question='" + ques_name + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                            con.Open();
                            count_StudId = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                            con.Close();
                            string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and FacultyName='" + fname + "' and Section='" + DDLSection.SelectedItem.Text + "' and Question='" + ques_name + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and FeedBack=";
                            cmd = new SqlCommand(query + "'Excellent'", con);
                            con.Open();
                            string s = cmd.ExecuteScalar().ToString();
                            exval = Convert.ToInt32(s);
                            con.Close();
                            cmd = new SqlCommand(query + "'VeryGood'", con);
                            con.Open();
                            vgud = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                            con.Close();
                            cmd = new SqlCommand(query + "'Good'", con);
                            con.Open();
                            gud = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                            con.Close();
                            cmd = new SqlCommand(query + "'Satisfactory'", con);
                            con.Open();
                            sat = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                            con.Close();

                            cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                            con.Open();
                            nsat = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                            con.Close();

                            float tot_ns = exval * 10 + vgud * 8 + gud * 6 + sat * 4 + nsat * 2;

                            float total = ((tot_ns * 100) / (count_StudId * 10));
                            //double total=in_perct* 100;
                            temp = temp + total;




                        }

                        float percent = temp / count_ques;
                        string percent1 = percent.ToString();
                        int n2 = Convert.ToInt32(percent1.Length);
                        if (n2 > 5)
                        {
                            final = percent1.Substring(0, 5).ToString();
                        }
                        else
                        {
                            final = percent1;
                        }
                        DataRow dataRow = myDataTable.NewRow();
                        dataRow["FacultyName"] = fname.ToString();
                        dataRow["Department"] = BName.ToString();
                        dataRow["Section"] = Section2.ToString();
                        dataRow["Year"] = Year.ToString();
                        dataRow["Semester"] = subject.ToString();
                        dataRow["subject"] = subject.ToString();
                        dataRow["Percentage"] = final.ToString();
                        myDataTable.Rows.Add(dataRow);
                        GridView1.DataSource = myDataTable;
                        GridView1.DataBind();
                        con.Close();
                    }

                }
                catch (Exception e1)
                {
                    string er = e1.Message;

                    ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
                }
            }

        }
        else if(RadioButtonList1.SelectedItem.Text=="M.Tech")
        {
            try
            {
                GridView1.Visible = true;
                da = new SqlDataAdapter("Select Distinct(FacultyName),Department,Section,Year,Subject,Semester from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    con.Close();
                    temp = 0;
                    fname = ds.Tables[0].Rows[i][0].ToString();
                    BName = ds.Tables[0].Rows[i][1].ToString();
                    Section2 = ds.Tables[0].Rows[i][2].ToString();
                    Year = ds.Tables[0].Rows[i][3].ToString();
                    subject = ds.Tables[0].Rows[i][4].ToString();
                    subject = ds.Tables[0].Rows[i][5].ToString();
                    con.Close();
                    SqlDataAdapter da1 = new SqlDataAdapter("Select distinct(question) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and FacultyName='" + fname + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                    con.Open();
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    count_ques = ds1.Tables[0].Rows.Count;
                    for (int k = 0; k < count_ques; k++)
                    {
                        //con.Close();
                        //cmd = new SqlCommand("Select distinct Question from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "'and FacultyName='" + fname + "'", con);
                        //con.Open();
                        string ques_name = ds1.Tables[0].Rows[k]["Question"].ToString(); 
                        con.Close();
                        cmd = new SqlCommand("Select count(distinct StudentId) from FeedBack_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and FacultyName='" + fname + "' and Question='" + ques_name + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        con.Open();
                        count_StudId = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                        con.Close();
                        string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + DDLBName.SelectedItem.Text + "' and FacultyName='" + fname + "' and Section='" + DDLSection.SelectedItem.Text + "' and Question='" + ques_name + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and FeedBack=";
                        cmd = new SqlCommand(query + "'Excellent'", con);
                        con.Open();
                        string s = cmd.ExecuteScalar().ToString();
                        exval = Convert.ToInt32(s);
                        con.Close();
                        cmd = new SqlCommand(query + "'VeryGood'", con);
                        con.Open();
                        vgud = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                        con.Close();
                        cmd = new SqlCommand(query + "'Good'", con);
                        con.Open();
                        gud = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                        con.Close();
                        cmd = new SqlCommand(query + "'Satisfactory'", con);
                        con.Open();
                        sat = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                        con.Close();

                        cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                        con.Open();
                        nsat = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                        con.Close();

                        int tot_ns = exval * 10 + vgud * 8 + gud * 6 + sat * 4 + nsat * 2;

                        float total = ((tot_ns * 100) / (count_StudId * 10));
                        //double total=in_perct* 100;
                        temp = temp + total;




                    }

                    float percent = temp / count_ques;
                    string percent1 = percent.ToString();
                    int n1 = Convert.ToInt32(percent1.Length);
                    if (n1 > 5)
                    {
                        final = percent1.Substring(0, 5).ToString();
                    }
                    else
                    {
                        final = percent1;
                    }
                    DataRow dataRow = myDataTable.NewRow();
                    dataRow["FacultyName"] = fname.ToString();
                    dataRow["Department"] = BName.ToString();
                    dataRow["Section"] = Section2.ToString();
                    dataRow["Year"] = Year.ToString();
                    dataRow["Semester"] = Semester.ToString();
                    dataRow["subject"] = subject.ToString();
                    dataRow["Percentage"] = final.ToString();
                    myDataTable.Rows.Add(dataRow);
                    GridView1.DataSource = myDataTable;
                    GridView1.DataBind();
                    con.Close();
                }
            }
            catch (Exception e1)
            {
                string er = e1.Message;

                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
            }
        }
        else
        {
            try
            {
                GridView1.Visible = true;
                da = new SqlDataAdapter("Select Distinct(FacultyName),Department,Section,Year,Subject,Semester from FeedBack_Details where BranchName='" + lblBranch.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                con.Open();
                ds = new DataSet();
                da.Fill(ds, "Coursename");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    con.Close();
                    temp = 0;
                    fname = ds.Tables[0].Rows[i][0].ToString();
                    BName = ds.Tables[0].Rows[i][1].ToString();
                    Section2 = ds.Tables[0].Rows[i][2].ToString();
                    Year = ds.Tables[0].Rows[i][3].ToString();
                    subject = ds.Tables[0].Rows[i][4].ToString();
                    Semester = ds.Tables[0].Rows[i][5].ToString();
                    con.Close();
                    SqlDataAdapter da1 = new SqlDataAdapter("Select Distinct(question) from FeedBack_Details where BranchName='" + lblBranch.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and FacultyName='" + fname + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                    con.Open();
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    count_ques = ds1.Tables[0].Rows.Count;
                    for (int k = 0; k < count_ques; k++)
                    {
                        //con.Close();
                        //cmd = new SqlCommand("Select distinct Question from FeedBack_Details where BranchName='" + lblBranch.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "'and FacultyName='" + fname + "'", con);
                        //con.Open();
                        string ques_name = ds1.Tables[0].Rows[k]["Question"].ToString(); 
                        con.Close();
                        cmd = new SqlCommand("Select count(distinct StudentId) from FeedBack_Details where BranchName='" + lblBranch.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and FacultyName='" + fname + "' and Question='" + ques_name + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "'", con);
                        con.Open();
                        count_StudId = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                        con.Close();
                        string query = "Select Count(FeedBack) from Feedback_Details where BranchName='" + lblBranch.Text + "' and Section='" + DDLSection.SelectedItem.Text + "' and FacultyName='" + fname + "' and Question='" + ques_name + "' and Year='" + DDLYear.SelectedItem.Text + "' and Semester='" + DDLSemester.SelectedItem.Text + "' and AcademicYear='" + DDLYear0.SelectedItem.Text + "' and FeedBack=";
                        cmd = new SqlCommand(query + "'Excellent'", con);
                        con.Open();
                        string s = cmd.ExecuteScalar().ToString();
                        exval = Convert.ToInt32(s);
                        con.Close();
                        cmd = new SqlCommand(query + "'VeryGood'", con);
                        con.Open();
                        vgud = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                        con.Close();
                        cmd = new SqlCommand(query + "'Good'", con);
                        con.Open();
                        gud = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                        con.Close();
                        cmd = new SqlCommand(query + "'Satisfactory'", con);
                        con.Open();
                        sat = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                        con.Close();

                        cmd = new SqlCommand(query + "'NotSatisfactory'", con);
                        con.Open();
                        nsat = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                        con.Close();

                        int tot_ns = exval * 10 + vgud * 8 + gud * 6 + sat * 4 + nsat * 2;

                    float total = ((tot_ns * 100) / (count_StudId * 10));
                        //double total=in_perct* 100;
                        temp = temp + total;




                    }

                    float percent = temp / count_ques;
                    string percent1 = percent.ToString();
                    int n1 = Convert.ToInt32(percent1.Length);
                    if (n1 > 5)
                    {
                        final = percent1.Substring(0, 5).ToString();
                    }
                    else
                    {
                        final = percent1;
                    }
                    DataRow dataRow = myDataTable.NewRow();
                    dataRow["FacultyName"] = fname.ToString();
                    dataRow["Department"] = BName.ToString();
                    dataRow["Section"] = Section2.ToString();
                    dataRow["Year"] = Year.ToString();
                    dataRow["Semester"] = Semester.ToString();
                    dataRow["subject"] = subject.ToString();
                    dataRow["Percentage"] = final.ToString();
                    myDataTable.Rows.Add(dataRow);
                    GridView1.DataSource = myDataTable;
                    GridView1.DataBind();
                    con.Close();
                }
            }
            catch (Exception e1)
            {
                string er = e1.Message;

                ClientScript.RegisterStartupScript(GetType(), "Onload", "alert('" + er + "')", true);
            }
        }

    }

    

   
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        
    }
    
    protected void DDLSemester_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        DDLSection.SelectedIndex = 0;
    }
    protected void DDLSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
    }
    protected void DDLYear0_SelectedIndexChanged(object sender, EventArgs e)
    {
        branch();
    }
}
