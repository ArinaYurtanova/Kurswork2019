using EyeClinic.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeClinic.Service
{
    public class EyeClinicDBContext: DbContext
    {
        public EyeClinicDBContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
         

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Therapy> Therapys { get; set; }

        public virtual DbSet<TherapyScheme> TherapySchemes { get; set; }

        public virtual DbSet<Scheme> Schemes { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Illness> Illnesses { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Medication> Medications { get; set; }

        public virtual DbSet<Storage> Storages { get; set; }

        public virtual DbSet<StorageMedication> StorageMedications { get; set; }

        public virtual DbSet<MedicalHistory> MedicalHistorys { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception)
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                    }
                }
                throw;
            }
        }
    }
}