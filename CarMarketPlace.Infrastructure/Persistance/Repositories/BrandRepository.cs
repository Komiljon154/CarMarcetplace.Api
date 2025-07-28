using CarMarketPlace.Application.Interfaces;
using CarMarketPlace.Core.Errors;
using CarMarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarMarketPlace.Infrastructure.Persistance.Repositories;

public class BrandRepository(AppDbContext _context) : IBrandRepository
{
    public async Task AddBrandAsync(Brand brand)
    {
        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();  
    }

    public async Task DeleteBrandAsync(int brandId)
    {
        var brand = await GetBrandByIdAsync(brandId);
        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Brand>> GetAllBrandAsync() => await _context.Brands.ToListAsync();

    public async Task<Brand> GetBrandByIdAsync(int brandId)
    {
        var brand =await _context.Brands.FirstOrDefaultAsync(x=>x.Id == brandId);
        if(brand == null)
        {
            throw new EntityNotFoundException($"Entity not found with id {brandId}");
        }
        return brand;
    }

    public async Task UpdateBrandAsync(Brand brand)
    {
        _context.Update(brand);
        await _context.SaveChangesAsync();
    }
}
