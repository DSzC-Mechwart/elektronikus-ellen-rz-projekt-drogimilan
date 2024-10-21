using System.Collections.Generic;

namespace TanuloApp
{
    public class Tantargy
    {
        public string Nev { get; set; } = string.Empty;
        public List<Jegy> Jegyek { get; set; } = new List<Jegy>();

        // Átlag számítása
        public double GetAtlag()
        {
            if (Jegyek.Count == 0) return 0;
            double osszeg = 0;
            foreach (var jegy in Jegyek)
            {
                osszeg += jegy.Ertek;
            }
            return osszeg / Jegyek.Count;
        }
    }
}
