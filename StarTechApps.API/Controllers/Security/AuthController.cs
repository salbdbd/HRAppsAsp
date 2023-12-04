using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StarTech.Application.Command;
using StarTech.Application.Queries.HR.Attendance;
using StarTech.Application.Queries.Security;
using StarTech.Model.Attendance;
using StarTech.Model.Security;
using StarTechApps.API.Controllers.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace StarTechApps.API.Controllers.Security
{

    public class AuthController : BaseApiController
    {
        [HttpPost("login")]
        public async Task<IActionResult> LogIn(SystemLoginCommand model)
        {
            var token = await _mediatr.Send(model);
            return Ok(token);
        }


    }
}
