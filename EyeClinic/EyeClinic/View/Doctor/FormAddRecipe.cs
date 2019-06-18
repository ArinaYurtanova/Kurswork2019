using EyeClinic.Service.Interface;
using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace EyeClinic.View.Doctor
{
    public partial class FormAddRecipe : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private int? id;
        private readonly IMedicalHistory service;
        private readonly IMedication serviceM;
        public static string file;
        public FormAddRecipe(IMedicalHistory service, IMedication serviceM)
        {
            InitializeComponent();
            this.service = service;
            this.serviceM = serviceM;
        }

        private void FormAddRecipe_Load(object sender, EventArgs e)
        {
            List<MedicationView> listM = serviceM.GetList();
            if (listM != null)
            {
                comboBoxMedication.DisplayMember = "MedicationName";
                comboBoxMedication.ValueMember = "Id";
                comboBoxMedication.DataSource = listM;
                comboBoxMedication.SelectedItem = null;
            }
            comboBoxMedication.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxMedication.AutoCompleteSource = AutoCompleteSource.ListItems;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                List<RecipeView> list = service.GetListRecipe(id.Value);
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].HeaderText = "Номер";
                    dataGridView1.Columns[1].HeaderText = "Пациент";
                    dataGridView1.Columns[2].HeaderText = "Врач";
                    dataGridView1.Columns[3].HeaderText = "Заболевание";
                    dataGridView1.Columns[4].HeaderText = "Лечение";
                    dataGridView1.Columns[5].HeaderText = "Статус";
                    dataGridView1.Columns[6].HeaderText = "Дата";



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Export_Data_To_Word(dataGridView1, sfd.FileName);
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];


                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    }
                }

                var winword = new Microsoft.Office.Interop.Word.Application();
                object missing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Document oDoc =
                    winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                oDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }


                oRange.Text = oTemp;

                object Separator = Microsoft.Office.Interop.Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();


                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 10;


                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }
                oDoc.Application.Selection.Tables[1].Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;
                oDoc.Application.Selection.Tables[1].Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;

                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;


                oDoc.Application.Selection.Tables[1].Rows[RowCount + 2].Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleNone;
                oDoc.Application.Selection.Tables[1].Rows[RowCount + 2].Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleNone;
                oDoc.Application.Selection.Tables[1].Rows[RowCount + 1].Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleDouble;

                foreach (Microsoft.Office.Interop.Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Лекарственный рецепт, действующий с  " + dateTimePicker1.Text +" в течение 14 дней";

                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }
                var paragraph = oDoc.Paragraphs.Add(missing);
                var range = paragraph.Range;
                paragraph = oDoc.Paragraphs.Add(missing);
                range = paragraph.Range;

                range.Text = "Выписанное лекарство: " + comboBoxMedication.Text;

                var paragraph1 = oDoc.Paragraphs.Add(missing);
                var range1 = paragraph.Range;
                paragraph1 = oDoc.Paragraphs.Add(missing);
                range1 = paragraph.Range;

                range1.Text = "Подпись лечащего врача " ;


                object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatXMLDocument;
                oDoc.SaveAs(filename, ref fileFormat, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing);
                oDoc.Close(ref missing, ref missing, ref missing);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fo = new OpenFileDialog();
            fo.ShowDialog();
            file = fo.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните Email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("courseworkclinic2019@gmail.com", "courseworkclinic");
            string from = "courseworkclinic2019@gmail.com";
            string mail = textBox1.Text;
            if (!string.IsNullOrEmpty(mail))
            {
                if (!Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    MessageBox.Show("Неверный формат для электронной почты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            string subject = "Лекарственный рецепт";
            String text = "Уважаемый пациент, Ваш рецепт прилагается в файле. Лекарство  " + comboBoxMedication.Text;
            MailMessage message = new MailMessage(from, mail, subject, text);
            try
            {
                Attachment sendfile = new Attachment(file);
                message.Attachments.Add(sendfile);

            }
            catch
            {
                MessageBox.Show("Файл не выбран ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {

                client.Send(message);
                MessageBox.Show("Письмо отправлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }
    }
}
