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
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        ICollectionView view;
        public DodatnaUslugaWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatnaUsluga);
            view.Filter = DodatnaUFilter;

            dgUsluga.ItemsSource = Projekat.Instance.DodatnaUsluga;

            List<string> ponudjeno = new List<string>() { "NazivUsluge" , "CijenaUsluge" };
            cbSort.ItemsSource = ponudjeno;
        }
        private bool DodatnaUFilter(object obj)
        {
            return ((DodatnaUsluga)obj).Obrisan == false;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga du = new DodatnaUsluga();
            EditDodatnaUslugaWindow duw = new EditDodatnaUslugaWindow(du,EditDodatnaUslugaWindow.Operacija.DODAVANJE);
            duw.ShowDialog();
            view.Refresh();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga Selektovani = dgUsluga.SelectedItem as DodatnaUsluga;
            DodatnaUsluga kopija = (DodatnaUsluga)Selektovani.Clone();
            var u = new EditDodatnaUslugaWindow(kopija, EditDodatnaUslugaWindow.Operacija.IZMJENA);
            if (u.ShowDialog() == true)
            {
                int index = Projekat.Instance.DodatnaUsluga.IndexOf(Selektovani);
                DodatnaUsluga.Update(kopija);
                view.Refresh();
            }
            view.Refresh();
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.DodatnaUsluga;
            DodatnaUsluga du = dgUsluga.SelectedItem as DodatnaUsluga;
            if (MessageBox.Show($"Da li zelite da izbrisete: {du.NazivUsluge}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DodatnaUsluga.Delete(du);
            }
            view.Refresh();
         }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgUsluga_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tekst = cbSort.SelectedItem as string;
            view = CollectionViewSource.GetDefaultView(DodatnaUsluga.Order(tekst));
            dgUsluga.ItemsSource = view;
        }

        private void btnPretraga_Click(object sender, RoutedEventArgs e)
        {
            var tekst = tbPretraga.Text.Trim();
            view = CollectionViewSource.GetDefaultView(DodatnaUsluga.Search(tekst));
            dgUsluga.ItemsSource = view;
        }
    }
}
