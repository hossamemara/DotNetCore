namespace DotNetCore.DataContext
{
    public class RecordOfSale
    {
        public int Id { get; set; }
        public DateTime DateOfSale { get; set; }
        public decimal Price { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
