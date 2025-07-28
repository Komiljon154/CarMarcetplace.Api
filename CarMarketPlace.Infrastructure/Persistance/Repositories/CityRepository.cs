using CarMarketPlace.Application.Interfaces;
using CarMarketPlace.Core.Errors;
using CarMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarMarketPlace.Infrastructure.Persistance.Repositories;

public class CityRepository(AppDbContext _context) : ICityRepository
{
    public async Task AddCityAsync(City city)
    {
        await _context.Citys.AddAsync(city);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCityAsync(int cityId)
    {
        var city = await GetCityByIdAsync(cityId);
        _context.Citys.Remove(city);
        await _context.SaveChangesAsync();
    }

    public async Task<List<City>> GetAllCityAsync() => await _context.Citys.ToListAsync();

    public async Task<City> GetCityByIdAsync(int cityId)
    {
        var city =await _context.Citys.FirstOrDefaultAsync(x=>x.Id == cityId);
        if(city == null)
        {
            throw new EntityNotFoundException($"Entity not found with id {cityId}");
        }
        return city;
    }

    public async Task UpdateCityAsync(City city)
    {
        _context.Citys.Update(city);
        await _context.SaveChangesAsync();
    }
}
