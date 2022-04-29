using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Project
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        private int get_TrainID()
        {
            int Train_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Train.ID FROM Train where Train.[Name]='" + cBoxTrain.SelectedValue.ToString() + "'", con);
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
        private int get_StationId()
        {
            int station_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Station.ID FROM Station where Station.[Name]='" + cBoxStation.SelectedValue.ToString() + "'", con);
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
        private void CBoxTrainFill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Train.Name from Train", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
             cBoxTrain.DataSource = dtable;
             cBoxTrain.DisplayMember = "Train";
            cBoxTrain.ValueMember = "Name";
        }
        private void CBoxStationFill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Station.[Name] from Station", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
            cBoxStation.DataSource = dtable;
            cBoxStation.DisplayMember = "Station";
            cBoxStation.ValueMember = "Name";
        }
        private void DataGridView_Fill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from View_Routes", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void Form10_Load(object sender, EventArgs e)
        {
            CBoxTrainFill();
            CBoxStationFill();
            DataGridView_Fill();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Train_Route values (@Train_ID,@Station_ID,@Arrival_Time,@Dep_Time)", con);
            cmd.Parameters.AddWithValue("@Train_ID", get_TrainID());
            cmd.Parameters.AddWithValue("@Station_ID", get_StationId());
            cmd.Parameters.AddWithValue("@Arrival_Time", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Dep_Time", dateTimePicker2.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Route Has Been Added Successfully","Message");
            Form10_Load(sender, e);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Train_Route WHERE Train_Route.Train_ID=@Train_ID and Train_Route.Station_ID=@Station_ID", con);
            cmd.Parameters.AddWithValue("@Train_ID", get_TrainID());
            cmd.Parameters.AddWithValue("@Station_ID",get_StationId());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Route Has Been Removed Successfully");
            Form10_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update Train_Route SET Train_Route.ArrivalTime=@Arrival_Time,Train_Route.DepartureTime=@Dep_Time WHERE Train_Route.Train_ID=@Train_ID and Train_Route.Station_ID=@Station_ID", con);
            cmd.Parameters.AddWithValue("@Train_ID", get_TrainID());
            cmd.Parameters.AddWithValue("@Station_ID", get_StationId());
            cmd.Parameters.AddWithValue("@Arrival_Time", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Dep_Time", dateTimePicker2.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Route Has Been Updated Successfully");
            Form10_Load(sender, e);
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
            panel2.Controls.Add(form);
            panel2.Tag = form;
            form.BringToFront();
            form.Show();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            change_form(new Form5());
        }
    }
}
