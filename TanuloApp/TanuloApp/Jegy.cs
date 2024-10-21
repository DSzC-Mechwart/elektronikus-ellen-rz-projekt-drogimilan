using System;

namespace TanuloApp
{
    public class Jegy
    {
        public int Ertek { get; set; }
        public string Tema { get; set; } = string.Empty;
        public string Tipus { get; set; } = string.Empty;
        public DateTime Datum { get; set; } = DateTime.Now;
    }
}
