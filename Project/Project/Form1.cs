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
            Show();
        }

        private void Show()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from ClassAttendance ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime time = dateTimePicker1.Value;
            
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into ClassAttendance values (@AttendanceDate)", con);

            
            cmd.Parameters.AddWithValue("@AttendanceDate", time.Date);
            


            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully added");
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Delete from StudentAttendance where StudentId=(select Id from ClassAttendance where Id="+dataGridView1.CurrentRow.Cells[0].Value+") ", con);
            cmd.Parameters.AddWithValue("@Id", dataGridView1.CurrentRow.Cells[0].Value);
            cmd.ExecuteNonQuery();

            con = Configuration.getInstance().getConnection();
            cmd = new SqlCommand("Delete from StudentAttendance where AttendanceId=(select Id from ClassAttendance where Id="+dataGridView1.CurrentRow.Cells[0].Value+" )", con);
            cmd.Parameters.AddWithValue("@Id", dataGridView1.CurrentRow.Cells[0].Value);
            cmd.ExecuteNonQuery();

            con = Configuration.getInstance().getConnection();
             cmd = new SqlCommand("Delete from ClassAttendance where Id=@Id ", con);
            cmd.Parameters.AddWithValue("@Id", dataGridView1.CurrentRow.Cells[0].Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
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
        private void label3_Click(object sender, EventArgs e)
        {
            change_form(new Attendance());
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.Gold;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.Transparent;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gold;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gold;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }
    }
}
