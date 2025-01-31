﻿using BookStore.Dto.Request;
using BookStore.Dto.Response;

namespace BookStore.Services.Interfaces
{
    public interface ICustomerService
    {

        Task<BaseResponseGeneric<ICollection<CustomerResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<CustomerResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(CustomerRequestDto request);
        Task<BaseResponse> UpdateAsync(int id, CustomerRequestDto request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
