﻿namespace CarMarketPlace.Domain.Entities;

public class Car
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
    public Brand CarBrand { get; set; }


    public int DealerId { get; set; }
    public Dealer Dealer { get; set; }
}
