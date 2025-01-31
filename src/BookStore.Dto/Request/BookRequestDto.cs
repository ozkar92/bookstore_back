namespace BookStore.Dto.Request
{
    public class BookRequestDto
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string ISBN { get; set; } = default!;
       // public bool Status { get; set; }
    }
}
