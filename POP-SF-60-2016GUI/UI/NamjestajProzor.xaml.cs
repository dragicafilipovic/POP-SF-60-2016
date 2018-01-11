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
    /// Interaction logic for NamjestajProzor.xaml
    /// </summary>
    public partial class NamjestajProzor : Window
    {
        ICollectionView view;

 //       public Namjestaj Selektovani { get; set; }
        public NamjestajProzor()
        {
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namjestaj);
            view.Filter = NamjestajFilter;
            InitializeComponent();
            dgNamjestaj.ItemsSource = Projekat.Instance.Namjestaj;
            //           Selektovani = dgNamjestaj.SelectedItem as Namjestaj;
            List<string> ponudjeno = new List<string>() { "Naziv","Sifra", "Cijena", "Kolicina", "Tip Namjestaja"};
            cbSort.ItemsSource = ponudjeno;
        }

        private bool NamjestajFilter(object obj)
        {
            return ((Namjestaj)obj).Obrisan == false;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Namjestaj n = new Namjestaj();
            NamjestajWindow enw = new NamjestajWindow(n,NamjestajWindow.Operacija.DODAVANJE);
            enw.ShowDialog();
            view.Refresh();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            Namjestaj Selektovani = dgNamjestaj.SelectedItem as Namjestaj;
            Namjestaj kopija = (Namjestaj)Selektovani.Clone();
            var namjestaj = new NamjestajWindow(kopija, NamjestajWindow.Operacija.IZMJENA);
            if (namjestaj.ShowDialog() == true)
            {
                int index = Projekat.Instance.Namjestaj.IndexOf(Selektovani);
                Namjestaj.Update(kopija);
                view.Refresh();
            }
            view.Refresh();
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Namjestaj;
            Namjestaj n = dgNamjestaj.SelectedItem as Namjestaj;
            if (MessageBox.Show($"Da li zelite da izbrisete: {n.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Namjestaj.Delete(n);
            }
            view.Refresh();
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgNamjestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan" ||
                (string)e.Column.Header == "TipNamjestajaID")
            {
                e.Cancel = true;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tekst = cbSort.SelectedItem as string;
            if (tekst == "Tip Namjestaja")
                tekst = "TipNamjestaja.Naziv";
            else if (tekst == "Naziv")
                tekst = "Namjestaj.Naziv";
            view = CollectionViewSource.GetDefaultView(Namjestaj.Order(tekst));
            dgNamjestaj.ItemsSource = view;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tekst = tbPretraga.Text.Trim();
            view = CollectionViewSource.GetDefaultView(Namjestaj.Search(tekst));
            dgNamjestaj.ItemsSource = view;
        }
    }
}
