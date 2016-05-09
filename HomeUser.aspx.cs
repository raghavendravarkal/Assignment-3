using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomeUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["Role"].ToString() == "Doctor")
        {
            Response.Redirect("homedoctor.aspx");
        }
            if (!Page.IsPostBack)
        {
            loadActiveAppointment();
            loadddl_dateAppCompleted();
        }
    }

    protected void loadActiveAppointment()
    {
        try
        {

        }
        catch (Exception ec)
        {
        }

    }

    protected void btn_check_Click(object sender, EventArgs e)
    {

    }

    protected void loadddl_dateAppCompleted()
    {
        try
        {
            DataSet ds;
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            int rowcount;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select dateneeded from appointments where status='completed' and userid='" + (Session["UserID"]).ToString() + "'", conn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da.Fill(ds);
                    rowcount = Convert.ToInt32(ds.Tables[0].Rows.Count);
                }
            }
            if (rowcount > 0)
            {
                ddl_dateAppCompleted.DataTextField = "dateneeded";
                ddl_dateAppCompleted.DataValueField = "dateneeded";
                ddl_dateAppCompleted.DataSource = ds;
                ddl_dateAppCompleted.DataBind();
                ddl_dateAppCompleted.Items.Insert(0, new ListItem("Select", "Select"));
                ddl_dateAppCompleted.SelectedItem.Text = "Select";
            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddl_dateAppCompleted_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds;
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            int rowcount;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select prescription from appointments where dateneeded='"+Convert.ToDateTime(ddl_dateAppCompleted.SelectedValue.ToString())+"' and status='completed' and userid='" + (Session["UserID"]).ToString() + "'", conn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da.Fill(ds);
                    rowcount = Convert.ToInt32(ds.Tables[0].Rows.Count);
                }
            }
            if (rowcount > 0)
            {
                txt_prescription.Text = ds.Tables[0].Rows[0]["prescription"].ToString();
            }
            ddl_dateAppCompleted.SelectedValue = "Select";
        }
        catch (Exception ex)
        { }
    }
}