using StarTech.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Interface.RepositoryInterface.HR
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmpInfoModel>> GetEmpInfo(string empCode, int companyID, string department,string name, string reportTo, int pageNumber, int rowsOfPage);
        Task<IEnumerable<EmploymentViewModel>> GetEmployment(string empCode, int companyID);
        Task<IEnumerable<EmpSearchViewModel>> SearchEmployee(EmpSearchViewModel serachKeys);
        Task<IEnumerable<EmpProfile>> GetEmployeeProfileInfo(string empCode);
    }
}
