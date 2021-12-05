using System;
using System.Collections.Generic;

#nullable disable

namespace JhankaulAPI.Models
{
    public partial class TblSignUpMobile
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public bool IsVisibleData { get; set; }
    }
}
