using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class EntrepreneurResourceFromEntityAssembler
{
   public static EntrepreneurResource ToResourceFromEntity(Entrepreneur entity)
   {
       return new EntrepreneurResource(entity.Id, entity.UserId, entity.LogoImage);
   }
}