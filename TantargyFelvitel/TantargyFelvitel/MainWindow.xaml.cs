using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TantargyFelvitel
{
    public partial class MainWindow : Window
    {
        private const string FilePath = "tantargyak.txt";

        public MainWindow()
        {
            InitializeComponent();
            LoadTantargyak();
        }

        private void LoadTantargyak()
        {
            if (File.Exists(FilePath))
            {
                var tantargyak = File.ReadAllLines(FilePath);
                foreach (var tantargy in tantargyak)
                {
                    TantargyListBox.Items.Add(tantargy);
                }
            }
        }

        private void Mentés_Click(object sender, RoutedEventArgs e)
        {
            string tantargyNev = TantargyTextBox.Text;
            int evfolyam = int.Parse(((ComboBoxItem)EvfolyamComboBox.SelectedItem).Content.ToString());
            string tipus = ((ComboBoxItem)TipusComboBox.SelectedItem).Content.ToString();
            int hetiOraszam = int.Parse(HetiOraszamTextBox.Text);
            int evesOraszam = SzamitasEvesOraszam(evfolyam, tipus, hetiOraszam);

            string tantargyInfo = $"{tantargyNev}, Évfolyam: {evfolyam}, Típus: {tipus}, Heti óraszám: {hetiOraszam}, Éves óraszám: {evesOraszam}";
            TantargyListBox.Items.Add(tantargyInfo);

            File.AppendAllText(FilePath, tantargyInfo + Environment.NewLine);
        }

        private int SzamitasEvesOraszam(int evfolyam, string tipus, int hetiOraszam)
        {
            int hetSzam = 36; 

            if (evfolyam == 12)
            {
                hetSzam = tipus == "Közismereti" ? 31 : 36;
            }
            else if (evfolyam == 13)
            {
                hetSzam = 31;
            }
            else if (evfolyam < 9 || evfolyam > 11)
            {
                throw new Exception("Érvénytelen évfolyam.");
            }

            return hetiOraszam * hetSzam;
        }

        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            if (TantargyListBox.SelectedItem != null)
            {
                string selectedTantargy = TantargyListBox.SelectedItem.ToString();
                TantargyListBox.Items.Remove(selectedTantargy);
                SaveTantargyak();
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy tantárgyat a törléshez.");
            }
        }

        private void SaveTantargyak()
        {
            File.WriteAllLines(FilePath, TantargyListBox.Items.Cast<string>().ToArray());
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow();
            adminWindow.Show();
        }

        private void Hozzarendel_Click(object sender, RoutedEventArgs e)
        {
            if (TantargyListBox.SelectedItem == null)
            {
                MessageBox.Show("Kérlek válassz ki egy tantárgyat.");
                return;
            }

            string selectedTantargy = TantargyListBox.SelectedItem.ToString();
            string selectedTanulo = ((ComboBoxItem)TanuloComboBox.SelectedItem).Content.ToString();

            TanulokTantargyaiListBox.Items.Add($"{selectedTanulo} - {selectedTantargy}");
        }

    }
}
