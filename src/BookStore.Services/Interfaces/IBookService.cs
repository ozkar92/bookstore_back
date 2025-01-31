using BookStore.Dto.Request;
using BookStore.Dto.Response;

namespace BookStore.Services.Interfaces
{
    public interface IBookService
    {

        Task<BaseResponseGeneric<ICollection<BookResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<BookResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(BookRequestDto request);
        Task<BaseResponse> UpdateAsync(int id, BookRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
