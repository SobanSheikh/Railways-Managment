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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRoutes_Click(object sender, EventArgs e)
        {
            change_form(new Form9());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            change_form(new Form1());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            change_form(new Form9());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have logged out...");
            change_form(new Form3());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            change_form(new Refunds());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            change_form(new Payment());
        }
    }
}
