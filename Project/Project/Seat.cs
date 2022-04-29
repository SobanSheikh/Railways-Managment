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
    public partial class Seat : Form
    {
        public Seat()
        {
            InitializeComponent();
        }
        private int max_TicketId=0;
        private int get_TrainID()
        {
            int Train_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Train.ID FROM Train where Train.[Name]='" + textBox1.Text + "'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                    Train_id = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
            return Train_id;
        }
        private int get_CoachId()
        {
            int Train_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Coach.ID FROM Coach where Coach.Coach_No='"+textbox2.Text+"' and Coach.Train_ID='"+get_TrainID()+"'", con);
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
        private void Available_Seats()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Seat.Seat_No from Seat where Coach_ID='"+get_CoachId()+"' and seat.[Status]=6", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dtable = new DataTable();
            dat.Fill(dtable);
            comboBox1.DataSource = dtable;
            comboBox1.DisplayMember = "Seat";
            comboBox1.ValueMember = "Seat_No";
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            change_form(new Book_t());
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
        private void DataGridViewFill()
        {
           /* foreach (int id in Program.listofSeats)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("select Coach.Coach_No FROM Coach where Coach.Train_ID='" + get_TrainID() + "' and Coach.Class='" + get_ClassId() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(); da.Fill(dt);
                dataGridView1.DataSource = dt;
            }*/
        }
        private void Seat_Load(object sender, EventArgs e)
        {
            DataGridViewFill();
            Available_Seats();
        }
        private void get_MaxTicketId()
        {
            max_TicketId = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select MAX(Ticket.ID) FROM Ticket", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                   max_TicketId = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
        }
        private int get_SeatId()
        {
            int Train_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Seat.ID FROM Seat where seat.Coach_ID='"+get_CoachId()+"' and Seat.Seat_No='"+comboBox1.SelectedValue.ToString()+"'", con);
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
        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Ticket values (@Ticket_ID,@Seat_ID,@Source,@Destination,@Status)", con);
            cmd.Parameters.AddWithValue("@Ticket_ID",max_TicketId+1);
            cmd.Parameters.AddWithValue("@Seat_ID",get_SeatId());
            cmd.Parameters.AddWithValue("@Source", Program.source);
            cmd.Parameters.AddWithValue("@Destination",Program.destination);
            cmd.Parameters.AddWithValue("@Status", 7);
            Program.listofSeats.Add(max_TicketId + 1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Seat Has Been occupied Successfully", "Message");
            Seat_Load(sender, e);
        }
    }
}
