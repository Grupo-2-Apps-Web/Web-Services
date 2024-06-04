using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Commands;

namespace ACME.CargoApp.API.Registration.Domain.Model.Entities;

public class Evidence
{
    public Evidence()
    {
        Link = string.Empty;
        Trip = new Trip();
    }
    
    public Evidence(string link, int tripId)
    {
        Link = link;
        TripId = tripId;
    }
    
    public Evidence(CreateEvidenceCommand command, Trip trip)
    {
        Link = command.Link;
        Trip = trip;
    }
    public int Id { get; set; }
    public string Link { get; set; }
    public int TripId { get; set; }
    public Trip Trip { get; }
}