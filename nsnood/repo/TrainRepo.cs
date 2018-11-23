using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using nsnood.model;

namespace nsnood.repo
{
    public class TrainRepo
    {
        public Material GetMaterial(int materieelNummer)
        {
            return new Material()
            {
                MaterieelNummer = materieelNummer,
                Type = "VIRM VI"
            };
        }


        public Train GetTrainByMaterial(int materieelNummer)
        {
            return new Train()
            {
                Bron = "dvs",
                Ritnummer = 1,
                Station = "UCS",
                Type = "VIRM",
                Vervoerder = "NS",
                Spoor = "1",
                MaterieelDelen =
                    new List<Material>
                    {
                        new Material
                        {
                            MaterieelNummer = materieelNummer,
                            Type = "VIRM VI"
                        }
                    },
                Ingekort = false,
                Lengte = 4,
                LengteInMeters = 107,
                LengteInPixels = 0,
                Debug = new List<string>
                {
                    "No platform information for HGL - 3"
                }

            };
        }
        
        
    }
}