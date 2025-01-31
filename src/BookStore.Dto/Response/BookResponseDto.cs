namespace BookStore.Dto.Response
{
    public class BookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        public bool Status { get; set; }
    }
}
