using EyeClinic.Service.Interface;
using EyeClinic.Service.ViewModel;
using EyeClinic.View.Doctor;
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
    public partial class FormLogin : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IUser service;

        public FormLogin(IUser service)
        {
            InitializeComponent();
            this.service = service;

        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            
          


                if (string.IsNullOrEmpty(comboBoxRole.Text))
                {
                    MessageBox.Show("Заполните роль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(textBoxLogin.Text))
                {
                    MessageBox.Show("Заполните логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(textBoxPassword.Text))
                {
                    MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                List<UserView> list = service.GetList();

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Role == comboBoxRole.Text && list[i].Login == textBoxLogin.Text && list[i].Password == textBoxPassword.Text)
                    {
                        if (comboBoxRole.Text == "Врач")
                        {
                            var form = Container.Resolve<FormHistory>();
                            form.ShowDialog();

                        }
                        if (comboBoxRole.Text == "Аптекарь")
                        {
                            var form = Container.Resolve<FormMainApteka>();
                            form.ShowDialog();

                        }
                        if (comboBoxRole.Text == "Работник регистратуры")
                        {
                            var form = Container.Resolve<FormMain>();
                            form.ShowDialog();

                        }
                        if (comboBoxRole.Text == "Администратор")
                        {
                            var form = Container.Resolve<FormMainAdmin>();
                            form.ShowDialog();

                        }

                    }


                }
            

            textBoxLogin.Clear();
            textBoxPassword.Clear();
            return;

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            comboBoxRole.Items.AddRange(new string[] { "Врач", "Работник регистратуры", "Аптекарь", "Администратор" });
            textBoxLogin.Text = "Юртанова";
            textBoxPassword.Text = "123";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxLogin.Text = "Юртанова";
            textBoxPassword.Text = "123";
        }
    }
}
