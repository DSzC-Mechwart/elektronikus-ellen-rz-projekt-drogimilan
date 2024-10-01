using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ellenorzoo
{
    
        public class Tantargy
        {
            public string Nev { get; set; }
            public List<Jegy> Jegyek { get; set; } = new List<Jegy>();

            public Tantargy(string nev)
            {
                Nev = nev;
            }
        }

        public class Jegy
        {
            public int Ertek { get; set; }
            public string Tema { get; set; }
            public string SzamonkeresTipusa { get; set; }

            public Jegy(int ertek, string tema, string szamonkeresTipusa)
            {
                Ertek = ertek;
                Tema = tema;
                SzamonkeresTipusa = szamonkeresTipusa;
            }

            public override string ToString()
            {
                return $"Jegy: {Ertek} - {Tema} ({SzamonkeresTipusa})";
            }
        }

        public class Tanulo
        {
            public string Nev { get; set; }
            public string Jelszo { get; set; }
            public List<Tantargy> Tantargyak { get; set; } = new List<Tantargy>();

            public Tanulo(string nev, string jelszo)
            {
                Nev = nev;
                Jelszo = jelszo;
            }

            public void HozzaadTantargy(Tantargy tantargy)
            {
                Tantargyak.Add(tantargy);
            }
        }

    
}
