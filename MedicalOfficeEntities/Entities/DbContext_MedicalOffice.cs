using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalOfficeEntities.Entities
{
   public class DbContext_MedicalOffice : DbContext
    {
        public DbContext_MedicalOffice()
            //: base("Data Source=.;Initial Catalog=MedicalOffice_XE;Integrated Security=True"){
            : base("MedicalOffice_XE"){
            
            }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Visit> Visits { get; set; }

    }
}
