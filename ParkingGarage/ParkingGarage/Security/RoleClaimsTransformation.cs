using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ParkingGarage.Security
{
    public class RoleClaimsTransformation : IClaimsTransformation
    {
        private readonly ITokenProvider _tokenProvider;

        public RoleClaimsTransformation(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            return Task.FromResult(_tokenProvider.TransformPrincipal(principal));
        }
    }
}
