using EyeClinic.Service.Implementation;
using EyeClinic.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EyeClinic.Service
{
    public class DataBaseBackup

    {

        static EyeClinicDBContext context;

        static DataBaseBackup()

        {

            context = new EyeClinicDBContext();

        }

        public static void CreateBackup(string StatusName)

        {

            SaveFileDialog sfd = new SaveFileDialog

            {

                Filter = "xml|*.xml"

            };

            if (sfd.ShowDialog() == DialogResult.OK)

            {

                try

                {

                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate))

                    {

                        var xser = new XmlSerializer(typeof(PatientView));

                        var list = new PatientService(context).GetStatus(StatusName);

                        foreach (var row in list)

                        {

                            xser.Serialize(fs, row);

                        }

                    }

                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch (Exception ex)

                {

                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

    }

}
