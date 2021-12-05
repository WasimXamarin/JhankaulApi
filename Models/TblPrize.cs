using System;
using System.Collections.Generic;

#nullable disable

namespace JhankaulAPI.Models
{
    public partial class TblPrize
    {
        public int Id { get; set; }
        public string PrizeName { get; set; }
        public string PrizeDescription { get; set; }
        public string Year { get; set; }
        public bool IsVisibleData { get; set; }
        public string PrizePhoto { get; set; }
        public string PrizePosition { get; set; }
        public string PrizeClass { get; set; }
    }
}
