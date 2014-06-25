using Hodor.Client.HodorService;
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

namespace Hodor.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HodorServiceClient svc = new HodorServiceClient("netTcpEndpoint");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                svc.Hodorize();
                this.txtMessage.Text = "Victim Hodorized.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Hodorizing", MessageBoxButton.OK, MessageBoxImage.Error);                
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                svc.Dehodorize();
                this.txtMessage.Text = "Victim Dehodorized.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Dehodorizing", MessageBoxButton.OK, MessageBoxImage.Error);                
            }
            
        }
    }
}
