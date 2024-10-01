using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace TantargyApp
{
    public partial class MainWindow : Window
    {
        private List<Tantargy> tantargyak = new List<Tantargy>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Mentés_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tantargyNev = tantargyNevTextBox.Text;
                int evfolyam = int.Parse(evfolyamTextBox.Text);
                string tipus = ((ComboBoxItem)tantargyTipusComboBox.SelectedItem).Content.ToString().ToLower();
                int hetiOraszam = int.Parse(hetiOraszamTextBox.Text);

                int evesOraszam = SzamolEvesOraszam(evfolyam, tipus, hetiOraszam);

                Tantargy ujTantargy = new Tantargy
                {
                    Nev = tantargyNev,
                    Evfolyam = evfolyam,
                    Tipus = tipus,
                    HetiOraszam = hetiOraszam,
                    EvesOraszam = evesOraszam
                };

                tantargyak.Add(ujTantargy);
                MentésFájlba();

                messageTextBlock.Text = "Sikeresen mentve!";
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message);
            }
        }

        private int SzamolEvesOraszam(int evfolyam, string tipus, int hetiOraszam)
        {
            if (evfolyam >= 9 && evfolyam <= 11)
            {
                return hetiOraszam * 36;
            }
            else if (evfolyam == 12)
            {
                return tipus == "közismereti" ? hetiOraszam * 31 : hetiOraszam * 36;
            }
            else if (evfolyam == 13)
            {
                return hetiOraszam * 31;
            }
            else
            {
                throw new ArgumentException("Érvénytelen évfolyam.");
            }
        }

        private void MentésFájlba()
        {
            string json = JsonSerializer.Serialize(tantargyak, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("tantargyak.json", json);
        }

        private void ClearFields()
        {
            tantargyNevTextBox.Clear();
            evfolyamTextBox.Clear();
            hetiOraszamTextBox.Clear();
            tantargyTipusComboBox.SelectedIndex = 0;
        }
    }

    public class Tantargy
    {
        public string Nev { get; set; }
        public int Evfolyam { get; set; }
        public string Tipus { get; set; }
        public int HetiOraszam { get; set; }
        public int EvesOraszam { get; set; }
    }
}
