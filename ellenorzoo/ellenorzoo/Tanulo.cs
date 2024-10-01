using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ellenorzoo
{
    internal class Tanulo
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
