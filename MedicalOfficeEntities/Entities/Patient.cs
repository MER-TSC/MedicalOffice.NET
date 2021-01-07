using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalOfficeEntities
{
    public class Patient
    {
        private int patientId;
        private string lastname, firstname, address, email;

        [Key]
        public int PatientId { get => patientId; set => patientId = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }

        public Patient() { }
    }
}
