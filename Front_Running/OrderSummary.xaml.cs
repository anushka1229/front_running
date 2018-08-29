using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for OrderSummary.xaml
    /// </summary>
    public partial class OrderSummary : Window
    {
        public OrderSummary()
        {
            
            InitializeComponent();
            
        }
      
        
        private void confirmOrder_Click(object sender, RoutedEventArgs e)
        { string security = labelSecurity.Content.ToString();
            string company = labelcompany.Content.ToString();
            string tradetype = labeltype.Content.ToString();
            int quantity;
             Int32.TryParse(labelquantity.Content.ToString(), out quantity);
            double price;
            double.TryParse(labelPrice.Content.ToString(), out price);
            double value;
            double.TryParse(labelValue.Content.ToString(), out value);
            string date = labeltime.Content.ToString();
            Login_Trader obj = new Login_Trader();
           // string uname = obj.userName.Text;
            string tradertype;
            SqlConnection con1 = new SqlConnection(@"Data Source=GRAD128-HP;Integrated Security = SSPI;Initial Catalog=Registration");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand($"SELECT TRADERTYPE FROM GEN_TRADER WHERE USERNAME='{Global.uname}'",con1);
            tradertype = (string)cmd1.ExecuteScalar();
            //cmd1.Parameters.AddWithValue("@TRADERTYPE", );
            //using (SqlDataReader reader = cmd1.ExecuteReader())
            //{
            //    tradertype = String.Format("{0}", reader["TRADERTYPE"]);
            //}

            string today = DateTime.Today.ToString("yyyy-MM-dd");
            string todaytime = DateTime.Now.ToString("HH:mm:ss");
                SqlConnection con = new SqlConnection(@"Data Source=GRAD128-HP;Integrated Security = SSPI;Initial Catalog=Registration");
            con.Open();
            SqlCommand cmd = new SqlCommand($"Insert into PLACE_ORDER (NAME, CLASS, COMPANY, TRADE_DATE, TRADE_TIME, TRADE_TYPE, SECURITY_TYPE, QUANTITY, PRICE, VALUE) values('{Global.uname}','{tradertype}','{company}','{today}','{todaytime}','{tradetype}','{security}','{quantity}','{price}','{value}')", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Your order has been placed successfully");
            Welcome w = new Welcome();
            w.Show();
            this.Close();

        }

        private void cancelOrder_Click(object sender, RoutedEventArgs e)
        {
            Welcome w = new Welcome();
            w.Show();
            this.Close();
        }
    }
}
