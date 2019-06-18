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

namespace EyeClinic.View.Doctor
{
    public partial class FormHistory : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private int? id;
        private readonly IMedicalHistory service;
        private readonly IPatient serviceP;
        private readonly IStatus serviceS;
        private readonly ITherapy serviceT;
        private readonly IIllness serviceI;
        private readonly IUser serviceU;

        public FormHistory(IMedicalHistory service, IPatient serviceP, IStatus serviceS, ITherapy serviceT, IIllness serviceI, IUser serviceU)
        {
            InitializeComponent();
            this.service = service;
            this.serviceP = serviceP;
            this.serviceS = serviceS;
            this.serviceT = serviceT;
            this.serviceI = serviceI;
            this.serviceU = serviceU;
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            List<PatientView> listP = serviceP.GetList();
            if (listP != null)
            {
                comboBoxPatient.DisplayMember = "Surname";
                comboBoxPatient.ValueMember = "Id";
                comboBoxPatient.DataSource = listP;
                comboBoxPatient.SelectedItem = null;
            }
            comboBoxPatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxPatient.AutoCompleteSource = AutoCompleteSource.ListItems;
            List<UserView> listU = serviceU.GetList("Врач");
            if (listU != null )
            {
                comboBoxDoctor.DisplayMember = "Login";
                comboBoxDoctor.ValueMember = "Id";
                comboBoxDoctor.DataSource = listU;
                comboBoxDoctor.SelectedItem = null;
            }
            List<IllnessView> listI = serviceI.GetList();
            if (listI != null)
            {
                comboBoxIllness.DisplayMember = "IllnessName";
                comboBoxIllness.ValueMember = "Id";
                comboBoxIllness.DataSource = listI;
                comboBoxIllness.SelectedItem = null;
            }
            comboBoxIllness.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxIllness.AutoCompleteSource = AutoCompleteSource.ListItems;
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
            List<StatusView> listS = serviceS.GetList();
            if (listS != null)
            {
                comboBoxStatus.DisplayMember = "StatusName";
                comboBoxStatus.ValueMember = "Id";
                comboBoxStatus.DataSource = listS;
                comboBoxStatus.SelectedItem = null;
            }
            comboBoxStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                List<MedicalHistoryView> list = service.GetList();
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[9].Visible = false;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxDoctor.Text) || string.IsNullOrEmpty(comboBoxIllness.Text) || string.IsNullOrEmpty(comboBoxPatient.Text) || string.IsNullOrEmpty(comboBoxStatus.Text) || string.IsNullOrEmpty(comboBoxTherapy.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new MedicalHistoryView
                    {
                        Id = id.Value
                    });
                }
                else
                {
                    service.AddElement(new MedicalHistoryView
                    {

                       
                        PatientId = Convert.ToInt32(comboBoxPatient.SelectedValue),
                        UserId = Convert.ToInt32(comboBoxDoctor.SelectedValue),
                        IllnessId = Convert.ToInt32(comboBoxIllness.SelectedValue),
                        TherapyId = Convert.ToInt32(comboBoxTherapy.SelectedValue),
                        StatusId = Convert.ToInt32(comboBoxStatus.SelectedValue),

                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                LoadData();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxDoctor.Text) || string.IsNullOrEmpty(comboBoxIllness.Text) || string.IsNullOrEmpty(comboBoxPatient.Text) || string.IsNullOrEmpty(comboBoxStatus.Text) || string.IsNullOrEmpty(comboBoxTherapy.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
                id = Convert.ToInt32(dataGridView1[0, CurrentRow].Value.ToString());
                if (id.HasValue)
                {
                    service.UpdElement(new MedicalHistoryView
                    {
                        Id = id.Value,
                        PatientId = Convert.ToInt32(comboBoxPatient.SelectedValue),
                        UserId = Convert.ToInt32(comboBoxDoctor.SelectedValue),
                        IllnessId = Convert.ToInt32(comboBoxIllness.SelectedValue),
                        TherapyId = Convert.ToInt32(comboBoxTherapy.SelectedValue),
                        StatusId = Convert.ToInt32(comboBoxStatus.SelectedValue)
                    });
                }
                else
                {
                    service.AddElement(new MedicalHistoryView
                    {

                        PatientId = Convert.ToInt32(comboBoxPatient.SelectedValue),
                        UserId = Convert.ToInt32(comboBoxDoctor.SelectedValue),
                        IllnessId = Convert.ToInt32(comboBoxIllness.SelectedValue),
                        TherapyId = Convert.ToInt32(comboBoxTherapy.SelectedValue),
                        StatusId = Convert.ToInt32(comboBoxStatus.SelectedValue)

                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                LoadData();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadData();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //выбрана строка CurrentRow             
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение Name выбранной строки           
            string pId = dataGridView1[2, CurrentRow].Value.ToString();
            string dId = dataGridView1[4, CurrentRow].Value.ToString();
            string iId = dataGridView1[6, CurrentRow].Value.ToString();
            string tId = dataGridView1[8, CurrentRow].Value.ToString();
            string sId = dataGridView1[10, CurrentRow].Value.ToString();
            comboBoxPatient.Text = pId;
            comboBoxDoctor.Text = dId;
            comboBoxIllness.Text = iId;
            comboBoxTherapy.Text = tId;
            comboBoxStatus.Text = sId;
        }

        private void buttonGetPatient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxPatient.Text) )
            {
                MessageBox.Show("Выберете пациента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
                List<MedicalHistoryView> list = service.GetList(Convert.ToInt32(comboBoxPatient.SelectedValue));
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                }
            
        }

        private void buttonGetDoctor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxDoctor.Text))
            {
                MessageBox.Show("Выберете врача", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<MedicalHistoryView> list = service.GetList(Convert.ToInt32(comboBoxDoctor.SelectedValue));
            if (list != null)
            {
                dataGridView1.DataSource = list;
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            
                var form = Container.Resolve<FormAddPatient>();
                form.Id = Convert.ToInt32(Convert.ToInt32(comboBoxPatient.SelectedValue));
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            
        }

        private void buttonRecipe_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormAddRecipe>();
                form.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать строку в истории болезни", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

    }
}
