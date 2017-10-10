using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PointOfSale.Models
{
    public class Receipt : BaseModel
    {
        public int? InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public ReceiptType Type { get; set; }
        public string Remarks { get; set; }
        public bool Paid { get; set; }
        public decimal? Discount { get; set; }
        public decimal? ExchangeRate { get; set; }  
        public string Number { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? TaxId { get; set; }
        public virtual Tax Tax { get; set; }
        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }    
        public int? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }  

        public ICollection<GeneralJournal> Journals { get; set; }

        [NotMapped]
        public decimal? Amount { get; set; }

        public Receipt()
        {
            if (Journals != null) Amount = Journals.Sum(q => q.Amount);
        }
    }
}
