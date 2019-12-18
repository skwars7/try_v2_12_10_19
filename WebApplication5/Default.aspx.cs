using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace WebApplication5
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con;
            string qs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=manufacture;Integrated Security=True";
            con = new SqlConnection(qs);
            con.Open();
            string bq;
            bq = "select * from cat";
            SqlDataAdapter adp = new SqlDataAdapter(bq, con);
            DataTable res1 = new DataTable();
            adp.Fill(res1);
            String s = "<select class=\"col-md-8\" name=\"eplt\" id=\"eplt\">";
            foreach (DataRow seb in res1.Rows)
            {
                    string plt,value;
                    plt = seb["cname"].ToString();
                    value = seb["cid"].ToString();
                    s += "<option value="+ value + ">"+plt+"</option>";
            }
            s += "</select>";
            Div1.InnerHtml = s;
            if (Request.QueryString["ssubbtn"] != null)
            {
                string a = Request.QueryString["cname"];
                string baseqr;
                baseqr = "insert into cat values('" + a + "')";
                SqlCommand cmd = new SqlCommand(baseqr, con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert(\"inserted\");</script>");
                con.Close();
            }
            string aaa;
            aaa = "select * from cat";
            SqlDataAdapter ada = new SqlDataAdapter(aaa, con);
            DataTable vav = new DataTable();
            ada.Fill(vav);
            DataGarid1.DataSource = vav;
            DataGarid1.DataBind();
            string bfq;
            bfq = "select * from man";
            SqlDataAdapter avv = new SqlDataAdapter(bfq, con);
            DataTable resv = new DataTable();
            avv.Fill(resv);
            no2.DataSource = resv;
            no2.DataBind();
        }
    }
}