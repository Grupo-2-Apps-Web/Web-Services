using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.Shared.Domain.Repositories;

namespace ACME.CargoApp.API.Registration.Application.Internal.CommandServices;

public class EvidenceCommandService(IEvidenceRepository evidenceRepository ,ITripRepository tripRepository, IUnitOfWork unitOfWork)
    : IEvidenceCommandService
{
    public async Task<Evidence?> Handle(CreateEvidenceCommand command)
    {
        var evidence = new Evidence(command.Link, command.TripId);
        await evidenceRepository.AddAsync(evidence);
        await unitOfWork.CompleteAsync();
        return evidence;
    }
    
    public async Task<Evidence?> Handle(UpdateEvidenceCommand command)
    {
        var evidence = await evidenceRepository.FindByIdAsync(command.TripId);
        if (evidence == null)
        {
            return null;
        }
        //Update the evidence information
        evidence.Link = command.Link;
        
        await unitOfWork.CompleteAsync();
        return evidence;
    }
}