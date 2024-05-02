using Microsoft.AspNetCore.Mvc;
using Twilio.TwiML;  // Certifique-se de ter o pacote Twilio instalado

namespace zappzap.robochat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwilioController : ControllerBase
    {
        [HttpPost("ReceiveMessage")]
        public ContentResult ReceiveMessage([FromForm] string From, [FromForm] string Body)
        {
            var response = new MessagingResponse();
            if (Body.ToLower().Contains("chatrobot"))
            {
                var message = "Qual Robô deseja falar?\n1. Nenhum\n2. Parque Jurubatuba\n3. gpt";
                response.Message(message);
            }
            else if (Body.ToLower() == "parque jurubatuba")
            {
                response.Message("Este serviço não está pronto!");
            }

            return Content(response.ToString(), "text/xml");
        }
    }
}
