using BookStore.Entities;
using BookStore.Persistence;
using BookStore.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories.Implementations
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        private readonly IHttpContextAccessor httpContext;

        public BookRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) : base(context)
        {
            this.httpContext = httpContext;
        }
    }
}
