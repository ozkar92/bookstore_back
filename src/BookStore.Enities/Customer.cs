namespace BookStore.Entities
{
    public class Customer :EntityBase
    {
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string DNI { get; set; } = default!;
        public int Age { get; set; }
    }
}
