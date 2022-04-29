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
    public partial class Form4 : Form
    {
        private int Max_UserID=0;
        public Form4()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

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
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (is_account() == false)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO [USER] VALUES(@Id,@Name,@Password,@Email,@Contact,@CNIC,@DateofBirth)", con);
                cmd.Parameters.AddWithValue("@Id", Max_UserID + 1);
                cmd.Parameters.AddWithValue("@Name", tBoxName.Text);
                cmd.Parameters.AddWithValue("@Password", tBoxPassword.Text);
                cmd.Parameters.AddWithValue("@Email", tBoxEmail.Text);
                cmd.Parameters.AddWithValue("@Contact", tBoxContact.Text);
                cmd.Parameters.AddWithValue("@CNIC", tBoxCNIC.Text);
                cmd.Parameters.AddWithValue("@DateofBirth", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account Has Been Created Successfully");
            }
            else
            {
                MessageBox.Show("Your Account Already Exists");
            }
            Form4_Load(sender, e);
        }
        private void get_MaxUserId()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select MAX(ID) FROM [User]", con);
            var rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                   if(rq[0]!=null)
                    Max_UserID = int.Parse(rq[0].ToString());  
            }
            rq.Close();
        }
        private bool is_account()
        {
            bool flag=false;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select * from [User]", con);
            SqlDataReader rq = cmd.ExecuteReader();
            while (rq.Read())
            {
                if ((rq[1].ToString() == tBoxName.Text.ToString() && rq[2].ToString() ==tBoxPassword.Text.ToString()) || (rq[3].ToString() == tBoxEmail.Text.ToString() && rq[2].ToString() == tBoxPassword.Text.ToString()))
                {
                    flag = true;
                }
            }
            rq.Close();
            return flag;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            clean();
            get_MaxUserId();
        }
        private void clean()
        {
            tBoxName.Text = "";
            tBoxEmail.Text = "";
            tBoxCNIC.Text = "";
            tBoxContact.Text = "";
            tBoxPassword.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clean();
        }
        private void tBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            change_form(new Form3());
        }
    }
}
