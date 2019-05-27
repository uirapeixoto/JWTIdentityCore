using AuthenticationService.Managers;
using JWTIdentityCore.Api.Common;
using JWTIdentityCore.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace JWTIdentityCore.Api.Controllers
{
    [Authorize(AuthenticationSchemes = TokenAuthenticationOptions.Bearer)]
    [ApiController]
    [Produces("application/json")]
    [Route("api/conversor")]
    public class ConversorAlturasController : ControllerBase
    {
        [HttpGet("PesMetros/{alturaPes}")]
        public object Get(double alturaPes)
        {
            
            var claims = User.Claims;
            var identity = HttpContext.User.Identity as ClaimsIdentity;


            var x = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name)).Value;
                var y = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Role)).Value;


            return Ok(new {
                AlturaPes = alturaPes,
                AlturaMetros = Math.Round(alturaPes * 0.3048, 4)
            });
        }
    }
}