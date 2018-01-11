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
    /// Interaction logic for TipNamjestajaProzor.xaml
    /// </summary>
    public partial class TipNamjestajaProzor : Window
    {
        ICollectionView view;
        public TipNamjestajaProzor()
        {
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipoviNamjestaja);
            view.Filter = TipNamjestajaFilter;
            InitializeComponent();

            dgTipNamjestaj.ItemsSource = Projekat.Instance.TipoviNamjestaja;

            List<string> ponudjeno = new List<string>() { "Naziv"};
            cbSort.ItemsSource = ponudjeno;
        }

        private bool TipNamjestajaFilter(object obj)
        {
            return ((TipNamjestaja)obj).Obrisan == false;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            TipNamjestaja tn = new TipNamjestaja();
            EditTipNamjestajaWindow etn = new EditTipNamjestajaWindow(tn, EditTipNamjestajaWindow.Operacija.DODAVANJE);
            etn.ShowDialog();
            view.Refresh();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            TipNamjestaja Selektovani = dgTipNamjestaj.SelectedItem as TipNamjestaja;
            TipNamjestaja kopija = (TipNamjestaja)Selektovani.Clone();
            var tip = new EditTipNamjestajaWindow(kopija, EditTipNamjestajaWindow.Operacija.IZMJENA);
            if (tip.ShowDialog() == true)
            {
                int index = Projekat.Instance.TipoviNamjestaja.IndexOf(Selektovani);
                TipNamjestaja.Update(kopija);
            }
            view.Refresh();
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.TipoviNamjestaja;
            TipNamjestaja tn = dgTipNamjestaj.SelectedItem as TipNamjestaja;
            if (MessageBox.Show($"Da li zelite da izbrisete: {tn.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                TipNamjestaja.Delete(tn);
            }
            view.Refresh();
        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgTipNamjestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tekst = cbSort.SelectedItem as string;
            view = CollectionViewSource.GetDefaultView(TipNamjestaja.Order(tekst));
            dgTipNamjestaj.ItemsSource = view; 
        }

        private void btnPretraga_Click(object sender, RoutedEventArgs e)
        {
            var tekst = tbPretraga.Text.Trim();
            view = CollectionViewSource.GetDefaultView(TipNamjestaja.Search(tekst));
            dgTipNamjestaj.ItemsSource = view;
        }
    }
}
