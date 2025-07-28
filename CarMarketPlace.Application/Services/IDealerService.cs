using CarMarketPlace.Application.Dtos;
using CarMarketPlace.Domain.Entities;

namespace CarMarketPlace.Application.Services;

public interface IDealerService
{
    Task AddDealerAsync(DealerCreateDto dealer);
    Task DeleteDealerAsync(int dealerId);
    Task UpdateDealerAsync(DealerGetDto dealer);
    Task<List<DealerGetDto>> GetAllDealerAsync();
    Task<DealerGetDto> GetDealerByIdAsync(int dealerId);
    Task<List<DealerGetDto>> GetDealerByCityIdAsync(int cityId);
}