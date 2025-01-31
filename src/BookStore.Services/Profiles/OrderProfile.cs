using AutoMapper;
using BookStore.Dto.Request;
using BookStore.Dto.Response;
using BookStore.Entities;

namespace BookStore.Services.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResponseDto>();

            CreateMap<OrderRequestDto, Order>();
        }
    }
}
