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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        private void DataGridViewFill()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select * FROM View_Passenger", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form12_Load(object sender, EventArgs e)
        {
            DataGridViewFill();
        }
    }
}
