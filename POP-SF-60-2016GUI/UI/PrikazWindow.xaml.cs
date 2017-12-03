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
    /// Interaction logic for PrikazWindow.xaml
    /// </summary>
    public partial class PrikazWindow : Window
    {
        private ProdajaNamjestaja prodaja;
        public PrikazWindow(ProdajaNamjestaja prodaja)
        {
            InitializeComponent();
            this.prodaja = prodaja;

            dgNamjestaj.ItemsSource = prodaja.NamjestajProdaja;
            dgDodatnaU.ItemsSource = prodaja.DodatneUsluge;
        }

    }
}
