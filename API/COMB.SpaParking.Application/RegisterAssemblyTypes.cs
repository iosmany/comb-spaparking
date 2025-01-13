using COMB.SpaParking.Application.ParkingAreas.Query;
using COMB.SpaParking.Application.ParkingPermits.Command;
using COMB.SpaParking.Application.ParkingPermits.Query;
using COMB.SpaParking.Base;
using Microsoft.Extensions.DependencyInjection;

namespace COMB.SpaParking.Application
{
    public sealed class RegisterAssemblyTypes : ITypeRegistration
    {
        public void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IGetParkingAreasListQuery, GetParkingAreasListQuery>();

            serviceCollection.AddScoped<IGetParkingAreaTypesListQuery, GetParkingAreaTypesListQuery>();

            serviceCollection.AddScoped<IDeactivateParkingPermitCommand, DeactivateParkingPermitCommand>();
            serviceCollection.AddScoped<IGetParkingPermitsListQuery, GetParkingPermitsListQuery>();
            serviceCollection.AddScoped<IGetParkingPermitDetailQuery, GetParkingPermitDetailQuery>();
        }
    }
}
