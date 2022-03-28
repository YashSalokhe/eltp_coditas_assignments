﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Shopping_Cart.Models
{
    public partial class BillMaster
    {
        public BillMaster()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int BillNo { get; set; }
        public int BillAmount { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
