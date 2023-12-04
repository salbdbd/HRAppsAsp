using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarTech.Application.Queries.HR;
using StarTechApps.API.Controllers.Common;

namespace StarTechApps.API.Controllers.HR
{
    [Authorize]
    public class BasicEntryController : BaseApiController
    {
        [HttpGet("basic/get-branch-list/{compId}")]
        public async Task<IActionResult> GetBranchList(int compId)
        {
            return Ok(await _mediatr.Send(new GetBasicEntryQuery { tableName = "Branch", compId = compId }));
        }
        [HttpGet("basic/get-department-list/{compId}")]
        public async Task<IActionResult> GetDepartmentList(int compId)
        {
            return Ok(await _mediatr.Send(new GetBasicEntryQuery { tableName = "Department", compId = compId }));
        }
    }
}
