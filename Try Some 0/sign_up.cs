using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Try_Some
{
    public partial class sign_up : Form
    {
        public string constring = "Data Source=DESKTOP-U5VD9JQ\\SQLSQL;Initial Catalog=research_articles_final;Integrated Security=True";
        SqlCommand com = new SqlCommand();

        public sign_up()
        {
            InitializeComponent();
            pictureBox4.Dock= DockStyle.Fill;
            pictureBox4.SendToBack();
            panel2.Location = new Point(1035, 62);
            panel1.BringToFront();
           //        (    this.back   ,    this.front   )
            help_png.blendpics(pictureBox4, pictureBox5);
            help_png.blendpics(pictureBox4, pictureBox6);
            
            help_png.blendpics(pictureBox7, pictureBox1);
            help_png.blendpics(pictureBox7, pictureBox2);
            help_png.blendpics(pictureBox7, pictureBox3);
            help_png.blendpics(pictureBox7, pictureBox8);
            help_png.blendpics(pictureBox7, pictureBox9);
            help_png.blendpics(pictureBox7, pictureBox13);

            help_png.blendpics(pictureBox16, pictureBox10);
            help_png.blendpics(pictureBox16, pictureBox11);
            help_png.blendpics(pictureBox16, saasdf);
            help_png.blendpics(pictureBox16, pictureBox14);
            help_png.blendpics(pictureBox16, pictureBox15);
            help_png.blendpics(pictureBox16, pictureBox17);
            help_png.blendpics(pictureBox16, pictureBox12);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            emailbox.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            f_namebox.Focus();
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {// 1034, 62
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Doctor_Readers where not fullname = '" + f_namebox.Text.ToString() + " " + l_namebox.Text.ToString() + "'";
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == false)
            {
                label1.Text = "THIS USER NAME IS TAKEN";
                SystemSounds.Hand.Play();
            }
            else
            {
                if (emailbox.Text == "" || f_namebox.Text == "" || comb.Text == "")
                {
                    label1.Text = "YOU SHOULD FILL ALL BOXES";
                    SystemSounds.Hand.Play();
                }
                else
                {
                    panel2.BringToFront();
                    phonebox.Focus();
                }
            }
            
           
            con.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        { 
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            label2.Visible = false;

            if (phonebox.Text == "" || passbox.Text == "" || con_passbox.Text == "")
            {
                label2.Visible = true;
                SystemSounds.Hand.Play();
            }
            else if (passbox.Text != con_passbox.Text)
            {
                MessageBox.Show("Passwords NOT Matches", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                panel2.BringToFront();
                phonebox.Focus();
                if(con.State == System.Data.ConnectionState.Open)
                {
                    string into = "insert into Doctor_Readers(email,FirstName,LastName,fullname,country,Mobile,passwordd)\r\n  " +
                                  "values ('" + emailbox.Text.ToString()+"','"+f_namebox.Text.ToString() + "','"+ l_namebox.Text.ToString() + "','"+ f_namebox.Text.ToString() +" "+ l_namebox.Text.ToString() + "'," +
                                  "  '"+comb.Text.ToString()+"','"+phonebox.Text.ToString()+"','"+passbox.Text.ToString()+"')";
                    SqlCommand com = new SqlCommand(into, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Sign up Done...!", "congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void phonebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            emailbox.Focus();
        }

        int x = 0;
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (x == 0)
            {
                passbox.PasswordChar = '\0';
                x++;
            }
            else
            {
                passbox.PasswordChar = '*';
                x--;
            }
        }

        private void con_passbox_KeyUp(object sender, KeyEventArgs e)
        {
            label3.BackColor = Color.Transparent;

            if (passbox.Text == con_passbox.Text) 
            {
                label3.Text = "Passwords are Match";
                label3.ForeColor= Color.Green;
            }
            else
            {
                label3.Text = "Passwords NOT Match";
                label3.ForeColor = Color.Red;
            }
        }
    }
}
