﻿using POP.Model;
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
    /// Interaction logic for NamjestajProzor.xaml
    /// </summary>
    public partial class NamjestajProzor : Window
    {
        public NamjestajProzor()
        {
            InitializeComponent();
            dgNamjestaj.ItemsSource = Projekat.Instance.Namjestaj;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Namjestaj n = new Namjestaj();
            NamjestajWindow enw = new NamjestajWindow(n,NamjestajWindow.Operacija.DODAVANJE);
            enw.ShowDialog();
        }

        private void Izmjena_Click(object sender, RoutedEventArgs e)
        {
            Namjestaj n = dgNamjestaj.SelectedItem as Namjestaj;
            NamjestajWindow enw = new NamjestajWindow(n, NamjestajWindow.Operacija.IZMJENA);
            enw.ShowDialog();
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Namjestaj;
            Namjestaj n = dgNamjestaj.SelectedItem as Namjestaj;
            n.Obrisan = true;
            GenericSerializer.Serialize("namjestaj.xml", lista);
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
