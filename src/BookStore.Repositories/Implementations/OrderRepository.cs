

using System.Linq.Expressions;
using BookStore.Entities;
using BookStore.Persistence;
using BookStore.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.Implementations
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly IHttpContextAccessor httpContext;
        public OrderRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) : base(context)
        {
            this.httpContext = httpContext;
        }
        public async Task<List<Book>?> GetBooksByIdsAsync(List<int> bookIds)
        {
            return await context.Set<Book>().Where(x => bookIds.Contains(x.Id)).ToListAsync();

        }
        public override async Task<ICollection<Order>> GetAsync(Expression<Func<Order, bool>> predicate)
        {
            return await context.Set<Order>()
                .Include(x => x.Books).Include(x => x.Customer).Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
