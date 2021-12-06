using System;
using System.Collections.Generic;

#nullable disable

namespace JhankaulAPI.Models
{
    public partial class TblHome
    {
        public int Id { get; set; }
        public string NumberOfMale { get; set; }
        public string NumberOfFemale { get; set; }
        public string History { get; set; }
        public string ImageOne { get; set; }
        public string ImageTwo { get; set; }
        public string ImageThree { get; set; }
        public string ImageFour { get; set; }
        public string ImageFive { get; set; }
        public bool IsVisibleData { get; set; }
    }
}
