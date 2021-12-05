using System;
using System.Collections.Generic;

#nullable disable

namespace JhankaulAPI.Models
{
    public partial class TblSchool
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string PrincipleName { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string AddressLineThree { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string HelpLineNumberOne { get; set; }
        public string HelpLineNumberTwo { get; set; }
        public string NumberOfTeacherMale { get; set; }
        public string NumberOfTeacherFemale { get; set; }
        public string NumberOfStudent { get; set; }
        public string NumberOfBoy { get; set; }
        public string NumberOfGirl { get; set; }
        public string NumberOfBus { get; set; }
        public string PrincipleImage { get; set; }
        public string SchoolImageOne { get; set; }
        public string SchoolImageTwo { get; set; }
        public string SchoolImageThree { get; set; }
        public string SchoolImageFour { get; set; }
        public string SchoolImageFive { get; set; }
        public string YearFrom { get; set; }
    }
}
