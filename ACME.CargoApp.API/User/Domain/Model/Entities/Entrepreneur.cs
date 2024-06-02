namespace ACME.CargoApp.API.User.Domain.Model.Entities;

public class Entrepreneur
{
    public Entrepreneur()
    {
        User = new Aggregates.User();
    }
    
    public Entrepreneur(int userId, Aggregates.User user)
    {
        UserId = userId;
        User = user;
    }
    
    public int Id { get; set; }
    public Aggregates.User User { get; set; }
    public int UserId { get; set; }
    public string LogoIma { get; set; } 
}