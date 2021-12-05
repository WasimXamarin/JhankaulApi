using System;
using System.Collections.Generic;

#nullable disable

namespace JhankaulAPI.Models
{
    public partial class TblSignUp
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ProfilePhoto { get; set; }
        public bool IsVisibleData { get; set; }
    }
}
