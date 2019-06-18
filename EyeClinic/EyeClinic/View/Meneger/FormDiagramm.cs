using EyeClinic.Model;
using EyeClinic.Service.Interface;
using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Unity;
using Unity.Attributes;

namespace EyeClinic.View
{

    public partial class FormDiagramm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IPatient serviceP;
        private readonly ITherapy serviceT;
        private int? id;
        public FormDiagramm(ITherapy serviceT, IPatient serviceP)
        {
            InitializeComponent();
            this.serviceT = serviceT;
            this.serviceP = serviceP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Пациенты"].Points.AddXY("Больных", textBoxIll.Text);
            this.chart1.Series["Пациенты"].Points.AddXY("Проблемы в лечении", textBoxProbl.Text);
            this.chart1.Series["Пациенты"].Points.AddXY("Здоровых", textBoxZdor.Text);
            this.chart1.Series["Пациенты"].Points.AddXY("На лечении", textBoxCount.Text);
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxTherapy.Text))
            {
                MessageBox.Show("Выберете лечение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            List<PatientView> list = serviceP.GetStatus("На лечении", comboBoxTherapy.Text);
            if (list != null)
            {
                int count = list.Count;
                textBoxCount.Text = Convert.ToString(count);
            }
            else
            {
                textBoxCount.Text = "0";
            }

            List<PatientView> listProbl = serviceP.GetStatus("Проблемы в лечении", comboBoxTherapy.Text);
            if (listProbl != null)
            {
                int count = listProbl.Count;
                textBoxProbl.Text = Convert.ToString(count);
            }
            else
            {
                textBoxCount.Text = "0";
            }

            List<PatientView> listIll = serviceP.GetStatus("Болен", comboBoxTherapy.Text);
            if (listIll != null)
            {
                int count = listIll.Count;
                textBoxIll.Text = Convert.ToString(count);
            }
            else
            {
                textBoxCount.Text = "0";
            }

            List<PatientView> listZdor = serviceP.GetStatus("Здоров", comboBoxTherapy.Text);
            if (listZdor != null)
            {
                int count = listZdor.Count;
                textBoxZdor.Text = Convert.ToString(count);
            }
            else
            {
                textBoxCount.Text = "0";
            }
            textBox1.Text = Convert.ToString(Convert.ToDecimal(Convert.ToDecimal(textBoxZdor.Text) / (Convert.ToDecimal(textBoxZdor.Text) + Convert.ToDecimal(textBoxIll.Text) + Convert.ToDecimal(textBoxProbl.Text) + Convert.ToDecimal(textBoxCount.Text))));
        }

        private void FormDiagramm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                List<TherapyView> listT = serviceT.GetList();
                if (listT != null)
                {
                    comboBoxTherapy.DisplayMember = "TherapyName";
                    comboBoxTherapy.ValueMember = "Id";
                    comboBoxTherapy.DataSource = listT;
                    comboBoxTherapy.SelectedItem = null;
                }
                comboBoxTherapy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxTherapy.AutoCompleteSource = AutoCompleteSource.ListItems;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxCount.Text = "";
            textBoxZdor.Text = "";
            textBoxIll.Text = "";
            textBoxProbl.Text = "";
            textBoxName.Text = "";
            comboBoxTherapy.Text = "";
            textBox1.Text = "";
            chart1.Series["Пациенты"].Points.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Введите название диаграммы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                this.chart1.SaveImage("D:\\chart\\" + textBoxName.Text + ".jpeg", ChartImageFormat.Jpeg);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Уже есть диаграмма с таким именем", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
