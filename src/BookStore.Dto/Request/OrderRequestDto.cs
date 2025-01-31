namespace BookStore.Dto.Request
{
    public class OrderRequestDto
    {
        //public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public List<int> Books { get; set; } =new List<int>();
    }
}
