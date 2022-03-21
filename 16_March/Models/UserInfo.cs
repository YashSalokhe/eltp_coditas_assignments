using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace _16_March.Models
{
    public partial class UserInfo
    {
       
        public int UserId { get; set; }
        [Required (ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string UserPassword { get; set; }
    }
}
