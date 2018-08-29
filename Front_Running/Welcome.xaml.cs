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
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }
        
        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            string Security = ComboSecurityType.Text;
            string company = comboCompany.Text;
            string type = (comboTradeType.Text[0]).ToString();
            int quantity;
           Int32.TryParse(textBoxQuantity.Text, out quantity);
            double price;
            double.TryParse(textBoxPrice.Text, out price);
            double value = price * quantity;
            string curdate = DateTime.Now.ToString();
            OrderSummary o = new OrderSummary();
            o.labelquantity.Content = quantity;
            o.labelSecurity.Content = Security;
            o.labelcompany.Content = company;
            o.labelPrice.Content = price;
            o.labelValue.Content = value;
            o.labeltype.Content = type;
            o.labeltime.Content = curdate;


            o.Show();
            this.Close();

        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Login_Trader exp = new Login_Trader();
            exp.Show();
            this.Close();
            Global.uname = "";
        }

    }
}
