using CarMarketPlace.Application.Dtos;
using CarMarketPlace.Domain.Entities;

namespace CarMarketPlace.Application.Interfaces;

public interface IDealerRepository
{
    Task AddDealerAsync(Dealer dealer);
    Task DeleteDealerAsync(int dealerId);
    Task UpdateDealerAsync(Dealer dealer);
    Task<List<Dealer>> GetAllDealerAsync();
    Task<Dealer> GetDealerByIdAsync(int dealerId);
    Task<List<Dealer>> GetDealerByCityIdAsync(int cityId);
}
