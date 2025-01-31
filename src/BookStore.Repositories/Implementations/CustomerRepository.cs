using BookStore.Entities;
using BookStore.Persistence;
using BookStore.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.Implementations
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly IHttpContextAccessor httpContext;
        public CustomerRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) : base(context)
        {
            this.httpContext = httpContext;
        }
    }
}
