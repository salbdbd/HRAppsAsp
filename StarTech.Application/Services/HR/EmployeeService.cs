using AutoMapper;
using MediatR;
using StarTech.Application.Interface.RepositoryInterface.HR;
using StarTech.Application.Interface.ServiceInterface.HR;
using StarTech.Model.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Services.HR
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<EmpInfoModel>> GetEmpInfo(string empCode, int companyID,string department, string name, string reportTo, int pageNumber, int rowsOfPage) => await _repository.GetEmpInfo(empCode, companyID, department,name, reportTo, pageNumber, rowsOfPage);

        public async Task<IEnumerable<EmpProfile>> GetEmployeeProfileInfo(string empCode) => await _repository.GetEmployeeProfileInfo(empCode);


        public async Task<IEnumerable<EmploymentViewModel>> GetEmployment(string empCode, int companyID)=> await _repository.GetEmployment(empCode, companyID);

        public async Task<IEnumerable<EmpSearchViewModel>> SearchEmployee(EmpSearchViewModel serachKeys) => await _repository.SearchEmployee(serachKeys);

    }
}
