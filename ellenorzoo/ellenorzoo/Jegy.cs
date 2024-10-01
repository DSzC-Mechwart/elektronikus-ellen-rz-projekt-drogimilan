using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ellenorzoo
{
    internal class Jegy
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
}
