using CarMarketPlace.Application.Interfaces;
using CarMarketPlace.Core.Errors;
using CarMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CarMarketPlace.Infrastructure.Persistance.Repositories;

public class DealerRepository(AppDbContext _context) : IDealerRepository
{
    public async Task AddDealerAsync(Dealer dealer)
    {
        await _context.Dealers.AddAsync(dealer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDealerAsync(int dealerId)
    {
        var dealer = await GetDealerByIdAsync(dealerId);
        _context.Dealers.Remove(dealer);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Dealer>> GetAllDealerAsync() => await _context.Dealers.ToListAsync();

    public async Task<List<Dealer>> GetDealerByCityIdAsync(int cityId) => await _context.Dealers.Where(x => x.CityId == cityId).ToListAsync();

    public async Task<Dealer> GetDealerByIdAsync(int dealerId)
    {
        var dealer = await _context.Dealers.FirstOrDefaultAsync(x=>x.Id == dealerId);
        if(dealer == null)
        {
            throw new EntityNotFoundException($"Entity not found with id {dealerId}");
        }
        return dealer;
    }

    public async Task UpdateDealerAsync(Dealer dealer)
    {
        _context.Dealers.Update(dealer);
        await _context.SaveChangesAsync();
    }
}
