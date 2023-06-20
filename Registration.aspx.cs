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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Random ps = new Random();
            int pwd = ps.Next();
            string s = "insert into mail2 values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + pwd + "','" + 0 + "')";
            SqlConnection sc = new SqlConnection(@"Data Source=Akku;Initial Catalog=manu;Integrated Security=True");
            sc.Open();
            SqlCommand scm = new SqlCommand(s, sc);
            int i = scm.ExecuteNonQuery();
            if (i > 0)
            {
                string s1 = "select * from mail2 where '" + TextBox2.Text + "'=email";
                SqlCommand scm1 = new SqlCommand(s1, sc);
                SqlDataReader dr = scm1.ExecuteReader();
                if (dr.Read())
                {
                    string nm = dr[1].ToString();
                    string em = dr[2].ToString();
                    string mn = dr[3].ToString();
                    string p = dr[4].ToString();

                    SmtpClient obj = new SmtpClient();
                    obj.Credentials = new NetworkCredential("vermaiamakk@gmail.com", " rofpsgkyndiryocy ");
                    obj.Host = "smtp.gmail.com";
                    obj.Port = 587;
                    obj.EnableSsl = true;

                    MailMessage msg = new MailMessage("email",em);
                    msg.Subject = "Successfully Registered in BTPS..........";
                    msg.Body = "Dear '" + nm + "'\r\n Your user_name is '" + em + "' and Password is '" + p + "'";
                    obj.Send(msg);
                    Response.Write("Successfully Registered in BTPS......\r\n Check Your Email..........");
                }
            }
            else
            {
                Response.Write("Invalid input !!!");
            }
        }

      

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}
