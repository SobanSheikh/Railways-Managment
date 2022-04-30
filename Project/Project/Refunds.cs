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
    public partial class Refunds : Form
    {
        List<int> L = new List<int>();
        public Refunds()
        {
            InitializeComponent();
        }

        private void Refunds_Load(object sender, EventArgs e)
        {
            Grid_Fill();
            textBox1.Text = Get_Totalfare().ToString();
        }
        private void Grid_Fill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Booking.Ticket_ID as [Ticket Number],Booking.Travel_Date as [Travelling Date],Booking.Fare as [Refunded Ammount] From Booking JOIN Ticket ON Ticket.Ticket_No=Booking.Ticket_ID  where Booking.[User_ID]='" + Program.current_UserID + "' and Ticket.[Status] = 9", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private int Get_Totalfare()
        {
            int fare = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Booking.Ticket_ID as [Ticket Number],Booking.Travel_Date as [Travelling Date],Booking.Fare From Booking JOIN Ticket ON Ticket.Ticket_No=Booking.Ticket_ID  where Booking.[User_ID]='" + Program.current_UserID + "' and Ticket.[Status] = 9", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                    fare = fare + int.Parse(rq[2].ToString());
                }
            }
            rq.Close();
            return fare;
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
            change_form(new Form8());
        }
        private void Seat_IDS()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Booking.Ticket_ID as [Ticket Number],Booking.Travel_Date as [Travelling Date],Booking.Fare as [Refunded Ammount] From Booking JOIN Ticket ON Ticket.Ticket_No=Booking.Ticket_ID  where Booking.[User_ID]='" + Program.current_UserID + "' and Ticket.[Status] = 9", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                    L.Add(int.Parse(rq[0].ToString()));
                }
            }
            rq.Close();
        }
        private void Change_Ticket()
        {
            Seat_IDS();
            foreach(int id in L)
             {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Update Ticket SET [Status]=10 where Ticket.Ticket_No='" + id + "'", con);
                cmd.ExecuteNonQuery();
            }
            L.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox1.SelectedIndex.ToString() != "")
            {
                MessageBox.Show("Ammount Has benn Added to Your Account");
                Change_Ticket();
            }
            else
            {
                MessageBox.Show("Invalid Method or Account Number");
            }
            Refunds_Load(sender, e);
        }
    }
}
