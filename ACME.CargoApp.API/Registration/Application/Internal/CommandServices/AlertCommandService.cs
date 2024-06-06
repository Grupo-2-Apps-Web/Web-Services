using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.Shared.Domain.Repositories;

namespace ACME.CargoApp.API.Registration.Application.Internal.CommandServices;

public class AlertCommandService(IAlertRepository alertRepository, ITripRepository tripRepository, IUnitOfWork unitOfWork)
    :IAlertCommandService
{
    public async Task<Alert?> Handle(CreateAlertCommand command)
    {
        // Additional validation to check if the trip exists
        var trip = await tripRepository.FindByIdAsync(command.TripId);
        if (trip == null)
        {
            throw new ArgumentException("TripId not found.");
        }

        var alert = new Alert(command, trip);
        await alertRepository.AddAsync(alert);
        await unitOfWork.CompleteAsync();
        return alert;
    }
}