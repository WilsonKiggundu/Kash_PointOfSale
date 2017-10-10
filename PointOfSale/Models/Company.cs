namespace PointOfSale.Models
{
    public class Company : BaseModel
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }  
        public bool? Landlord { get; set; }
        public bool? Occupant { get; set; }
    }
}
