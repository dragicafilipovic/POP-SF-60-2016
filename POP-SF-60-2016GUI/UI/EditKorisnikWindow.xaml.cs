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
    /// Interaction logic for EditKorisnikWindow.xaml
    /// </summary>
    public partial class EditKorisnikWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMJENA
        }
        Korisnik korisnik;
        Operacija operacija;
        public EditKorisnikWindow(Korisnik korisnik,Operacija operacija)
        {
            InitializeComponent();

            this.korisnik = korisnik;
            this.operacija = operacija;
            tbIme.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKIme.DataContext = korisnik;
            cbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika)).Cast<TipKorisnika>();
            cbTipKorisnika.DataContext = korisnik;

            if(operacija == Operacija.IZMJENA)
            {
                tbKIme.IsReadOnly = true;
            }
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Korisnik;
            if(operacija == Operacija.DODAVANJE)
            {
                Korisnik.Create(korisnik);
            }
            Close();
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
