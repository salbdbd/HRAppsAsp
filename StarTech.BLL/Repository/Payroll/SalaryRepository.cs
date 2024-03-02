using MailKit.Security;
using Microsoft.Data.SqlClient;
using MimeKit.Text;
using MimeKit;
using StarTech.Application.Common.Mailing;
using StarTech.Application.Interface.RepositoryInterface.Payroll;
using StarTech.Model.Leave;
using StarTech.Model.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;

namespace StarTech.BLL.Repository.Payroll
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly IConfiguration config;
        public IDbConnection _db;
        private readonly MailSettings _mailSettings;

        public SalaryRepository(IConfiguration config, IOptions<MailSettings> mailSettings)
        {
            _db = new SqlConnection(Connection.ConnectionString());
            this.config = config;
            _mailSettings = mailSettings.Value;
        }

        public async Task<IEnumerable<PaySlipModel>> GetPaySlip(string EmpCode, int PeriodID, int CompanyID, string department)
        {
            var result = await _db.QueryAsync<PaySlipModel>("SP_API_Getpayslip_NI",
                param: new
                {
                    EmpCode,
                    PeriodID,
                    CompanyID,
                    department
                },

             commandType: CommandType.StoredProcedure);
            return result.ToList(); ;
        }

        public async Task<IEnumerable<SalaryPeriodModel>> GetPeriodList(int CompanyID)
        {

            var result = await _db.QueryAsync<SalaryPeriodModel>("GetPeriodList_NI",
                 param: new
                 {
                     CompanyID
                 },

              commandType: CommandType.StoredProcedure);
            return result.ToList(); ;
        }

        public async Task<IEnumerable<RptLoanInfoLedgerModel>> GetRptLoanInfoLedgerReport(string empCode, int companyID)
        {

            var result = await _db.QueryAsync<RptLoanInfoLedgerModel>("spRptLoanInfoLedgerReport",
                param: new
                {
                    empCode,
                    companyID
                },
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void SendEmail(MailRequest request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(this.config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(this.config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(this.config.GetSection("EmailUsername").Value, this.config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }



        //public async Task SendEmailAsync(MailRequest mailRequest)
        //{
        //    var email = new MimeMessage();
        //    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        //    email.To.Add(MailboxAddress.Parse(mailRequest.To));
        //    email.Subject = mailRequest.Subject;
        //    var builder = new BodyBuilder();
        //    builder.HtmlBody = mailRequest.Body;
        //    email.Body = builder.ToMessageBody();
        //    using var smtp = new SmtpClient();
        //    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //}

        //public void SendEmail(MailRequest message)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
