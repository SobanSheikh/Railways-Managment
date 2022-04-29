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
    public partial class Form13 : Form
    {
        private int Max_TrainDetailId;
        public Form13()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void get_MaxTrainDetailId()
        {
            Max_TrainDetailId = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select MAX(Train_Details.ID) FROM Train_Details", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                     Max_TrainDetailId = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
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
        private int Get_SourceId()
        {
            int station_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Station.ID FROM Station where Station.[Name]='" +  cBoxSource.SelectedValue.ToString() + "'", con);
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
        private int Get_DestinationId()
        {
            int station_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Station.ID FROM Station where Station.[Name]='" + cBoxDest.SelectedValue.ToString() + "'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                    station_id = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
            return station_id;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Train_Details values (@ID,@Train_ID,@Source_Id,@Dest_ID,@AC,@Business,@Economy)", con);
            cmd.Parameters.AddWithValue("@ID", Max_TrainDetailId + 1);
            cmd.Parameters.AddWithValue("@Train_ID", get_TrainID());
            cmd.Parameters.AddWithValue("@Source_Id", Get_SourceId());
            cmd.Parameters.AddWithValue("@Dest_ID", Get_DestinationId());
            cmd.Parameters.AddWithValue("@AC", int.Parse(tBoxAc.Text));
            cmd.Parameters.AddWithValue("@Business", int.Parse(tBoxBusi.Text));
            cmd.Parameters.AddWithValue("@Economy", int.Parse(tBoxEco.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Fare Details Has Been Added Successfully");
            Form13_Load(sender, e);
        }
        private void CBOXTrainFill()
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
        private void CBoxSource()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Station.Name from Station", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
             cBoxSource.DataSource = dtable;
             cBoxSource.DisplayMember = "Station";
             cBoxSource.ValueMember = "Name";
        }
        private void CBoxDestinationFill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Station.Name from Station ", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
            cBoxDest.DataSource = dtable;
            cBoxDest.DisplayMember = "Station";
            cBoxDest.ValueMember = "Name";
        }
        private void DataGridView_Fill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from view_FareDetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form13_Load(object sender, EventArgs e)
        {
            DataGridView_Fill();
            CBOXTrainFill();
            CBoxSource();
            CBoxDestinationFill();
            get_MaxTrainDetailId();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Delete FROM Train_Details Where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Get_TrainDetailsId());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Detail Has Been Removed Successfully");
            Form13_Load(sender, e);
        }

        private int Get_TrainDetailsId()
        {
            int id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Train_Details.ID FROM Train_Details where Train_Details.Train_ID='" + get_TrainID() + "'and Source='"+Get_SourceId()+"' and Destination='"+Get_DestinationId()+"'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0] != null)
                {
                    id = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
            return id;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update Train_Details SET AC_Fare=@AC,Business_Fare=@Business,Economy_Fare=@Economy WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Get_TrainDetailsId());
            cmd.Parameters.AddWithValue("@AC", int.Parse(tBoxAc.Text));
            cmd.Parameters.AddWithValue("@Business", int.Parse(tBoxBusi.Text));
            cmd.Parameters.AddWithValue("@Economy", int.Parse(tBoxEco.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Fare Detail Has Been Updated Successfully");
            Form13_Load(sender, e);
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
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            change_form(new Form7());
        }
    }
}
