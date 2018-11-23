using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nsnood.model;

namespace nsnood.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        [HttpPost("komtmeldingaan")]
        public ActionResult<string> KomtMeldingAan([FromBody] MeldingSoort meldingSoort)
        {
            var notification = new Notification
            {
                NotificationId = Guid.NewGuid(),
                Soort = meldingSoort
            };

            return notification.NotificationId.ToString();
        }

        [HttpPost("maakmelding")]
        public void MaakMelding([FromBody] Notification notification)
        {

        }
    }
}