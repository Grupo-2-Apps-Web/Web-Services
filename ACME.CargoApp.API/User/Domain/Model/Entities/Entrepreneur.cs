using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;

namespace ACME.CargoApp.API.User.Domain.Model.Entities;

public class Entrepreneur
{
    public Entrepreneur()
    {
        User = new Aggregates.User();
    }
    
    public Entrepreneur(int userId, string logoImage, Aggregates.User user)
    {
        UserId = userId;
        LogoImage = logoImage;
        User = user;
    }
    
    public int Id { get; set; }
    public Aggregates.User User { get; set; }
    public int UserId { get; set; }
    public string LogoImage { get; set; } 
    
    public ICollection<Trip> Trips { get; }
}