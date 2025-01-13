using Microsoft.AspNetCore.Authorization;

namespace COMB.SpaParking.UI.Server.Support
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =false)]
    public class AuthorizeCustomerServiceRep : AuthorizeAttribute
    {
        const string POLICY_PREFIX = "CustomerServiceRep";
        public AuthorizeCustomerServiceRep()
        {
            Policy = $"{POLICY_PREFIX}";
            Roles = $"{POLICY_PREFIX}";
        }
    }
}
