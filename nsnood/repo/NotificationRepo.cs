using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using nsnood.model;

namespace nsnood.repo
{
    public class NotificationRepo
    {

        public readonly Dictionary<Guid, Notification> notifications = new Dictionary<Guid, Notification>();

        public IEnumerable<Notification> All()
        {
            return notifications.Values;
        }

        public Guid RegisterNotification()
        {
            Guid id = Guid.NewGuid();

            var noti = new Notification()
            {
                NotificationId = id
            };
            
            notifications.Add(id, noti);
            
            return id;
        }

        public void UpdateNotification(Notification noti)
        {
            notifications[noti.NotificationId] = noti;
        }

        public Notification GetNotification(Guid id)
        {
            return notifications[id];
        }

        public List<Notification> GetNotificationFromTrain(int trainNumber)
        {
            List<Notification> notis = new List<Notification>();
            
            foreach (KeyValuePair<Guid, Notification> pair in notifications)
            {
                var noti = pair.Value;
                
                DateTime today = DateTime.Now;
                DateTime agoTime = today.AddHours(-3); 
                
                if (noti.TreinstelNummer == trainNumber && (noti.meldMoment.Ticks > today.Ticks && noti.meldMoment.Ticks < agoTime.Ticks))
                {
                    notis.Add(noti);
                }
            }

            return notis;
        }
    }
}