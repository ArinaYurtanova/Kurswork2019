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
    public partial class FormSearchPatient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }


        private readonly IPatient service;
        private int? id;
        public FormSearchPatient(IPatient service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFIO.Checked)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = false;
                comboBoxSurname.Visible = true;
                comboBoxName.Visible = true;
                comboBoxInsurance.Visible = false;
            }
            if (radioButtonInsurance.Checked)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = true;
                comboBoxSurname.Visible = false;
                comboBoxName.Visible = false;
                comboBoxInsurance.Visible = true;
            }
        }


        private void FormSearchPatient_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            radioButtonFIO.Checked = false;
            radioButtonInsurance.Checked = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            comboBoxSurname.Visible = false;
            comboBoxName.Visible = false;
            comboBoxInsurance.Visible = false;
            List<PatientView> list = service.GetList();
            if (list != null)
            {
                dataGridView1.DataSource = list;
            }
            try
            {
                List<PatientView> listF = service.GetList();
                if (listF != null)
                {
                    comboBoxSurname.DisplayMember = "Surname";
                    comboBoxSurname.ValueMember = "Id";
                    comboBoxSurname.DataSource = listF;
                    comboBoxSurname.SelectedItem = null;
                }
                int id1 = Convert.ToInt32(comboBoxSurname.SelectedValue);

                comboBoxSurname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxSurname.AutoCompleteSource = AutoCompleteSource.ListItems;

                List<PatientView> listN = service.GetList();
                if (listN != null)
                {
                    comboBoxName.DisplayMember = "Name";
                    comboBoxName.ValueMember = "Id";
                    comboBoxName.DataSource = listN;
                    comboBoxName.SelectedItem = null;
                }
                comboBoxName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxName.AutoCompleteSource = AutoCompleteSource.ListItems;

                List<PatientView> listS = service.GetList();
                if (listS != null)
                {
                    comboBoxInsurance.DisplayMember = "Insurance";
                    comboBoxInsurance.ValueMember = "Id";
                    comboBoxInsurance.DataSource = listS;
                    comboBoxInsurance.SelectedItem = null;
                }
                int id2 = Convert.ToInt32(comboBoxInsurance.SelectedValue);
                comboBoxInsurance.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxInsurance.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(comboBoxSurname.Text) && string.IsNullOrEmpty(comboBoxInsurance.Text))
            {
                MessageBox.Show("Введите фамилию и страховое свидетельство", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButtonFIO.Checked)
            {
                if (Convert.ToInt32(comboBoxSurname.SelectedValue) == Convert.ToInt32(comboBoxName.SelectedValue))
                {
                    List<PatientView> list = service.GetList(Convert.ToInt32(comboBoxSurname.SelectedValue));
                    if (list != null)
                    {
                        dataGridView1.DataSource = list;
                    }
                }
                else
                {
                    MessageBox.Show("Такого пациента нет в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (radioButtonInsurance.Checked)
            {
                List<PatientView> list = service.GetList(Convert.ToInt32(comboBoxInsurance.SelectedValue));
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                }
            }

        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormAddPatient>();
                form.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}

