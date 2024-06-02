using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;

namespace ACME.CargoApp.API.Registration.Domain.Model.Entities;

public class Evidence
{
    public Evidence()
    {
        Link = string.Empty;
    }
    
    public Evidence(string link, int tripId)
    {
        Link = link;
        TripId = tripId;
    }
    public int Id { get; set; }
    public string Link { get; set; }
    public int TripId { get; set; }
    
    public Trip Trip { get; }
}