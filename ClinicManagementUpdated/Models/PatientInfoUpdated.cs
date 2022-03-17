using System;
using System.Collections.Generic;

namespace ClinicManagementUpdated.Models
{
    public partial class PatientInfoUpdated
    {
        public PatientInfoUpdated()
        {
            PatientBillUpdateds = new HashSet<PatientBillUpdated>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public string PatientAddress { get; set; } = null!;
        public int? Age { get; set; }
        public double PatientWeight { get; set; }
        public double PatientHeight { get; set; }
        public string? BloodPressure { get; set; }
        public string? Cholestrol { get; set; }
        public string? Sugar { get; set; }
        public string? MedicineSubscribed { get; set; }
        public DateTime? AppointmentDate { get; set; }

        public virtual ICollection<PatientBillUpdated> PatientBillUpdateds { get; set; }
    }
}
