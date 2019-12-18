using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication4
{
    /*Created By Rajbhara mohammad Juned
     *As activity 2 program 
     *Subject : C#.net programming 
     * ####################   Readme ##################### *
     * for using current function in your application you first need to copy my model into your project
     * then fuction instruction writen next to each function
     * batter information just create database(change the connection string down there) and this form will take care of rest
     * One important thing when you create database for every primary id use '-id' ex teacher-id 
     * * and every foreign key use '_tbl' ex: teacher-id_tbl 
     * * * last one use IDENTITY(1,1) after your primery-id [datatype] IDENTITY(1,1) when you create a table
     */
    class model
    {
        SqlConnection con;
        string qs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=trainmng;Integrated Security=True";
        public string[] gettblname()
        {
            string[] resdt = new string[20];
            con = new SqlConnection(qs);
            con.Open();
            int it = 0;
            DataTable t = con.GetSchema("Tables");
            foreach (DataRow trow in t.Rows)
            {
                var field = new Dictionary<string, string>();
                var field1 = trow["TABLE_NAME"].ToString();
                resdt[it] = field1;
                it++;
            }
            return resdt;
        }
        public void connection(string fname)
        {
            con = new SqlConnection(qs);
            con.Open();
            DataTable t = con.GetSchema("Tables");
            foreach (DataRow trow in t.Rows)
            {
                var field = new Dictionary<string, string>();
                var field1 = trow["TABLE_NAME"].ToString();
                var data = new Dictionary<string, string>();
                Console.WriteLine(field1);
                SqlDataAdapter adp = new SqlDataAdapter("select * from " + field1, con);
                DataTable stbl = new DataTable();
                adp.Fill(stbl);
                string[] fieldas = new string[2] { "1", "'mscit'" };
                int f = 0;
                foreach (DataColumn stbc in stbl.Columns)
                {
                    data.Add(stbc.ColumnName, fieldas[f]);
                    Console.WriteLine(stbc.ColumnName);
                    f++;
                }
                string strrr = Insertq(field1, data, null);
                string str = Updateq(field1, data, field, null);
                Console.WriteLine(strrr);
                Console.WriteLine(str);
                DataTable sedata = new DataTable();
                sedata = Selectq(field1, null, data);
                foreach (DataRow seb in sedata.Rows)
                {
                    foreach (DataColumn sebc in sedata.Columns)
                    {
                        String s = seb[sebc].ToString();
                        Console.WriteLine(s + "->" + sebc);
                    }
                }
                continue;
            }
            con.Close();
        }
        public DataTable Selectq(string tbl, string[] fields, Dictionary<string, string> data)
        {
            string basequery = null, field1e = null, wherecl = null;
            if (fields == null)
            {
                field1e = "*";
            }
            else
            {
                foreach (string field in fields)
                {
                    field1e += field + ",";
                }
            }
            basequery = "select " + field1e + " from " + tbl;
            if (data != null)
            {
                int i = 0;
                foreach (KeyValuePair<string, string> singlesvpair in data)
                {
                    string ste = singlesvpair.Value.ToString();
                    if (ste.StartsWith("'") && ste.EndsWith("'"))
                    {
                        wherecl += singlesvpair.Key + " like " + singlesvpair.Value;//can change it to symbol array to give saprate symbols
                    }
                    else
                    {
                        wherecl += singlesvpair.Key + " = " + singlesvpair.Value;//can change it to symbol array to give saprate symbols
                    }
                    //wherecl += singlesvpair.Key +" = "+ singlesvpair.Value;//can change it to symbol array to give saprate symbols
                    i++;
                    if (i > 0 & i == data.Count - 1)
                    {
                        wherecl += " and ";
                    }
                }
                basequery += " where " + wherecl;
            }
            Console.WriteLine(basequery);
            con = new SqlConnection(qs);
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(basequery, con);
            DataTable res1 = new DataTable();
            adp.Fill(res1);
            return res1;
        }
        public string Insertq(string tbl, Dictionary<string, string> data, String conn)// tbl ,data ,conn
        {
            string basequery = null, res1 = null, v = null, k = null;
            if (data != null)
            {
                int i = 0;
                string vv = null, kk = null;
                foreach (KeyValuePair<string, string> singlesvpair in data)
                {
                    k = string.Join(",", data.Keys);
                    v = string.Join(",", data.Values);
                    kk += singlesvpair.Key;
                    vv += singlesvpair.Value;
                    i++;
                    if (i == data.Count - 1)
                    {
                        vv += ",";
                        kk += ",";
                    }
                    else if (data.Count == 1)
                    {
                        continue;
                    }
                }
            }
            basequery = "insert into " + tbl + " values(" + v + ")";// (" + k + ")
                Console.WriteLine(basequery);
            con = new SqlConnection(qs);
            con.Open();
            SqlCommand cmd = new SqlCommand(basequery, con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Inserting Data Successfully");
            con.Close();
            res1 = "Datasuccessull inserted";
            return res1;
        }
        public string Updateq(string tbl, Dictionary<string, string> data, Dictionary<string, string> fields, String conn)// tbl ,field,data ,conn
        {
            string basequery = null, wherecl = null, res1 = null, cond = null;
            if (data != null)  // this will add after update (tbl) set 
            {
                int i = 0;
                foreach (KeyValuePair<string, string> singlesvpair in fields)
                {
                    string ste = singlesvpair.Value.ToString();
                    if (ste.StartsWith("'") && ste.EndsWith("'"))
                    {
                        cond += singlesvpair.Key + " like " + singlesvpair.Value;
                    }
                    else
                    {
                        cond += singlesvpair.Key + " = " + singlesvpair.Value;
                    }
                    
                    i++;
                    if (i > 0 & i == data.Count - 1)
                    {
                        cond += " and ";
                    }
                }
            }
            basequery = "update " + tbl + " set " + cond;
            if (data != null) // this is where clause
            {
                int i = 0;
                foreach (KeyValuePair<string, string> singlesvpair in data)
                {
                    wherecl += singlesvpair.Key + " = " + singlesvpair.Value;//can change it to symbol array to give saprate symbols
                    i++;
                    if (i > 0 & i == data.Count - 1)
                    {
                        wherecl += " and ";
                    }
                }
                basequery += " where " + wherecl;
            }
            res1 = basequery;
            con = new SqlConnection(qs);
            con.Open();
            SqlCommand cmd = new SqlCommand(basequery, con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Inserting Data Successfully");
            con.Close();
            res1 = "Datasuccessull Update";
            return res1;
        }
    }
}