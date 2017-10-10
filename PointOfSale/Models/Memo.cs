using System.Collections.Generic;

namespace PointOfSale.Models
{
    public class Memo : BaseModel
    {
        public MemoType Type { get; set; }
        public string Remarks { get; set; }
        public bool Paid { get; set; }
        public decimal? Discount { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string Number { get; set; }

        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int? TaxId { get; set; }
        public Tax Tax { get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<GeneralJournal> Journals { get; set; }
    }
}
