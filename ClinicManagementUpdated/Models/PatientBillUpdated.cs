using System;
using System.Collections.Generic;

namespace ClinicManagementUpdated.Models
{
    public partial class PatientBillUpdated
    {
        public int Billnumber { get; set; }
        public int PatientId { get; set; }
        public int Fees { get; set; }
        public DateTime? Currentdate { get; set; }

        public virtual PatientInfoUpdated Patient { get; set; } = null!;
    }
}
