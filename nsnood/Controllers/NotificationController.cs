using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nsnood.model;
using nsnood.repo;

namespace nsnood.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private NotificationRepo _notificationRepo;
        public NotificationController(NotificationRepo notificationRepo)
        {
            _notificationRepo = notificationRepo;
        }

        [HttpPost("komtmeldingaan")]
        public ActionResult<string> KomtMeldingAan([FromBody] Notification notification)
        {
            var id = _notificationRepo.RegisterNotification();

            return id.ToString();
        }

        [HttpPost("maakmelding")]
        public ActionResult<string> MaakMelding([FromBody] Notification notification)
        {
            try
            {
                _notificationRepo.UpdateNotification(notification);

                return Ok("Noodmelding succesvol afgehandeld");

            }
            catch(Exception)
            {
                return NotFound("Er is iets misgegaan met het maken van de noodmelding");
            }
        }
    }
}