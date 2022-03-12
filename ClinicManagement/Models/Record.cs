using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class Record
    {
        public int RecordId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;
        public double PatientWeight { get; set; }
        public double PatientHeight { get; set; }
        public string? BloodPressure { get; set; }
        public string? Cholestrol { get; set; }
        public string? Sugar { get; set; }
        public string? MedicineSubscribed { get; set; }
        public DateTime? AppointmentDate { get; set; }

        public virtual PatientInfo Patient { get; set; } = null!;
    }
}
