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

namespace EyeClinic.View.Meneger
{
    public partial class FormDoctors : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IUser service;
        private int? id;
        public FormDoctors(IUser service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormDoctors_Load(object sender, EventArgs e)
        {

            try
            {
                List<UserView> list = service.GetList("Врач");
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[0].HeaderText = "Номер";
                    dataGridView1.Columns[1].HeaderText = "Роль";
                    dataGridView1.Columns[2].HeaderText = "Фамилия";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
