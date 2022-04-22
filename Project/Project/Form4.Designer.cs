
namespace Project
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tBoxPassword = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tBoxName = new System.Windows.Forms.TextBox();
            this.tBoxEmail = new System.Windows.Forms.TextBox();
            this.tBoxCNIC = new System.Windows.Forms.TextBox();
            this.tBoxContact = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 466);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.1711F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.8289F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.tableLayoutPanel1.Controls.Add(this.tBoxName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tBoxEmail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tBoxPassword, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tBoxContact, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tBoxCNIC, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(123, 88);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(485, 100);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // tBoxPassword
            // 
            this.tBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBoxPassword.Location = new System.Drawing.Point(265, 3);
            this.tBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tBoxPassword.Name = "tBoxPassword";
            this.tBoxPassword.PlaceholderText = "Password";
            this.tBoxPassword.Size = new System.Drawing.Size(218, 23);
            this.tBoxPassword.TabIndex = 7;
            this.tBoxPassword.TextChanged += new System.EventHandler(this.tBoxPassword_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(266, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(216, 23);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // tBoxName
            // 
            this.tBoxName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBoxName.Location = new System.Drawing.Point(2, 3);
            this.tBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.tBoxName.Name = "tBoxName";
            this.tBoxName.PlaceholderText = "Name ";
            this.tBoxName.Size = new System.Drawing.Size(220, 23);
            this.tBoxName.TabIndex = 2;
            // 
            // tBoxEmail
            // 
            this.tBoxEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBoxEmail.Location = new System.Drawing.Point(2, 36);
            this.tBoxEmail.Margin = new System.Windows.Forms.Padding(2);
            this.tBoxEmail.Name = "tBoxEmail";
            this.tBoxEmail.PlaceholderText = "Email";
            this.tBoxEmail.Size = new System.Drawing.Size(220, 23);
            this.tBoxEmail.TabIndex = 8;
            // 
            // tBoxCNIC
            // 
            this.tBoxCNIC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBoxCNIC.Location = new System.Drawing.Point(2, 72);
            this.tBoxCNIC.Margin = new System.Windows.Forms.Padding(2);
            this.tBoxCNIC.Name = "tBoxCNIC";
            this.tBoxCNIC.PlaceholderText = "CNIC";
            this.tBoxCNIC.Size = new System.Drawing.Size(220, 23);
            this.tBoxCNIC.TabIndex = 11;
            // 
            // tBoxContact
            // 
            this.tBoxContact.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBoxContact.Location = new System.Drawing.Point(265, 36);
            this.tBoxContact.Margin = new System.Windows.Forms.Padding(2);
            this.tBoxContact.Name = "tBoxContact";
            this.tBoxContact.PlaceholderText = "Contact";
            this.tBoxContact.Size = new System.Drawing.Size(218, 23);
            this.tBoxContact.TabIndex = 6;
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.Location = new System.Drawing.Point(366, 240);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(78, 29);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClear.Location = new System.Drawing.Point(218, 240);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 29);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(303, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create Account";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 466);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form4";
            this.Text = "User Registration";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tBoxCNIC;
        private System.Windows.Forms.TextBox tBoxEmail;
        private System.Windows.Forms.TextBox tBoxPassword;
        private System.Windows.Forms.TextBox tBoxContact;
        private System.Windows.Forms.TextBox tBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}