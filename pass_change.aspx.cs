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
    public partial class pass_change : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select * from mail2 where '" + TextBox1.Text + "'=password";
            SqlConnection sc = new SqlConnection(@"Data Source=Akku;Initial Catalog=manu;Integrated Security=True");
            sc.Open();
            SqlCommand scm1 = new SqlCommand(s, sc);
            SqlDataReader dr = scm1.ExecuteReader();
            if (dr.Read())
            {
                string pwd = dr[4].ToString();
                if (TextBox1.Text == pwd)
                {
                    string s1 = "update mail2 set password='" + TextBox2.Text + "' where '" + TextBox1.Text + "' = password";
                    SqlConnection sc1 = new SqlConnection(@"Data Source=Akku;Initial Catalog=manu;Integrated Security=True");
                    sc1.Open();
                    SqlCommand scm = new SqlCommand(s1, sc1);
                    scm.ExecuteNonQuery();
                }
            }

            else
            {
                Response.Write("current Password Is incorrect");
            }
        }
    }
}

    
