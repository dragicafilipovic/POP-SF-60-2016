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
    /// Interaction logic for EditTipNamjestajaWindow.xaml
    /// </summary>
    public partial class EditTipNamjestajaWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMJENA
        }
        private TipNamjestaja tipNamjestaja;
        private Operacija operacija;

        public EditTipNamjestajaWindow(TipNamjestaja tipNamjestaja, Operacija operacija)
        {
            InitializeComponent();

            this.tipNamjestaja = tipNamjestaja;
            this.operacija = operacija;
            tbNaziv.DataContext = tipNamjestaja;
        }

        private void SacuvajIzmjene(object sender, RoutedEventArgs e)
        {
            var listaTipovaNamjestaja = Projekat.Instance.TipoviNamjestaja;
            if (operacija == Operacija.DODAVANJE)
            {
                tipNamjestaja.Id = listaTipovaNamjestaja.Count + 1;
                listaTipovaNamjestaja.Add(tipNamjestaja);
            }
            GenericSerializer.Serialize("tipNamjestaja.xml", listaTipovaNamjestaja);
            Close();
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
