using System.Windows;

namespace TanuloApp
{
    public partial class JegyHozzaadasWindow : Window
    {
        private Tantargy kiválasztottTantargy;

        public JegyHozzaadasWindow(Tantargy tantargy)
        {
            InitializeComponent();
            kiválasztottTantargy = tantargy;
        }

        private void Hozzaad_Click(object sender, RoutedEventArgs e)
        {
            
            int ertek;
            if (int.TryParse(ertekTextBox.Text, out ertek))
            {
                string tema = temaTextBox.Text;
                string tipus = tipusTextBox.Text;

                Jegy ujJegy = new Jegy
                {
                    Ertek = ertek,
                    Tema = tema,
                    Tipus = tipus,
                    Datum = System.DateTime.Now
                };

                kiválasztottTantargy.Jegyek.Add(ujJegy);
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Érvénytelen érték!");
            }
        }
    }
}
