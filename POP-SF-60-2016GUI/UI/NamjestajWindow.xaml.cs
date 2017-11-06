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

            InicijalizacijaVrijednosti(namjestaj, operacija);
        }

        private void InicijalizacijaVrijednosti(Namjestaj namjestaj, Operacija operacija)
        {
            this.namjestaj = namjestaj;
            this.operacija = operacija;

            this.tbNaziv.Text = namjestaj.Naziv;
        }

        private void SacuvajIzmjene(object sender, RenderingEventArgs e)
        {
            var listaNamjestaja = Projekat.Instance.Namjestaj;
       
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviNamjestaj = new Namjestaj()
                    {
                        ID = listaNamjestaja.Count + 1, 
                        Naziv = this.tbNaziv.Text
                    };
                    listaNamjestaja.Add(noviNamjestaj);
                    break;
                case Operacija.IZMJENA:
                    foreach (var n in listaNamjestaja)
                    {
                        if (n.ID == namjestaj.ID)
                        {
                            n.Naziv = this.tbNaziv.Text;
                            break;
                        }
                    }
                    break;
                
            }

            Projekat.Instance.Namjestaj = listaNamjestaja;
            Close();
        }

        private void Izadji(object sender, RenderingEventArgs e)
        {
            this.Close();
        }

    }
}
