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
    public partial class FormMainAdmin : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public FormMainAdmin()
        {
            InitializeComponent();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormUsers>();
            form.ShowDialog();
        }

        private void статусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStatus>();
            form.ShowDialog();
        }

        private void группаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormGroups>();
            form.ShowDialog();
        }
    }
}
