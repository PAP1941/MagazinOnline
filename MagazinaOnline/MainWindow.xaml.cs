using AppMagazin.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppMagazin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private MagazinContext magazinContext;
        private Comanda comanda;


        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            magazinContext = new MagazinContext();
            magazinContext.Database.EnsureCreated();
            comanda = new Comanda();
            DataContext= comanda;            
            RefreshProduse();
            RefreshComenzi();
        }

        private void RefreshComenzi()
        {
            comenziDataGrid.ItemsSource = magazinContext.GetComenzi();
        }

        private void RefreshProduse()
        {
            produseDataGrid.ItemsSource = magazinContext.GetProduse();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowComenzi_Click(object sender, RoutedEventArgs e)
        {
            grbxShowComenzi.Visibility= Visibility.Visible;
            grbxProdus.Visibility= Visibility.Collapsed;
            grbShowProduse.Visibility= Visibility.Collapsed;
        }

        private void AddComanda_Click(object sender, RoutedEventArgs e)
        {
            grbxProdus.Visibility = Visibility.Collapsed;
            grbxShowComenzi.Visibility= Visibility.Visible;
            grbShowProduse.Visibility = Visibility.Collapsed;
        }

        private void DeleteProdus_Click(object sender, RoutedEventArgs e)
        {
            grbShowProduse.Visibility = Visibility.Visible;
            grbxShowComenzi.Visibility = Visibility.Collapsed;
            grbxProdus.Visibility = Visibility.Collapsed;
            if (produseDataGrid.SelectedItem==null)
            {
                return;
            }
            var selectedProdus = (Produs)produseDataGrid.SelectedItem;
            magazinContext.StergeProdus(selectedProdus);
            RefreshProduse();
        }

        private void UpdateProdus_Click(object sender, RoutedEventArgs e)
        {
            //grbShowProduse.Visibility = Visibility.Visible;
            //grbxShowComenzi.Visibility = Visibility.Collapsed;
            //grbxProdus.Visibility = Visibility.Collapsed;
            Produs? produs = produseDataGrid.SelectedItem as Produs;
            if (produs == null)
            {
                return;
            }
            grbxProdus.Visibility = Visibility.Visible;
            grbxShowComenzi.Visibility = Visibility.Collapsed;
            grbShowProduse.Visibility = Visibility.Collapsed;
            denumireTextBox.Text = produs.Denumire;
            pretTextBox.Text = produs.Pret.ToString();
            cantitateTextBox.Text = produs.Cantitate.ToString();
            dataAdaugariiDatePicker.Text = produs.DataAdaugare.ToString();
            btAdauga.Content = "Modifica datele";

        }

        private void AddProdus_Click(object sender, RoutedEventArgs e)
        {
            grbxProdus.Visibility = Visibility.Visible;
            grbxShowComenzi.Visibility = Visibility.Collapsed;
            grbShowProduse.Visibility = Visibility.Collapsed;
            denumireTextBox.Text = "";
            pretTextBox.Text = "";
            cantitateTextBox.Text = "";
            dataAdaugariiDatePicker.Text = "";
            denumireTextBox.Focus();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddProdusButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btAdauga.Content!="Modifica datele")
                {
                    using (var context = new MagazinContext())
                    {
                        var produs = new Produs
                        {
                            Denumire = denumireTextBox.Text,
                            Pret = double.Parse(pretTextBox.Text),
                            Cantitate = int.Parse(cantitateTextBox.Text),
                            DataAdaugare = DateOnly.FromDateTime(dataAdaugariiDatePicker.SelectedDate.Value)
                        };
                        context.AdaugaProdus(produs);
                        MessageBox.Show("Produsul a fost adaugat!");
                        denumireTextBox.Text = "";
                        pretTextBox.Text = "";
                        cantitateTextBox.Text = "";
                        dataAdaugariiDatePicker.Text = "";
                        denumireTextBox.Focus();
                        RefreshProduse();
                    }                    
                }
                else
                {
                    Produs produs = produseDataGrid.SelectedItem as Produs;
                    if (produs == null)
                    {
                        return;
                    }
                    if (magazinContext.GetProdusById(produs.IdProdus) != null)
                    {
                        produs.Denumire = denumireTextBox.Text;
                        produs.Pret = double.Parse(pretTextBox.Text);
                        produs.Cantitate = int.Parse(cantitateTextBox.Text);
                        produs.DataAdaugare = DateOnly.FromDateTime(dataAdaugariiDatePicker.SelectedDate.Value);
                        magazinContext.ActualizeazaProdus(produs);
                        RefreshProduse();
                        MessageBox.Show("Datele au fost modificate cu succes!");
                        grbxProdus.Visibility = Visibility.Collapsed;
                        grbShowProduse.Visibility = Visibility.Visible;
                    }
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Eroare! Date introduse incorecte!");
            }
        }

        private void ShowStok_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowVinzari_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowDespre_Click(object sender, RoutedEventArgs e)
        {
            DespreWindow despreWindow = new DespreWindow();
            despreWindow.ShowDialog();
        }

        private void ShowHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowProduse_Click(object sender, RoutedEventArgs e)
        {
            grbShowProduse.Visibility = Visibility.Visible;
            grbxShowComenzi.Visibility = Visibility.Collapsed;
            grbxProdus.Visibility = Visibility.Collapsed;
        }

        private void SalveazaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AnuleazaButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
