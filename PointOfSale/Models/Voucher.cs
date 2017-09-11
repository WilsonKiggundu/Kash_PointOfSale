using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Voucher : BaseModel
    {
        public VoucherType Type { get; set; }
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
        public virtual Invoice Invoice { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<GeneralJournal> Journals { get; set; }
    }
}
