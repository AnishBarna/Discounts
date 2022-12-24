namespace Discount.Models
{
    public partial class Key
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public int ProductId { get; set; }     

        public int ProductCityId { get; set; } 
        
    }
}