using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace TanuloApp
{
    public partial class MainWindow : Window
    {
        private List<Tanulo> tanulok = new List<Tanulo>(); // Tanulók listája
        private Tanulo? bejelentkezettTanulo;  // Nullable típus

        public MainWindow()
        {
            InitializeComponent();
            FeltoltTanulok();  // Tanulók feltöltése
            tanuloComboBox.ItemsSource = tanulok;  // A ComboBox feltöltése tanulókkal
            tanuloComboBox.DisplayMemberPath = "Nev";  // A tanuló nevének megjelenítése a listában
        }

        // Tanulók és tantárgyak létrehozása
        private void FeltoltTanulok()
        {
            Tanulo tanulo1 = new Tanulo { Nev = "Kiss Péter" };
            tanulo1.Tantargyak.Add(new Tantargy { Nev = "Matematika" });
            tanulo1.Tantargyak.Add(new Tantargy { Nev = "Irodalom" });
            tanulo1.Tantargyak.Add(new Tantargy { Nev = "Fizika" });
            tanulo1.Tantargyak.Add(new Tantargy { Nev = "Biológia" });

            Tanulo tanulo2 = new Tanulo { Nev = "Nagy Ádám" };
            tanulo2.Tantargyak.Add(new Tantargy { Nev = "Fizika" });
            tanulo2.Tantargyak.Add(new Tantargy { Nev = "Történelem" });
            tanulo2.Tantargyak.Add(new Tantargy { Nev = "Kémia" });
            tanulo2.Tantargyak.Add(new Tantargy { Nev = "Matematika" });

            Tanulo tanulo3 = new Tanulo { Nev = "Tóth Anna" };
            tanulo3.Tantargyak.Add(new Tantargy { Nev = "Kémia" });
            tanulo3.Tantargyak.Add(new Tantargy { Nev = "Biológia" });
            tanulo3.Tantargyak.Add(new Tantargy { Nev = "Matematika" });
            tanulo3.Tantargyak.Add(new Tantargy { Nev = "Informatika" });

            Tanulo tanulo4 = new Tanulo { Nev = "Szabó Dániel" };
            tanulo4.Tantargyak.Add(new Tantargy { Nev = "Informatika" });
            tanulo4.Tantargyak.Add(new Tantargy { Nev = "Földrajz" });
            tanulo4.Tantargyak.Add(new Tantargy { Nev = "Történelem" });
            tanulo4.Tantargyak.Add(new Tantargy { Nev = "Matematika" });

            // Tanulók hozzáadása a listához
            tanulok.Add(tanulo1);
            tanulok.Add(tanulo2);
            tanulok.Add(tanulo3);
            tanulok.Add(tanulo4);
        }

        // Bejelentkezés gomb eseménykezelő
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (tanuloComboBox.SelectedItem != null)
            {
                bejelentkezettTanulo = (Tanulo)tanuloComboBox.SelectedItem;
                tantargyListBox.ItemsSource = bejelentkezettTanulo.Tantargyak;

                // Frissítjük a lemorzsolódással veszélyeztetett checkbox állapotát
                lemorzsolodasCheckbox.IsChecked = bejelentkezettTanulo.LemorzsolodasVeszelyeztetett();
            }
            else
            {
                MessageBox.Show("Kérlek válassz egy tanulót a listából!");
            }
        }

        // Új jegy hozzáadása
        private void UjJegy_Click(object sender, RoutedEventArgs e)
        {
            if (tantargyListBox.SelectedItem != null && bejelentkezettTanulo != null)
            {
                Tantargy kiválasztottTantargy = (Tantargy)tantargyListBox.SelectedItem;
                JegyHozzaadasWindow hozzaadasWindow = new JegyHozzaadasWindow(kiválasztottTantargy);
                bool? result = hozzaadasWindow.ShowDialog();

                if (result == true)
                {
                    // Frissítsd a jegyek listáját
                    jegyekDataGrid.ItemsSource = null;
                    jegyekDataGrid.ItemsSource = kiválasztottTantargy.Jegyek;

                    // Frissítsük a lemorzsolódással veszélyeztetett checkbox állapotát
                    lemorzsolodasCheckbox.IsChecked = bejelentkezettTanulo.LemorzsolodasVeszelyeztetett();
                }
            }
            else
            {
                MessageBox.Show("Válassz ki egy tantárgyat és egy tanulót!");
            }
        }

        // Tantárgyak listájának kezelése
        private void TantargyListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (tantargyListBox.SelectedItem != null && bejelentkezettTanulo != null)
            {
                Tantargy kiválasztottTantargy = (Tantargy)tantargyListBox.SelectedItem;
                jegyekDataGrid.ItemsSource = kiválasztottTantargy.Jegyek;

                // Kiszámoljuk az átlagot és megjelenítjük
                double atlag = kiválasztottTantargy.GetAtlag();
                tantargyAtlagTextBlock.Text = $"Tantárgy Átlag: {atlag:F2}";

                if (atlag < 2.0)
                {
                    tantargyAtlagTextBlock.Foreground = Brushes.Red; // Átlag piros színnel
                }
                else
                {
                    tantargyAtlagTextBlock.Foreground = Brushes.Black; // Normál szín
                }
            }
        }

        // Tanulók kiválasztása
        private void TanuloComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (tanuloComboBox.SelectedItem != null)
            {
                bejelentkezettTanulo = (Tanulo)tanuloComboBox.SelectedItem;
                tantargyListBox.ItemsSource = bejelentkezettTanulo.Tantargyak;

                // Frissítjük a lemorzsolódással veszélyeztetett checkbox állapotát
                lemorzsolodasCheckbox.IsChecked = bejelentkezettTanulo.LemorzsolodasVeszelyeztetett();
            }
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow(tanulok);
            adminWindow.ShowDialog();
        }
    }
}
