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

            dpDatum.DataContext = prodaja;
            tbKupac.DataContext = prodaja;
            tbRacun.DataContext = prodaja;

            dgNamjestaj.ItemsSource = prodaja.NamjestajPro;
            dgDUsluga.ItemsSource = prodaja.DodatnaU;
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.ProdajaNamjestaja;
            double cijenaN = 0;
            double cijenaU = 0;

            for (int i = 0; i < prodaja.NamjestajPro.Count; i++)
            {
                if (prodaja.NamjestajPro[i].Namjestaj.Cijena > 0)
                    cijenaN += prodaja.NamjestajPro[i].Namjestaj.AkcijskaCijena;
                else
                    cijenaN += prodaja.NamjestajPro[i].Namjestaj.Cijena;
            }

            for (int i = 0; i < prodaja.DodatnaU.Count; i++)
            {
                cijenaU += prodaja.DodatnaU[i].CijenaUsluge;
            }

            if (operacija == Operacija.DODAVANJE)
            {
                prodaja.Id = lista.Count + 1;
                for (int i = 0; i < prodaja.NamjestajPro.Count; i++)
                {
                    prodaja.UkupanIznos = (cijenaN * prodaja.NamjestajPro[i].Kolicina) + cijenaU + ((prodaja.UkupanIznos)*20)/100;
                }
                ProdajaNamjestaja.Create(prodaja);
            }
            ProdajaNamjestaja.Update(prodaja);
            Close();
        }

        private void btnPreuzmiN_Click(object sender, RoutedEventArgs e)
        {
            PreuzmiNamjestaj pn = new PreuzmiNamjestaj(PreuzmiNamjestaj.TipOperacije.Prodaja);
            if (pn.ShowDialog() == true)
            prodaja.NamjestajPro.Add(pn.Stavke);
        }

        private void btnPreuzmiDU_Click(object sender, RoutedEventArgs e)
        {
            PreuzmiDodatnuUslugu pdu = new PreuzmiDodatnuUslugu();
            if (pdu.ShowDialog() == true)
            prodaja.DodatnaU.Add(pdu.IzabranaU);
        }

        private void dgDUsluga_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void dgNamjestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "Sifra"
            || (string)e.Column.Header == "TipNamjestajaID")
            {
                e.Cancel = true;
            }
        }
    }
}
