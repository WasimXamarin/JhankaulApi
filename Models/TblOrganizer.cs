using System;
using System.Collections.Generic;

#nullable disable

namespace JhankaulAPI.Models
{
    public partial class TblOrganizer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public string Year { get; set; }
        public bool? IsVisibleData { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
