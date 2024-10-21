using System.Collections.Generic;

namespace TanuloApp
{
    public class Tanulo
    {
        public string Nev { get; set; } = string.Empty;
        public List<Tantargy> Tantargyak { get; set; } = new List<Tantargy>();

        
        public bool LemorzsolodasVeszelyeztetett()
        {
            int bukottTantargyakSzama = 0;

            foreach (var tantargy in Tantargyak)
            {
                if (tantargy.GetAtlag() < 1.75)
                {
                    bukottTantargyakSzama++;
                }
            }

            return bukottTantargyakSzama >= 3;
        }
    }
}
