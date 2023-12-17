using StarTech.Application.Interface.RepositoryInterface.Payroll;
using StarTech.Application.Interface.ServiceInterface.Payroll;
using StarTech.Model.Leave;
using StarTech.Model.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Services.Payroll
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _repository;

        public SalaryService(ISalaryRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<PaySlipModel>> GetPaySlip(string empCode, int periodID, int companyID, string department) => await _repository.GetPaySlip(empCode, periodID, companyID,department);
        public async Task<IEnumerable<SalaryPeriodModel>> GetPeriodList(int companyID) => await _repository.GetPeriodList(companyID);

        public async Task<IEnumerable<RptLoanInfoLedgerModel>> GetRptLoanInfoLedgerReport(string empCode, int companyID)
        {
            return await _repository.GetRptLoanInfoLedgerReport(empCode, companyID);
        }
           
    }
}
