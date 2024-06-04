﻿using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Commands;

namespace ACME.CargoApp.API.Registration.Domain.Model.Entities;

public class Alert
{
    public Alert()
    {
        Title= string.Empty;
        Description = string.Empty;
        Date = DateTime.Now;
        Trip = new Trip();
    }
    
    public Alert(string title, string description, DateTime date, int tripId)
    {
        Title = title;
        Description = description;
        Date = date;
        TripId = tripId;
    }

    public Alert(CreateAlertCommand command, Trip trip)
    {
        Title = command.Title;
        Description = command.Description;
        Date = command.Date;
        Trip = trip;
    }
    
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public int TripId { get; set; }
    public Trip Trip { get; }
}