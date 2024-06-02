namespace ACME.CargoApp.API.User.Domain.Model.Commands;

public record UpdateConfigurationCommand(int ConfigurationId, string Theme, string View, bool AllowDataCollection, bool UpdateDataSharing);