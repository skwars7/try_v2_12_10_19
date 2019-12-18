using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace WebApplication5
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con;
            string qs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=manufacture;Integrated Security=True";
            con = new SqlConnection(qs);
            con.Open();
            string bq;
            bq = "select * from ret";
            SqlDataAdapter adp = new SqlDataAdapter(bq, con);
            DataTable res1 = new DataTable();
            adp.Fill(res1);
            dr1.DataSource = res1;
            dr1.DataBind();
            if (Request.QueryString["subbtn"] != null)
            {
                string a = Request.QueryString["tname"];
                string baseqr;
                baseqr = "insert into ret values('" + a + "')";
                SqlCommand cmd = new SqlCommand(baseqr, con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert(\"inserted\");</script>");
                con.Close();
            }
            if (Request.QueryString["sssubbtn"] != null)
            {
                string a = Request.QueryString["tname"];
                string baseqr;
                baseqr = "delete from ret where rid = " + a;
                SqlCommand cmd = new SqlCommand(baseqr, con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert(\"Deleted\");</script>");
                con.Close();
            }
        }
    }
}