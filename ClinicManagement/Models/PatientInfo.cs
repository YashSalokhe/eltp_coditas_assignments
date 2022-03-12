using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class PatientInfo
    {
        public PatientInfo()
        {
            PatientBills = new HashSet<PatientBill>();
            Records = new HashSet<Record>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public string PatientAddress { get; set; } = null!;
        public int? Age { get; set; }

        public virtual ICollection<PatientBill> PatientBills { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
