using CarMarketPlace.Application.Interfaces;
using CarMarketPlace.Core.Errors;
using CarMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarMarketPlace.Infrastructure.Persistance.Repositories;

public class CarRepository(AppDbContext _context) : ICarRepository
{
    public async Task AddCarAsync(Car car)
    {
        await _context.AddAsync(car);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCarAsync(int carId)
    {
        var car = await GetCarByIdAsync(carId);
        _context.Remove(car);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Car>> GetAllCarAsync() => await _context.Cars.ToListAsync();

    public async Task<List<Car>> GetCarByBrandIdAsync(int brandId) => await _context.Cars.Where(x => x.BrandId == brandId).ToListAsync();

    public async Task<List<Car>> GetCarByDealerIdAsync(int dealerId) => await _context.Cars.Where(x => x.DealerId == dealerId).ToListAsync();

    public async Task<Car> GetCarByIdAsync(int carId)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == carId);
        if (car is null)
        {
            throw new EntityNotFoundException($"Entity not found by id {carId}");
        }
        return car;
    }

    public async Task UpdateCarAsync(Car car)
    {
        await UpdateCarAsync(car);
        await _context.SaveChangesAsync();
    }
}
