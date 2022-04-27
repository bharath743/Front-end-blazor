using FrondEnd.Shared.DTOs;
using FrondEnd.Shared.Models;
using FrontEnd.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login(UserDTO login)
        {
            try
            {
                return Ok(await _authenticationService.AuthenticateAsync(login.Username, login.Password));
            }
            catch (Exception e)
            {
                return Unauthorized(new Response<string>("ERROR", e.Message));
                throw;
            }
        }
    }
}
