using EventBookingBackend.Models.DTO.Token;
using System.Security.Claims;

namespace EventBookingBackend.Repositories.Interface
{
    public interface ITokenService
    {
        TokenResponse GetToken(IEnumerable<Claim> claim);
        string GetRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
