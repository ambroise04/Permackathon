using System;

namespace Permackathon.Common.TO
{
    public class FinancialTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Objective { get; set; }
        public decimal ActualSale { get; set; }
        public DateTime ReportDate { get; set; }
        public ActivityTO Activity { get; set; }
    }
}