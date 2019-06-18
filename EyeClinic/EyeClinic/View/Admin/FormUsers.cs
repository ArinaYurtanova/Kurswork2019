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
    public partial class FormUsers : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IUser service;
        private int? id;
        public FormUsers(IUser service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void LoadData()
        {
            try
            {
                List<UserView> list = service.GetList();
                if (list != null)
                {
                    dataGridView1.DataSource = list;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text) || string.IsNullOrEmpty(textBoxPassword.Text) || string.IsNullOrEmpty(comboBoxRole.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new UserView
                    {
                        Id = id.Value,
                        Role = comboBoxRole.Text,
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text
                    });
                }
                else
                {
                    service.AddElement(new UserView
                    {

                        Role = comboBoxRole.Text,
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text

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

        private void FormUsers_Load(object sender, EventArgs e)
        {
            comboBoxRole.Items.AddRange(new string[] { "Врач", "Работник регистратуры", "Аптекарь" });
            LoadData();
        }



        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text) || string.IsNullOrEmpty(textBoxPassword.Text) || string.IsNullOrEmpty(comboBoxRole.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
                id  = Convert.ToInt32(dataGridView1[0, CurrentRow].Value.ToString());
                if (id.HasValue)
                {
                    service.UpdElement(new UserView
                    {
                        Id = id.Value,
                        Role = comboBoxRole.Text,
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text
                    });
                }
                else
                {
                    service.AddElement(new UserView
                    {

                        Role = comboBoxRole.Text,
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text

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
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //выбрана строка CurrentRow             
            int CurrentRow = dataGridView1.SelectedCells[0].RowIndex;
            //получить значение Name выбранной строки             
            string roleId = dataGridView1[1, CurrentRow].Value.ToString();
            string loginId = dataGridView1[2, CurrentRow].Value.ToString();
            string passwId = dataGridView1[3, CurrentRow].Value.ToString();
            comboBoxRole.Text = roleId;
            textBoxLogin.Text = loginId;
            textBoxPassword.Text = passwId;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
