using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            clear();
        }
        private Form isactive;
        private void change_form(Form form)
        {
            if (isactive != null)
            {
                isactive.Close();
            }
            isactive = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Add(form);
            panel1.Tag = form;
            form.BringToFront();
            form.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            change_form(new Form4());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            GET_CurrentUserID(textBox1.Text, textBox2.Text);
            if(Program.current_UserID >=0)
            {
                MessageBox.Show("You Have Logged In Successfully ...");
                change_form(new Form8());
            }
            else
            {
                MessageBox.Show("Invalid Login Attempt", "Error");
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            change_form(new Main_P());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void GET_CurrentUserID(string username, string password)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select [User].ID from User_Role as UR JOIN [User] ON UR.[User_ID]=[User].ID where UR.Role_ID=2 and ([User].Full_Name='" + username + "' or [User].Email='" + username + "') and [User].[Password]='" + password + "'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                    Program.current_UserID = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void Load_Form3(object sender, EventArgs e)
        {
            Program.current_UserID = -1;
            clear();
        }
    }
}
