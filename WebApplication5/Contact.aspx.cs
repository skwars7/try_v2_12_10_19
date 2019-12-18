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
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con;
            string qs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=manufacture;Integrated Security=True";
            con = new SqlConnection(qs);
            con.Open();
            string newsr;
            newsr = "select * from retxman";
            SqlDataAdapter adpaa = new SqlDataAdapter(newsr, con);
            DataTable neres = new DataTable();
            adpaa.Fill(neres);
            string bq;
            bq = "select * from ret";
            SqlDataAdapter adp = new SqlDataAdapter(bq, con);
            DataTable res1 = new DataTable();
            adp.Fill(res1);
            String s = "<select class=\"col-md-8\" name=\"eplt\" id=\"eplt\">";
            foreach (DataRow seb in res1.Rows)
            {
                string plt, value;
                plt = seb["rname"].ToString();
                value = seb["rid"].ToString();
                s += "<option value=" + value + ">" + plt + "</option>";
            }
            s += "</select>";
            rune.InnerHtml = s;
            bq = "select * from man";
            SqlDataAdapter adpa = new SqlDataAdapter(bq, con);
            DataTable res2 = new DataTable();
            adpa.Fill(res2);
            String sa = "<select class=\"col-md-8\" name=\"splt\" id=\"splt\">";
            foreach (DataRow seba in res2.Rows)
            {
                string plta, valuea;
                plta = seba["productname"].ToString();
                valuea = seba["mid"].ToString();
                sa += "<option value=" + valuea + ">" + plta + "</option>";
            }
            sa += "</select>";
            Div1.InnerHtml = sa;
            if (Request.QueryString["subbtn"] != null)
            {
                
                string b = Request.QueryString["splt"];
                string c = Request.QueryString["eplt"];
                string baseqr;
                baseqr = "insert into retxman values(" + b + "," + c + ")";
                SqlCommand cmd = new SqlCommand(baseqr, con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert(\"inserted\");</script>");
                con.Close();
            }
            if (Request.QueryString["ssubbtn"] != null)
            {
                string a = Request.QueryString["tide"];
                string b = Request.QueryString["splt"];
                string c = Request.QueryString["eplt"];
                string baseqr;
                baseqr = "update retxman set  raid = " + b + ",maid = " + c + " where rmid = "+ a;
                SqlCommand cmd = new SqlCommand(baseqr, con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert(\"updated\");</script>");
                con.Close();
            }
            if (Request.QueryString["sssubbtn"] != null)
            {
                string a = Request.QueryString["tide"];
                string b = Request.QueryString["splt"];
                string c = Request.QueryString["eplt"];
                string baseqr;
                baseqr = "delete from retxman where tpid = " + a;
                SqlCommand cmd = new SqlCommand(baseqr, con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert(\"Delete\");</script>");
                con.Close();
            }
            DataGrid1.DataSource = neres;
            DataGrid1.DataBind();
        }
    }
}