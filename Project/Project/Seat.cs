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
            SqlCommand cmd = new SqlCommand("select Seat.Seat_No FROM Seat where Seat.Coach_ID='"+get_CoachId()+"' and Seat.ID NOT IN (select Ticket.Seat_ID FROM Booking JOIN Ticket ON Ticket.Ticket_No=Booking.Ticket_ID where YEAR(Booking.Travel_Date) =YEAR('"+dateTimePicker1.Value+ "') and MONTH(Booking.Travel_Date)=MONTH('" + dateTimePicker1.Value + "') and DAY(Booking.Travel_Date)=DAY('" + dateTimePicker1.Value + "') )", con);
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
        private int get_MaxTicketId()
        {
            max_TicketId = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select MAX(Ticket.Ticket_No) FROM Ticket", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                   max_TicketId = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
            return max_TicketId;
        }
        private int get_SeatId()
        {
            int Train_id = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Seat.ID FROM Seat where seat.Coach_ID='"+get_CoachId()+"' and Seat.Seat_No='"+comboBox1.SelectedValue.ToString()+"'", con);
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
        private int select_Class()
        {
            int f = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Coach.Class from Coach where Coach.ID='"+get_CoachId()+"'", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                    f = int.Parse(rq[0].ToString());
                }
            }
            rq.Close();
            return f;
        }
        private int Calculate_Fare()
        {
            int f = 0;
            if (select_Class()==3)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("select Train_Details.Economy_Fare FROM Train_Details where Train_Details.Source='" + Program.source + "' and Train_Details.Destination='" + Program.destination + "' and Train_Details.Train_ID='" + get_TrainID() + "'", con);
                SqlDataReader rq = cmd.ExecuteReader();
                while (rq.Read())
                {
                    if (rq[0].ToString() != "")
                    {
                        f = int.Parse(rq[0].ToString());
                    }
                }
                rq.Close();
            }
            else if(select_Class()==4)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("select Train_Details.Business_Fare FROM Train_Details where Train_Details.Source='" + Program.source + "' and Train_Details.Destination='" + Program.destination + "' and Train_Details.Train_ID='" + get_TrainID() + "'", con);
                SqlDataReader rq = cmd.ExecuteReader();
                while (rq.Read())
                {
                    if (rq[0].ToString() != "")
                    {
                        f = int.Parse(rq[0].ToString());
                    }
                }
                rq.Close();
            }
            else
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("select Train_Details.AC FROM Train_Details where Train_Details.Source='" + Program.source + "' and Train_Details.Destination='" + Program.destination + "' and Train_Details.Train_ID='" + get_TrainID() + "'", con);
                SqlDataReader rq = cmd.ExecuteReader();
                while (rq.Read())
                {
                    if (rq[0].ToString() != "")
                    {
                        f = int.Parse(rq[0].ToString());
                    }
                }
                rq.Close();
            }
            return f;
        }
        private void Add_Booking(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Booking values (@Ticket_ID,@User_ID,GETDATE(),@TDate,@Fare)", con);
            cmd.Parameters.AddWithValue("@Ticket_ID",id);
            cmd.Parameters.AddWithValue("@User_ID", Program.current_UserID);
            cmd.Parameters.AddWithValue("@TDate",dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Fare",Calculate_Fare());
            cmd.ExecuteNonQuery();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Ticket values (@Ticket_ID,@Seat_ID,@Source,@Destination,@Status)", con);
            cmd.Parameters.AddWithValue("@Ticket_ID", get_MaxTicketId()+1);
            cmd.Parameters.AddWithValue("@Seat_ID",get_SeatId());
            cmd.Parameters.AddWithValue("@Source", Program.source);
            cmd.Parameters.AddWithValue("@Destination",Program.destination);
            cmd.Parameters.AddWithValue("@Status", 7);
            cmd.ExecuteNonQuery();
            Add_Booking(get_MaxTicketId());
            Program.listofSeats.Add(get_MaxTicketId());
            MessageBox.Show("Seat Has Been occupied Successfully", "Message");
            Seat_Load(sender, e);
        }

        private void DateChange_Value(object sender, EventArgs e)
        {
            Available_Seats();
        }
    }
}
