using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace COMB.SpaParking.MVC.Responses
{
    public class BadRequestResposne : ObjectResult
    {
        public BadRequestResposne(object value) : base(value)
        {
            StatusCode = 400;
        }
    }
}
