using POP.Model;
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
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class ProdajaWindow : Window
    {
        public ProdajaWindow()
        {
            InitializeComponent();
            dgProdaja.ItemsSource = Projekat.Instance.ProdajaNamjestaja;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            ProdajaNamjestaja pn = new ProdajaNamjestaja();
            EditProdajaWindow epw = new EditProdajaWindow(pn, EditProdajaWindow.Operacija.DODAVANJE);
            epw.ShowDialog();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            ProdajaNamjestaja pn = dgProdaja.SelectedItem as ProdajaNamjestaja;
            EditProdajaWindow epw = new EditProdajaWindow(pn, EditProdajaWindow.Operacija.IZMJENA);
            epw.ShowDialog();
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
                || (string)e.Column.Header == "DodatneUsluge")
            {
                e.Cancel = true;
            }
        }
    }
}
