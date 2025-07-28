using CarMarketPlace.Domain.Entities;

namespace CarMarketPlace.Application.Interfaces;

public interface IBrandRepository
{
    Task AddBrandAsync(Brand brand);
    Task DeleteBrandAsync(int brandId);
    Task UpdateBrandAsync(Brand brand);
    Task<List<Brand>> GetAllBrandAsync();
    Task<Brand> GetBrandByIdAsync(int brandId);
}
