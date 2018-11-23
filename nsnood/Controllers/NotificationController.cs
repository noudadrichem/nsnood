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
            //_notificationRepo.Register(notification);


            return notification.NotificationId.ToString();
        }

        [HttpPost("maakmelding")]
        public void MaakMelding([FromBody] Notification notification)
        {

        }
    }
}