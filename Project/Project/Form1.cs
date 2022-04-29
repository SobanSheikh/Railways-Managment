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
    public partial class Form1 : Form
    {
        public Form1()
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
        private void CBoxSource()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Station.Name from Station", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
            comboBox1.DataSource = dtable;
            comboBox1.DisplayMember = "Station";
            comboBox1.ValueMember = "Name";
        }
        private void CBOXDestination()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Station.Name from Station", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
            CBox2.DataSource = dtable;
            CBox2.DisplayMember = "Station";
            CBox2.ValueMember = "Name";
        }
        private int Get_SourceId()
        {
            int station_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Station.ID FROM Station where Station.[Name]='" +comboBox1.SelectedValue.ToString() + "'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0] != null)
                {
                    station_id = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
            return station_id;
        }
        private int Get_DestinationID()
        {
            int station_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Station.ID FROM Station where Station.[Name]='" + CBox2.SelectedValue.ToString() + "'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0] != null)
                {
                    station_id = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
            return station_id;
        }
        private void Load_Trains(int s,int des)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select distinct Train.[Name] FROM Train_Details JOIN Train ON Train_Details.Train_ID=Train.ID WHERE Train_Details.Source='"+s+"' and Train_Details.Destination='"+des+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Load_Trains(Get_SourceId(), Get_DestinationID());
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            change_form(new Form8());
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.source = Get_SourceId();
            Program.destination = Get_DestinationID();
            Book_t bt = new Book_t();
            bt.tBoxName.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            change_form(bt);
        }
        private void Load_Form1(object sender, EventArgs e)
        {
            CBoxSource();
            CBOXDestination();
        }
    }
}
