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
    public partial class Form11 : Form
    {
        private int Max_CoachID = 0;
        public Form11()
        {
            InitializeComponent();
        }
        private void CBoxTrainsFill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Train.Name from Train", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
            cBoxTrains.DataSource = dtable;
            cBoxTrains.DisplayMember = "Train";
            cBoxTrains.ValueMember = "Name";
        }
        private void get_MaxCoachId()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select MAX(Coach.ID) FROM Coach", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0] != null)
                {
                    Max_CoachID = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
        }
        private void DataGridView_Fill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Coach", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    
        private int get_TrainID()
        {
            int Train_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Train.ID FROM Train where Train.[Name]='" + cBoxTrains.SelectedValue.ToString() + "'", con);
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
        private int get_CoachClass()
        {
            int class_ID = 0;
            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd = new SqlCommand("select [LookUp].ID FROM [LookUp] where [LookUp].[Name]='" + cBoxClass.Text + "'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0] != null)
                {
                    class_ID = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
            return class_ID;
        }
        /* private void button4_Click(object sender, EventArgs e)
         {
             var con = Configuration.getInstance().getConnection();
             SqlCommand cmd = new SqlCommand("Insert into Coach values (@ID,@Train_ID,@Coach_No,@class)", con);
             cmd.Parameters.AddWithValue("@ID",Max_CoachID+1);
             cmd.Parameters.AddWithValue("@Train_ID",get_TrainID());
             cmd.Parameters.AddWithValue("@Coach_No", int.Parse(tBoxCoachNo.Text));
             cmd.Parameters.AddWithValue("@class",get_CoachClass());
             cmd.ExecuteNonQuery();
             MessageBox.Show("AssessmentComponent Has Been Added Successfully");
         }*/
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Coach values (@ID,@Train_ID,@Coach_No,@class)", con);
            cmd.Parameters.AddWithValue("@ID", Max_CoachID + 1);
            cmd.Parameters.AddWithValue("@Train_ID", get_TrainID());
            cmd.Parameters.AddWithValue("@Coach_No", int.Parse(tBoxCoachNo.Text));
            cmd.Parameters.AddWithValue("@class", get_CoachClass());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Coach Has Been Added Successfully");
            Form11_Load_1(sender, e);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Delete Coach Where Train_ID=@Train_ID and Coach_No=@Coach_No", con);
            cmd.Parameters.AddWithValue("@Train_ID", get_TrainID());
            cmd.Parameters.AddWithValue("@Coach_No", int.Parse(tBoxCoachNo.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Coach Has Been Removed Successfully");
             Form11_Load_1(sender, e);
        }

        private void Form11_Load_1(object sender, EventArgs e)
        {
            CBoxTrainsFill();
            get_MaxCoachId();
            DataGridView_Fill();
        }
    }
}
