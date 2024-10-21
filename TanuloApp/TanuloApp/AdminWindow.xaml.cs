using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace TanuloApp
{
    public partial class AdminWindow : Window
    {
        public AdminWindow(List<Tanulo> tanulok)
        {
            InitializeComponent();
            FeltoltTantargyDataGrid(tanulok);
            FeltoltTanuloDataGrid(tanulok);
        }

        private void FeltoltTantargyDataGrid(List<Tanulo> tanulok)
        {
            var tantargyak = new List<TantargyAtlag>();

            foreach (var tanulo in tanulok)
            {
                foreach (var tantargy in tanulo.Tantargyak)
                {
                    tantargyak.Add(new TantargyAtlag
                    {
                        Nev = tantargy.Nev,
                        Atlag = tantargy.GetAtlag()
                    });
                }
            }

            tantargyDataGrid.ItemsSource = tantargyak.GroupBy(t => t.Nev)
                .Select(g => new TantargyAtlag
                {
                    Nev = g.Key,
                    Atlag = g.Average(t => t.Atlag)
                }).ToList();
        }

        private void FeltoltTanuloDataGrid(List<Tanulo> tanulok)
        {
            var tanuloAtlagok = tanulok.Select(t => new TanuloAtlag
            {
                Nev = t.Nev,
                Atlag = t.Tantargyak.Average(tg => tg.GetAtlag())
            }).ToList();

            tanuloDataGrid.ItemsSource = tanuloAtlagok;
        }
    }

    public class TantargyAtlag
    {
        public string Nev { get; set; } = string.Empty;
        public double Atlag { get; set; }
    }

    public class TanuloAtlag
    {
        public string Nev { get; set; } = string.Empty;
        public double Atlag { get; set; }
    }
}
