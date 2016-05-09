using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InsuranceDetails : System.Web.UI.Page
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
                using (SqlDataAdapter da = new SqlDataAdapter("select * from RegisteredUsers as RU join InsuranceDetails as ID on ID.insurancenumber=RU.insurancenumber and ru.userid='" + (Session["UserID"]).ToString() + "'", conn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da.Fill(ds);
                    rowcount = Convert.ToInt32(ds.Tables[0].Rows.Count);
                }
            }
            if (rowcount > 0)
            {
                txt_UserID.Text = ds.Tables[0].Rows[0]["name"].ToString();
                txt_id.Text = ds.Tables[0].Rows[0]["insuranceNumber"].ToString();
                txt_date.Text = ds.Tables[0].Rows[0]["expireon"].ToString();
                txt_plan.Text = ds.Tables[0].Rows[0]["planchoosen"].ToString();
            }
            
        }
        catch (Exception ec)
        {
        }
    }
}