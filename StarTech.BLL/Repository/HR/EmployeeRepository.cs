using Dapper;
using Microsoft.Data.SqlClient;
using StarTech.Application.Interface.RepositoryInterface.HR;
using StarTech.BLL.DBConfiguration;
using StarTech.Model.HR;
using StarTech.Model.HR.Attendance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.BLL.Repository.HR
{

    public class EmployeeRepository : IEmployeeRepository
    {
      
        public async Task<IEnumerable<EmpInfoModel>> GetEmpInfo(string EmpCode, int CompanyID, string Department, string Name, string ReportTo,int PageNumber,int RowsOfPage)
        {
            using var con = new SqlConnection(Connection.ConnectionString());
            var param = new
            {
                EmpCode,
                CompanyID,
                Department,
                Name,
                ReportTo,
                PageNumber,
                RowsOfPage
            };
            List<EmpInfoModel> result = con.Query<EmpInfoModel>("SP_API_GetEmpInfo",
                 param: param, commandType: CommandType.StoredProcedure).ToList();
            return result;

        }


        public async Task<IEnumerable<EmpProfile>> GetEmployeeProfileInfo(string empCode)
        {
            using (var connection = new SqlConnection(Connection.ConnectionString()))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<EmpProfile>("usp_FlipBook_All_Ni", new { EmpCode = empCode }, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        //nizam
        public async Task<IEnumerable<EmploymentViewModel>> GetEmployment(string EmpCode, int CompanyId)
        {
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                var peram = new
                {
                    EmpCode,
                    CompanyId
                };
                var  apply = await con.QueryAsync<EmploymentViewModel>("sp_Getemployment_info", param: peram, commandType: CommandType.StoredProcedure);
                return apply.ToList();
            }
        }

       
        public async Task<IEnumerable<EmpSearchViewModel>> SearchEmployee(EmpSearchViewModel serachKeys)
        {

            var con = new SqlConnection(Connection.ConnectionString());

            object paramObj = new
            {
                serachKeys.CompanyID,
                serachKeys.GradeValue,
                serachKeys.EmpName,
                serachKeys.EmpCode,
                serachKeys.Department,
                serachKeys.Designation,
                serachKeys.IsBlock,
                serachKeys.Status
            };
            var employees = await con.QueryAsync<EmpSearchViewModel>("sp_search_employee", param: paramObj, commandType: CommandType.StoredProcedure);
            return employees.ToList();
        }
      
    }
}
