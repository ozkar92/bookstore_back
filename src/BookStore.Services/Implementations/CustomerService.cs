using AutoMapper;
using BookStore.Dto.Request;
using BookStore.Dto.Response;
using BookStore.Entities;
using BookStore.Repositories.Interfaces;
using BookStore.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BookStore.Services.Implementations
{
    public class CustomerService :ICustomerService
    {
        private readonly ICustomerRepository repository;
        private readonly ILogger<CustomerService> logger;
        private readonly IMapper mapper;

        public CustomerService(
            ICustomerRepository repository,
            ILogger<CustomerService> logger,
            IMapper mapper
            )
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<BaseResponseGeneric<ICollection<CustomerResponseDto>>> GetAsync()
        {
            var response = new BaseResponseGeneric<ICollection<CustomerResponseDto>>();
            try
            {
                response.Data = mapper.Map<ICollection<CustomerResponseDto>>(await repository.GetAsync());
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener la información";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponseGeneric<CustomerResponseDto>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<CustomerResponseDto>();
            try
            {
                response.Data = mapper.Map<CustomerResponseDto>(await repository.GetAsync(id));
                response.Success = response.Data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener la información";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponseGeneric<int>> AddAsync(CustomerRequestDto request)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                response.Data = await repository.AddAsync(mapper.Map<Customer>(request));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al añadir la información";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponse> UpdateAsync(int id, CustomerRequestDto request)
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
    }
}
