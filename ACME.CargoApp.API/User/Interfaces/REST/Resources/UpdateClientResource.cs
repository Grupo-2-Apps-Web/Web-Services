﻿namespace ACME.CargoApp.API.User.Interfaces.REST.Resources;

public record UpdateClientResource(string Name, string Phone, string Ruc, string Address, string Subscription, int UserId);