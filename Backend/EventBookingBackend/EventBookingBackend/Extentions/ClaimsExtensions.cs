using System.Security.Claims;

namespace EventBookingBackend.Extentions
{
    public static class ClaimsExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "ClaimsPrincipal cannot be null");
            }

            var nameClaim = user.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"));
            return nameClaim?.Value;
        }
    }
}
