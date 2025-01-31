namespace BookStore.Entities
{
    public class Order:EntityBase
    {
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
