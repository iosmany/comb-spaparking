using COMB.SpaParking.Application.Interfaces.Persistence;
using COMB.SpaParking.Base;
using COMB.SpaParking.Persistence.ParkingAreas;
using Microsoft.Extensions.DependencyInjection;

namespace COMB.SpaParking.Persistence
{
    public sealed class RegisterAssemblyTypes : ITypeRegistration
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDatabaseService, DatabaseContext>();

            serviceCollection.AddScoped<IParkingAreaTypeRepository, ParkingAreaTypeRepository>();
            serviceCollection.AddScoped<IParkingAreaRepository, ParkingAreaRepository>();
            serviceCollection.AddScoped<IParkingPermitRepository, ParkingPermitRepository>();
        }
    }
}
