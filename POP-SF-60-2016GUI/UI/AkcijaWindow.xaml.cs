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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        ICollectionView view;
        public AkcijaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Akcija);
            view.Filter = AkcijaFilter;
            dgAkcija.ItemsSource = Projekat.Instance.Akcija;

            List<string> ponudjeno = new List<string>() { "PocetakAkcije", "ZavrsetakAkcije", "Popust"};
            cbSort.ItemsSource = ponudjeno;
        }

        private bool AkcijaFilter(object obj)
        {
            return ((Akcija)obj).Obrisan == false;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Akcija a = new Akcija();
            EditAkcijaWindow eaw = new EditAkcijaWindow(a, EditAkcijaWindow.Operacija.DODAVANJE);
            eaw.ShowDialog();
            view.Refresh();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Akcija;
            Akcija a= dgAkcija.SelectedItem as Akcija;
            if (MessageBox.Show($"Da li zelite da izbrisete: {a.Id}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var item in a.NamjestajNaAkciji)
                {
                    item.AkcijskaCijena = 0;
                    Namjestaj.Update(item);
                }
                Akcija.Delete(a);
            }
            view.Refresh();
        }

        private void dgAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Id" || (string)e.Column.Header == "NamjestajNaAkciji"
                ||(string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void Prikaz_Click(object sender, RoutedEventArgs e)
        {
            Akcija a = dgAkcija.SelectedItem as Akcija;
            PrikazAkcijaWindow paw = new PrikazAkcijaWindow(a);
            paw.ShowDialog();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tekst = cbSort.SelectedItem as string;
            view = CollectionViewSource.GetDefaultView(Akcija.Order(tekst));
            dgAkcija.ItemsSource = view;
        }

        private void btnPretraga_Click(object sender, RoutedEventArgs e)
        {
            var tekst = tbPretraga.Text.Trim();
            view = CollectionViewSource.GetDefaultView(Akcija.Search(tekst));
            dgAkcija.ItemsSource = view;
        }
    }
}
