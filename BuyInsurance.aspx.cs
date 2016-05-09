using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BuyInsurance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void btn_Buy_Click(object sender, EventArgs e)
    {
        try {
            int number = (new Random()).Next();
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand da = new SqlCommand("insert into InsuranceDetails (PlanChoosen,ExpireOn,InsuranceNumber) values ('" + ddl_plan.SelectedValue+"','"+Convert.ToDateTime(txt_expired.Text)+"','"+(number).ToString()+ "')", conn))
                {
                    da.CommandType = CommandType.Text;
                    conn.Open();
                    da.ExecuteNonQuery();
                    conn.Close();
                }
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand da = new SqlCommand("update RegisteredUsers set InsuranceNumber = ('" + number.ToString() + "') where UserId= '" + Session["UserID"].ToString()+"'", conn))
                {
                    da.CommandType = CommandType.Text;
                    conn.Open();
                    da.ExecuteNonQuery();
                    conn.Close();
                }
            }
            bought.Visible = true;
            buy.Visible = false;
        }
        catch (Exception ec)
        {
        }
    }
}