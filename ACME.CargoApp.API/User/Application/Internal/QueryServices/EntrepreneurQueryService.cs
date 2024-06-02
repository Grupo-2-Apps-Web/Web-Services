using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Domain.Model.Queries;
using ACME.CargoApp.API.User.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Services;

namespace ACME.CargoApp.API.User.Application.Internal.QueryServices;

public class EntrepreneurQueryService(IEntrepreneurRepository entrepreneurRepository) : IEntrepreneurQueryService
{
    public async Task<IEnumerable<Entrepreneur>> Handle(GetAllEntrepreneursQuery query)
    {
        return await entrepreneurRepository.ListAsync();
    }
    
    public async Task<Entrepreneur?> Handle(GetEntrepreneurByIdQuery query)
    {
        return await entrepreneurRepository.FindByIdAsync(query.EntrepreneurId);
    }
}
