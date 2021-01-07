using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalOfficeEntities.Entities
{
   public class Visit
    {
        int visitId, patientId;
        int? appointmentId;
        DateTime date;
        string record;

        [Key]
        public int VisitId { get => visitId; set => visitId = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Record { get => record; set => record = value; }
        [ForeignKey("Patient")]
        public int PatientId { get => patientId; set => patientId = value; }
        public Patient Patient { get; set; }
        [ForeignKey("Appointment")]
        public int? AppointmentId { get => appointmentId; set => appointmentId = value; }
        public Appointment Appointment { get; set; }

        public Visit() { }
    }
}
