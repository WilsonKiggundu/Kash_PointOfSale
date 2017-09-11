using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{

    public enum VoucherType
    {
        Sales = 1, Purchase
    }
    public enum InvoiceType
    {
        Sales = 1, Purchase
    }

    public enum MemoType
    {
        Sales = 1, Purchase
    }

    public enum ReceiptType
    {
        Sale = 1, Purchase
    }

    public enum ProductType
    {
        Service = 1,
        Stockable = 2,
        Consumable = 3
    }

    public enum TenantCategory
    {
        General = 1,
        School
    }

    public enum AccountCategory
    {
        None = 1
    }

    public enum CashflowCategory
    {
        None = 1
    }

    public enum BalanceSheetCategory
    {
        None = 1
    }
}
