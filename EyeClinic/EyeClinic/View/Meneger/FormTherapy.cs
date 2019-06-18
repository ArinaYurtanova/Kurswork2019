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
    public partial class FormTherapy : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly ITherapy service;

        private int? id;

        private List<TherapySchemesView> therapySchemes;
        public FormTherapy(ITherapy service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTherapySchemes>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.TherapyId = id.Value;
                    }
                    therapySchemes.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormTherapySchemes>();
                form.Model = therapySchemes[dataGridView1.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    therapySchemes[dataGridView1.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        therapySchemes.RemoveAt(dataGridView1.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
            decimal sum = 0;
            for (int i = 0; i < therapySchemes.Count; i++)
            {
                TherapySchemesView product = therapySchemes[i];
                sum += Convert.ToDecimal(product.SchemePrice);
            }
            textBoxPrice.Text = sum.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (therapySchemes == null || therapySchemes.Count == 0)
            {
                MessageBox.Show("Выберите программы ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Обновите чтобы увидеть сумму ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<TherapySchemesView> productComponentBM = new List<TherapySchemesView>();
                for (int i = 0; i < therapySchemes.Count; ++i)
                {
                    productComponentBM.Add(new TherapySchemesView
                    {
                        Id = therapySchemes[i].Id,
                        TherapyId = therapySchemes[i].TherapyId,
                        SchemeId = therapySchemes[i].SchemeId,
                        SchemePrice = therapySchemes[i].SchemePrice
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new TherapyView
                    {
                        Id = id.Value,
                        TherapyName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        TherapySchemes = productComponentBM
                    });
                }
                else
                {
                    service.AddElement(new TherapyView
                    {
                        TherapyName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        TherapySchemes = productComponentBM
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormTherapy_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    TherapyView view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.TherapyName;
                        textBoxPrice.Text = view.Price.ToString();
                        therapySchemes = view.TherapySchemes;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                therapySchemes = new List<TherapySchemesView>();
        }
        private void LoadData()
        {
            try
            {
                if (therapySchemes != null)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = therapySchemes;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
