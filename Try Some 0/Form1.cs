using Microsoft.VisualBasic;
using System.Drawing;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.SqlTypes;
using System.Data;

namespace Try_Some
{


    public partial class Form1 : Form
    {
        public static int num_test;
        public string str = " ";
        public static int fav_test = 0;
        public string constring = "Data Source=DESKTOP-U5VD9JQ\\SQLSQL;Initial Catalog=research_articles_final;Integrated Security=True";
        SqlCommand com = new SqlCommand();
        public static int b; 
        public static string[] butn_names = { "ARTICLE 1", "ARTICLE 2", "ARTICLE 3", "ARTICLE 4", "ARTICLE 5" };
        public Form1()
        {
            InitializeComponent();
            panel1.SendToBack();
            panel1.Visible = false;
            arty_name = "form";

        }
        
        private void sqlcheck(object sender, EventArgs e){ }
     
        private Form activeForm = null;
        private void open(Form panelform)
        {
            panel1.Visible= true;
            panel1.BringToFront();

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
            panel1.Controls.Add(panelform);
            panel1.Tag = panelform;

            panelform.BringToFront();
            panelform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           if(before_panel.Visible == false)
           {
                before_panel.Visible = true;
                button1.BackColor = Color.FromArgb(63, 140, 254);
           }
            else if(before_panel.Visible == true)
            {
                before_panel.Visible = false;
                button1.BackColor = Color.FromArgb(36, 38, 50);
            }

        }

    

        private void rels(object sender, EventArgs e)
        {
            before_panel.Visible = false;
            button1.BackColor = Color.FromArgb(36, 38, 50);
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            before_panel.Visible = false;
            button1.BackColor = Color.FromArgb(36, 38, 50);
            panel1.Dock= DockStyle.Fill;
            
            open(new article_form());
        }
        int[] v = {0,0,0};
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con0 = new SqlConnection(constring);
            con0.Open();
            com.Connection = con0;
            com.CommandText = "select MAX(ResearchID) from Research_Articles";
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                b = Int32.Parse(dr[""].ToString());
            }
            con0.Close();
            //" + v[0].ToString() + "
            do
            {
                for (int i = 0; i < 3; i++)
                {
                    Random r = new Random();
                    v[i] = r.Next(1, (b+1));
                }
            } while ( (v[0].ToString() == v[1].ToString()) || (v[0].ToString() == v[2].ToString()) || (v[1].ToString() == v[2].ToString()));
            
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Research_Articles where ResearchID = '" + v[0].ToString() + "'";
            SqlDataReader dr1 = com.ExecuteReader();                
            if(dr1.Read()) { button3.Text = dr1["Research_Name"].ToString();}

            SqlConnection con2 = new SqlConnection(constring);
            con2.Open();
            com.Connection = con2;
            com.CommandText = "select * from Research_Articles where ResearchID = '" + v[1].ToString() +"'";
            SqlDataReader dr2 = com.ExecuteReader();
            if (dr2.Read()) { button4.Text = dr2["Research_Name"].ToString(); }

            SqlConnection con3 = new SqlConnection(constring);
            con3.Open();
            com.Connection = con3;
            com.CommandText = "select * from Research_Articles where ResearchID = '" + v[2].ToString() +"'";
            SqlDataReader dr3 = com.ExecuteReader();
            if (dr3.Read()) {button5.Text = dr3["Research_Name"].ToString();}

            if (panel2.Visible == false )
            {
                pictureBox2.Visible = false;     // down arrow
                pictureBox3.Visible = true;     // up arrow
                before_panel.Visible = false;
                button1.BackColor = Color.FromArgb(36, 38, 50);
                panel2.Visible = true;
            }
            else 
            {
                pictureBox2.Visible = true; // down arrow
                pictureBox3.Visible = false; // up arrow
                panel2.Visible = false;
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            WindowState= FormWindowState.Minimized;
        }
       
        private void button13_Click(object sender, EventArgs e)
        {//ABOUT    11111
            before_panel.Visible = false;
            button1.BackColor = Color.FromArgb(36, 38, 50);
            panel1.Dock = DockStyle.Fill;
            
            num_test = 1;
            open(new about());
          
        }

        private void button10_Click(object sender, EventArgs e)
        {//CONTACT US   222222
            before_panel.Visible = false;
            button1.BackColor = Color.FromArgb(36, 38, 50);
            panel1.Dock = DockStyle.Fill;
            
            num_test = 2;
            open(new about());
        }

        private void button8_Click(object sender, EventArgs e)
        {//SIGN IN / SUGN UP 33333333
            before_panel.Visible = false;
            button1.BackColor = Color.FromArgb(36, 38, 50);
            panel1.Dock = DockStyle.Fill;
            
            num_test = 3;
            open(new about());
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            

            arty_name = "form";
            this.Location = new Point(405, 215);
            this.Size = new Size(1110, 625);
            loadpic.BringToFront();
            loadpic.Dock = DockStyle.Fill;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            load_panel.Width += 3;
            if(load_panel.Width >=500)
            {
                timer1.Stop();
                loadpic.Visible=false;
                this.WindowState= FormWindowState.Maximized;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {     // admin
            arty_name = "form";

            if (about.name != "USER NAME")
            {
                 if (aftr_panel.Visible == false)
                 {
                    aftr_panel.Visible = true;
                    button20.BackColor = Color.FromArgb(63, 140, 254);
                 }
                 else if (aftr_panel.Visible == true)
                 {
                    aftr_panel.Visible = false;
                    button20.BackColor = Color.FromArgb(36, 38, 50);
                 }
            }
            else
            {
                if (before_panel.Visible == false)
                {
                    before_panel.Visible = true;
                    button20.BackColor = Color.FromArgb(63, 140, 254);
                }
                else if (before_panel.Visible == true)
                {
                    before_panel.Visible = false;
                    button20.BackColor = Color.FromArgb(36, 38, 50);
                }
            }
        }
       // public string last = about.name;
       
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            panel1.Visible = false;
            panel1.Dock = DockStyle.None;
            label1.Text = about.name; 
        }

        private void button18_Click(object sender, EventArgs e)
        {//account setting 1111111111
            aftr_panel.Visible = false;
            button1.BackColor = Color.FromArgb(36, 38, 50);
            panel1.Dock = DockStyle.Fill;
            num_test = 1;
            open(new about_2());
        }
        private void button15_Click(object sender, EventArgs e)
        {//my articles 2222222
            aftr_panel.Visible = false;
            button1.BackColor = Color.FromArgb(36, 38, 50);
            panel1.Dock = DockStyle.Fill;
            num_test = 2;
            open(new about_2());
        }
        private void button17_Click(object sender, EventArgs e)
        {//account setting    33333333
            aftr_panel.Visible = false;
            button1.BackColor = Color.FromArgb(36, 38, 50);
            panel1.Dock = DockStyle.Fill;
            num_test = 3;
            open(new about_2());
        }
        private void button12_Click_1(object sender, EventArgs e)
        {//ABOUT US     444444444444
            aftr_panel.Visible = false;
            button1.BackColor = Color.FromArgb(36, 38, 50);
            panel1.Dock = DockStyle.Fill;
            num_test = 4;
            open(new about_2());
        }
        private void button9_Click(object sender, EventArgs e)
        {//SIGN OUT 55555555
            aftr_panel.Visible = false;
            button1.BackColor = Color.FromArgb(36, 38, 50);
            panel1.Dock = DockStyle.Fill;
            num_test = 5;
            open(new about_2());
        }
        public static string arty_name = "form";
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Dock = DockStyle.Fill;
            arty_name = button3.Text;
            open(new article_form());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Dock = DockStyle.Fill;
            arty_name = button4.Text;
            open(new article_form());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Dock = DockStyle.Fill;
            arty_name = button5.Text;
            open(new article_form());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            arty_name = "form";
            if (srch_box.Text != "")
            {
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                com.Connection = con;
                com.CommandText = "select * from Research_Articles where Research_Name like '%" + srch_box.Text + "%' ";
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    panel1.Dock = DockStyle.Fill;
                    arty_name = dr["Research_Name"].ToString();
                    open(new article_form());
                }
                con.Close();
            }
        }
    }
}