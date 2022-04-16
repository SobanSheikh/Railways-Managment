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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            ShowForm();
            combo();
            comboBox();
        }

        private void ShowForm()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from AssessmentComponent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into AssessmentComponent values (@Name, @RubricId,@TotalMarks,@DateCreated,@DateUpdated,@AssessmentId)", con);

           
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
         
            cmd.Parameters.AddWithValue("@DateCreated",DateTime.Now );
            cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Now);
            cmd.Parameters.AddWithValue("@TotalMarks", textBox9.Text);
            cmd.Parameters.AddWithValue("@RubricId", comboBox1.Text);
            cmd.Parameters.AddWithValue("@AssessmentId", comboBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully added");
            ShowForm();
        }

        private void comboBox()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Rubric", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
            comboBox1.DataSource = dtable;
            comboBox1.DisplayMember = "Rubric";
            comboBox1.ValueMember = "ID";
        }

        private void combo()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Assessment", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
            comboBox2.DataSource = dtable;
            comboBox2.DisplayMember = "Assessment";
            comboBox2.ValueMember = "ID";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();

            if (textBox1.Text != "")
            {
                SqlCommand cmd = new SqlCommand("update AssessmentComponent set Name='" + textBox1.Text + "' WHERE Id='" + textBox3.Text + "'", con);
                cmd.ExecuteNonQuery();
            }
            
            if (textBox9.Text != "")
            {
                SqlCommand cmd = new SqlCommand("update AssessmentComponent set TotalMarks='" + textBox9.Text + "' WHERE Id='" + textBox3.Text + "'", con);
                cmd.ExecuteNonQuery();
            }
            ShowForm();
            MessageBox.Show("Successfully Updated");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM AssessmentComponent WHERE  Id=" + textBox3.Text, con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Successfully Deleted");
            ShowForm();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from AssessmentComponent WHERE  Id Like '%" + textBox5.Text + "%' OR Name Like '%" + textBox5.Text + "%' OR RubricId Like '%" + textBox5.Text + "%' OR TotalMarks Like '%" + textBox5.Text + "%' OR AssessmentId Like '%" + textBox5.Text + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
