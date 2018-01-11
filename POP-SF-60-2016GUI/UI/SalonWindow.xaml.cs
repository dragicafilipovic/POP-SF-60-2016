using POP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class SalonWindow : Window
    {
        public SalonWindow()
        {
            InitializeComponent();

            dgSalon.ItemsSource = Projekat.Instance.Salon;
        }

        private void btnIzmjena_Click(object sender, RoutedEventArgs e)
        {
            Salon a = dgSalon.SelectedItem as Salon;
            EditSalonWindow esw = new EditSalonWindow(a);
            esw.ShowDialog();

        }

        private void dgSalon_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
