﻿
using AutoMapper;
using BookStore.Dto.Request;
using BookStore.Dto.Response;
using BookStore.Entities;
using BookStore.Repositories.Interfaces;
using BookStore.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BookStore.Services.Implementations
{
    public class BookService :IBookService
    {
        private readonly IBookRepository repository;
        private readonly ILogger<BookService> logger;
        private readonly IMapper mapper;

        public BookService(
            IBookRepository repository,
            ILogger<BookService> logger,
            IMapper mapper
            )
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<BaseResponseGeneric<ICollection<BookResponseDto>>> GetAsync()
        {
            var response = new BaseResponseGeneric<ICollection<BookResponseDto>>();
            try
            {
                response.Data = mapper.Map<ICollection<BookResponseDto>>(await repository.GetAsync());
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener la información";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponseGeneric<BookResponseDto>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<BookResponseDto>();
            try
            {
                response.Data = mapper.Map<BookResponseDto>(await repository.GetAsync(id));
                response.Success = response.Data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener la información";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponseGeneric<int>> AddAsync(BookRequestDto request)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                response.Data = await repository.AddAsync(mapper.Map<Book>(request));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al añadir la información";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }
        public async Task<BaseResponse> UpdateAsync(int id, BookRequestDto request)
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
