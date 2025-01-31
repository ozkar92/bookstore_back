namespace BookStore.Entities
{
    public class Book : EntityBase
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        public List<Order> Orders { get; set; } = default!;
    }
}
