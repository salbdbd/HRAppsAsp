using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarTech.Application.Interface.RepositoryInterface.Mail;
using StarTech.Model.Mail;
using StarTech.BLL.Repository.Mail;
using Microsoft.AspNetCore.Authorization;

namespace StarTechApps.API.Controllers.Mail
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmailController : Controller
    {

        private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}

