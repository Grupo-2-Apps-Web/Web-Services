﻿using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;

namespace ACME.CargoApp.API.Registration.Domain.Model.Entities;

public class Expense
{
    public Expense()
    {
        FuelAmount = 0;
        FuelDescription = string.Empty;
        ViaticsAmount = 0;
        ViaticsDescription = string.Empty;
        TollsAmount = 0;
        TollsDescription = string.Empty;
    }
    
    public Expense(int fuelAmount, string fuelDescription, int viaticsAmount, string viaticsDescription, int tollsAmount, string tollsDescription, int tripId)
    {
        FuelAmount = fuelAmount;
        FuelDescription = fuelDescription;
        ViaticsAmount = viaticsAmount;
        ViaticsDescription = viaticsDescription;
        TollsAmount = tollsAmount;
        TollsDescription = tollsDescription;
        TripId = tripId;
    }
    public int Id { get; set; }
    public int FuelAmount { get; set; }
    public string FuelDescription { get; set; }
    public int ViaticsAmount { get; set; }
    public string ViaticsDescription { get; set; }
    public int TollsAmount { get; set; }
    public string TollsDescription { get; set; }
     
    public int TripId { get; set; }
    
    public Trip Trips { get; set; }

}