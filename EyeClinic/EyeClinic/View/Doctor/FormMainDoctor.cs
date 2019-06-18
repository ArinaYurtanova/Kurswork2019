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

namespace EyeClinic.View.Doctor
{
    public partial class FormMainDoctor : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public FormMainDoctor()
        {
            InitializeComponent();
        }

        private void историяБолезниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormHistory>();
            form.ShowDialog();
        }
    }
}
