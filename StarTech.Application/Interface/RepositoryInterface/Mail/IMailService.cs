using Microsoft.AspNetCore.Http;
using StarTech.Model.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.Application.Interface.RepositoryInterface.Mail
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
