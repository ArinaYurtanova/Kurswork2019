using EyeClinic.View.Apteka;
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
    public partial class FormMainApteka : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public FormMainApteka()
        {
            InitializeComponent();
        }

        private void лекарстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMedications>();
            form.ShowDialog();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStorages>();
            form.ShowDialog();
        }

        private void отчетПоЛекарствамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStoragesLoad>();
            form.ShowDialog();
        }

        private void добавитьНаСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPutOnStorage>();
            form.ShowDialog();
            
        }

      
    }
}
