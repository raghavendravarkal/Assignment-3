using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomeDoctor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            laodAllPatient();
            loadActivePatients();
            loadAllAppointment();
        }
    }

    protected void loadAllAppointment()
    {
        try
        {
            DataSet ds;
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            int rowcount;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select RU.name, Ru.mobile, ru.mail, ap.dateneeded, ap.[status] from registeredusers as RU join appointments as AP on Ru.userID=Ap.UserID and Ap.DoctorID='" + (Session["UserID"]).ToString() + "'", conn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da.Fill(ds);
                    rowcount = Convert.ToInt32(ds.Tables[0].Rows.Count);
                    dataGrid1.DataSource = ds;
                    dataGrid1.DataBind();
                }
            }
            if (rowcount > 0)
            {
                div_MainPanel.Visible = true;
                div_mainPanelEmpty.Visible = false;
            }
            else
            {
                div_MainPanel.Visible = false;
                div_mainPanelEmpty.Visible = true;
            }
        }
        catch (Exception ec)
        {
        }
    }

    protected void laodAllPatient()
    {
        try
        {
            DataSet ds;
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            int rowcount;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select ru.UserId,ru.name from appointments as ap join  registeredusers as ru on ap.userid=ru.userid and ap.status='pending' and ap.doctorid='" + (Session["UserID"]).ToString() + "'", conn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da.Fill(ds);
                    rowcount = Convert.ToInt32(ds.Tables[0].Rows.Count);
                }
            }
            if (rowcount > 0)
            {
                ddl_patient.DataTextField = "name";
                ddl_patient.DataValueField = "userid";
                ddl_patient.DataSource = ds;
                ddl_patient.DataBind();
                ddl_patient.Items.Insert(0, new ListItem("Select", "Select"));
                ddl_patient.SelectedItem.Text = "Select";
            }
        }
        catch (Exception ex)
        { }
    }

    protected void loadActivePatients()
    {
        try
        {
            DataSet ds;
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            int rowcount;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select ru.UserId,ru.name from appointments as ap join  registeredusers as ru on ap.userid=ru.userid and ap.status='Active' and ap.doctorid='" + (Session["UserID"]).ToString() + "'", conn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da.Fill(ds);
                    rowcount = Convert.ToInt32(ds.Tables[0].Rows.Count);
                }
            }
            if (rowcount > 0)
            {
                ddl_PatientActive.DataTextField = "name";
                ddl_PatientActive.DataValueField = "userid";
                ddl_PatientActive.DataSource = ds;
                ddl_PatientActive.DataBind();
                ddl_PatientActive.Items.Insert(0, new ListItem("Select", "Select"));
                ddl_PatientActive.SelectedItem.Text = "Select";
            }
        }
        catch (Exception ex)
        { }
    }

    protected void ddl_patient_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds;
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            int rowcount;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select * from appointments where status ='pending' and userid='" + (ddl_patient.SelectedValue).ToString() + "'", conn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da.Fill(ds);
                    rowcount = Convert.ToInt32(ds.Tables[0].Rows.Count);
                }
            }
            if (rowcount > 0)
            {
                txt_patientName.Text = ddl_patient.SelectedItem.Text;
                txt_dateApptointment.Text = ds.Tables[0].Rows[0]["dateneeded"].ToString();
                txt_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            }

        }
        catch (Exception ec)
        {
        }
    }

    protected void btn_confirm_Click(object sender, EventArgs e)
    {
        try
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand da = new SqlCommand("update appointments set status='active' where Userid='" + ddl_patient.SelectedValue.ToString() + "' and  dateneeded ='" + Convert.ToDateTime(txt_dateApptointment.Text) + "'", conn))
                {
                    da.CommandType = CommandType.Text;
                    conn.Open();
                    da.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        catch (Exception ec)
        {
        }
        laodAllPatient();
        loadActivePatients();
        loadAllAppointment();
        txt_patientName.Text = "NA";
        txt_dateApptointment.Text = "NA";
        txt_status.Text = "NA";
        ddl_patient.SelectedValue = "Select";
    }


    protected void btn_CreatePrescription_Click(object sender, EventArgs e)
    {
        try
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand da = new SqlCommand("update appointments set Prescription='"+txt_prescription.Text+"', status='completed' where Userid='" + ddl_PatientActive.SelectedValue.ToString() + "' and  status ='active'", conn))
                {
                    da.CommandType = CommandType.Text;
                    conn.Open();
                    da.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        catch (Exception ec)
        {
        }
        laodAllPatient();
        loadActivePatients();
        loadAllAppointment();
        txt_prescription.Text = "";
        ddl_PatientActive.SelectedValue = "Select";
    }
}