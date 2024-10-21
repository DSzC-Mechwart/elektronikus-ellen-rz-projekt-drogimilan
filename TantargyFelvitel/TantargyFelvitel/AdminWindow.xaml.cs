using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace TantargyFelvitel
{
    public partial class AdminWindow : Window
    {
        private const string FilePath = "tantargyak.txt";

        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Kimutatas_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(FilePath))
            {
                MessageBox.Show("Nincsenek tantárgyak az állományban.");
                return;
            }

            var tantargyak = File.ReadAllLines(FilePath);
            var kimutatas = new Dictionary<(int evfolyam, string tipus), (int szam, int evesOraszam)>();

            foreach (var tantargy in tantargyak)
            {
                var reszletek = tantargy.Split(new[] { ", " }, StringSplitOptions.None);
                if (reszletek.Length >= 5)
                {
                    int evfolyam = int.Parse(reszletek[1].Split(':')[1].Trim());
                    string tipus = reszletek[2].Split(':')[1].Trim();
                    int evesOraszam = int.Parse(reszletek[4].Split(':')[1].Trim());

                    var key = (evfolyam, tipus);
                    if (!kimutatas.ContainsKey(key))
                    {
                        kimutatas[key] = (0, 0);
                    }
                    kimutatas[key] = (kimutatas[key].szam + 1, kimutatas[key].evesOraszam + evesOraszam);
                }
            }

            KimutatasListBox.Items.Clear();
            foreach (var item in kimutatas)
            {
                KimutatasListBox.Items.Add($"Évfolyam: {item.Key.evfolyam}, Típus: {item.Key.tipus}, Tantárgyak száma: {item.Value.szam}, Összesített óraszám: {item.Value.evesOraszam}");
            }
        }
    }
}
