using System;
using System.Collections.Generic;

#nullable disable

namespace JhankaulAPI.Models
{
    public partial class TblProfile
    {
        public int Id { get; set; }
        public string RollNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public string DateOfBirth { get; set; }
        public string TotalNumber { get; set; }
        public string OutOfNumber { get; set; }
        public string PositionInClass { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MobileNumberOne { get; set; }
        public string MobileNumberTwo { get; set; }
        public string SchoolName { get; set; }
        public string StudentImage { get; set; }
        public string StudentSignature { get; set; }
        public string ParentSignature { get; set; }
        public string Village { get; set; }
        public string Post { get; set; }
        public string Thana { get; set; }
        public string District { get; set; }
        public string StateName { get; set; }
        public string Nationality { get; set; }
        public bool IsVisibleData { get; set; }
    }
}
