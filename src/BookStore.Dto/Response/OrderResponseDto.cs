namespace BookStore.Dto.Response
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerResponseDto Customer { get; set; } = default!;
        public List<BookResponseDto> Books { get; set; } = default!;
    }
}
