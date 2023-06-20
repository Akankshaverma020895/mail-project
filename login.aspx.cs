using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace mail_project
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select * from mail2 where '" + TextBox1.Text + "'=email";
            SqlConnection sc = new SqlConnection(@"Data Source=Akku;Initial Catalog=manu;Integrated Security=True");
            sc.Open();
            SqlCommand scm1 = new SqlCommand(s, sc);
            SqlDataReader dr = scm1.ExecuteReader();
            if (dr.Read())
            {
                string nm = dr[1].ToString();
                string em = dr[2].ToString();
                string mn = dr[3].ToString();
                string p = dr[4].ToString();
                string st = dr[5].ToString();
                if (TextBox1.Text == em && TextBox2.Text == p)
                {
                    if (st == "0")
                    {

                        string up = "update mail2 set status='" + 1 + "' where'" + TextBox1.Text + "'=email ";

                        SqlConnection sc1 = new SqlConnection(@"Data Source=Akku;Initial Catalog=manu;Integrated Security=True");
                        sc1.Open();
                        SqlCommand scm = new SqlCommand(up, sc1);
                        int i = scm.ExecuteNonQuery();
                        if (i > 0)
                        {
                            Response.Redirect("pass_change.aspx");
                        }
                        else
                        {
                            Response.Write("incorrect Password !");
                        }
                    }
                    else
                    {
                        Response.Redirect("home.aspx");
                    }
                }

                else
                {
                    Response.Write("user name & password Does not match ");
                }







            }
        }
    }
}