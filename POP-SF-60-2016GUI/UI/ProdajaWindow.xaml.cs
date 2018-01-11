using POP.Model;
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
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    /// 
    public partial class ProdajaWindow : Window
    {
        ICollectionView view;
        public ProdajaWindow()
        {
            InitializeComponent();

            if(MainWindow.korisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                btnIzmjena.Visibility = Visibility.Hidden;
            }

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.ProdajaNamjestaja);
            view.Filter = ProdajaFilter;
            dgProdaja.ItemsSource = Projekat.Instance.ProdajaNamjestaja;

        }

        private bool ProdajaFilter(object obj)
        {
            return ((ProdajaNamjestaja)obj).Obrisan == false;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            ProdajaNamjestaja pn = new ProdajaNamjestaja();
            EditProdajaWindow epw = new EditProdajaWindow(pn, EditProdajaWindow.Operacija.DODAVANJE);
            epw.ShowDialog();
            view.Refresh();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            ProdajaNamjestaja Selektovani = dgProdaja.SelectedItem as ProdajaNamjestaja;
            ProdajaNamjestaja kopija = (ProdajaNamjestaja)Selektovani.Clone();
            var p = new EditProdajaWindow(kopija, EditProdajaWindow.Operacija.IZMJENA);
            if (p.ShowDialog() == true)
            {
                int index = Projekat.Instance.ProdajaNamjestaja.IndexOf(Selektovani);
                ProdajaNamjestaja.Update(kopija);
                view.Refresh();
            }
            view.Refresh();
        }

        private void Prikaz_Click(object sender, RoutedEventArgs e)
        {
            ProdajaNamjestaja pn = dgProdaja.SelectedItem as ProdajaNamjestaja;
            PrikazWindow pw = new PrikazWindow(pn);
            pw.ShowDialog();
        }

        private void dgProdaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Id" || (string)e.Column.Header == "NamjestajProdajaID" ||
                (string)e.Column.Header == "NamjestajProdaja" || (string)e.Column.Header == "DodatnaUslugaID" 
                || (string)e.Column.Header == "DodatneUsluge" || (string)e.Column.Header == "DodatnaU" ||
                (string)e.Column.Header == "NamjestajPro" || (string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }

    }
}
