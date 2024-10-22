using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1
{
    public class Tanulo
    {
        public string Name { get; set; }
        public string Birthplace { get; set; }
        public DateTime BirthDate { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Major { get; set; }
        public string Class { get; set; }
        public bool IsDormitory { get; set; }
        public string Dormitory { get; set; }
        public int LogNumber { get; set; }
        public string RegisterNumber { get; set; }

        public override string ToString()
        {
            return $"{Name};{Birthplace};{BirthDate.ToShortDateString()};{MotherName};{Address};{EnrollmentDate.ToShortDateString()};{Major};{Class};{IsDormitory};{Dormitory};{LogNumber};{RegisterNumber}";
        }
    }
}