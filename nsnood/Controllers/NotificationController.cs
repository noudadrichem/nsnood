using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private readonly NotificationRepo _notificationRepo;
        public IEnumerable<Notification> Index()
        {
            return _notificationRepo.();
        }

        [Route("notificaties/{id}")]
        public ActionResult GetNotification(string id)
        {
            if (Guid.TryParse(id, out Guid guid))
            {
                try
                {
                    return new JsonResult(_notificationRepo.GetNotification(guid));
                }
                catch (Exception e)
                {
                    return NotFound();
                }
            }
            return this.BadRequest();
        }

        [Route("notificaties/treinstel/{id}")]
        public ActionResult GetNotificationsByMaterial(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            try
            {
                return new JsonResult(_notificationRepo.GetNotificationFromTrain(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
            return BadRequest();
        }

        [Route("notificaties/medewerker/{id}")]
        public ActionResult GetNotificationByWorker(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            try
            {
                return new JsonResult(this._notificationRepo.GetNotificationFromTrain(id));
            }
            catch (Exception e)
            {
                return NotFound();
            }
            return BadRequest();
        }
        
        
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