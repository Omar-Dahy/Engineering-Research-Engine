using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Try_Some
{
    public partial class sign_in : Form
    {
       

        public sign_in()
        {
            InitializeComponent();
             
            pictureBox3.SendToBack();
            pictureBox3.Dock = DockStyle.Fill;

            help_png.blendpics(pictureBox3, pictureBox1);
            help_png.blendpics(pictureBox3, pictureBox2);

            help_png.blendpics(pictureBox4, pictureBox5);
            help_png.blendpics(pictureBox4, pictureBox6);
            help_png.blendpics(pictureBox4, pictureBox7);
            help_png.blendpics(pictureBox4, pictureBox8);
            help_png.blendpics(pictureBox4, pictureBox9);
            help_png.blendpics(pictureBox4, pictureBox10);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
        
         this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            emailbox.Focus();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            passbox.Focus();

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                pictureBox9_Click(sender, e);
            }
        }
        
        
        public static string user = "USER NAME";
        public string constring = "Data Source=DESKTOP-U5VD9JQ\\SQLSQL;Initial Catalog=research_articles_final;Integrated Security=True";
                    
        SqlCommand com = new SqlCommand();

        
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            com.Connection= con;
            com.CommandText = "select * from Doctor_Readers where email ='" + emailbox.Text.ToString() + "' or fullname = '"+ emailbox.Text.ToString() + "'  ";
            SqlDataReader dr = com.ExecuteReader();

            if(dr.Read()) 
            {
                if ( ( emailbox.Text.Equals( dr["email"].ToString() ) || emailbox.Text.Equals(dr["fullname"].ToString() )) && (passbox.Text.Equals(dr["passwordd"].ToString() ) ) )
                {
                    MessageBox.Show("Login Done...!","congrats",MessageBoxButtons.OK, MessageBoxIcon.Information );
                    user = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                    this.Close();

                }  
                else
                {
                    //noncheck();
                    MessageBox.Show("password Is Wrong", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passbox.Text = "";
                }
            }
            con.Close();
        }
        
        private void sign_in_Load(object sender, EventArgs e)
        {
            user = "USER NAME";
            emailbox.Focus();
        }
        int x=0;
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if(x==0)
            {
                pictureBox6.Visible = false;
                pictureBox7.Visible = true;
                passbox.PasswordChar = '\0';
                x++;
            }
            else 
            {
                pictureBox7.Visible = false;
                pictureBox6.Visible = true;
                passbox.PasswordChar = '*';
                x--;
            }
        }
    }
}
