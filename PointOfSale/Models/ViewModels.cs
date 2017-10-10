using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public class ProductViewModel
    {
        public int? Id { get; set; }
        public int WebId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal? Price { get; set; }
        public bool? Purchase { get; set; }
        public bool? Sale { get; set; }
        public bool? Active { get; set; }
        public int TenantId { get; set; }
        //public string DateAdded { get; set; }
    }

    public class UploadResponseViewModel
    {
        public int Id { get; set; }
        public int WebId { get; set; }
    }

    public class TenantViewModel
    {
        public int? Id { get; set; }
        public int WebId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public string Tin { get; set; }
        // public string Category { get; set; }
        // public string Url { get; set; }
    }

    public class InvoiceItemViewModel
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int? WebId { get; set; }
        public int ProductId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Quantity { get; set; }
        public string Particulars { get; set; }
        public int? PropertyUnitId { get; set; }
    }
    
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public int? WebId { get; set; }
        public decimal Total { get; set; }
        public decimal? Discount { get; set; }
        public string Remarks { get; set; }
        public string Type { get; set; }
        public int CompanyId { get; set; }
        public decimal? AmountPaid { get; set; }
        public DateTime DateAdded { get; set; }
        public List<InvoiceItemViewModel> InvoiceItems { get; set; }
    }

    public class CompanyViewModel
    {
        public int Id { get; set; }
        public int? WebId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Currency { get; set; }
        public bool? Landlord { get; set; }
        public bool? Occupant { get; set; }
        public int? TenantId { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class OrganizationViewModel
    {
        public int? Id { get; set; }
        public int WebId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public int TenantId { get; set; }
        public bool? Occupant { get; set; }
        public bool? LandLord { get; set; }
    }

    public class ReceiptViewModel
    {
        public int Id { get; set; }
        public int? WebId { get; set; }
        public int? InvoiceId { get; set; }
        public int CompanyId { get; set; }
        public string Remarks { get; set; }
        public decimal? AmountPaid { get; set; }
        public string AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
        public List<RecieptItemViewModel> ReceiptItems { get; set; }
    }

    public class RecieptItemViewModel
    {
        public int Id { get; set; }
        public int? WebId { get; set; }
        public int ProductId { get; set; }
        public int RecieptId { get; set; }
        public string Particulars { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Quantity { get; set; }
        public int? PropertyUnitId { get; set; }
    }

    public class VoucherViewModel
    {
        public int Id { get; set; }
        public int? WebId { get; set; }
        public string Remarks { get; set; }
        public string Type { get; set; }
        public int CompanyId { get; set; }
        public List<VoucherItemViewModel> VoucherItems { get; set; }
    }

    public class VoucherItemViewModel
    {
        public int Id { get; set; }
        public int? WebId { get; set; }
        public int VoucherId { get; set; }
        public int ProductId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Quantity { get; set; }
        public string Particulars { get; set; }
        public int? PropertyUnitId { get; set; }
    }

    public class PropUnitViewModel
    {
        public int WebId { get; set; }
        public int? Id { get; set; }
        public string Code { get; set; }
        public decimal Rent { get; set; }
        public bool? Active { get; set; }
        public int TenantId { get; set; }
        public int PropertyId { get; set; }
    }

    public class PropViewModel
    {
        public int WebId { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? CompanyId { get; set; }
        public string Address { get; set; }
        public int TenantId { get; set; }
        public string Remarks { get; set; }
        public float? Percentage { get; set; }
    }

    public class PropertyViewModel
    {
        public int Id { get; set; }
        public int? WebId { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expiry { get; set; }
        public string Name { get; set; }
        public float Percentage { get; set; }
        public string Remarks { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
    }

    public class PropertyUnitViewModel
    {
        public int Id { get; set; }
        public int? WebId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }
        public string Code { get; set; }
        public decimal Rent { get; set; }
        public int PropertyId { get; set; }
    }

    public class PropTenantViewModel
    {
        public int WebId { get; set; }
        public int? Id { get; set; }
        public int PropertyUnitId { get; set; }
        public int? CompanyId { get; set; }
        public bool? Active { get; set; }
        public int TenantId { get; set; }
        public float? Rent { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
    }

    public class PropertyTenantViewModel
    {
        public int Id { get; set; }
        public int? WebId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InvoicePeriod { get; set; }
        public float? Rent { get; set; }
        public int CompanyId { get; set; }
        public int PropertyUnitId { get; set; }
    }

}
