using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarTech.Application.Queries.Security;
using StarTech.Model.Security;
using StarTechApps.API.Controllers.Common;

namespace StarTechApps.API.Controllers.Security
{
    [Authorize]
    public class SecurityController : BaseApiController
    {
        [HttpPost("security/change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            return Ok(await _mediatr.Send(new ChangePasswordQuery { model = model }));
        }
    }
}
