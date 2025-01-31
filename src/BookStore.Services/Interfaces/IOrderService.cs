

using BookStore.Dto.Request;
using BookStore.Dto.Response;

namespace BookStore.Services.Interfaces
{
    public interface IOrderService
    {

        Task<BaseResponseGeneric<ICollection<OrderResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<ICollection<OrderResponseDto>>> GetAsync(string dni);
        Task<BaseResponseGeneric<int>> AddAsync(OrderRequestDto request);
        /*
        Task<BaseResponse> UpdateAsync(int id, OrderRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);*/
    }
}
