using COMB.SpaParking.Base.Result;

namespace COMB.SpaParking.API.Models
{
    public sealed class ApiResponse<D>
    {
        public D? Data { get;  }
        public Dictionary<string, string> Errors { get; } = new();
        private ApiResponse()
        {
        }
        private ApiResponse(D data) : this()
        {
            Data = data;
        }
        public static ApiResponse<D> Success(D data)
        {
            return new ApiResponse<D>(data);
        }

        public static ApiResponse<D> Error(Error error)
        {
            var response= new ApiResponse<D>();
            response.Errors.Add("errorMessage", error.Message);
            return response;
        }
    }
}
