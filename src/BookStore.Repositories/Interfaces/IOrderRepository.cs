using BookStore.Entities;

namespace BookStore.Repositories.Interfaces
{
    public interface IOrderRepository:IRepositoryBase<Order>
    {
        Task<List<Book>?> GetBooksByIdsAsync(List<int> bookIds);
    }
}
