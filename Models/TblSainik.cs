using System;
using System.Collections.Generic;

#nullable disable

namespace JhankaulAPI.Models
{
    public partial class TblSainik
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Facebook { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public string Village { get; set; }
        public string YearFrom { get; set; }
        public string YearTo { get; set; }
        public bool IsVisibleData { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
