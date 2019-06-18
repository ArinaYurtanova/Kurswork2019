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
using Unity;
using Unity.Attributes;

namespace EyeClinic.View
{
    public partial class FormProblem : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }

        private readonly IPatient serviceP;
        private readonly IStatus service;
        private int? id;
        public FormProblem(IPatient serviceP, IStatus service)
        {
            InitializeComponent();

            this.service = service;
            this.serviceP = serviceP;
        }

        private void FormProblem_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            List<PatientView> list = serviceP.GetList();
            if (list != null)
            {
                dataGridView1.DataSource = list;
            }
            try
            {
                List<StatusView> listG = service.GetList();
                if (listG != null)
                {
                    comboBoxStatus.DisplayMember = "StatusName";
                    comboBoxStatus.ValueMember = "Id";
                    comboBoxStatus.DataSource = listG;
                    comboBoxStatus.SelectedItem = null;
                }
                int id1 = Convert.ToInt32(comboBoxStatus.SelectedValue);

                comboBoxStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxStatus.AutoCompleteSource = AutoCompleteSource.ListItems;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxStatus.Text))
            {
                MessageBox.Show("Выберете группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            List<PatientView> list = serviceP.GetStatus(comboBoxStatus.Text);
            if (list != null)
            {
                dataGridView1.DataSource = list;

            }



        }
    }
}
