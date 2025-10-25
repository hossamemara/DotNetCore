namespace DotNetCore.DataContext
{
    public class Car
    {
        public int Id { get; set; }
        public string LicencePlate { get; set; }
        public string Model { get; set; }
        public List<RecordOfSale> SaleHistory { get; set; }

    }
}
