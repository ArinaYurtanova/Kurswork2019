using EyeClinic.Model;
using EyeClinic.Service;
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
    public partial class FormAddPatient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IPatient serviceP;
        private readonly IStatus serviceS;
        private readonly ITherapy serviceT;
        private readonly IIllness serviceI;
        private readonly IGroup serviceG;
        private int? id;
        public FormAddPatient(IPatient serviceP, IStatus serviceS, ITherapy serviceT, IIllness serviceI, IGroup serviceG)
        {
            InitializeComponent();
            this.serviceP = serviceP;
            this.serviceS = serviceS;
            this.serviceT = serviceT;
            this.serviceI = serviceI;
            this.serviceG = serviceG;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Surname.Text) || string.IsNullOrEmpty(NamePatient.Text) || string.IsNullOrEmpty(Insurance.Text) || string.IsNullOrEmpty(Illness.Text))
            {
                MessageBox.Show("Заполните обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    serviceP.UpdElement(new PatientView
                    {
                        Id = id.Value,
                        Surname = Surname.Text,
                        Name = NamePatient.Text,
                        Otchestvo = Otchestvo.Text,
                        Insurance = Insurance.Text,
                        Illness = Illness.Text,
                        Group = Group.Text,
                        Therapy = Therapy.Text,
                        Status = Status.Text,
                        Day = Day.Text,
                        Month = Month.Text,
                        Year = Year.Text

                    });
                }
                else
                {
                    serviceP.AddElement(new PatientView
                    {

                        Surname = Surname.Text,
                        Name = NamePatient.Text,
                        Otchestvo = Otchestvo.Text,
                        Insurance = Insurance.Text,
                        Illness = Illness.Text,
                        Group = Group.Text,
                        Therapy = Therapy.Text,
                        Status = Status.Text,
                        Day = Convert.ToString(dateTimePicker1.Value.Day),
                        Month = Convert.ToString(dateTimePicker1.Value.Month),
                        Year = Convert.ToString(dateTimePicker1.Value.Year)
                    });
                }
                if (Status.Text == "Здоров")
                {
                    DataBaseBackup.CreateBackup(Status.Text);
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;


                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormAddPatient_Load(object sender, EventArgs e)
        {
            List<GroupView> listG = serviceG.GetList();
            if (listG != null)
            {
                Group.DisplayMember = "GroupName";
                Group.ValueMember = "Id";
                Group.DataSource = listG;
                Group.SelectedItem = null;
            }
            Group.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Group.AutoCompleteSource = AutoCompleteSource.ListItems;
            List<IllnessView> listI = serviceI.GetList();
            if (listI != null)
            {
                Illness.DisplayMember = "IllnessName";
                Illness.ValueMember = "Id";
                Illness.DataSource = listI;
                Illness.SelectedItem = null;
            }
            Illness.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Illness.AutoCompleteSource = AutoCompleteSource.ListItems;
            List<TherapyView> listT = serviceT.GetList();
            if (listT != null)
            {
                Therapy.DisplayMember = "TherapyName";
                Therapy.ValueMember = "Id";
                Therapy.DataSource = listT;
                Therapy.SelectedItem = null;
            }
            Therapy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Therapy.AutoCompleteSource = AutoCompleteSource.ListItems;
            List<StatusView> listS = serviceS.GetList();
            if (listS != null)
            {
                Status.DisplayMember = "StatusName";
                Status.ValueMember = "Id";
                Status.DataSource = listS;
                Status.SelectedItem = null;
            }
            Status.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Status.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (id.HasValue)
            {
                try
                {

                    PatientView view = serviceP.GetElement(id.Value);
                    if (view != null)
                    {
                        Surname.Text = view.Surname;
                        NamePatient.Text = view.Name;
                        Otchestvo.Text = view.Otchestvo;
                        Insurance.Text = view.Insurance;
                        Illness.Text = view.Illness;
                        Group.Text = view.Group;
                        Therapy.Text = view.Therapy;
                        Status.Text = view.Status;
                        Day.Text = view.Day;
                        Month.Text = view.Month;
                        Year.Text = view.Year;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
