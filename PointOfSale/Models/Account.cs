using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Currency : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Rate { get; set; }
    }

    public class Account : BaseModel
    {
        public string Name { get; set; }   
        public decimal? Fees { get; set; }
        public decimal? Depreciation { get; set; }
        public decimal? Budget { get; set; }
        public AccountCategory? Category { get; set; }
        public CashflowCategory? CashflowCategory { get; set; } 
        public BalanceSheetCategory? BalanceSheetCategory { get; set; }

        public int? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public int? ParentAccountId { get; set; }
        public virtual Account ParentAccount { get; set; }
        public int? PurchaseAccountId { get; set; }
        public virtual Account PurchaseAccount { get; set; }
    }
}
