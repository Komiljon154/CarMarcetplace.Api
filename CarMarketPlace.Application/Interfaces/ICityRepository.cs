using CarMarketPlace.Domain.Entities;

namespace CarMarketPlace.Application.Interfaces;

public interface ICityRepository
{
    Task AddCityAsync(City city);
    Task DeleteCityAsync(int cityId);
    Task UpdateCityAsync(City city);
    Task<List<City>> GetAllCityAsync();
    Task<City> GetCityByIdAsync(int cityId);
}
