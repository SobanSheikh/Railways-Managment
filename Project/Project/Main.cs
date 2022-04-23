using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Main : Form
    {
        public Main()
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
            panel2.Controls.Add(form);
            panel2.Tag = form;
            form.BringToFront();
            form.Show();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            change_form(new Form2());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            change_form(form);
            
        }

       
           

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState== FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
