using StarTech.Application.Common.Mailing;
using StarTech.Model.Leave;
using StarTech.Model.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Interface.RepositoryInterface.Payroll
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<PaySlipModel>> GetPaySlip(string empCode, int periodID, int companyID, string department);
        Task<IEnumerable<SalaryPeriodModel>> GetPeriodList(int companyID);
        Task<IEnumerable<RptLoanInfoLedgerModel>> GetRptLoanInfoLedgerReport(string empCode, int companyID);
        void SendEmail(MailRequest message);
        //Task SendEmailAsync(MailRequest mailRequest);

    }
}
