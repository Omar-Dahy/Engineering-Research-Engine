using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Try_Some
{
    public partial class about_2 : Form
    {
        
        public static string user_test = "";
        public string username = sign_in.user;
       
        public static string name2 = "USER NAME";
        public about_2()
        {
            InitializeComponent();
            user_test = label6.Text;
            label6.Text = username;

        }
        private Form activeForm = null;
        private void open(Form panelform)
        {
            fpanel.Visible = true;
            fpanel.BringToFront();
            //panelform.
            if (activeForm != null)
                activeForm.Close();
            activeForm = panelform;
            panelform.TopLevel = false;
            panelform.FormBorderStyle = FormBorderStyle.None;
            panelform.Dock = DockStyle.Fill;
            // panel5    panel that you need put form on it
            fpanel.Controls.Add(panelform);
            fpanel.Tag = panelform;
            panelform.BringToFront();
            panelform.Show();
        }
        private void hide()
        {
            label6.Text = username;
            setting_panel.Visible = false;
            articles_panel.Visible = false;
            fav_panel.Visible = false;
            fav_label.Visible = false;
            about_panel1.Visible = false;
            about_panel2.Visible = false;
            support_panel.Visible = false;
            out_panel.Visible = false;
            pictureBox21.Visible = false;
            pictureBox20.Visible = false;

            no_lab.Visible = false;
        }
        public string constring = "Data Source=DESKTOP-U5VD9JQ\\SQLSQL;Initial Catalog=research_articles_final;Integrated Security=True";
        SqlCommand com = new SqlCommand();
        private void acc_data()
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Doctor_Readers where fullname = '" +label6.Text.ToString()+"'";
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                user_box.Text = dr["fullname"].ToString();
                email_box.Text = dr["email"].ToString();
                phone_box.Text = dr["Mobile"].ToString();
                pass_box.Text = dr["passwordd"].ToString();
                COUNTRY_BOX.Text = dr["country"].ToString();
            }
        }
       
        public int test = Form1.num_test;
        public string fave = article_form.fave;
        int test_t = 0;
        private void about2_Load(object sender, EventArgs e)
        {
            button8.Text  = article_form.fav_names[0];
            button9.Text  = article_form.fav_names[1];
            button10.Text = article_form.fav_names[2];
            button11.Text = article_form.fav_names[3];
            button12.Text = article_form.fav_names[4];

            if (label6.Text == "admin admin")
            {
                test_t = 300;
            }
            else 
            {
                test_t = 100;
            }

            if (test == 1)//account
            {
                acc_data();
                setting_panel.Visible = true;
                sidebar_1.BringToFront();
                setting_panel.Location = new Point(505, 290);
            }
            else if (test == 2)//my articles
            {
                if(test_t == 300)
                {
                    articles_panel.Visible = true;
                    sidebar_2.BringToFront();
                    articles_panel.Location = new Point(505, 290);
                }
                else if (test_t == 100)
                {
                    no_lab.Visible = true;
                    sidebar_2.BringToFront();
                    no_lab.Location = new Point(505, 290);
                }
                
            }
            else if (test == 3)//favouruits
            {
                sidebar_3.BringToFront();
                if (button8.Text == "ARTICLE 1" && button9.Text == "ARTICLE 2" && button10.Text == "ARTICLE 3" && button11.Text == "ARTICLE 4" && button12.Text == "ARTICLE 5")
                {
                    fav_panel.Visible = false;
                    fav_label.Visible = true;
                    fav_label.Location = new Point(505, 290);
                }
                else
                {
                    fav_label.Visible = false;
                    fav_panel.Visible = true;
                    fav_panel.Location = new Point(505, 290);
                }
            }
            else if (test == 4)//about us
            {
                about_panel1.Visible = true;
                sidebar_4.BringToFront();
                about_panel1.Location = new Point(505, 290);
                pictureBox20.Visible = true;
                pictureBox21.Visible = true;
            }
            else if (test == 5)//sign out
            {
                out_panel.Visible = true;
                sidebar_6.BringToFront();
                out_panel.Location = new Point(505, 290);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {// account setting button
            hide();
            acc_data();
            sidebar_1.BringToFront();
            setting_panel.Visible= true;
            setting_panel.Location = new Point(505, 290);
        }
        private void button2_Click(object sender, EventArgs e)
        {// my articles button
            hide();
            if (test_t == 300)
            {
                articles_panel.Visible = true;
                sidebar_2.BringToFront();
                articles_panel.Location = new Point(505, 290);
            }
            else if (test_t == 100)
            {
                no_lab.Visible = true;
                sidebar_2.BringToFront();
                no_lab.Location = new Point(505, 290);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {//favouruits button
            hide();
            sidebar_3.BringToFront();
            if(button8.Text == "ARTICLE 1" && button9.Text == "ARTICLE 2" && button10.Text == "ARTICLE 3" && button11.Text == "ARTICLE 4" && button12.Text == "ARTICLE 5")
            {
                fav_panel.Visible = false;
                fav_label.Visible= true;
                fav_label.Location = new Point(505, 290);
            }
            else 
            { 
                fav_label.Visible = false;
                fav_panel.Visible = true;
                fav_panel.Location = new Point(505, 290);
            }
         
        }
        private void button4_Click(object sender, EventArgs e)
        {// about us button
            hide();
            sidebar_4.BringToFront();
            about_panel1.Visible = true;
            about_panel1.Location = new Point(505, 290);
            pictureBox20.Visible = true;
            pictureBox20.BringToFront() ;
            pictureBox21.Visible = true;

        }
        private void button5_Click(object sender, EventArgs e)
        {// support button
            hide();
            sidebar_5.BringToFront();
            support_panel.Visible = true;
            support_panel.Location = new Point(505, 290);

        }
        private void button6_Click(object sender, EventArgs e)
        {// sign out button
            hide();
            sidebar_6.BringToFront();
            out_panel.Visible = true;
            out_panel.Location = new Point(505, 290);

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            up_panel.Visible= false;
            this.AutoScroll = false;
            fpanel.Dock= DockStyle.Fill;
            
            open(new add_article());
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://www.paypal.com/eg/home");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://www.patreon.com/");
        }
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://mail.google.com/mail/u/0/#inbox");
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://www.whatsapp.com/?lang=ar");
        }
        private void abt_btn(object sender, EventArgs e)
        {
            about_panel1.Location = new Point(505, 290);
            about_panel2.Location = new Point(505, 290);

            if (about_panel2.Visible == false)
            {
                pictureBox20.SendToBack();
                about_panel2.Visible = true;
                about_panel1.Visible = false;
            }
            else
            {
                pictureBox20.BringToFront();
                about_panel2.Visible = false;
                about_panel1.Visible = true;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            about.user_test = "USER NAME";
            about.name= "USER NAME";
            this.Close();
        }
        private void pictureBox18_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int i=9;
        private void fpanel_MouseMove(object sender, MouseEventArgs e)
        {
            button8.Text = article_form.fav_names[0];
            button9.Text = article_form.fav_names[1];
            button10.Text = article_form.fav_names[2];
            button11.Text = article_form.fav_names[3];
            button12.Text = article_form.fav_names[4];

            fpanel.Visible= false;
            this.AutoScroll = true;
            up_panel.Visible= true;
            this.AutoScroll = true;
            fpanel.Dock = DockStyle.None;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text != "ARTICLE 1")
            {
                Form1.arty_name = button8.Text;
                up_panel.Visible = false;
                fpanel.Dock = DockStyle.Fill;
                open(new article_form());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text != "ARTICLE 2")
            {
                Form1.arty_name = button9.Text;
                up_panel.Visible = false;
                fpanel.Dock = DockStyle.Fill;
                open(new article_form());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text != "ARTICLE 3")
            {
                Form1.arty_name = button10.Text;
                up_panel.Visible = false;
                fpanel.Dock = DockStyle.Fill;
                open(new article_form());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text != "ARTICLE 4")
            {
                Form1.arty_name = button11.Text;
                up_panel.Visible= false;
                fpanel.Dock = DockStyle.Fill;
                open(new article_form());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text != "ARTICLE 5")
            {
                Form1.arty_name = button12.Text;
                up_panel.Visible = false;
                fpanel.Dock = DockStyle.Fill;
                open(new article_form());
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            if(email_box.ReadOnly == true && phone_box.ReadOnly == true && pass_box.ReadOnly == true)
            {
                email_box.ReadOnly = false;
                email_box.ForeColor = Color.Black;
                phone_box.ReadOnly = false;
                phone_box.ForeColor = Color.Black;
                pass_box.ReadOnly = false;
                pass_box.ForeColor = Color.Black;
                button13.Text = "DONE?";
            }
            else
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string into = "update Doctor_Readers " +
                                  "set passwordd = '" + pass_box.Text.ToString() + "' ,Mobile ='" + phone_box.Text.ToString() + "' , email = '"+email_box.Text.ToString()+"'  " +
                                  "where fullname ='" + user_box.Text.ToString() + "'";
                    SqlCommand com = new SqlCommand(into, con);
                    com.ExecuteNonQuery();
                }
                email_box.ReadOnly = true;
                email_box.ForeColor = Color.Gray;
                phone_box.ReadOnly = true;
                phone_box.ForeColor = Color.Gray;
                pass_box.ReadOnly = true;
                pass_box.ForeColor = Color.Gray;
                button13.Text = "EDIT";
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            new_author nn = new new_author();
            nn.Show();
        }
    }
}
