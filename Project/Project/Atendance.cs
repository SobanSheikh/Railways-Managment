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
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
            Show();
            combo();
        }

        private void Show()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT s.Id,CONCAT(s.FirstName, ' ',s.LastName) as Name,s.RegistrationNumber,s.Contact as Status,s.Email as Date From Student s ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            foreach(DataGridViewRow d in dataGridView1.Rows)
            {
                d.Cells[3].Value = "Present";
                d.Cells[4].Value = DateTime.Now;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ar = 4;

            string a = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                
                
                if (a == "Present")
                {
                    ar = 1;
                }
                else if (a=="Absent")
                {
                    ar = 2;
                }
                else if(a=="Leave")
                {
                    ar = 3;
                }
                else if(a=="Late")
                {
                    ar = 4;
                }
       
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into StudentAttendance values (@AttendanceId,@StudentId, @AttendanceStatus)", con);
            
            cmd.Parameters.AddWithValue("@AttendanceId", int.Parse(comboBox1.Text));
            cmd.Parameters.AddWithValue("@StudentId", int.Parse(textBox2.Text));
            
            cmd.Parameters.AddWithValue("@AttendanceStatus", ar);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully added");
        }

        private void button6_Click(object sender, EventArgs e)
        {

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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            change_form(new Form1());
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Gold;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void combo()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from ClassAttendance", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
            comboBox1.DataSource = dtable;
            comboBox1.DisplayMember = "ClassAttendance";
            comboBox1.ValueMember = "ID";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Cells[0].Selected = true;
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.Cells[3].Value = comboBox2.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ar = 4;

            string a = dataGridView1.CurrentRow.Cells[3].Value.ToString();


            if (a == "Present")
            {
                ar = 1;
            }
            else if (a == "Absent")
            {
                ar = 2;
            }
            else if (a == "Leave")
            {
                ar = 3;
            }
            else if (a == "Late")
            {
                ar = 4;
            }

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update StudentAttendance set  AttendanceStatus=@AttendanceStatus where StudentId="+textBox2.Text+"AND AttendanceId="+comboBox1.Text, con);
            cmd.Parameters.AddWithValue("@AttendanceStatus", ar);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully updated");
        }
    }
}
