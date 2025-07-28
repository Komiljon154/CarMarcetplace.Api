using CarMarketPlace.Application.Dtos;
using CarMarketPlace.Application.Interfaces;
using CarMarketPlace.Domain.Entities;

namespace CarMarketPlace.Application.Services;

public class DealerService(IDealerRepository _repo) : IDealerService
{
    public async Task AddDealerAsync(DealerCreateDto dealer)
    {
        var dealerEntity = Converter(dealer);
        await _repo.AddDealerAsync(dealerEntity);
    }

    public async Task DeleteDealerAsync(int dealerId)
    {
        await _repo.DeleteDealerAsync(dealerId);
    }

    public async Task<List<DealerGetDto>> GetAllDealerAsync()
    {
        var dealers = await _repo.GetAllDealerAsync();
        return dealers.Select(Converter).ToList();
    }

    public async Task<List<DealerGetDto>> GetDealerByCityIdAsync(int cityId)
    {
        var dealers = await _repo.GetDealerByCityIdAsync(cityId);
        return dealers.Select(Converter).ToList();
    }

    public async Task<DealerGetDto> GetDealerByIdAsync(int dealerId)
    {
        return Converter(await _repo.GetDealerByIdAsync(dealerId));
    }

    public async Task UpdateDealerAsync(DealerGetDto dealer)
    {
        var dealerEntity = await GetDealerByIdAsync(dealer.Id);
        dealerEntity.Rating = dealer.Rating;
        dealerEntity.Address = dealer.Address;
        dealerEntity.Phone = dealer.Phone;
        dealerEntity.Email = dealer.Email;
        dealerEntity.CityId = dealer.CityId;
        dealerEntity.Name = dealer.Name;
        //await _repo.UpdateDealerAsync(dealerEntity);
    }

    private Dealer Converter(DealerCreateDto dto)
    {
        return new Dealer
        {
            CityId = dto.CityId,
            Address = dto.Address,
            Email = dto.Email,
            Name = dto.Name,
            Phone = dto.Phone,
            Rating = dto.Rating,
        };
    }
    private DealerGetDto Converter(Dealer dto)
    {
        return new DealerGetDto
        {
            CityId = dto.CityId,
            Address = dto.Address,
            Email = dto.Email,
            Name = dto.Name,
            Phone = dto.Phone,
            Rating = dto.Rating,
            Id = dto.Id,
        };
    }

}
