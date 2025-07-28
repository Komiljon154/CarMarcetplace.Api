using CarMarketPlace.Application.Dtos;

namespace CarMarketPlace.Application.Services;

public interface IBrandService
{
    Task AddBrandAsync(BrandCreateDto brand);
    Task DeleteBrandAsync(int brandId);
    Task UpdateBrandAsync(BrandGetDto brand);
    Task<List<BrandGetDto>> GetAllBrandAsync();
    Task<BrandGetDto> GetBrandByIdAsync(int brandId);
}