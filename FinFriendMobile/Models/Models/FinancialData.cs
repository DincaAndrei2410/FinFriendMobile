using System;
namespace Models.Models
{
    public class FinancialData
    {
        public SummaryDetail SummaryDetail { get; set; }
    }

    public class SummaryDetail
    {
        public decimal PER { get; set; }
    }
}
