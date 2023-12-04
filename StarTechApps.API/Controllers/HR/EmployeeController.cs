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
using System.Reflection.Emit;

namespace StarTechApps.API.Controllers.HR
{
    [Authorize]
    public class EmployeeController : BaseApiController
    {
       
        //[HttpGet("employee/get-employee-info/{empCode}/{companyID}/{department}/{name}/{reportTo}/{pageNumber}/{rowsOfPage}")]
        //public async Task<IActionResult> GetEmployeeInfo(string empCode, int companyID, string department, string name,string reportTo, int pageNumber, int rowsOfPage)
        //{
        //    return Ok(await _mediatr.Send(new GetEmployeeInfoQuery { empCode = empCode, companyID = companyID, department = department,name=name, reportTo= reportTo, pageNumber= pageNumber , rowsOfPage = rowsOfPage }));
        //}
        //[HttpPost("SearchEmployee/hr/employee/search")]
        //public async Task<IActionResult> SearchEmployee(EmpSearchViewModel serachKeys)
        //{
        //    return Ok(await _mediatr.Send(new SearchEmployeeQuery { EmpSearch = serachKeys }));
        //}

        [HttpGet("GetEmployment/{empCode}/{companyID}")]
        public async Task<IActionResult> GetEmployment(string empCode, int companyID)
        {
            return Ok(await _mediatr.Send(new GetEmploymentQuery { empCode = empCode, companyID = companyID}));
        } 
       
    }
}
   