using ACME.CargoApp.API.IAM.Domain.Model.Commands;
using ACME.CargoApp.API.IAM.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}