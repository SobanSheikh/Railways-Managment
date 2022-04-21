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
    public partial class Form6 : Form
    {
        private int Max_StationId;
        public Form6()
        {
            InitializeComponent();
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("execute  sp_AddStation @Station_ID=@Id,@Station_Name=@Name,@Station_Location=@Location", con);
            cmd.Parameters.AddWithValue("@Id", Max_StationId+1);
            cmd.Parameters.AddWithValue("@Name", tBoxName.Text);
            cmd.Parameters.AddWithValue("@Location", tBoxLocation.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Station Has Been Added Successfully");
            Form6_Load(sender, e);
        }
        private void DataGridView_Fill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Station", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void get_MaxStationID()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select MAX(Station.ID) FROM Station", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                Max_StationId = int.Parse(rq[0].ToString());
            }
            rq.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            DataGridView_Fill();
            get_MaxStationID();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("execute  sp_RemoveStation @Station_Name=@Name,@Station_Location=@Location", con);
            cmd.Parameters.AddWithValue("@Name", tBoxName.Text);
            cmd.Parameters.AddWithValue("@Location", tBoxLocation.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Station Has Been Removed Successfully");
            Form6_Load(sender, e);
        }
    }
}
