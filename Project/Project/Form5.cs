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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            
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
            panel3.Controls.Add(form);
            panel3.Tag = form;
            form.BringToFront();
            form.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            change_form(new Form6());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            change_form(new Form7());
        }
    }
}
