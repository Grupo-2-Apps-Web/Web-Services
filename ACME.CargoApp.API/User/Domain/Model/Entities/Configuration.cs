namespace ACME.CargoApp.API.User.Domain.Model.Entities;

public class Configuration
{
    public Configuration()
    {
        User = new Aggregates.User();
        AllowDataCollection = false;
        UpdateDataSharing = false;
    }
    
    public Configuration(int userId, Aggregates.User user)
    {
        UserId = userId;
        User = user;
    }
    
    public int Id { get; set; }
    public Aggregates.User User { get; set; }
    public int UserId { get; set; }
    public string Theme { get; set; }
    public string View { get; set; }
    public bool AllowDataCollection { get; set; }
    public bool UpdateDataSharing { get; set; }
}