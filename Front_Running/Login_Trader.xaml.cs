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
    /// Interaction logic for Login_Trader.xaml
    /// </summary>
    public partial class Login_Trader : Window
    {
        public Login_Trader()
        {
            InitializeComponent();
        }
        TraderRegister registration = new TraderRegister();

        Welcome welcome = new Welcome();
        private void buttonRegister_Click(object sender, RoutedEventArgs e)

        {

            registration.Show();

            Close();

        }
        private void button1_Click(object sender, RoutedEventArgs e)

        {

            if (userName.Text.Length == 0)

            {

                errormessage.Text = "Enter user name.";

                userName.Focus();

            }
             Global.uname = userName.Text;
            string password = passwordBox1.Password;

            SqlConnection con = new SqlConnection(@"Data Source=GRAD128-HP;Integrated Security = SSPI;Initial Catalog=Registration");

            con.Open();

             
            SqlCommand cmd = new SqlCommand("Select * from GEN_TRADER where USERNAME='" + Global.uname + "'  and password='" + password + "'", con);

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = cmd;

            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)

            {

                string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();

                welcome.TextBlockName.Text = username;//Sending value from one form to another form.

                welcome.Show();

                Close();

            }

            else

            {

                errormessage.Text = "Sorry! Please enter valid username/password.";

            }

            con.Close();

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            userName.Text = "";
            passwordBox1.Password = "";

        }
    }
   
}
