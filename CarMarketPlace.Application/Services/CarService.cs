using CarMarketPlace.Application.Dtos;
using CarMarketPlace.Application.Interfaces;
using CarMarketPlace.Domain.Entities;

namespace CarMarketPlace.Application.Services;

public class CarService(ICarRepository _carRepo,IBrandRepository _brandRepo) : ICarService
{
    public async Task AddCarAsync(CarCreateDto car)
    {
        var carEntity = Converter(car);
        var brand = await _brandRepo.GetBrandByIdAsync(car.BrandId);
        carEntity.Brand =brand.Name;
        await _carRepo.AddCarAsync(carEntity);
    }

    public async Task DeleteCarAsync(int carId)
    {
        await _carRepo.DeleteCarAsync(carId);
    }

    public async Task<List<CarGetDto>> GetAllCarAsync()
    {
        var cars =await _carRepo.GetAllCarAsync();
        return cars.Select(Converter).ToList();
    }

    public async Task<List<CarGetDto>> GetCarByBrandIdAsync(int brandId)
    {
        var cars = await _carRepo.GetCarByBrandIdAsync(brandId);
        return cars.Select(Converter).ToList();
    }

    public async Task<List<CarGetDto>> GetCarByDealerIdAsync(int dealerId)
    {
        var cars = await _carRepo.GetCarByDealerIdAsync(dealerId);
        return cars.Select(Converter).ToList();
    }

    public async Task<CarGetDto> GetCarByIdAsync(int carId)
    {
        return Converter(await _carRepo.GetCarByIdAsync(carId));
    }

    public async Task UpdateCarAsync(CarGetDto car)
    {
        var carById = await _carRepo.GetCarByIdAsync(car.Id);
        carById.Color = car.Color;
        carById.Transmission = car.Transmission;
        carById.Price = car.Price;
        carById.Year = car.Year;
        carById.BrandId = car.BrandId;
        carById.DealerId = car.DealerId;
        carById.Description = car.Description;
        carById.FuelType = car.FuelType;
        carById.ImageUrl = car.ImageUrl;
        carById.IsAvailable = car.IsAvailable;
        carById.Mileage = car.Mileage;
        carById.Model = car.Model;

        var brand = await _brandRepo.GetBrandByIdAsync(car.BrandId);
        carById.Brand = brand.Name;

        await _carRepo.UpdateCarAsync(carById);
    }

    private Car Converter(CarCreateDto dto)
    {
        return new Car
        {
            BrandId = dto.BrandId,
            Color = dto.Color,
            DealerId = dto.DealerId,
            Description = dto.Description,
            FuelType = dto.FuelType,
            ImageUrl = dto.ImageUrl,
            IsAvailable = dto.IsAvailable,
            Year = dto.Year,
            Transmission = dto.Transmission,
            Price = dto.Price,
            Model = dto.Model,
            Mileage = dto.Mileage,
        };
    }
    private CarGetDto Converter(Car car)
    {
        return new CarGetDto
        {
            Id = car.Id,
            BrandId = car.BrandId,
            Color = car.Color,
            DealerId = car.DealerId,
            Description = car.Description,
            FuelType = car.FuelType,
            ImageUrl = car.ImageUrl,
            IsAvailable = car.IsAvailable,
            Year = car.Year,
            Transmission = car.Transmission,
            Price = car.Price,
            Model = car.Model,
            Mileage = car.Mileage,
            Brand = car.Brand,  
        };
    }
}
