using System.Text.RegularExpressions;

namespace nsnood.model
{
    public class Material
    {
        public int MaterieelNummer { get; set; }
        public string Type { get; set; }
        
        /// <summary>
        /// Returns true if the train is a double decker
        /// </summary>
        public bool IsDoubleDecker
        {
            get => Type.Contains("VIRM") || Type.Contains("DDZ");
        }

        public int Size
        {
            get
            {
                if (Type.Contains("VIRM"))
                {
                    if (Type.Contains("IV"))
                    {
                        return 4;
                    }
                    if (Type.Contains("VI"))
                    {
                        return 6;
                    }
                }
                else
                {
                    var regex = new Regex($"\\d$");
                    var regexMatch = regex.Match(this.Type);
                    if (regexMatch.Success)
                    {
                        if (int.TryParse(regexMatch.Value, out int integerValue))
                        {
                            return integerValue;
                        }
                    }
                }

                return 0;
            }
        }
        
    }
}