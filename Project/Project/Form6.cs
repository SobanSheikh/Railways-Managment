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
        private int current_StationID = -1;
        private int Max_StationId=0;
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
            SqlCommand cmd = new SqlCommand("Select * from view_Station", con);
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
                if (rq[0].ToString()!="")
                {
                    Max_StationId = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            DataGridView_Fill();
            get_MaxStationID();
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("DELETE T FROM Train_Route T, Station S Where S.Name=@Name and S.Location=@Location and S.ID=T.Station_ID ", con);
            SqlCommand cmd = new SqlCommand("execute  sp_RemoveStation @Station_Name=@Name,@Station_Location=@Location", con);
            cmd.Parameters.AddWithValue("@Name", tBoxName.Text);
            cmd.Parameters.AddWithValue("@Location", tBoxLocation.Text);
            cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Station Has Been Removed Successfully");
            Form6_Load(sender, e);
        }
        private void get_CurrentStationID(string name,string loc)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Station.ID from Station where Station.[Name] ='"+name+"' and Station.[Location]='"+loc+"'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                    current_StationID = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
        }
        private void Cell_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            tBoxName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            tBoxLocation.Text= dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            get_CurrentStationID(tBoxName.Text,tBoxLocation.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if ( current_StationID >= 0)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("execute sp_UpdateStation @Station_ID=@Id,@Station_Name=@Name,@Station_Location=@Location", con);
                cmd.Parameters.AddWithValue("@Id", current_StationID);
                cmd.Parameters.AddWithValue("@Name", tBoxName.Text);
                cmd.Parameters.AddWithValue("@Location",tBoxLocation.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Train Has Been Updated Successfully");
            }
            Form6_Load(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            change_form(new Form5());
        }
    }
}
