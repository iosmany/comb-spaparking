using Asp.Versioning;
using COMB.SpaParking.Application.ParkingAreas;
using COMB.SpaParking.Application.ParkingPermits;
using COMB.SpaParking.Application.ParkingPermits.Command;
using COMB.SpaParking.Application.ParkingPermits.Query;
using Microsoft.AspNetCore.Mvc;

namespace COMB.SpaParking.API.Controllers
{
    using ParkingPermitResponse = Models.ApiResponse<IParkingPermit>;
    using ParkingPermitsListResponse = Models.ApiResponse<IReadOnlyCollection<IParkingPermit>>;

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiVersion(1)]
    public class ParkingPermitsController : ControllerBase
    {
        readonly IGetParkingPermitsListQuery _getParkingPermitsListQuery;
        readonly IGetParkingPermitDetailQuery _getParkingPermitDetailQuery;
        readonly IDeactivateParkingPermitCommand _deactivateParkingPermitCommand;

        public ParkingPermitsController(IGetParkingPermitsListQuery getParkingPermitsListQuery, 
            IGetParkingPermitDetailQuery getParkingPermitDetailQuery, IDeactivateParkingPermitCommand deactivateParkingPermitCommand)
        {
            _getParkingPermitsListQuery = getParkingPermitsListQuery;
            _getParkingPermitDetailQuery = getParkingPermitDetailQuery;
            _deactivateParkingPermitCommand = deactivateParkingPermitCommand;
        }

        /// <summary>
        /// Get a list of parking permits
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ParkingPermitsListResponse), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ParkingPermitsListResponse), statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] ParkingPermitFilterDTO request)
        {
            var response = await _getParkingPermitsListQuery.ExecuteAsync(request);
            return response.Match<IActionResult>(
                Right: entities => Ok(ParkingPermitsListResponse.Success(entities)),
                Left: error => BadRequest(ParkingPermitsListResponse.Error(error))
            );
        }

        /// <summary>
        /// Get a parking permit details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ParkingPermitResponse), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _getParkingPermitDetailQuery.ExecuteAsync(id);
            return response.Match<IActionResult>(
                Right: entity => Ok(ParkingPermitResponse.Success(entity)),
                Left: error => BadRequest(ParkingPermitResponse.Error(error))
            );
        }

        /// <summary>
        /// Deactivate a parking permit setting its status to inactive
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/deactivate")]
        [ProducesResponseType(typeof(ParkingPermitResponse), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Deactivate(int id)
        {
            var response = await _deactivateParkingPermitCommand.ExecuteAsync(id);
            return response.Match<IActionResult>(
                Right: entity => Ok(ParkingPermitResponse.Success(entity)),
                Left: error => BadRequest(ParkingPermitResponse.Error(error))
            );
        }
    }
}
