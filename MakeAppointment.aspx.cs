using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MakeAppointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            ddl_SpecializationLoad();
        }
    }

    protected void ddl_SpecializationLoad()
    {
        try
        {
            DataSet ds;
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            int rowcount;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select Specialization,doctorid from doctordetails", conn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da.Fill(ds);
                    rowcount = Convert.ToInt32(ds.Tables[0].Rows.Count);
                }
            }
            if (rowcount > 0)
            {
              ddl_Specialization.DataTextField = "Specialization";
              ddl_Specialization.DataValueField = "doctorid";
              ddl_Specialization.DataSource = ds;
              ddl_Specialization.DataBind();
              ddl_Specialization.Items.Insert(0, new ListItem("Select", "Select"));
              ddl_Specialization.SelectedItem.Text = "Select";
            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddl_Specialization_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds;
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            int rowcount;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select name from registeredusers where userid='"+ddl_Specialization.SelectedValue.ToString()+"'", conn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da.Fill(ds);
                    rowcount = Convert.ToInt32(ds.Tables[0].Rows.Count);
                }
            }
            if (rowcount > 0)
            {

                ddl_Doctors.DataTextField = "name";
                ddl_Doctors.DataValueField = "name";
                ddl_Doctors.DataSource = ds;
                ddl_Doctors.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btn_Create_Click(object sender, EventArgs e)
    {
        try {
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand da = new SqlCommand("insert into [Appointments] (UserID,DoctorID,DateNeeded,[Status]) values ('" + (Session["UserID"]).ToString()+"','"+ddl_Specialization.SelectedValue.ToString()+"','"+Convert.ToDateTime(txt_Date.Text)+"','Pending')", conn))
                {
                    da.CommandType = CommandType.Text;
                    conn.Open();
                    da.ExecuteNonQuery();
                    conn.Close();
                }
            }
            Response.Redirect("Appointmenthistory.aspx");
        }
        catch (Exception ex)
        { }
    }
}