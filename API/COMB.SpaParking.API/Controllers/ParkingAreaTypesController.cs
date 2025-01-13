using Asp.Versioning;
using COMB.SpaParking.API.Models;
using COMB.SpaParking.Application.ParkingAreas;
using COMB.SpaParking.Application.ParkingAreas.Query;
using Microsoft.AspNetCore.Mvc;

namespace COMB.SpaParking.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiVersion(1)]
    public class ParkingAreaTypesController : ControllerBase
    {
        readonly IGetParkingAreaTypesListQuery _getParkingAreaTypesListQuery;
        public ParkingAreaTypesController(IGetParkingAreaTypesListQuery getParkingAreaTypesListQuery)
        {
            _getParkingAreaTypesListQuery = getParkingAreaTypesListQuery;
        }

        /// <summary>
        /// Get a list of parking area types
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyCollection<IParkingAreaType>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var response= await _getParkingAreaTypesListQuery.ExecuteAsync();
            return response.Match<IActionResult>(
                Right: entities => Ok(ApiResponse<IReadOnlyCollection<IParkingAreaType>>.Success(entities)),
                Left: error => BadRequest(ApiResponse<IReadOnlyCollection<IParkingAreaType>>.Error(error))
            );
        }
    }
}
