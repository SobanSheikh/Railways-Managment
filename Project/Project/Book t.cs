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
            Class_Fill();
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
        private int get_TrainID()
        {
            int Train_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Train.ID FROM Train where Train.[Name]='" + tBoxName.Text + "'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0] != null)
                {
                    Train_id = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
            return Train_id;
        }
        private int get_ClassId()
        {
            int Train_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select [LookUp].ID FROM [LookUp] where [LookUp].[Name]='"+comboBox1.SelectedValue.ToString()+"'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0] != null)
                {
                    Train_id = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
            return Train_id;
        }
        private void Class_Fill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select[LookUp].[Name] FROM[LookUp] where[LookUp].Name = 'Economy' or[LookUp].Name = 'Business' or[LookUp].Name = 'AC'", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
            comboBox1.DataSource = dtable;
            comboBox1.DisplayMember = "LookUp";
            comboBox1.ValueMember = "Name";
        }
        private void Load_TrainCoaches(int tid,int cla)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Coach.Coach_No FROM Coach where Coach.Train_ID='"+get_TrainID()+"' and Coach.Class='"+get_ClassId()+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            change_form(new Form1());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Load_TrainCoaches(get_TrainID(), get_ClassId());
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seat s = new Seat();
            s.textBox1.Text = tBoxName.Text;
            s.textbox2.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            change_form(s);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
