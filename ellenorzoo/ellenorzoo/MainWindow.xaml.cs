using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ellenorzoo
{
    public partial class MainWindow : Window
    {
        private List<Tanulo> tanulok;
        private Tanulo bejelentkezettTanulo;

        public MainWindow()
        {
            InitializeComponent();
            
            tanulok = new List<Tanulo>
        {
            new Tanulo("Péter", "password1"),
            new Tanulo("Anna", "password2"),
            new Tanulo("Gábor", "password3"),
            new Tanulo("Kata", "password4")
        };

            
            tanulok[0].HozzaadTantargy(new Tantargy("Matematika"));
            tanulok[0].HozzaadTantargy(new Tantargy("Irodalom"));
            tanulok[1].HozzaadTantargy(new Tantargy("Történelem"));
            tanulok[1].HozzaadTantargy(new Tantargy("Kémia"));
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string nev = txtUsername.Text;
            string jelszo = txtPassword.Password;

            bejelentkezettTanulo = tanulok.Find(t => t.Nev == nev && t.Jelszo == jelszo);

            if (bejelentkezettTanulo != null)
            {
                lblMessage.Text = "Sikeres bejelentkezés!";
                GradesWindow gradesWindow = new GradesWindow(bejelentkezettTanulo);
                gradesWindow.Show();
                this.Close();
            }
            else
            {
                lblMessage.Text = "Hibás felhasználónév vagy jelszó!";
            }
        }

    }
}