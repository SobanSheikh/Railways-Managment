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
    public partial class Book_t : Form
    {
        public Book_t()
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            change_form(new Form1());
            Combo();
        }

       private void Combo()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Coach.Coach_No FROM Train JOIN Coach ON Coach.Train_ID=Train.ID where Train.ID='1'", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
            comboBox1.DataSource = dtable;
            comboBox1.DisplayMember = "Coach";
            comboBox1.ValueMember = "Coach_No";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
