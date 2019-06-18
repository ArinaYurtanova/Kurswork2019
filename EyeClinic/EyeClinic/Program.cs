using EyeClinic.Service;
using EyeClinic.Service.Implementation;
using EyeClinic.Service.Interface;
using EyeClinic.View;
using EyeClinic.View.Doctor;
using EyeClinic.View.Not_meneger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace EyeClinic
{
    static class Program
    {
        public static int id;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormLogin>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, EyeClinicDBContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPatient, PatientService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IScheme, SchemeService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITherapy, TherapyService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStatus, StatusService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIllness, IllnessService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGroup, GroupService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IUser, UserService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMedication, MedicationService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorage, StorageService>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMedicalHistory, MedicalHistoryService>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}

