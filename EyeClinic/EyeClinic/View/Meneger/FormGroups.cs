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
using Unity;
using Unity.Attributes;

namespace EyeClinic.View
{
    public partial class FormGroups : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }

        private readonly IPatient serviceP;
        private readonly IGroup service;
        private int? id;
        public FormGroups(IGroup service, IPatient serviceP)
        {
            InitializeComponent();
            this.service = service;
            this.serviceP = serviceP;
        }

        private void FormGroups_Load(object sender, EventArgs e)
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
                List<GroupView> listG = service.GetList();
                if (listG != null)
                {
                    comboBoxGroup.DisplayMember = "GroupName";
                    comboBoxGroup.ValueMember = "Id";
                    comboBoxGroup.DataSource = listG;
                    comboBoxGroup.SelectedItem = null;
                }
                int id1 = Convert.ToInt32(comboBoxGroup.SelectedValue);

                comboBoxGroup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxGroup.AutoCompleteSource = AutoCompleteSource.ListItems;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxGroup.Text))
            {
                MessageBox.Show("Выберете группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            List<PatientView> list = serviceP.GetGroup(comboBoxGroup.Text);
            if (list != null)
            {
                dataGridView1.DataSource = list;
                int count = list.Count;
                textBoxCount.Text = Convert.ToString(count);
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
    }
}
