namespace Models.Models
{
    public class Company : EntityBase
    {
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanySymbol { get; set; }
        public bool IsSelected { get; set; }
    }
}
