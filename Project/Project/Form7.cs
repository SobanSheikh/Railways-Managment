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
    public partial class Form7 : Form
    {
        private int Max_TrainId=0;
        private int current_TrainID=-1;
        public Form7()
        {
            InitializeComponent();
            
        }
        private void combo()
        {
            
        }
        private void button6_MouseEnter(object sender, EventArgs e)
        {

        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {
           
        }
        private void button6_Click(object sender, EventArgs e)
        {
            
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Gold;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Transparent;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Gold;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Transparent;
        }
        private void button7_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Gold;
        }
        private void button7_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Transparent;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("execute sp_AddTrain @TrainId=@Id,@TrainName=@Name", con);
            cmd.Parameters.AddWithValue("@Id", Max_TrainId + 1);
            cmd.Parameters.AddWithValue("@Name",tBoxName.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Train Has Been Added Successfully");
            Form7_Load(sender,e);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("execute sp_RemoveTrain @TrainName=@Name", con);
            cmd.Parameters.AddWithValue("@Name", tBoxName.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Train Has Been Removed Successfully");
            Form7_Load(sender, e);
        }
        private void DataGridView_Fill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from view_Train", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void get_MaxTrainId()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Train.ID FROM Train where Train.[Name]='a' ", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                    current_TrainID = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
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
        private void Form7_Load(object sender, EventArgs e)
        {
            get_MaxTrainId();
            DataGridView_Fill();
        }
        private void btnCoach_Click(object sender, EventArgs e)
        {
            change_form(new Form11());
        }
        private void Cell_Clicked(object sender, DataGridViewCellEventArgs e)
        {
             dataGridView1.CurrentRow.Selected = true;
             tBoxName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
             get_CurrentTrainID(tBoxName.Text);     
        }

        private void get_CurrentTrainID(string name)
        {
           
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Train.ID FROM Train where Train.[Name]='"+name+"'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                    current_TrainID = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            if (current_TrainID >= 0)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("execute sp_UpdateTrain @Train_Name=@Name,@Train_Id=@Id", con);
                cmd.Parameters.AddWithValue("@Name", tBoxName.Text);
                cmd.Parameters.AddWithValue("@Id", current_TrainID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Train Has Been Updated Successfully");
            }
            Form7_Load(sender, e);
        }

        private void btnFare_Click(object sender, EventArgs e)
        {
            change_form(new Form13());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            change_form(new Form5());
        }
    }
}
