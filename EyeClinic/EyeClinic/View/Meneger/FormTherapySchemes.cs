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
    public partial class FormTherapySchemes : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public TherapySchemesView Model { set { model = value; } get { return model; } }

        private readonly IScheme service;

        private TherapySchemesView model;

        public FormTherapySchemes(IScheme service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormTherapySchemes_Load(object sender, EventArgs e)
        {
            
            List <SchemeView> list = service.GetList();
            try
            {
                if (list != null)
                {
                    comboBoxSchema.DisplayMember = "SchemeName";
                    comboBoxSchema.SelectedValue = "Id";
                    comboBoxSchema.DataSource = list;
                }
                comboBoxSchema.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxSchema.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (model != null)
            {
                comboBoxSchema.Enabled = false;
                foreach (SchemeView item in list)
                {
                    if (item.SchemeName == model.SchemeName)
                    {
                        comboBoxSchema.SelectedItem = item;
                    }
                }
            }
        }
        private void CalcSum()
        {
            try
            {
                int id = ((SchemeView)comboBoxSchema.SelectedItem).Id;
                SchemeView product = service.GetElement(id);
                textBoxPrice.Text = product.PriceScheme.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBoxSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxSchema.SelectedItem == null)
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxPrice.Text == null)
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new TherapySchemesView
                    {
                        SchemeId = ((SchemeView)comboBoxSchema.SelectedItem).Id,
                        SchemeName = comboBoxSchema.Text,
                        SchemePrice = Convert.ToDecimal(textBoxPrice.Text)
                    };
                }
            else
            {
                model.SchemePrice = Convert.ToInt32(textBoxPrice.Text);
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
