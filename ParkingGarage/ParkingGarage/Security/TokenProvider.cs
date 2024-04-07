using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParkingGarage.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace ParkingGarage.Security
{
    public interface ITokenProvider
    {
        string CreateToken(IPrincipal principal);

        ClaimsPrincipal TransformPrincipal(ClaimsPrincipal principal);
    }
    public class TokenProvider : ITokenProvider
    {
        private const string AuthoritiesKey = "auth";

        private readonly SecuritySettings _securitySettings;

        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        private readonly ILogger<TokenProvider> _log;

        private SigningCredentials _key;

        private long _tokenValidityInSeconds;

        public TokenProvider(ILogger<TokenProvider> log, IOptions<SecuritySettings> securitySettings)
        {
            _log = log;
            _securitySettings = securitySettings.Value;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            Init();
        }
        public string CreateToken(IPrincipal principal)
        {
            var subject = CreateSubject(principal);
            var validity =
                DateTime.UtcNow.AddSeconds(_tokenValidityInSeconds);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = validity,
                SigningCredentials = _key
            };

            var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            return _jwtSecurityTokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal TransformPrincipal(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        private void Init()
        {
            var secret = _securitySettings.Authentication.Jwt.Base64Secret;

            _key = new SigningCredentials(new SymmetricSecurityKey(Convert.FromBase64String(secret)), SecurityAlgorithms.HmacSha256Signature);
            _tokenValidityInSeconds = _securitySettings.Authentication.Jwt.TokenValidityInSeconds;
        }

        private static ClaimsIdentity CreateSubject(IPrincipal principal)
        {
            var user = principal as ClaimsPrincipal;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = user.Identity.Name;
            var role = user.FindFirst(ClaimTypes.Role)?.Value;
            var authValue = !string.IsNullOrEmpty(role) ? role : string.Empty;

            return new ClaimsIdentity(new[] {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.NameId, userId),
                new Claim(AuthoritiesKey, authValue)
            });
        }
    }
}
