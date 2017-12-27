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
    /// Interaction logic for PrikazAkcijaWindow.xaml
    /// </summary>
    public partial class PrikazAkcijaWindow : Window
    {
        private Akcija akcija;
        public PrikazAkcijaWindow(Akcija akcija)
        {
            InitializeComponent();
            this.akcija = akcija;

            dgAkcijaN.ItemsSource = akcija.NamjestajNaAkciji;
        }

        private void dgAkcijaN_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan" ||
                (string)e.Column.Header == "TipNamjestajaID")

                e.Cancel = true;
        }
    }
}
