using POP.Model;
using POP.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POP_SF_60_2016GUI.UI
{
    /// <summary>
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        public KorisnikWindow()
        {
            InitializeComponent();

            dgKorisnik.ItemsSource = Projekat.Instance.Korisnik;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = new Korisnik();
            EditKorisnikWindow ekw = new EditKorisnikWindow(k, EditKorisnikWindow.Operacija.DODAVANJE);
            ekw.ShowDialog();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = dgKorisnik.SelectedItem as Korisnik;
            EditKorisnikWindow ekw = new EditKorisnikWindow(k, EditKorisnikWindow.Operacija.IZMJENA);
            ekw.ShowDialog();
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Korisnik;
            Korisnik k = dgKorisnik.SelectedItem as Korisnik;
            k.Obrisan = true;
            GenericSerializer.Serialize("korisnik.xml", lista);
        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
