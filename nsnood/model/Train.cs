using System.Collections;
using System.Collections.Generic;

namespace nsnood.model
{
    public class Train
    {
        public string Bron { get; set; }
        public int Ritnummer { get; set; }
        public string Station { get; set; }
        public string Type { get; set; }
        public string Vervoerder { get; set; }
        public string Spoor { get; set; }
        public IEnumerable<Material> MaterieelDelen { get; set; }
        public bool Ingekort { get; set; }
        public int Lengte { get; set; }
        public int LengteInMeters { get; set; }
        public int LengteInPixels { get; set; }
        public IEnumerable<string> Debug { get; set; }
    }
}