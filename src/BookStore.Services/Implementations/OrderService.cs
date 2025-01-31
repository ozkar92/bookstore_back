
using AutoMapper;
using BookStore.Dto.Request;
using BookStore.Dto.Response;
using BookStore.Entities;
using BookStore.Repositories.Interfaces;
using BookStore.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BookStore.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        private readonly ILogger<OrderService> logger;
        private readonly IMapper mapper;

        public OrderService(
            IOrderRepository repository,
            ILogger<OrderService> logger,
            IMapper mapper
            )
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

       
        public async Task<BaseResponseGeneric<ICollection<OrderResponseDto>>> GetAsync()
        {
            var response = new BaseResponseGeneric<ICollection<OrderResponseDto>>();
            try
            {
                response.Data = mapper.Map<ICollection<OrderResponseDto>>(await repository.GetAsync());
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener la información";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponseGeneric<ICollection<OrderResponseDto>>> GetAsync(string dni)
        {
            var response = new BaseResponseGeneric<ICollection<OrderResponseDto>>();
            try
            {
                var data = await repository.GetAsync(
                    predicate: x => x.Customer.DNI.ToLower().Contains(dni ?? string.Empty)
                    );
                response.Data = mapper.Map<ICollection<OrderResponseDto>>(data);
                response.Success = response.Data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error al filtrar las ventas por fecha.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        /*
        public async Task<BaseResponseGeneric<OrderResponseDto>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<OrderResponseDto>();
            try
            {
                response.Data = mapper.Map<OrderResponseDto>(await repository.GetAsync(id));
                response.Success = response.Data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener la información";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        */
        public async Task<BaseResponseGeneric<int>> AddAsync(OrderRequestDto request)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {

                var books = await repository.GetBooksByIdsAsync(request.Books);

                var ord = new Order
                {
                    Books = books,
                    CustomerId = request.CustomerId
                };

                response.Data = await repository.AddAsync(ord);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al añadir la información";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        /*
         public async Task<BaseResponse> UpdateAsync(int id, OrderRequestDto request)
         {
             var response = new BaseResponse();
             try
             {
                 var entity = await repository.GetAsync(id);
                 if (entity is null)
                 {
                     response.ErrorMessage = "No se encontro el registro el registro";
                     return response;
                 }

                 mapper.Map(request, entity);
                 await repository.UpdateAsync();
                 response.Success = true;
             }
             catch (Exception ex)
             {
                 response.ErrorMessage = "Ocurrió un error al actualizar la información";
                 logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
             }
             return response;
         }
         public async Task<BaseResponse> DeleteAsync(int id)
         {
             var response = new BaseResponse();
             try
             {
                 await repository.DeleteAsync(id);
                 response.Success = true;
             }
             catch (Exception ex)
             {
                 response.ErrorMessage = "Ocurrió un error al eliminar la información";
                 logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
             }
             return response;
         }
         */
    }
}
