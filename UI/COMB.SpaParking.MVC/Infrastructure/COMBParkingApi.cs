using System.Text;
using COMB.SpaParking.Application.ParkingAreas;
using COMB.SpaParking.Application.ParkingPermits;
using COMB.SpaParking.Base.Result;
using LanguageExt;
using Newtonsoft.Json;

namespace COMB.SpaParking.MVC.Infrastructure
{
    public interface ICOMBParkingApi
    {
        /// <summary>
        /// Returns a parking-area list read from the API
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Either<Error, IReadOnlyCollection<IParkingArea>>> ReadParkingAreasAsync(IParkingAreaFilter request);
        /// <summary>
        /// Returns a parking-permit list read from the API
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Either<Error, IReadOnlyCollection<IParkingPermit>>> ReadParkingPermitsAsync(IParkingPermitFilter request);
        /// <summary>
        /// Get a parking permit by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Either<Error, IParkingPermit>> GetParkingPermitAsync(int id);
        /// <summary>
        /// Returns a parking-area-type list read from the API
        /// </summary>
        /// <returns></returns>
        Task<Either<Error, IReadOnlyCollection<IParkingAreaType>>> ReadParkingAreaTypesAsync();

        Task<Either<Error, IReadOnlyCollection<IParkingAreaType>>> DeactivateParkingPermitAsync(int id);

    }

    public sealed class COMBParkingApi : ICOMBParkingApi
    {
        
        readonly IHttpClientFactory _clientFactory;

        readonly ILogger<COMBParkingApi> _logger;
        public COMBParkingApi(IHttpClientFactory clientFactory, ILogger<COMBParkingApi> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        const string ApiErrorMessage = "Error retrieving data from api";

        HttpClient CreateClient()
        {
            return _clientFactory.CreateClient(Namings.FactoryApiName);
        }

        public async Task<Either<Error, IParkingPermit>> GetParkingPermitAsync(int id)
        {
            try
            {
                using var client = CreateClient();
                var response = await client.GetAsync($"api/v1/parkingpermits/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var parkingPermit = JsonConvert.DeserializeObject<ApiResponse<ParkingPermitDTO>>(data)
                            ?? new ApiResponse<ParkingPermitDTO>();

                    return parkingPermit.Data is not null ? parkingPermit.Data : Error.Create("Parking Permit not found");
                }
                _logger.LogWarning(response.ReasonPhrase);
                return Error.Create("Couldn't be possible get the Parking Permit.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception on getting parking permit {id}");
                return Error.Create(ApiErrorMessage);
            }
        }

        public async  Task<Either<Error, IReadOnlyCollection<IParkingArea>>> ReadParkingAreasAsync(IParkingAreaFilter request)
        {
            try
            {
                var pathBuilder = new StringBuilder();
                pathBuilder.Append($"api/v1/parkingareas?skip={request.Skip}&length={request.Length}");
                if (request.ParkingAreaTypeId !=0)
                    pathBuilder.Append($"&parkingareatypeid={request.ParkingAreaTypeId}");

                using var client = CreateClient();
                var response = await client.GetAsync(pathBuilder.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var parkingAreas = JsonConvert.DeserializeObject<ApiResponse<List<ParkingAreaDTO>>>(data)
                        ?? new ApiResponse<List<ParkingAreaDTO>>();
                    return parkingAreas.Data ?? new List<ParkingAreaDTO>();
                }
                _logger.LogWarning(response.ReasonPhrase);
                return Error.Create("Couldn't be possible get the Parking Areas.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception on getting parking areas list");
                return Error.Create(ApiErrorMessage);
            }
        }

        public async Task<Either<Error, IReadOnlyCollection<IParkingPermit>>> ReadParkingPermitsAsync(IParkingPermitFilter request)
        {
            try
            {
                using var client = CreateClient();
                
                var pathBuilder = new StringBuilder();
                pathBuilder.Append($"api/v1/parkingpermits?skip={request.Skip}&length={request.Length}");
                if (!string.IsNullOrWhiteSpace(request.ByLicensePlate))
                    pathBuilder.Append($"&bylicenseplate={request.ByLicensePlate}");
                if(request.Expired is not null)
                    pathBuilder.Append($"&expired={request.Expired.Value}");

                var response = await client.GetAsync(pathBuilder.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var parkingPermitsResponse = JsonConvert.DeserializeObject<ApiResponse<List<ParkingPermitDTO>>>(data)
                        ?? new ApiResponse<List<ParkingPermitDTO>>();
                    return parkingPermitsResponse.Data ?? new List<ParkingPermitDTO>();
                }
                _logger.LogWarning(response.ReasonPhrase);
                return Error.Create("Couldn't be possible get the Parking Permits List.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception on getting parking permits list");
                return Error.Create(ApiErrorMessage);
            }
        }

        public async Task<Either<Error, IReadOnlyCollection<IParkingAreaType>>> ReadParkingAreaTypesAsync()
        {
            try
            {
                using var client = CreateClient();
                var response = await client.GetAsync("api/v1/parkingareatypes");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var parkingAreas = JsonConvert.DeserializeObject<ApiResponse<List<ParkingAreaTypeDTO>>>(data)
                        ?? new ApiResponse<List<ParkingAreaTypeDTO>>();
                    return parkingAreas.Data ?? new List<ParkingAreaTypeDTO>();
                }
                _logger.LogWarning(response.ReasonPhrase);
                return Error.Create("Couldn't be possible get the Parking Area Types.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception on getting parking-area-types list");
                return Error.Create(ApiErrorMessage);
            }
        }

        public async Task<Either<Error, IReadOnlyCollection<IParkingAreaType>>> DeactivateParkingPermitAsync(int id)
        {
            try
            {
                using var client = CreateClient();
                var response = await client.GetAsync($"api/v1/parkingpermits/{id}/deactivate");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var parkingAreas = JsonConvert.DeserializeObject<ApiResponse<List<ParkingAreaTypeDTO>>>(data)
                        ?? new ApiResponse<List<ParkingAreaTypeDTO>>();
                    return parkingAreas.Data ?? new List<ParkingAreaTypeDTO>();
                }
                _logger.LogWarning(response.ReasonPhrase);
                return Error.Create("Couldn't be possible get the Parking Area Types.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception on getting parking-area-types list");
                return Error.Create(ApiErrorMessage);
            }
        }

        class ApiResponse<D>
        {
            public D? Data { get; set; }
            public Dictionary<string, string> Errors { get; set; } = new();
        }
    }
}
