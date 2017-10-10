using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Models
{
    public class Invoice : BaseModel
    {
        public InvoiceType InvoiceType { get; set; }
        public string Remarks { get; set; }
        public bool Paid { get; set; }
        public decimal? Discount { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string Number { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }    
        public int? TaxId { get; set; }
        public Tax Tax { get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public virtual ICollection<GeneralJournal> Journals { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }      

        public int? LocationId { get; set; }
        public virtual Location Location { get; set; } 
        
    }

    
}
