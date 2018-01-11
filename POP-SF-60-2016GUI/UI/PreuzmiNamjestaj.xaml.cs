using POP.Model;
using POP_SF_60_2016GUI.Model;
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
    /// Interaction logic for PreuzmiNamjestaj.xaml
    /// </summary>
    public partial class PreuzmiNamjestaj : Window
    {
        public enum TipOperacije
        {
            Akcija,
            Prodaja
        }
        public Namjestaj IzabraniN { get; set; }
        public Stavke Stavke { get; set; } = new Stavke();
        private TipOperacije tip;
        public PreuzmiNamjestaj(TipOperacije tip)
        {
            InitializeComponent();
            dgnamjestaj.ItemsSource = Projekat.Instance.Namjestaj;
            this.tip = tip;

            if (tip == TipOperacije.Akcija)
            {
                tbKolicina.Visibility = Visibility.Hidden;
                lbKolicina.Visibility = Visibility.Hidden;
            }
        }

        private void btnPreuzmi_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            IzabraniN = dgnamjestaj.SelectedItem as Namjestaj;
            if (tip == TipOperacije.Prodaja)
            {
                var kolicina = int.Parse(tbKolicina.Text.Trim());
                if(kolicina > IzabraniN.Kolicina)
                {
                    MessageBox.Show("Namjstaja nema u toj kolicini", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                Stavke.Kolicina = kolicina;
                Stavke.Namjestaj = IzabraniN;
            }
            this.Close();
        }

        private void dgnamjestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "Sifra"
            || (string)e.Column.Header == "TipNamjestajaID" || (string)e.Column.Header == "TipNamjestaja" )
            {
                e.Cancel = true;
            }
        }
    
    }
}
