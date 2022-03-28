﻿using System;
using System.Collections.Generic;

#nullable disable

namespace _16_March.Models
{
    public partial class Log
    {
        public int RequestId { get; set; }
        public DateTime? RequestDateTime { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ExecutionCompletionTime { get; set; }
    }
}
