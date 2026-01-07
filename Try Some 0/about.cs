using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Try_Some
{
    public partial class about : Form
    {
        public int test = Form1.num_test;
        public static string user_test = "";
        public static string name = "USER NAME";
        public about()
        {
            InitializeComponent();
            pictureBox2.Location = new Point(1459, 45);
            panel1.Dock = DockStyle.Fill;
            user_test = label2.Text;
        }




        private Form activeForm = null;
        private void open(Form panelform)
        {

            fpanel.Visible = true;
            fpanel.BringToFront();

            //panelform.
            if (activeForm != null)
            {
                activeForm.Close();
            }
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


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {//support us button
            side_bar_4.BringToFront();
            support_panel.Visible = true;
            support_panel.Location = new Point(450, 296);

            pictureBox8.Visible= false;
            pictureBox9.Visible = false;

            sign_panel.Visible = false;
            contact_panel.Visible= false;
            about_panel1.Visible = false;
            about_panel2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {// contact button
            side_bar_2.BringToFront();
            contact_panel.Visible = true;
            contact_panel.Location = new Point(450, 296);

            pictureBox8.Visible = false;
            pictureBox9.Visible = false;

            sign_panel.Visible = false;
            about_panel1.Visible= false;
            about_panel2.Visible= false;
            support_panel.Visible= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {//sign in / sign up button
            side_bar_1.BringToFront();
            sign_panel.Visible = true;
            sign_panel.Location = new Point(450, 296);

            pictureBox8.Visible = false;
            pictureBox9.Visible = false;

            contact_panel.Visible = false;
            about_panel1.Visible = false;
            about_panel2.Visible = false;
            support_panel.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {// about us button
            pictureBox8.BringToFront();
            pictureBox8.Visible= true;
            side_bar_3.BringToFront();
            about_panel1.Visible = true;
            about_panel1.Location = new Point(450, 296);

            pictureBox8.Visible = true;
            pictureBox9.Visible = true;

            sign_panel.Visible = false; 
            about_panel2.Visible = false;
            contact_panel.Visible = false;
            support_panel.Visible= false;
        }

        
        private void fpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (label2.Text == "USER NAME") 
            {
                label2.Text = sign_in.user;
                name = label2.Text; 
            }
            else
            {
                label2.Text = "USER NAME";
            }
            fpanel.Visible = false;
            panel1.Visible= true;

            if (sign_in.user != "USER NAME")
            {
                this.Close();
            }
        }

        private void about_Load(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(1459, 45);
            label2.Text = "USER NAME";
            
            if (test == 1)//about us
            {
                about_panel1.Visible = true;
                side_bar_3.BringToFront();
                about_panel1.Location = new Point(450, 296);
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
               
            }
            else if (test == 2)//contact us
            {
                contact_panel.Visible = true;
                side_bar_2.BringToFront();
                contact_panel.Location = new Point(450, 296);
                
            }
            else if (test == 3)//sign in / sign up
            {
                
                side_bar_1.BringToFront();
                sign_panel.Location = new Point(450, 296);
                sign_panel.Visible = true;
                
            }
        }
       
        private void button6_Click_1(object sender, EventArgs e)
        {
            panel1.Visible= false;
            fpanel.Dock = DockStyle.Fill;
            open(new sign_in());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            fpanel.Dock = DockStyle.Fill;
            open(new sign_up());
        }

        private void abt_btn(object sender, EventArgs e)
        {
            about_panel1.Location = new Point(450, 296);
            about_panel2.Location = new Point(450, 296);
            if (about_panel2.Visible == false)
            {
                pictureBox8.SendToBack();
                about_panel2.Visible = true;
                about_panel1.Visible = false;
            }
            else
            {
                pictureBox8.BringToFront();
                about_panel2.Visible = false;
                about_panel1.Visible = true;
                
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://www.patreon.com/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://www.paypal.com/eg/home");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://mail.google.com/mail/u/0/#inbox");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", "https://www.whatsapp.com/?lang=ar");
        }
    }
}
