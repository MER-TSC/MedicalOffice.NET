using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalOfficeEntities.Entities
{
    public class Appointment
    {
        private int appointmentId, patientId;
        private DateTime dateTime;
        string status; // attended, canceled, NULL 

        [Key]
        public int AppointmentId { get => appointmentId; set => appointmentId = value; }
        [ForeignKey("Patient")]
        public int PatientId { get => patientId; set => patientId = value; }
        public Patient Patient { get; set; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string Status { get => status; set => status = value; }

        public Appointment() { }
    }
}
