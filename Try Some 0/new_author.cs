using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Try_Some
{
    public partial class new_author : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-U5VD9JQ\\SQLSQL;Initial Catalog=research_articles_final;Integrated Security=True");
        SqlCommand com;
        SqlDataAdapter adpt;
        DataTable dt;
          
        public new_author()
        {
            InitializeComponent();
            datashow();
            
    }
        private void datashow()
        {
            adpt= new SqlDataAdapter("select *from Author",con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource= dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            string strfname = fbox.Text;
            string strlname = lbox.Text;
            string strcat = catobox.Text;

            if (fbox.Text != "" && lbox.Text !="" && catobox.Text !="")
           {
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string into = "insert into Author (FirstName,LastName,CategoryID) " +
                              "values ('"+strfname+"','"+strlname+"','"+strcat+"')";
                    SqlCommand com = new SqlCommand(into, con);
                    com.ExecuteNonQuery();
                    con.Close();
                }
                fbox.Text = "";
                lbox.Text = "";
                catobox.Text = "";
                label4.Text = "";
                datashow();
           }
           else
           {
                label4.Text = "YOU SHOULD FILL ALL BOXES";
                SystemSounds.Hand.Play();
           }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                fbox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                lbox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                catobox.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }

            

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            string strfname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string strlname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string strcat   = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string into = "update Author " +
                              "set FirstName='"+ fbox.Text.ToString() + "',LastName='"+lbox.Text.ToString()+"',CategoryID='"+catobox.Text.ToString()+ "' " +
                              "where FirstName='"+ strfname + "'and LastName='"+ strlname + "'and CategoryID='"+ strcat + "'";
                SqlCommand com = new SqlCommand(into, con);
                com.ExecuteNonQuery();
                con.Close();
            }

            datashow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strfname = fbox.Text;
            string strlname = lbox.Text;
            string strcat = catobox.Text;
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string into = "delete from Author " +
                              "where FirstName = '"+strfname+"' and LastName = '"+strlname+"' ";
                SqlCommand com = new SqlCommand(into, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            datashow();
        }
    }
}
