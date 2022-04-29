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
    public partial class Payment : Form
    {
        List<int> L = new List<int>();
        private string cancel = "";
        public Payment()
        {
            InitializeComponent();
        }
        private void Update_Ticket()
        {
            foreach(int id in  L)
            {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("update Ticket set [Status]=8 where Ticket.Ticket_No='"+id+"'", con);
                    cmd.ExecuteNonQuery();
            }
            L.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox1.SelectedIndex.ToString() != "")
            {
                MessageBox.Show("Payment has been made successfully");
                Update_Ticket();
            }
            else
            {
                MessageBox.Show("Invalid Method or Account Number");
            }
            Payment_Load(sender, e);
        }
        private int Get_Totalfare()
        {
            int fare = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from view_Booking", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if (rq[0].ToString() != "")
                {
                    fare =fare + int.Parse(rq[2].ToString());
                }
            }
            rq.Close();
            return fare;
        }
        private void Seat_IDS()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Booking.Ticket_ID as [Ticket Number],Booking.Travel_Date as [Travelling Date],Booking.Fare From Booking JOIN Ticket ON Ticket.Ticket_No=Booking.Ticket_ID where Booking.[User_ID]='"+Program.current_UserID+"' and Ticket.[Status] != 8", con);
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
        private void DATAGRIDVIEWFILL()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Booking.Ticket_ID as [Ticket Number],Booking.Travel_Date as [Travelling Date],Booking.Fare From Booking JOIN Ticket ON Ticket.Ticket_No=Booking.Ticket_ID where Booking.[User_ID]='" + Program.current_UserID + "' and Ticket.[Status] != 8", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            textBox1.Text = Get_Totalfare().ToString();
            DATAGRIDVIEWFILL();
            Seat_IDS();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(cancel!="")
            {
                Delete_Booking();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Ticket where Ticket.Ticket_No='" + int.Parse(cancel) + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ticket Cancelled");
            }
            else
            {
                MessageBox.Show("No Ticket Selected");
            }
            Payment_Load(sender, e);
        }
        private void Delete_Booking()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Booking where Booking.Ticket_ID='" + int.Parse(cancel) + "'", con);
            cmd.ExecuteNonQuery();
        }
        private void Cell_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            cancel = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
        }
    }
}
