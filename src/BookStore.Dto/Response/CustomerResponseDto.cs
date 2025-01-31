namespace BookStore.Dto.Response
{
    public class CustomerResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string DNI { get; set; } = default!;
        public int Age { get; set; }
        public bool Status { get; set; }
    }
}
