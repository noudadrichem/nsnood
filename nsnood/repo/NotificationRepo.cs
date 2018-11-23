using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using nsnood.model;

namespace nsnood.repo
{
    public class NotificationRepo
    {

        public Dictionary<Guid, Notification> notifications { get; set; }

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
                
                if (noti.TreinstelNummer == trainNumber)
                {
                    notis.Add(noti);
                }
            }

            return notis;
        }

    }
}