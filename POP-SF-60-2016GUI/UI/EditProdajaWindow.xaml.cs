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
    /// Interaction logic for EditProdajaWindow.xaml
    /// </summary>
    public partial class EditProdajaWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMJENA
        }
        private ProdajaNamjestaja prodaja;
        private Operacija operacija;
        public EditProdajaWindow(ProdajaNamjestaja prodaja, Operacija operacija)
        {
            InitializeComponent();

            this.prodaja = prodaja;
            this.operacija = operacija;

            cbNamjestaj.ItemsSource = Projekat.Instance.Namjestaj;
            cbUsluga.ItemsSource = Projekat.Instance.DodatnaUsluga;

            cbNamjestaj.DataContext = prodaja;
            cbUsluga.DataContext = prodaja;
            dpDatum.DataContext = prodaja;
            tbKupac.DataContext = prodaja;
            tbRacun.DataContext = prodaja;
            tbIznos.DataContext = prodaja;
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.ProdajaNamjestaja;
            if (operacija == Operacija.DODAVANJE)
            {
                prodaja.Id = lista.Count + 1;
                lista.Add(prodaja);
            }
            GenericSerializer.Serialize("prodajaNamjestaj.xml", lista);
            Close();
        }
    }
}
