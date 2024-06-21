using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class UpdateEntrepreneurCommandFromResourceAssembler
{
    public static UpdateEntrepreneurCommand ToCommandFromResource(UpdateEntrepreneurResource resource, int entrepreneurId)
    {
        return new UpdateEntrepreneurCommand(entrepreneurId, resource.Name, resource.Phone, resource.Ruc, 
            resource.Address, resource.Subscription, resource.UserId, resource.LogoImage);
    }
    
}