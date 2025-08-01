﻿using CarMarketPlace.Domain.Entities;

namespace CarMarketPlace.Application.Dtos;

public class CarGetDto
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int Mileage { get; set; }
    public string Color { get; set; }
    public string FuelType { get; set; }
    public string Transmission { get; set; }
    public bool IsAvailable { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int BrandId { get; set; }
    public int DealerId { get; set; }
}
