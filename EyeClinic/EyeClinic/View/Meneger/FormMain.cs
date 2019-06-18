using EyeClinic.View.Meneger;
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
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public FormMain()
        {
            InitializeComponent();
        }

        private void добавитьПациентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddPatient>();
            form.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
           
        }

        

        private void списокПациентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSearchPatient>();
            form.ShowDialog();
        }
        
        private void списокПрограммToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSchemes>();
            form.ShowDialog();
        }

        private void списокЛеченияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTherapys>();
            form.ShowDialog();
        }

        private void группыПациентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormGroups>();
            form.ShowDialog();
        }

        private void диаграммауспешностьЛеченияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDiagramm>();
            form.ShowDialog();
        }

        private void проблемыВЛеченииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormProblem>();
            form.ShowDialog();
        }

        private void врачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDoctors>();
            form.ShowDialog();
        }
    }
}
