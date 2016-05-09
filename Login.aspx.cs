using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            Response.Redirect("HomeUser.aspx");
        }
    }


    protected void btn_Login_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds;
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            int rowcount;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select count(*) from RegisteredUsers where userid='" + txt_UserID.Text + "' and [password]='" + txt_Password.Text + "'", conn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da.Fill(ds);
                    rowcount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            if (rowcount > 0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("select count(*) from doctordetails where doctorid='" + txt_UserID.Text + "'", conn))
                    {
                        da.SelectCommand.CommandType = CommandType.Text;
                        ds = new DataSet();
                        da.Fill(ds);
                        rowcount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    }
                }
                HttpContext.Current.Session["UserID"] = Convert.ToString(txt_UserID.Text);
                if (rowcount > 0)
                {
                    HttpContext.Current.Session["Role"] = "Doctor";
                    Response.Redirect("HomeDoctor.aspx");
                }
                else
                {
                    HttpContext.Current.Session["Role"] = "User";
                    Response.Redirect("HomeUser.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        catch (Exception ec)
        {
           
        }
    }
}