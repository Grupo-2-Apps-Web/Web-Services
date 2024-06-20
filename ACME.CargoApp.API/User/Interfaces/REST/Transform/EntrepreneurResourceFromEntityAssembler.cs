using ACME.CargoApp.API.User.Domain.Model.Aggregates;
using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class EntrepreneurResourceFromEntityAssembler
{
   public static EntrepreneurResource ToResourceFromEntity(Entrepreneur entity)
   {
       return new EntrepreneurResource(
           entity.Id, 
           entity.Name,
           entity.Phone,
           entity.Ruc,
           entity.Address,
           entity.Subscription,
           entity.UserId, 
           entity.LogoImage);
   }
}