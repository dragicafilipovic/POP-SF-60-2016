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
    /// Interaction logic for PreuzmiDodatnuUslugu.xaml
    /// </summary>
    public partial class PreuzmiDodatnuUslugu : Window
    {
        public DodatnaUsluga IzabranaU { get; set; }
        public PreuzmiDodatnuUslugu()
        {
            InitializeComponent();

            dgUsluga.ItemsSource = Projekat.Instance.DodatnaUsluga;
        }

        private void Preuzmi_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            IzabranaU = dgUsluga.SelectedItem as DodatnaUsluga;
            this.Close();
        }

        private void dgUsluga_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
