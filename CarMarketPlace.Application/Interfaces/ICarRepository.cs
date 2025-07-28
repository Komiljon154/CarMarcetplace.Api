using CarMarketPlace.Domain.Entities;

namespace CarMarketPlace.Application.Interfaces;

public interface ICarRepository
{
    Task AddCarAsync(Car car);
    Task DeleteCarAsync(int carId);
    Task UpdateCarAsync(Car car);
    Task<List<Car>> GetAllCarAsync();
    Task<Car> GetCarByIdAsync(int carId);
    Task<List<Car>> GetCarByDealerIdAsync(int dealerId);
    Task<List<Car>> GetCarByBrandIdAsync(int brandId);
}
