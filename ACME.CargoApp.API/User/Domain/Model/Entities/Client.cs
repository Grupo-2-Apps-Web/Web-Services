using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;

namespace ACME.CargoApp.API.User.Domain.Model.Entities;

public class Client
{
    public Client()
    {
        User = new Aggregates.User();
    }
    
    public Client(int userId, Aggregates.User user)
    {
        UserId = userId;
        User = user;
    }
    
    
    public int Id { get; set; }
    public Aggregates.User User { get; set; }
    public int UserId { get; set; }
    
    
    public ICollection<Trip> Trips { get; }
    
}