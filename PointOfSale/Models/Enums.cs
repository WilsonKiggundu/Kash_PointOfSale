using System.ComponentModel.DataAnnotations;
using PointOfSale.Properties;

namespace PointOfSale.Models
{

    public enum VoucherType
    {
        Sale = 1, Purchase
    }
    public enum InvoiceType
    {
        Sale = 1, Purchase
    }

    public enum MemoType
    {
        Sale = 1, Purchase
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
        None = 0,
        Expense = 1,
        Income = 2,
    }

    public enum CashflowCategory
    {
        None = 0,
        Operating,
        Financing,
        Investing
    }

    public enum BalanceSheetCategory
    {
        None = 0,
        Asset,
        Equity,
        Liability
    }

    public enum StockCategory
    {
        In = 1,
        Out = 2,
        Transfer = 3
    }

    public enum JournalCategory
    {
        Invoice = 1, // items from an invoice
        Receipt = 2,
        Voucher = 3,
        Memo = 4
    }
    
    public enum SyncAction
    {
        Download = 1,
        Upload = 2
    }

    public enum Module
    {
        [Display(Name = "Invoices")]
        Invoice,
        [Display(Name = "Receipts")]
        Receipt,
        [Display(Name = "Vouchers")]
        Voucher,
        [Display(Name = "Memos")]
        Memo,
        [Display(Name = "Stock Transactions")]
        Inventory,
        [Display(Name = "Users")]
        Users,
        [Display(Name = "Companies")]
        Companies,
        [Display(Name = "Tenants")]
        Tenants,
        [Display(Name = "Taxes")]
        Taxes,
        [Display(Name = "Currencies")]
        Currencies,
        [Display(Name = "Accounts")]
        Accounts,
        [Display(Name = "Products and Services")]
        Products,
        [Display(Name = "Stock Locations")]
        Locations
    }
}
