using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AppointmentHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        loadData();
    }

    protected void loadData()
    {
        try
        {
            DataSet ds;
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            int rowcount;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select RU.name, Ru.mobile, ru.mail, ap.dateneeded, ap.[status] from registeredusers as RU join appointments as AP on Ru.userID=Ap.UserID and Ap.UserID='" + (Session["UserID"]).ToString() + "'", conn))
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
}