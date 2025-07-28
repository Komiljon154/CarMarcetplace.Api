namespace CarMarketPlace.Domain.Entities;

public class Dealer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public decimal Rating { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }

    public ICollection<Car> Cars { get; set; }
}
