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
            Show();
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


        private void Show()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select [Name] As TrainName, c.Coach_No From Train t Join Coach c on t.ID=c.Train_ID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seat s = new Seat();
            s.tBoxName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            s.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            change_form(s);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
