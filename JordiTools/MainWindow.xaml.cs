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
using System.Windows.Navigation;
using System.Windows.Shapes;
using JordiTools.Network;

namespace JordiTools
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            JNetwork.GenerateInterfaceAndIps();
            


            // Add columns
            var gridView = new GridView();
            this.ListInter.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Interfície",
                DisplayMemberBinding = new Binding("Type")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "IP",
                DisplayMemberBinding = new Binding("IP")
            });

            

            foreach (Interficie i in JNetwork.GetInterficies())
            {
                // Populate list
                this.ListInter.Items.Add(i);
            }

            try
            {
                string externalip = new System.Net.WebClient().DownloadString("http://icanhazip.com") + "";
                ipPub.Content = externalip;

            }
            catch
            {
                ipPub.Content = "No hi ha IP Pública";
            }




        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
