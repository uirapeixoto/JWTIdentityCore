using Microsoft.AspNetCore.Authentication;

namespace JWTIdentityCore.Api.Common
{
    public class TokenAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string Bearer = "Bearer";
    }
}
