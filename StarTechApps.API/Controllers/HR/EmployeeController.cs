using Dapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StarTech.Application.Queries;
using StarTech.Application.Queries.HR;
using StarTech.BLL.DBConfiguration;
using StarTech.Model.HR;
using StarTechApps.API.Controllers.Common;
using System.ComponentModel.Design;
using System.Data;
using System.Reflection.Emit;

namespace StarTechApps.API.Controllers.HR
{
    //[Authorize]
    public class EmployeeController : BaseApiController
    {
       

        [HttpGet("GetEmployment/{empCode}/{companyID}")]
        public async Task<IActionResult> GetEmployment(string empCode, int companyID)
        {
            return Ok(await _mediatr.Send(new GetEmploymentQuery { empCode = empCode, companyID = companyID}));
        }

        [HttpGet("GetEmployeeInfo/{empCode}")]
        public async Task<IActionResult> GetEmployeeProfileInfo(string empCode)
        {
            return Ok(await _mediatr.Send(new EmpProfileQuery { empCode = empCode }));
            
        }

    }
}

   