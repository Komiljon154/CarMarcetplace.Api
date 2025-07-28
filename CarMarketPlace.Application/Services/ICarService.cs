using CarMarketPlace.Application.Dtos;
using CarMarketPlace.Domain.Entities;

namespace CarMarketPlace.Application.Services;

public interface ICarService
{
    Task AddCarAsync(CarCreateDto car);
    Task DeleteCarAsync(int carId);
    Task UpdateCarAsync(CarGetDto car);
    Task<List<CarGetDto>> GetAllCarAsync();
    Task<CarGetDto> GetCarByIdAsync(int carId);
    Task<List<CarGetDto>> GetCarByDealerIdAsync(int dealerId);
    Task<List<CarGetDto>> GetCarByBrandIdAsync(int brandId);
}