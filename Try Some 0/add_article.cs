using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Try_Some
{
    public partial class add_article : Form
    {
        public add_article()
        {
            InitializeComponent();
        }

        private bool mouseDown;
        private Point lastLocation;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string constring = "Data Source=DESKTOP-U5VD9JQ\\SQLSQL;Initial Catalog=research_articles_final;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            if (athr_box.Text == "" || art_box.Text == "" || cato_box.Text == "" || cost_box.Text =="" || lang_box.Text =="" ||article_box.Text == "")
            {
                label4.Visible = true;
                SystemSounds.Hand.Play();
            }
            else
            {
                

                string text = article_box.Text;
                text = text.Replace("'", "''");
                article_box.Text = text;

                SqlConnection con = new SqlConnection(constring);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    com_test();
                    string into = "insert into Research_Articles(Research_Name,Research_date,Research_cost,article,LanguegeID,CategoryID,AuthorID)" +
                                 " values ('"+art_box.Text.ToString()+"','"+date_box.Value+"','"+cost_box.Text.ToString()+"'," +
                                 " '"+article_box.Text.ToString()+"','"+lang_x+"','"+cato_x+"','2')";
                    SqlCommand com = new SqlCommand(into, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("ARTICLES HAS BEEN ADDED", "congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    art_box.Text = "";
                    cato_box.Text = "";
                    cost_box.Text = "";
                    lang_box.Text = "";
                    article_box.Text = "";
                }
                con.Close();
            }
        }
        int cato_x = 0;
        int lang_x = 0;
        private void com_test()
        {
            if      (cato_box.Text == cato_box.Items[0].ToString()) { cato_x = 1; }
            else if (cato_box.Text == cato_box.Items[1].ToString()) { cato_x = 2; }
            else if (cato_box.Text == cato_box.Items[2].ToString()) { cato_x = 3; }
            else if (cato_box.Text == cato_box.Items[3].ToString()) { cato_x = 4; }
            else if (cato_box.Text == cato_box.Items[4].ToString()) { cato_x = 5; }
            else if (cato_box.Text == cato_box.Items[5].ToString()) { cato_x = 6; }
            else if (cato_box.Text == cato_box.Items[6].ToString()) { cato_x = 7; }
            else if (cato_box.Text == cato_box.Items[7].ToString()) { cato_x = 8; }
            else if (cato_box.Text == cato_box.Items[8].ToString()) { cato_x = 9; }

            if      (lang_box.Text == lang_box.Items[0].ToString()) { lang_x = 1; }
            else if (lang_box.Text == lang_box.Items[1].ToString()) { lang_x = 2; }


        }
    }
}
