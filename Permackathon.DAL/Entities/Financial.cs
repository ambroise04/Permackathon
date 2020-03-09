using System;

namespace Permackathon.DAL.Entities
{
    public class Financial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Objective { get; set; }
        public decimal ActualSale { get; set; }
        public DateTime ReportDate { get; set; }
        public Activity Activity { get; set; }
    }
}