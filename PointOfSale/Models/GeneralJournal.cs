using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class GeneralJournal : BaseModel
    {
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Quantity { get; set; }
        public string Category { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? CreditAccountId { get; set; }
        public Account CreditAccount { get; set; }
        public int? DebitAccountId { get; set; }
        public Account DebitAccount { get; set; }
        public int? VoucherId { get; set; }
        public Voucher Voucher { get; set; }
        public int? MemoId { get; set; }
        public Memo Memo { get; set; }
        public int? ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public string Particulars { get; set; }
        public int? BankId { get; set; }
        public int? TaxId { get; set; }
        public virtual Tax Tax { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string Term { get; set; }
        public string Form { get; set; }
        public int? Year { get; set; }
        public string ReferenceNumber { get; set; }
    }
}
