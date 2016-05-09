using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Registartion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            Response.Redirect("HomeUser.aspx");
        }
    }
    protected void btn_Register_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds;
            string connectionString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            int rowcount;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select count(*) from RegisteredUsers where userid='" + txt_UserID.Text +  "'", conn))
                {
                    da.SelectCommand.CommandType = CommandType.Text;
                    ds = new DataSet();
                    da.Fill(ds);
                    rowcount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            if (rowcount > 0)
            {
                Page.SetFocus(txt_UserID);
                lbl_exists.Visible = true;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand da = new SqlCommand("insert into RegisteredUsers (UserId,[password],SecQuestion,SecAnswer,Name,Mobile,Mail,[Address]) values ('" + txt_UserID.Text + "','" + txt_Password.Text + "','" + txt_SecQuestion.Text + "','" + txt_SecAnswer.Text + "','" + txt_Name.Text + "','" + txt_Mobile.Text + "','" + txt_Email.Text + "','" + txt_Address.Text + "')", conn))
                    {
                        da.CommandType = CommandType.Text;
                        conn.Open();
                        da.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                HttpContext.Current.Session["UserID"] = Convert.ToString(txt_UserID.Text);
                HttpContext.Current.Session["Role"] = "User";
                Response.Redirect("HomeUser.aspx");
            }
        }
        catch (Exception ec)
        {
        }
   }
}