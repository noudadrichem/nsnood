using System;

namespace nsnood.model
{
    public class Notification
    {
        public Guid NotificationId { get; set; }

        public MeldingSoort Soort { get; set; }

        public string Beschrijving { get; set; }

        public int TreinstelNummer { get; set; }

        public DateTime meldMoment { get; set; }
    }

    public enum MeldingSoort
    {
        Intimidatie,

        Geweld,

        Medisch         
    }
}