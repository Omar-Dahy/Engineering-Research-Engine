using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Try_Some
{
    
    public partial class article_form : Form
    {
        public string constring = "Data Source=DESKTOP-U5VD9JQ\\SQLSQL;Initial Catalog=research_articles_final;Integrated Security=True";
        SqlCommand com = new SqlCommand();

        public article_form()
        {
            InitializeComponent();
           

            panel4.Location = new Point(1467, 0);
            label6.Text = Form1.arty_name;//name of random article

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Research_Articles where Research_Name = '" + label6.Text+"'";
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["article"].ToString(); 
                label9.Text = "WRITTEN BY:" + dr["AuthorID"].ToString();
                label8.Text = "DATE:" + dr["Research_date"].ToString();
                label7.Text = "FIELD:" + dr["CategoryID"].ToString();
            }
            con.Close();

           
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static string fave = "";
        public static string[] fav_names = { "ARTICLE 1", "ARTICLE 2", "ARTICLE 3", "ARTICLE 4", "ARTICLE 5" };
        
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // Size size = TextRenderer.MeasureText(textBox1.Text, textBox1.Font);
            //textBox1.Height = size.Height;
        }

        private void article_form_Load(object sender, EventArgs e)
        {
           // save_button();

            panel6.Height= label6.Height + 15;
            pictureBox3.Width = label6.Width + 15;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
