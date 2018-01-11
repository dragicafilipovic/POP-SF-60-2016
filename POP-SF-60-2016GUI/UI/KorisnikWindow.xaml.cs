using POP.Model;
using POP.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        ICollectionView view;
        public KorisnikWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnik);
            view.Filter = KorisnikFilter;

            dgKorisnik.ItemsSource = Projekat.Instance.Korisnik;

            List<string> ponudjeno = new List<string>() { "Ime", "Prezime", "KorisnickoIme", "Lozinka", "TipKorisnika" };
            cbSort.ItemsSource = ponudjeno;
        }

        private bool KorisnikFilter(object obj)
        {
            return ((Korisnik)obj).Obrisan == false;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = new Korisnik();
            EditKorisnikWindow ekw = new EditKorisnikWindow(k, EditKorisnikWindow.Operacija.DODAVANJE);
            ekw.ShowDialog();
            view.Refresh();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            Korisnik Selektovani = dgKorisnik.SelectedItem as Korisnik;
            Korisnik kopija = (Korisnik)Selektovani.Clone();
            var k = new EditKorisnikWindow(kopija, EditKorisnikWindow.Operacija.IZMJENA);
            if (k.ShowDialog() == true)
            {
                int index = Projekat.Instance.Korisnik.IndexOf(Selektovani);
                Korisnik.Update(kopija);
                view.Refresh();
            }
            view.Refresh();
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Korisnik;
            Korisnik k = dgKorisnik.SelectedItem as Korisnik;
            if (MessageBox.Show($"Da li zelite da izbrisete: {k.Ime}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Korisnik.Delete(k);
            }
            view.Refresh();
        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgKorisnik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tekst = cbSort.SelectedItem as string;
            view = CollectionViewSource.GetDefaultView(Korisnik.Order(tekst));
            dgKorisnik.ItemsSource = view;
        }

        private void btnPretraga_Click(object sender, RoutedEventArgs e)
        {
            var tekst = tbPretraga.Text.Trim();
            view = CollectionViewSource.GetDefaultView(Korisnik.Search(tekst));
            dgKorisnik.ItemsSource = view;
        }
    }
}
