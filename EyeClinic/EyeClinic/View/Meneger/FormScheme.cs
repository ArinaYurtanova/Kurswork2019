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
    public partial class FormScheme : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IScheme service;

        private int? id;

        public FormScheme(IScheme service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormScheme_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SchemeView view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.SchemeName;
                        textBoxPriceScheme.Text = view.PriceScheme.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new SchemeView
                    {
                        Id = id.Value,
                        SchemeName = textBoxName.Text,
                        PriceScheme = Convert.ToInt32(textBoxPriceScheme.Text)
                    });
                }
                else
                {
                    service.AddElement(new SchemeView
                    {
                        SchemeName = textBoxName.Text,
                        PriceScheme = Convert.ToInt32(textBoxPriceScheme.Text)
                    });
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

