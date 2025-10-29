namespace DotNetCore.DataContext
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public double Amount { get; set; }
    }

    public class OrderNew
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public double Amount { get; set; }
    }
}
