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

namespace Front_Running
{
    /// <summary>
    /// Interaction logic for IntroPage.xaml
    /// </summary>
    public partial class IntroPage : Window
    {
        public IntroPage()
        {
            InitializeComponent();
        }

        private void RegAsTrader_Click(object sender, RoutedEventArgs e)
        {
            TraderRegister reg = new TraderRegister();
            reg.Show();
            this.Close();

        }

        private void regAsCompliance_Click(object sender, RoutedEventArgs e)
        {
            MainWindow regCompliance = new MainWindow();
            regCompliance.Show();
            this.Close();
        }

        private void loginTrader_Click(object sender, RoutedEventArgs e)
        {
            Login_Trader lTrader = new Login_Trader();
            lTrader.Show();
            this.Close();
        }

        private void loginCompliance_Click(object sender, RoutedEventArgs e)
        {
            Login lcompliance = new Login();
            lcompliance.Show();
            this.Close();
        }
    }
}
