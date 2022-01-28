using Microsoft.AspNetCore.Mvc;
using ProjectOs.Domain.Interface;
using ProjectOs.Domain.Models;
using System.Threading.Tasks;

namespace ProjectOs.Controllers
{
    [ApiController]
    [Route("v1/SendEmail")]
    public class SendEmailController : ControllerBase
    {
        private readonly IMailRepository mailRepository;

        public SendEmailController(IMailRepository mailRepository)
        {
        
            this.mailRepository = mailRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Send([FromForm] SendEmail sendEmail)
        {
            await mailRepository.SendEmailAsync(sendEmail);
            return Ok();
        }
    }
}
