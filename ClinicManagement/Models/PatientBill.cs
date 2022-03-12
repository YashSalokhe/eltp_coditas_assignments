using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class PatientBill
    {
        public int Billnumber { get; set; }
        public int PatientId { get; set; }
        public int Fees { get; set; }
        public DateTime? Currentdate { get; set; }

        public virtual PatientInfo Patient { get; set; } = null!;
    }
}
