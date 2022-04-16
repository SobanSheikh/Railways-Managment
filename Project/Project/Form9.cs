using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Forms;
using Document = iTextSharp.text.Document;

namespace Project
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex==0)

            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Clo.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                { 
                    if (!ErrorMessage)
                    {
                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in dataGridView1.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    pTable.AddCell(dcell.Value.ToString());
                                }
                            }
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                iTextSharp.text.Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("File Generated Successfully");
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "PDF (*.pdf)|*.pdf";
                    save.FileName = "Assessment.pdf";
                    bool ErrorMessage = false;
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        if (!ErrorMessage)
                        {
                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in dataGridView1.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    pTable.AddCell(dcell.Value.ToString());
                                }
                            }
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                iTextSharp.text.Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("File Generated Successfully");
                        }
                    }
                }
            
            else if (comboBox1.SelectedIndex == 2)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Attendance.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (!ErrorMessage)
                    {
                        PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                        pTable.DefaultCell.Padding = 2;
                        pTable.WidthPercentage = 100;
                        pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                            pTable.AddCell(pCell);
                        }
                        foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell dcell in viewRow.Cells)
                            {
                                pTable.AddCell(dcell.Value.ToString());
                            }
                        }
                        using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                        {
                            iTextSharp.text.Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                            PdfWriter.GetInstance(document, fileStream);
                            document.Open();
                            document.Add(pTable);
                            document.Close();
                            fileStream.Close();
                        }
                        MessageBox.Show("File Generated Successfully");
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Student.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (!ErrorMessage)
                    {
                        PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                        pTable.DefaultCell.Padding = 2;
                        pTable.WidthPercentage = 100;
                        pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                            pTable.AddCell(pCell);
                        }
                        foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell dcell in viewRow.Cells)
                            {
                                pTable.AddCell(dcell.Value.ToString());
                            }
                        }
                        using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                        {
                            iTextSharp.text.Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                            PdfWriter.GetInstance(document, fileStream);
                            document.Open();
                            document.Add(pTable);
                            document.Close();
                            fileStream.Close();
                        }
                        MessageBox.Show("File Generated Successfully");
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Rubric.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (!ErrorMessage)
                    {
                        PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                        pTable.DefaultCell.Padding = 2;
                        pTable.WidthPercentage = 100;
                        pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                            pTable.AddCell(pCell);
                        }
                        foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell dcell in viewRow.Cells)
                            {
                                pTable.AddCell(dcell.Value.ToString());
                            }
                        }
                        using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                        {
                            iTextSharp.text.Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                            PdfWriter.GetInstance(document, fileStream);
                            document.Open();
                            document.Add(pTable);
                            document.Close();
                            fileStream.Close();
                        }
                        MessageBox.Show("File Generated Successfully");
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECt distinct c.Name AS CLO,AC.Name AS CloAttain,COUNT(StudentId) AS NumberofStudent,(SUM(AC.TotalMarks)/4) As AverageClo  FROm StudentResult SR Join RubricLevel RL1  On RL1.Id=SR.RubricMeasurementId Join AssessmentComponent AC On AC.Id=SR.AssessmentComponentId  Join Rubric R1 On R1.Id=AC.RubricId Join Clo C On C.Id=R1.CloId join Assessment a on a.Id=ac.AssessmentId Group by c.Name,ac.Name,Rl1.MeasurementLevel,ac.TotalMarks,r1.Id", con);
                SqlDataAdapter d = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                d.Fill(dt2);
                dataGridView1.DataSource = dt2;
            } 
           if (comboBox1.SelectedIndex==1)
            {

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECt distinct a.Title,Concat (s.FirstName,' ' ,s.LastName) AS Name,SUm(a.TotalMarks) TotalMarks,Sum(a.TotalWeightage)/Count(a.TotalMarks) as Weightage  FROm Assessment a join AssessmentComponent Ac  on a.Id=Ac.AssessmentId join StudentResult sr on Ac.Id=Sr.AssessmentComponentId join Student s on s.Id=Sr.StudentId Group by a.Title,s.FirstName,s.LastName", con);
                SqlDataAdapter d = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                d.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECt Concat(s.FirstName,' ',s.LastName) As name,s.RegistrationNumber,sa.StudentId,ca.AttendanceDate,sa.AttendanceStatus FROm StudentAttendance sa join ClassAttendance ca on sa.AttendanceId=ca.Id join Student s on s.Id=sa.StudentId", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * From Student", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT distinct r.Details,a.TotalMarks,a.TotalWeightage,Sum(a.TotalMarks)/4 As Avg_ FROM Rubric r join RubricLevel rl on r.Id=rl.RubricId join StudentResult sr on rl.Id=sr.RubricMeasurementId join AssessmentComponent ac on sr.AssessmentComponentId=ac.Id join Assessment a on a.Id=ac.AssessmentId group by r.Details,a.TotalMarks,a.TotalWeightage", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gold;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }
    }
    }

