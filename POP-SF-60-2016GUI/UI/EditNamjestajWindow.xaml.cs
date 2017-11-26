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
    /// Interaction logic for NamjestajWindow.xaml
    /// </summary>
    public partial class NamjestajWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMJENA
        }
        private Namjestaj namjestaj;
        private Operacija operacija;

        public NamjestajWindow(Namjestaj namjestaj, Operacija operacija)
        {
            InitializeComponent();

            this.namjestaj = namjestaj;
            this.operacija = operacija;

            tbNaziv.DataContext = namjestaj;
            tbCijena.DataContext = namjestaj;
            tbKolicina.DataContext = namjestaj;
            tbSifra.DataContext = namjestaj;
            cbTipNamjestaja.ItemsSource = Projekat.Instance.TipoviNamjestaja;
            cbTipNamjestaja.DataContext = namjestaj;
        }

        private void SacuvajIzmjene(object sender, RoutedEventArgs e)
        {
            var listaNamjestaja = Projekat.Instance.Namjestaj;
            var selekrovani = cbTipNamjestaja.SelectedItem as TipNamjestaja;
            if (operacija == Operacija.DODAVANJE)
            {
                namjestaj.Id = listaNamjestaja.Count + 1;
                namjestaj.TipNamjestaja = selekrovani;
                listaNamjestaja.Add(namjestaj);
            }
            GenericSerializer.Serialize("namjestaj.xml", listaNamjestaja);
            Close();
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
